import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Constants } from 'src/app/shared/constants/constants';
import { LeadQuestionAnswers } from '../../models/lead-question-answer.model';
import { LeadService } from '../../services/lead.service';
import { SubscriptionLike as ISubscription } from 'rxjs';
import { CreateLeadModel, LeadDataModel, LeadStatusModel } from '../../models/create-lead-model';
import { ToastrService } from 'ngx-toastr';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-lead-details',
  templateUrl: './lead-details.component.html',
  styleUrls: ['./lead-details.component.css']
})
export class LeadDetailsComponent implements OnInit {

  page: any;
  subscriptionList: ISubscription[] = [];
  leadTypeList: any;
  getAllLeadTypesSubscription: any;
  eventTypeList: any;
  getAllEventTypesSubscription: any;
  categoryList: any;
  getAllCategoriesSubscription: any;
  leadModeList: any;
  getAllLeadModesSubscription: any;
  leadStatusList: any;
  getAllLeadStatusSubscription: any;
  leadLocationList: any;
  getAllLeadLocationSubscription: any;
  leadData: any;
  getLeadDataSubscription: any;
  valueTitle: string;
  formSubmitted: boolean;
  questionAnswers: Array<LeadQuestionAnswers>;
  dropdownSettings: IDropdownSettings;
  showQuestionTab: boolean = false;
  questionaireIndex: number;
  serviceTypes = [];
  leadsDetails: any[];
  leadId: any;
  isEdit: boolean = false;

  leadForm = this.formBuilder.group({
    leadId: [''],
    leadOwner: [''],
    leadOwnerMobile: [''],
    createdDate: [{ value: '', disabled: true }],
    customerName: [''],
    customerEmail: [''],
    customerMobileNum1: [''],
    customerMobileNum2: [''],
    location: [''],
    leadType: [''],
    eventDate: [''],
    eventType: [''],
    category: [''],
    leadMode: [''],
    cplcommissionValue: [''],
    budget: [''],
    expRevenue: [''],
    leadStatus: [''],
    description: ['']
  });
  id: any;

  get form() {
    return this.leadForm.controls;
  }

  constructor(
    private formBuilder: FormBuilder,
    private toast: ToastrService,
    private datePipe: DatePipe,
    private leadService: LeadService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.leadId = this.activatedRoute.snapshot.url[1].path;
    this.getAllLeadTypes();
    this.getAllEventTypes();
    this.getAllCategories();
    this.getAllLeadMode();
    this.getAllLeadStatus();
    this.getAllLeadLocation();
    this.getDetailsbyLeadId();
    this.leadForm.disable();
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
          this.setLeadDetails(this.leadData);

        }
      });
    this.subscriptionList.push(this.getLeadDataSubscription);
  }

  getAllLeadTypes() {
    this.getAllLeadTypesSubscription = this.leadService.getAllLeadTypes()
      .subscribe(response => {
        if (response) {
          this.leadTypeList = response;
        }
      });
    this.subscriptionList.push(this.getAllLeadTypesSubscription);
  }

  getAllEventTypes() {
    this.getAllEventTypesSubscription = this.leadService.getAllEventTypes()
      .subscribe(response => {
        if (response) {
          this.eventTypeList = response;
        }
      });
    this.subscriptionList.push(this.getAllEventTypesSubscription);
  }

  getAllCategories() {
    this.getAllCategoriesSubscription = this.leadService.getAllCategories()
      .subscribe(response => {
        if (response) {
          this.categoryList = response;
        }
      });
    this.subscriptionList.push(this.getAllCategoriesSubscription);
  }

  getAllLeadMode() {
    this.getAllLeadModesSubscription = this.leadService.getAllLeadModes()
      .subscribe(response => {
        if (response) {
          this.leadModeList = response;
          this.leadForm.get('leadMode').setValue(Constants.CplValue);
          this.onLeadModeChange();
        }
      });
    this.subscriptionList.push(this.getAllLeadModesSubscription);
  }

  getAllLeadStatus() {
    this.getAllLeadStatusSubscription = this.leadService.getAllLeadStatus()
      .subscribe(response => {
        if (response) {
          this.leadStatusList = response;
        }
      });
    this.subscriptionList.push(this.getAllLeadStatusSubscription);
  }

  getAllLeadLocation() {
    this.getAllLeadLocationSubscription = this.leadService.getAllLeadLocation()
      .subscribe(response => {
        if (response) {
          this.leadLocationList = response;
        }
      });
    this.subscriptionList.push(this.getAllLeadLocationSubscription);
  }

  getQuestionaireforCategory() {
    if (this.leadForm.controls.category.value != '') {
      this.leadService.getQuestionaireByCategory(this.leadForm.controls.category.value)
        .subscribe((response) => {
          if (response) {
            this.questionAnswers = response;
          }
        });
    }
  }

  setLeadDetails(lead) {
    this.leadForm.get('leadId').setValue(this.leadId);
    this.leadForm.get('leadOwner').setValue(lead.ownerName);
    this.leadForm.get('leadOwnerMobile').setValue('');
    this.leadForm.get('createdDate').setValue(this.datePipe.transform(lead.createdAt, 'MMM d, y, h:mm a'));
    this.leadForm.get('customerName').setValue(lead.customerName);
    this.leadForm.get('customerEmail').setValue(lead.customerEmail);
    this.leadForm.get('customerMobileNum1').setValue(lead.customerPhone1);
    this.leadForm.get('customerMobileNum2').setValue(lead.customerPhone2);
    this.leadForm.get('location').setValue(lead.eventLocation);
    this.leadForm.get('leadType').setValue(lead.leadType);
    this.leadForm.get('eventDate').setValue(lead.eventDate);
    this.leadForm.get('eventType').setValue(lead.eventType);
    this.leadForm.get('category').setValue(lead.category);
    this.leadForm.get('leadMode').setValue(lead.leadMode);
    this.leadForm.get('cplcommissionValue').setValue(lead.cplvalue ? lead.cplvalue : lead.commisionValue);
    this.leadForm.get('budget').setValue(lead.budget);
    this.leadForm.get('expRevenue').setValue(lead.revenue);
    this.leadForm.get('leadStatus').setValue(lead.leadStatusId);
    this.id = lead.id;
  }

  onLeadModeChange() {
    this.valueTitle = this.leadForm.controls.leadMode.value == Constants.CplValue ? "CPL value" : "Commission value %";
  }

  cplcommissionChange(value) {
    if (this.leadForm.controls.leadMode.value == Constants.CplValue) { //cpl
      this.leadForm.get('expRevenue').setValue(value);
    }
  }

  budgetChange(value) {
    if (this.leadForm.controls.leadMode.value == Constants.CommisionValue) { // commission
      this.leadForm.get('expRevenue').setValue((this.leadForm.controls.cplcommissionValue.value / 100) * value);
    }
  }

  detectRadio(j, o) {

    // for (let i = 0; this.categoryList[this.questionAnswers.questions[j].serviceAnswer.length > i; i++) {
    //   if (o === i) {
    //     this.categoryList[this.questionAnswers.questions[j].serviceAnswer[i].value = true;
    //   } else {
    //     this.categoryList[this.questionAnswers.questions[j].serviceAnswer[i].value = false;
    //   }
    // }
  }

  detectCheckBox(j, o) {
    // this.questionAnswers.questions[j].serviceAnswer[o].value = !this.questionAnswers.questions[j].serviceAnswer[o].value;
  }

  onItemSelect($event, result) {
    console.log(result);
  }

  editLead() {
    this.isEdit = true;
    this.leadForm.enable();
  }

  navigateToViewLeads() {
    this.router.navigate([`/app/superadmin/lead-management/view-lead`]);
  }

  updateLead() {

    this.formSubmitted = true;

    if (this.leadForm.valid) {

      const params = new CreateLeadModel();
      const leadData = new LeadDataModel();
      const leadStatus = new LeadStatusModel();

      params.customerId = this.leadForm.get('leadStatus').value;
      params.customerName = this.leadForm.get('customerName').value;
      params.customerEmail = this.leadForm.get('customerEmail').value;
      params.customerPhone1 = this.leadForm.get('customerMobileNum1').value;
      params.customerPhone2 = this.leadForm.get('customerMobileNum2').value;;
      params.customerLocation = '14';
      params.createdBy = this.leadForm.get('leadStatus').value;

      leadData.eventDate = this.leadForm.get('eventDate').value;
      leadData.eventLocation = this.leadForm.get('location').value;
      leadData.leadId = this.leadForm.get('leadId').value;
      leadData.owner = '100';
      leadData.ownerName = 'Test'; // logged in user
      leadData.description = null;
      leadData.leadType = this.leadForm.get('leadType').value;
      leadData.eventType = this.leadForm.get('eventType').value;
      leadData.leadStatusId = this.leadForm.get('leadStatus').value;
      leadData.leadMode = this.leadForm.get('leadMode').value;
      leadData.category = this.leadForm.get('category').value;
      leadData.budget = this.leadForm.get('budget').value;
      leadData.revenue = this.leadForm.get('expRevenue').value;
      leadData.cplvalue = this.leadForm.get('leadMode').value == Constants.CplValue ? this.leadForm.get('cplcommissionValue').value : null;
      leadData.commisionValue = this.leadForm.get('leadMode').value == Constants.CommisionValue ? this.leadForm.get('cplcommissionValue').value : null;
      leadData.walletStatus = null;
      leadData.leadQuality = null;
      leadData.createdBy = 0;
      leadData.leadStatus = [{
        "leadId": 0,
        "leadStatusId": this.leadForm.get('leadStatus').value,
        "date": new Date().toISOString(),
        "createdBy": 0
      }];

      params.leads.push(leadData);

      this.leadService.updateLead(leadData, this.id)
        .subscribe(response => {
          this.toast.success('', Constants.UpdatedSuccessMessage);
        });
    }
  }

  saveQuestion() {
    const vendorQuestionAnswers = [];
    const params = { vendorQuestionAnswers: [] };
    this.questionAnswers.forEach(i => {
      let answerID = null;
      if (i.serviceAnswer.length > 0 && i.serviceAnswer[0].controlType === 29) {
        i.serviceAnswer.forEach(t => {
          if (t.value === true) {
            answerID = t.id;
          }
        });
        const questParams = {
          questionId: i.id,
          vendorLeadId: this.leadId,
          controlType: i.serviceAnswer[0].controlType,
          answerId: answerID,
          vendoranswervalue: null,
          IsForVendor: 1,
          active: 1,
          createdBy: 1
        };
        params.vendorQuestionAnswers.push(questParams);
      } else if (i.serviceAnswer.length > 0 && i.serviceAnswer[0].controlType === 30) {
        i.serviceAnswer.forEach(t => {
          if (t.value === true) {
            answerID = t.id;

            const questParams = {
              questionId: i.id,
              vendorLeadId: this.leadId,
              answerId: answerID,
              vendoranswervalue: null,
              IsForVendor: 1,
              active: 1,
              createdBy: 1
            };
            params.vendorQuestionAnswers.push(questParams);
          }
        });

      } else if (i.serviceAnswer.length > 0 && i.serviceAnswer[0].controlType === 31) {
        i.serviceAnswer.forEach(t => {
          answerID = t.id;

          const questParams = {
            questionId: i.id,
            vendorLeadId: this.leadId,
            controlType: i.serviceAnswer[0].controlType,
            answerId: answerID,
            vendoranswervalue: null,
            IsForVendor: 1,
            active: 1,
            createdBy: 1
          };
          params.vendorQuestionAnswers.push(questParams);

        });
      } else if (i.serviceAnswer.length > 0 && i.serviceAnswer[0].controlType === 28) {
        i.serviceAnswer.forEach(t => {
          answerID = t.id;

          const questParams = {
            questionId: i.id,
            vendorLeadId: this.leadId,
            controlType: i.serviceAnswer[0].controlType,
            answerId: answerID,
            // vendoranswervalue: i.result,
            IsForVendor: 1,
            active: 1,
            createdBy: 1
          };
          params.vendorQuestionAnswers.push(questParams);
        });
      }

    });

    // this.saveQuestionAns = this.service.saveQuestion(params)
    //   .subscribe((response) => {
    //     if (response) {

    //     }
    //   });

  }

}
