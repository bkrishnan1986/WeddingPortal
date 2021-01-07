import { Component, ElementRef, OnDestroy, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { SubscriptionLike as ISubscription } from 'rxjs';
import { Constants } from 'src/app/shared/constants/constants';
import { LeadService } from '../../services/lead.service';
import { FollowupDetailsModalComponent } from '../followup-details-modal/followup-details-modal.component';

@Component({
  selector: 'app-view-lead',
  templateUrl: './view-lead.component.html',
  styleUrls: ['./view-lead.component.css']
})
export class ViewLeadComponent implements OnInit, OnDestroy {

  subscriptionList: ISubscription[] = [];
  leadsDataList: any;
  getAllLeadsSubscription: any;
  getAllLeadStatusSubscription: any;
  deleteLeadSubscription: any;
  leadsDetails: any[];
  bigTotalItems: number;
  bigCurrentPage = 1;
  maxSize = 30;
  pageSize = 10;
  pauseLeadSubscription: any;
  modalRef: BsModalRef;
  leadStatusList: any;
  submitforApprovalLeadId: any;
  leadStatusArray: any[] = []

  submitApproval = this.formBuilder.group({
    leadStatus: ['', Validators.required],
    // approvedDate: [''],
    // approvedBy: ['']
  });

  get form() {
    return this.submitApproval.controls;
  }

  constructor(
    private formBuilder: FormBuilder,
    private leadService: LeadService,
    private router: Router,
    private toast: ToastrService,
    private modalService: BsModalService
  ) { }

  ngOnInit(): void {
    this.getAllLeads();
    this.getAllLeadStatus();
  }

  ngOnDestroy() {
    this.subscriptionList.forEach(subscription => {
      if (subscription) {
        subscription.unsubscribe();
      }
    });
  }

  getAllLeads() {
    this.getAllLeadsSubscription = this.leadService.getAllLeads()
      .subscribe(response => {
        if (response) {
          this.leadsDataList = response;
          this.leadsDetails = [];
          this.leadsDataList.forEach(element => {
            this.leadsDetails.push(element.leads[0])
          });
        }
      });
    this.subscriptionList.push(this.getAllLeadsSubscription);
  }

  getAllLeadStatus() {
    this.getAllLeadStatusSubscription = this.leadService.getAllLeadStatus()
      .subscribe(response => {
        if (response) {
          this.leadStatusList = response;
          this.submitApproval.get('leadStatus').setValue(Constants.Pending);
        }

        this.leadStatusList.forEach(element => {
          this.leadStatusArray.push({label : element.value, value : element.value});
        });
        this.leadStatusArray = this.leadStatusArray.reduce((acc, val) => {
          if (!acc.find(el => el.value === val.value)) {
            acc.push(val);
          }
          return acc;
        }, []);
      });
    this.subscriptionList.push(this.getAllLeadStatusSubscription);
  }


  viewLeadDetails(leadId) {
    this.router.navigate([`/app/superadmin/lead-management/lead-details/` + leadId]);
  }

  openFollowUpDetailsModal(Id) {
    const initialState = { leadId: Id };
    this.modalRef = this.modalService.show(FollowupDetailsModalComponent, { initialState, class: 'modal-lg' });

    // this.modalRef.content.onClose.subscribe(result => {
    //   console.log('results', result);
    // })
  }

  closeModalWithComponent() {
    this.modalService.hide();
  }

  openModalForSubmit(leadId, submitforApproval: TemplateRef<any>) {
    this.submitforApprovalLeadId = leadId;
    this.modalRef = this.modalService.show(submitforApproval);
  }

  submitRequestforApproval() {
    if (this.submitApproval.valid) {
      const params = {
        "leadStatus": this.submitApproval.get('leadStatus').value,
        "updatedBy": 0 //logged in user
      }
      this.pauseLeadSubscription = this.leadService.changeLeadStatus(this.submitforApprovalLeadId, params)
        .subscribe(response => {
          this.toast.success('', Constants.UpdatedSuccessMessage);
          this.getAllLeads();
        });
      this.subscriptionList.push(this.pauseLeadSubscription);
    }
  }

  closeModal() {
    this.modalService.hide();
  }

  pauseLead(leadId) {
    const params = {
      "leadStatus": Constants.Paused,
      "updatedBy": 0 //logged in user
    }
    this.pauseLeadSubscription = this.leadService.changeLeadStatus(leadId, params)
      .subscribe(response => {
        this.toast.success('', Constants.UpdatedSuccessMessage);
        this.getAllLeads();
      });
    this.subscriptionList.push(this.pauseLeadSubscription);
  }

  deleteLead(leadId) {
    this.deleteLeadSubscription = this.leadService.deleteLead(leadId)
      .subscribe(response => {
        this.toast.success('', Constants.DeletedSuccessMessage);
        this.getAllLeads();
      });
    this.subscriptionList.push(this.deleteLeadSubscription);
  }

}
