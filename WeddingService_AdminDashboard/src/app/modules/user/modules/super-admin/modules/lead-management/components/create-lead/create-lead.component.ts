import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { SubscriptionLike as ISubscription } from 'rxjs';
import { Constants } from 'src/app/shared/constants/constants';
import { CreateLeadModel, LeadDataModel, LeadStatusModel } from '../../models/create-lead-model';
import { LeadQuestionAnswers } from '../../models/lead-question-answer.model';
import { LeadService } from '../../services/lead.service';
import { ToastrService } from 'ngx-toastr';
import { IDropdownSettings } from 'ng-multiselect-dropdown';

@Component({
  selector: 'app-create-lead',
  templateUrl: './create-lead.component.html',
  styleUrls: ['./create-lead.component.css']
})
export class CreateLeadComponent implements OnInit, OnDestroy {


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
  leadsDataList: any;
  getAllLeadsSubscription: any;
  getLeadIdSubscription: any;
  newLeadId: any;
  valueTitle: string;
  formSubmitted: boolean;
  questionAnswers: Array<LeadQuestionAnswers>;
  dropdownSettings: IDropdownSettings;
  showQuestionTab: boolean = false;
  questionaireIndex: number;
  serviceTypes = [];
  leadsDetails: any[];
  leadId: any;
  formData: FormData = new FormData();
  bigTotalItems: number;
  bigCurrentPage = 1;
  maxSize = 30;
  pageSize = 10;
  isEdit: boolean = false;

  leadForm = this.formBuilder.group({
    leadOwner: [''],
    leadId: [{ value: '', disabled: true }],
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
    leadStatus: [{ value: '', disabled: true }]
  });

  get form() {
    return this.leadForm.controls;
  }

  constructor(
    private formBuilder: FormBuilder,
    private leadService: LeadService,
    private toast: ToastrService,
  ) { }

  ngOnInit(): void {
    this.getNewLeadId();
    this.getAllLeadTypes();
    this.getAllEventTypes();
    this.getAllCategories();
    this.getAllLeadMode();
    this.getAllLeadStatus();
    this.getAllLeadLocation();
    this.getAllLeads();
  }

  ngOnDestroy() {
    this.subscriptionList.forEach(subscription => {
      if (subscription) {
        subscription.unsubscribe();
      }
    });
  }

  getNewLeadId() {
    this.getLeadIdSubscription = this.leadService.getLeadId()
      .subscribe(response => {
        if (response) {
          this.newLeadId = response;
          this.leadForm.get('leadId').setValue(this.newLeadId);
        }
      });
    this.subscriptionList.push(this.getLeadIdSubscription);
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
          this.leadForm.get('leadStatus').setValue(Constants.FollowUp);
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

  getAllLeads() {
    this.getAllLeadsSubscription = this.leadService.getAllLeads()
      .subscribe(response => {
        if (response) {
          this.leadsDataList = response;
          this.leadsDetails = [];
          this.leadsDataList.forEach(element => {
            this.leadsDetails.push(element.leads[0])
          });
          this.bigTotalItems = this.leadsDataList.length;
        }
      });
    this.subscriptionList.push(this.getAllLeadsSubscription);
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

  submitLead() {

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
      leadData.leadId = this.newLeadId;
      leadData.owner = '100'; //logged in userId
      leadData.ownerName = 'Test'; //logged in userName
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

      if (this.isEdit) {
        this.leadService.updateLead(leadData, this.leadId)
          .subscribe(response => {
            this.toast.success('', Constants.UpdatedSuccessMessage);
            this.clearLeadForm();
            this.getAllLeads();
          });
      }
      else {
        this.leadService.saveLead(params)
          .subscribe(response => {
            if (response.status == 201) {
              this.toast.success('', Constants.CreatedSuccessMessage);
              this.leadId = response.body.leadId;
              this.clearLeadForm();
              this.getAllLeads();
            }
          });
      }
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

  clearLeadForm() {
    this.isEdit = false;
    this.leadForm.reset();
    this.leadForm.get('leadStatus').setValue(Constants.FollowUp);
    this.onLeadModeChange();
  }

  editLeadDetails(lead) {
    this.isEdit = true;
    this.leadId = lead.leads[0].id;
    this.leadForm.get('leadOwner').setValue(lead.CreatedBy);
    this.leadForm.get('customerName').setValue(lead.CustomerName);
    this.leadForm.get('customerEmail').setValue(lead.CustomerEmail);
    this.leadForm.get('customerMobileNum1').setValue(lead.CustomerPhone1);
    this.leadForm.get('customerMobileNum2').setValue(lead.CustomerPhone2);
    this.leadForm.get('location').setValue(lead.leads[0].eventLocation);
    this.leadForm.get('leadType').setValue(lead.leads[0].leadType);
    this.leadForm.get('eventDate').setValue(lead.leads[0].eventDate);
    this.leadForm.get('eventType').setValue(lead.leads[0].eventType);
    this.leadForm.get('category').setValue(lead.leads[0].category);
    this.leadForm.get('leadMode').setValue(lead.leads[0].leadMode);
    this.leadForm.get('cplcommissionValue').setValue(lead.leads[0].cplvalue ? lead.leads[0].cplvalue : lead.leads[0].commisionValue);
    this.leadForm.get('budget').setValue(lead.leads[0].budget);
    this.leadForm.get('expRevenue').setValue(lead.leads[0].revenue);
    this.leadForm.get('leadStatus').setValue(lead.leads[0].leadStatusId);
  }

  cloneLeadDetails(lead) {
    this.isEdit = false;
    this.leadForm.get('leadOwner').setValue(lead.CreatedBy);
    this.leadForm.get('customerName').setValue(lead.CustomerName);
    this.leadForm.get('customerEmail').setValue(lead.CustomerEmail);
    this.leadForm.get('customerMobileNum1').setValue(lead.CustomerPhone1);
    this.leadForm.get('customerMobileNum2').setValue(lead.CustomerPhone2);
    this.leadForm.get('location').setValue(lead.leads[0].eventLocation);
    this.leadForm.get('leadType').setValue(lead.leads[0].leadType);
  }

}
