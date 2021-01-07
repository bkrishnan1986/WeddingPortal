import { Component, Input, OnInit } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { LeadService } from '../../services/lead.service';
import { SubscriptionLike as ISubscription } from 'rxjs';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-followup-details-modal',
  templateUrl: './followup-details-modal.component.html',
  styleUrls: ['./followup-details-modal.component.css']
})
export class FollowupDetailsModalComponent implements OnInit {

  @Input() leadId;
  subscriptionList: ISubscription[] = [];
  getLeadDataSubscription: any;
  leadData: any;
  formSubmitted: boolean;
  newFollowUp: FormArray;
  enablenewFollowUpValidation: any;
  enableEditFollowUpIndex: boolean;
  enableFollowUpEdit: any;
  fileToUpload: File = null;


  followUpForm = this.formBuilder.group({
    newFollowUp: this.formBuilder.array([]),
    followUpList: this.formBuilder.array([]),
  });
  selectedFile: any;
  leadFollowUpData: any;

  get newFollowUpForms() {
    return this.followUpForm.controls.newFollowUp as FormGroup;
  }

  get followUpForms() {
    return this.followUpForm.controls.followUpList as FormGroup;
  }

  get newFollowUpArray(): FormArray {
    return <FormArray>this.followUpForm.get('newFollowUp');
  }

  newFollowUpForm(): FormGroup {
    return this.formBuilder.group({
      callDateTime: [''],
      followedBy: [''],
      uploadedFile: [''],
      remarks: [''],
      isActive: [false]
    });
  }

  editTankForm(): FormGroup {
    return this.formBuilder.group({
      id: [''],
      callDateTime: [''],
      followedBy: [''],
      uploadedFile: [''],
      remarks: [''],
      isActive: [false],
    });
  }

  constructor(
    private leadService: LeadService,
    private formBuilder: FormBuilder,
    private modalService: BsModalService
  ) { }

  ngOnInit(): void {
    this.getDetailsbyLeadId();
  }

  ngOnDestroy() {
    this.subscriptionList.forEach(subscription => {
      if (subscription) {
        subscription.unsubscribe();
      }
    });
  }

  getDetailsbyLeadId() {
    this.getLeadDataSubscription = this.leadService.getLeadDatabyId(this.leadId)
      .subscribe(response => {
        if (response) {
          this.leadData = response;
          this.leadFollowUpData = response.leadvalidation;
          this.listFollowUpItems(this.leadFollowUpData);
        }
      });
    this.subscriptionList.push(this.getLeadDataSubscription);
  }

  get fileName(): string {
    return this.newFollowUp.value[0].uploadedFile ? this.newFollowUp.value[0].uploadedFile.split('/').pop() : 'Select file';
  }

  newFollowUpItem(): void {
    this.formSubmitted = false;
    this.newFollowUp = this.followUpForm.get('newFollowUp') as FormArray;
    this.newFollowUp.push(this.newFollowUpForm());
  }

  listFollowUpItems(followUp) {

    let controls = <FormArray>this.followUpForm.controls.followUpList;

    controls.controls = [];

    followUp.forEach(element => {
      controls.push(this.formBuilder.group({
        id: element.id,
        callDateTime: element.followUpDate,
        followedBy: element.calledBy,
        uploadedFile: element.callRecordings,
        remarks: element.remark,
        isActive: element.active
      }));
    });
  }

  saveNewFollowUp(i) {
    this.formSubmitted = true;
    this.enablenewFollowUpValidation = i;
    let controlNewFollowUp = <FormArray>this.followUpForm.controls.newFollowUp;
    let controlListFollowUp = <FormArray>this.followUpForm.controls.followUpList;

    if (controlNewFollowUp.controls[i].status === 'VALID') {
      const params = {
        "id": 0,
        "leadId": this.leadData.id,
        "calledBy": 100,//controlNewFollowUp.controls[i].value.followedBy,
        "calledOn": controlNewFollowUp.controls[i].value.callDateTime,
        "status": this.leadData.leadStatusId,
        "remark": controlNewFollowUp.controls[i].value.remarks,
        "followUpDate": controlNewFollowUp.controls[i].value.callDateTime,
        "callRecordings": controlNewFollowUp.controls[i].value.uploadedFile,
        "active": 0,
        "createdBy": 10, //logged in user
        "createdAt": new Date()
      };

      this.getLeadDataSubscription = this.leadService.saveNewFollowUp(this.leadData.id, params)
        .subscribe(response => {
          if (response) {
            controlListFollowUp.controls = [];
            controlNewFollowUp.removeAt(i);
            this.listFollowUpItems(response.body);
          }
        });
    }
  }

  editFollowUp(i) {
    this.enableEditFollowUpIndex = true;
    this.enableFollowUpEdit = i;
  }

  saveEditFollowUp(i) {
    this.enableFollowUpEdit = i;
    this.formSubmitted = true;

    let control = <FormArray>this.followUpForm.controls.followUpList;
    if (this.followUpForms.controls[i].status === 'VALID') {
      this.enableEditFollowUpIndex = false;
      const params = {
        id: control.controls[i].value.id,
        name: control.controls[i].value.name,
        capacity: control.controls[i].value.capacity,
        tankTypeId: control.controls[i].value.tankTypeId,
        unitId: control.controls[i].value.unit,
        isActive: control.controls[i].value.isActive,
        modifiedDate: new Date()
      };

    }
  }

  closeModal() {
    this.modalService.hide();
  }

}
