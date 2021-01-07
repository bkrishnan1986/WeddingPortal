import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { VendorManagmentService } from '../../service/vendor-managment.service';
import { PartialSaveService } from '../../service/partial-save.service';
import { VendorCategoryModel } from '../../model/vendor-category.model';
import { SubscriptionLike as ISubscription } from 'rxjs';

@Component({
  selector: 'app-vendor-category-details',
  templateUrl: './vendor-category-details.component.html',
  styleUrls: ['./vendor-category-details.component.css']
})
export class VendorCategoryDetailsComponent implements OnInit, OnDestroy {
  name: string;
  expression = [];
  subCat = [];

  dropdownSettings: IDropdownSettings;
  dropdownSettingsCat: IDropdownSettings;

  formData: FormData = new FormData();
  selectedItems = [];
  index: number;
  vendorId;
  inResult: string;
  commissionMode = '10% off';
  currentCategoryCount = 0;
  currentCategory;
  image;
  photoFiles: any[] = [];
  profileFiles: any[] = [];
  categoryList = new Array<VendorCategoryModel>();
  createCategorySubcript: ISubscription;
  getSubCat: ISubscription;
  getQuestSubcript: ISubscription;
  saveQuestionAns: ISubscription;
  // questionList: CategoryQuestionModel[] = [
  //   {
  //     serviceAnswer: [
  //       {
  //         id: 5,
  //         questionId: 3,
  //         controlType: 28,
  //         answer: "1998",
  //         active: 1,
  //         createdBy: 1,
  //         createdAt: "2020-07-01T00:00:00",
  //         updatedBy: null,
  //         updatedAt: null,
  //         controlTypeNavigation: null,
  //         question: null,
  //         vendorquestionanswers: []
  //       }
  //     ],
  //     id: 3,
  //     question: "Year of establishment-",
  //     serviceType: 32,
  //     vendorLeadId: 0,
  //     isForVendor: 0,
  //     active: 1,
  //     createdBy: 1,
  //     createdAt: "2020-07-01T00:00:00",
  //     updatedBy: null,
  //     updatedAt: null
  //   },
  //   {
  //     serviceAnswer: [
  //       {
  //         id: 6,
  //         questionId: 4,
  //         controlType: 31,
  //         answer: "New",
  //         active: 1,
  //         createdBy: 1,
  //         createdAt: "2020-07-01T00:00:00",
  //         updatedBy: null,
  //         updatedAt: null,
  //         controlTypeNavigation: null,
  //         question: null,
  //         vendorquestionanswers: []
  //       },
  //       {
  //         id: 7,
  //         questionId: 4,
  //         controlType: 31,
  //         answer: "Value",
  //         active: 1,
  //         createdBy: 1,
  //         createdAt: "2020-07-01T00:00:00",
  //         updatedBy: null,
  //         updatedAt: null,
  //         controlTypeNavigation: null,
  //         question: null,
  //         vendorquestionanswers: []
  //       }
  //     ],
  //     id: 4,
  //     question: "Brief words about your establishment -",
  //     serviceType: 32,
  //     vendorLeadId: 0,
  //     isForVendor: 0,
  //     active: 1,
  //     createdBy: 1,
  //     createdAt: "2020-07-01T00:00:00",
  //     updatedBy: 1,
  //     updatedAt: "2020-09-04T10:22:06"
  //   },
  //   {
  //     serviceAnswer: [
  //       {
  //         id: 7,
  //         questionId: 5,
  //         controlType: 30,
  //         answer: "Check 1",
  //         active: 1,
  //         createdBy: 1,
  //         createdAt: "2020-07-01T00:00:00",
  //         updatedBy: null,
  //         updatedAt: null,
  //         controlTypeNavigation: null,
  //         question: null,
  //         vendorquestionanswers: []
  //       },
  //       {
  //         id: 8,
  //         questionId: 5,
  //         controlType: 30,
  //         answer: "Check 2",
  //         active: 1,
  //         createdBy: 1,
  //         createdAt: "2020-07-01T00:00:00",
  //         updatedBy: null,
  //         updatedAt: null,
  //         controlTypeNavigation: null,
  //         question: null,
  //         vendorquestionanswers: []
  //       }
  //     ],
  //     id: 5,
  //     question: "Any specialities about your establishment- ",
  //     serviceType: 32,
  //     vendorLeadId: 0,
  //     isForVendor: 0,
  //     active: 1,
  //     createdBy: 1,
  //     createdAt: "2020 - 07 - 01T00: 00: 00",
  //     updatedBy: null,
  //     updatedAt: null
  //   },
  //   {
  //     serviceAnswer: [
  //       {
  //         id: 8,
  //         questionId: 6,
  //         controlType: 29,
  //         answer: "Yes",
  //         active: 1,
  //         createdBy: 1,
  //         createdAt: "2020-07-01T00:00:00",
  //         updatedBy: null,
  //         updatedAt: null,
  //         controlTypeNavigation: null,
  //         question: null,
  //         vendorquestionanswers: []
  //       },
  //       {
  //         id: 9,
  //         questionId: 6,
  //         controlType: 29,
  //         answer: "No",
  //         active: 1,
  //         createdBy: 1,
  //         createdAt: "2020-07-01T00:00:00",
  //         updatedBy: null,
  //         updatedAt: null,
  //         controlTypeNavigation: null,
  //         question: null,
  //         vendorquestionanswers: []
  //       }
  //     ],
  //     id: 6,
  //     question: "Any VIP clients done – ",
  //     serviceType: 32,
  //     vendorLeadId: 0,
  //     isForVendor: 0,
  //     active: 1,
  //     createdBy: 1,
  //     createdAt: "2020-07-01T00:00:00",
  //     updatedBy: null,
  //     updatedAt: null
  //   },
  // ];
  constructor(
    private router: Router,
    private service: VendorManagmentService,
    private partialService: PartialSaveService
  ) { }

  ngOnInit(): void {
    this.categoryList = this.partialService.getCategory();
    this.vendorId = this.partialService.getVendorNo();
    this.dropdownSettings = {
      singleSelection: false,
      itemsShowLimit: 7,
      idField: 'id',
      textField: 'answer',
      allowSearchFilter: true
    };
    this.dropdownSettingsCat = {
      singleSelection: false,
      itemsShowLimit: 7,
      idField: 'id',
      textField: 'value',
      allowSearchFilter: true
    };

    // this.currentCategory = this.categoryList[0];
    // this.getSubCat = this.service.getWalletRulesDetails(this.categoryList[0].id)
    // .subscribe((response) => {
    //   if (response) {
    //     this.commissionMode = response.commissionAmount;
    //   }
    // });
    this.getSubCat = this.service.getAllVendorMultidetails(this.categoryList[0].value)
      .subscribe((response) => {
        if (response) {
          this.subCat = response;
        }
      });
    this.getQuestSubcript = this.service.GetAllServiceQuestionByServiceTypeId(32)
      .subscribe((response) => {
        if (response) {
          this.categoryList[0].questions = response;
          this.categoryList[0].questions.forEach(x => {
            x.serviceAnswer.forEach(i => {
              if (i.controlType === 29) {
                i.value = false;
              }
              if (i.controlType === 30) {
                i.value = false;
              }
            })

          })


        }
      });
    this.categoryList.forEach(x => {

      x.commissionMode = this.commissionMode;
    });

  }
  ngOnDestroy() {
    if (this.createCategorySubcript) {
      this.createCategorySubcript.unsubscribe();
    }
    if (this.getQuestSubcript) {
      this.getQuestSubcript.unsubscribe();
    }
    if (this.getSubCat) {
      this.getSubCat.unsubscribe();
    }
  }
  nextStep() {
    const BranchResponseList = this.partialService.getBranchResponse();

    const params = new VendorCategoryModel();
    params.categoryId = this.categoryList[this.currentCategoryCount].id;

    // params.vendorId = this.vendorId;
    params.vendorId = '27';
    let obj = this.partialService.getPartialBasicDetails();
    params.vendorName = obj.companyName;
    params.districtId = this.categoryList[this.currentCategoryCount].districtId;
    params.websiteLink = this.categoryList[this.currentCategoryCount].websiteLink;
    params.facebookLink = this.categoryList[this.currentCategoryCount].facebookLink;
    params.instagramLink = this.categoryList[this.currentCategoryCount].instagramLink;
    params.pinterestLink = this.categoryList[this.currentCategoryCount].pinterestLink;
    params.twitterHandle = this.categoryList[this.currentCategoryCount].twitterHandle;
    params.profilePicture = this.categoryList[this.currentCategoryCount].profilePicture;
    params.createdBy = 1;
    const array = this.categoryList[this.currentCategoryCount].subCategory;
    params.commissionMode = this.categoryList[this.currentCategoryCount].commissionMode;
    params.videolink = this.categoryList[this.currentCategoryCount].videolink;

    array.forEach(i => {
      params.subCategory.push({
        subCategoryType: i.id,
        subCategoryValue: i.value
      });
    });
    BranchResponseList.forEach(x => {
      if (params.categoryId === x.serviceId) {
        params.ServiceType = x.branchServiceId;
      }
    });
    if (params.ServiceType) {
      alert('Somthing went wrong !');
    }

    this.formData.append('vendorName', JSON.stringify(params.vendorName));
    this.formData.append('vendorId', JSON.stringify(params.vendorId));
    this.formData.append('categoryType', JSON.stringify(params.categoryId));
    this.formData.append('websiteLink', JSON.stringify(params.websiteLink));
    this.formData.append('facebookLink', JSON.stringify(params.facebookLink));
    this.formData.append('instagramLink', JSON.stringify(params.instagramLink));
    this.formData.append('pinterestLink', JSON.stringify(params.pinterestLink));
    this.formData.append('twitterHandle', JSON.stringify(params.twitterHandle));
    this.formData.append('createdBy', JSON.stringify(params.createdBy));
    this.formData.append('subCategoryList', JSON.stringify(params.subCategory));
    // this.formData.append('commissionMode', JSON.stringify(params.commissionMode));
    this.formData.append('videolink', JSON.stringify(params.videolink));
    this.formData.append('serviceType', JSON.stringify(params.ServiceType));


    this.createCategorySubcript = this.service.saveCategoryDetails(this.formData)
      .subscribe((response) => {
        if (response) {
          this.formData = null;
        }
      });


    this.currentCategoryCount = this.currentCategoryCount + 1;
    // this.getQuestSubcript = this.service.GetAllServiceQuestionByServiceTypeId(this.categoryList[this.currentCategoryCount].id)
    //   .subscribe((response) => {
    //     if (response) {
    //       this.categoryList[this.currentCategoryCount].questions = response;
    //     }
    //   });

    if (this.categoryList.length > this.currentCategoryCount) {
      this.currentCategory = this.categoryList[this.currentCategoryCount];

      this.getSubCat = this.service.getAllVendorMultidetails(this.categoryList[this.currentCategoryCount].value)
        .subscribe((response) => {
          if (response) {
            this.subCat = response;
          }
        });
    } else {

      this.router.navigate([`/app/superadmin/vendor-management/KYCForm`]);
    }
  }

  prepareImagePhotoFilesList(files: Array<any>) {
    this.photoFiles = [];
    if (files.length > 5) {
      alert("choose 5 photos !");
      return;
    }
    for (const item of files) {
      const reader = new FileReader();
      reader.onload = (event: any) => {

        this.image = event.target.result;
        this.photoFiles.push({ 'image': this.image, 'fileName': item.name });
        this.categoryList[this.currentCategoryCount].uploadPhotos = this.photoFiles;

      };
      reader.readAsDataURL(item);
    }
    for (let i = 0; i < files.length; i++) {
      this.formData.append('UploadProfilePicture', files[i]);
    }

  }
  prepareImageProfileFilesList(files: Array<File>) {
    this.profileFiles = [];
    for (const item of files) {
      const reader = new FileReader();
      reader.onload = (event: any) => {
        this.image = event.target.result;
        this.name = item.name;
        this.profileFiles.push({ 'image': this.image, 'fileName': item.name });
        this.categoryList[this.currentCategoryCount].profilePhoto = this.profileFiles;
        // let fileType = item.type;
        // this.formData.append('profilePictures|' + fileType, this.image, item.name);
      };
      reader.readAsDataURL(item);
    }
    // for (let i = 0; i < files.length; i++) {
    //   debugger
    //   const format = [];
    //   format.push({ 'profileImage': files[i] });
    //   this.formData.append('profilePictures', JSON.stringify(format));



    // }
    for (let i = 0; i < files.length; i++) {
      this.formData.append('profileImage', files[i]);
    }
  }
  deleteFileProfileFilesList(index: number) {
    this.categoryList[this.currentCategoryCount].profilePhoto.splice(index, 1);
  }
  deleteFilePhotoFilesList(index: number) {
    this.categoryList[this.currentCategoryCount].uploadPhotos.splice(index, 1);
  }
  detectCheckBox(j, o) {

    this.categoryList[this.currentCategoryCount].questions[j].serviceAnswer[o].value = !this.categoryList[this.currentCategoryCount].questions[j].serviceAnswer[o].value;

  }
  detectRadio(j, o) {

    for (let i = 0; this.categoryList[this.currentCategoryCount].questions[j].serviceAnswer.length > i; i++) {
      if (o === i) {
        this.categoryList[this.currentCategoryCount].questions[j].serviceAnswer[i].value = true;
      } else {
        this.categoryList[this.currentCategoryCount].questions[j].serviceAnswer[i].value = false;
      }
    }

  }

  onItemSelect($event, result) {
    console.log(result);
  }
  // detectInput(i) {
  //   console.log(this.questionList[i].result);
  // }
  // radioButtonChange(j) {
  //   console.log(this.questionList[j].result);
  // }
  saveQuestion() {
    const vendorQuestionAnswers = [];
    const params = { vendorQuestionAnswers: [] };
    this.categoryList[this.currentCategoryCount].questions.forEach(i => {
      let answerID = null;
      if (i.serviceAnswer.length > 0 && i.serviceAnswer[0].controlType === 29) {
        i.serviceAnswer.forEach(t => {
          if (t.value === true) {
            answerID = t.id;
          }
        });
        const questParams = {
          questionId: i.id,
          vendorLeadId: this.vendorId,
          controlType: i.serviceAnswer[0].controlType,
          answerId: answerID,
          vendoranswervalue: null,
          IsForVendor: 1,
          active: 1,
          createdBy: 1
        };
        // vendorQuestionAnswers.push(questParams);
        params.vendorQuestionAnswers.push(questParams);
      } else if (i.serviceAnswer.length > 0 && i.serviceAnswer[0].controlType === 30) {
        i.serviceAnswer.forEach(t => {
          if (t.value === true) {
            answerID = t.id;

            const questParams = {
              questionId: i.id,
              vendorLeadId: this.vendorId,
              // controlType: i.serviceAnswer[0].controlType,
              answerId: answerID,
              vendoranswervalue: null,
              IsForVendor: 1,
              active: 1,
              createdBy: 1
            };
            // vendorQuestionAnswers.push(questParams);
            params.vendorQuestionAnswers.push(questParams);
          }
        });

      } else if (i.serviceAnswer.length > 0 && i.serviceAnswer[0].controlType === 31) {
        i.serviceAnswer.forEach(t => {
          answerID = t.id;

          const questParams = {
            questionId: i.id,
            vendorLeadId: this.vendorId,
            controlType: i.serviceAnswer[0].controlType,
            answerId: answerID,
            vendoranswervalue: null,
            IsForVendor: 1,
            active: 1,
            createdBy: 1
          };
          // vendorQuestionAnswers.push(questParams);
          params.vendorQuestionAnswers.push(questParams);

        });
      } else if (i.serviceAnswer.length > 0 && i.serviceAnswer[0].controlType === 28) {
        i.serviceAnswer.forEach(t => {
          answerID = t.id;

          const questParams = {
            questionId: i.id,
            vendorLeadId: this.vendorId,
            controlType: i.serviceAnswer[0].controlType,
            answerId: answerID,
            vendoranswervalue: i.result,
            IsForVendor: 1,
            active: 1,
            createdBy: 1
          };
          // vendorQuestionAnswers.push(questParams);
          params.vendorQuestionAnswers.push(questParams);
        });
      }

    });


    this.saveQuestionAns = this.service.saveQuestion(params)
      .subscribe((response) => {
        if (response) {

        }
      });

  }
  sameAsWebsite() {
    this.categoryList[this.currentCategoryCount].checkWebsiteLink = !this.categoryList[this.currentCategoryCount].checkWebsiteLink;
    if (this.categoryList[this.currentCategoryCount].checkWebsiteLink) {
      const obj = this.partialService.getPartialBasicDetails();
      this.categoryList[this.currentCategoryCount].websiteLink = obj.website;
    }
  }

  sameAsFacebook() {

    this.categoryList[this.currentCategoryCount].checkFacebookLink = !this.categoryList[this.currentCategoryCount].checkFacebookLink;
    if (this.categoryList[this.currentCategoryCount].checkFacebookLink) {
      const obj = this.partialService.getPartialBasicDetails();
      this.categoryList[this.currentCategoryCount].facebookLink = obj.facebookLink;
    }
  }
  sameAsInstagram() {
    this.categoryList[this.currentCategoryCount].checkInstagramLink = !this.categoryList[this.currentCategoryCount].checkInstagramLink;
    if (this.categoryList[this.currentCategoryCount].checkInstagramLink) {
      const obj = this.partialService.getPartialBasicDetails();
      this.categoryList[this.currentCategoryCount].instagramLink = obj.instagramLink;
    }

  }
  sameAsPinterest() {
    this.categoryList[this.currentCategoryCount].checkPinterestLink = !this.categoryList[this.currentCategoryCount].checkPinterestLink;
    if (this.categoryList[this.currentCategoryCount].checkPinterestLink) {
      const obj = this.partialService.getPartialBasicDetails();
      this.categoryList[this.currentCategoryCount].pinterestLink = obj.pintrestLink;
    }

  }
  sameAsTwitter() {
    this.categoryList[this.currentCategoryCount].checkTwitterHandle = !this.categoryList[this.currentCategoryCount].checkTwitterHandle;
    if (this.categoryList[this.currentCategoryCount].checkTwitterHandle) {
      const obj = this.partialService.getPartialBasicDetails();
      this.categoryList[this.currentCategoryCount].twitterHandle = obj.twitterHandle;
    }

  }
}
