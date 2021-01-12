import {
  Component,
  ElementRef,
  OnDestroy,
  OnInit,
  TemplateRef,
  ViewChild,
} from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";
import { Router } from "@angular/router";

import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { ToastrService } from "ngx-toastr";
import { SubscriptionLike as ISubscription } from "rxjs";
import { Constants } from "src/app/shared/constants/constants";
import { LeadService } from "../../services/lead.service";
import { FollowupDetailsModalComponent } from "../followup-details-modal/followup-details-modal.component";

@Component({
  selector: "app-lead-approve-auth-view",
  templateUrl: "./lead-approve-auth-view.component.html",
  styleUrls: ["./lead-approve-auth-view.component.css"],
})
export class LeadApproveAuthViewComponent implements OnInit {
  subscriptionList: ISubscription[] = [];
  leadsDataList: any;
  getAllLeadsSubscription: any;
  getAllLeadStatusSubscription: any;
  getAllLeadQualitySubscription: any;

  deleteLeadSubscription: any;
  leadsDetails: any[];
  bigTotalItems: number;
  bigCurrentPage = 1;
  maxSize = 30;
  pageSize = 10;
  pauseLeadSubscription: any;
  modalRef: BsModalRef;
  leadStatusList: any;
  leadQualityList: any;
  submitforApprovalLeadId: any;
  leadStatusArray: any[] = [];
  leadQualityArray: any[] = [];

  submitApproval_lead = this.formBuilder.group({
    leadStatus: ["", Validators.required],
    leadQuality: ["", Validators.required],
    // approvedDate: [''],
    // approvedBy: ['']
  });

  get form() {
    return this.submitApproval_lead.controls;
  }

  constructor(
    private formBuilder: FormBuilder,
    private leadService: LeadService,
    private router: Router,
    private toast: ToastrService,
    private modalService: BsModalService
  ) {}

  ngOnInit(): void {
    this.getAllLeads();
    this.getAllLeadQuality();
    this.getAllLeadStatus();
  }

  ngOnDestroy() {
    this.subscriptionList.forEach((subscription) => {
      if (subscription) {
        subscription.unsubscribe();
      }
    });
  }

  getAllLeads() {
    this.getAllLeadsSubscription = this.leadService
      .getAllLeads()
      .subscribe((response) => {
        if (response) {
          this.leadsDataList = response;
          console.log(response);
          this.leadsDetails = [];
          this.leadsDataList.forEach((element) => {
            this.leadsDetails.push(element.leads[0]);
          });
        }
      });
    this.subscriptionList.push(this.getAllLeadsSubscription);
  }

  getAllLeadStatus() {
    this.getAllLeadStatusSubscription = this.leadService
      .getAllLeadStatus()
      .subscribe((response) => {
        if (response) {
          this.leadStatusList = response;
          //  this.submitApproval.get('inpt_status').setValue(Constants.Pending);
        }

        this.leadStatusList.forEach((element) => {
          this.leadStatusArray.push({
            label: element.value,
            value: element.value,
          });
        });
        this.leadStatusArray = this.leadStatusArray.reduce((acc, val) => {
          if (!acc.find((el) => el.value === val.value)) {
            acc.push(val);
          }
          return acc;
        }, []);
      });
    this.subscriptionList.push(this.getAllLeadStatusSubscription);
  }

  getAllLeadQuality() {
    this.getAllLeadQualitySubscription = this.leadService
      .getAllLeadQuality()
      .subscribe((response) => {
        if (response) {
          this.leadQualityList = response;
          // this.submitApproval.get('leadQuality').setValue(Constants.Pending);
        }

        this.leadQualityList.forEach((element) => {
          this.leadQualityArray.push({
            label: element.value,
            value: element.value,
          });
        });
        this.leadQualityArray = this.leadQualityArray.reduce((acc, val) => {
          if (!acc.find((el) => el.value === val.value)) {
            acc.push(val);
          }
          return acc;
        }, []);
      });
    this.subscriptionList.push(this.getAllLeadQualitySubscription);
  }

  viewLeadDetails(leadId) {
    this.router.navigate([
      `/app/superadmin/lead-management/lead-details/` + leadId +`/`+true,
    ]);
  }

  openFollowUpDetailsModal(Id) {
    const initialState = { leadId: Id };
    this.modalRef = this.modalService.show(FollowupDetailsModalComponent, {
      initialState,
      class: "modal-lg",
    });

    // this.modalRef.content.onClose.subscribe(result => {
    //   console.log('results', result);
    // })
  }

  closeModalWithComponent() {
    this.modalService.hide();
  }

  openModalForSubmit(leadId, submitforApproval_lead: TemplateRef<any>) {
    this.submitforApprovalLeadId = leadId;
    this.modalRef = this.modalService.show(submitforApproval_lead);
  }

  submitRequestforApproval() {
    if (this.submitApproval_lead.valid) {
      const params = {
        leadquality: this.submitApproval_lead.get("leadQuality").value,
        leadStatus: this.submitApproval_lead.get("leadStatus").value,
        updatedBy: 0, //logged in user
      };
      this.pauseLeadSubscription = this.leadService
        .changeLeadStatus(this.submitforApprovalLeadId, params)
        .subscribe((response) => {
          this.toast.success("", Constants.UpdatedSuccessMessage);
          this.getAllLeads();
        });
      this.subscriptionList.push(this.pauseLeadSubscription);
      this.closeModalWithComponent();
    }
  }

  closeModal() {
    this.modalService.hide();
  }

  pauseLead(leadId) {
    const params = {
      leadStatus: Constants.Paused,
      updatedBy: 0, //logged in user *To Do
    };
    this.pauseLeadSubscription = this.leadService
      .changeLeadStatus(leadId, params)
      .subscribe((response) => {
        this.toast.success("", Constants.UpdatedSuccessMessage);
        this.getAllLeads();
      });
    this.subscriptionList.push(this.pauseLeadSubscription);
  }

  deleteLead(leadId) {
    this.deleteLeadSubscription = this.leadService
      .deleteLead(leadId)
      .subscribe((response) => {
        this.toast.success("", Constants.DeletedSuccessMessage);
        this.getAllLeads();
      });
    this.subscriptionList.push(this.deleteLeadSubscription);
  }

  authorize(leadId) {
    const params = {
      leadquality: 23,
      leadStatus: 24,
      updatedBy: 0, //logged in user
    };
    this.leadService.changeLeadStatus(leadId, params).subscribe((response) => {
      this.toast.success("", Constants.UpdatedSuccessMessage);
      this.getAllLeads();
    });
  }

  redirecttoassign(leadId) {
    alert("Redirect to assign");
  }
}
