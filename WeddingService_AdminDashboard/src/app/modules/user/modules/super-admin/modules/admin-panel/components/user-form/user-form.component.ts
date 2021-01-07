import { DatePipe } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AddUser } from '../../models/add-user.model';
import { ProfilePermission } from '../../models/profile-permission.model';
import { UserCreationService } from '../../services/user-creation.service';
import { SubscriptionLike as ISubscription } from 'rxjs';
import { UserResponseModel } from '../../models/user-response.model';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit, OnDestroy {

  emailValidation = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{3,}))$/;
  page: string;
  id: any;
  userContent: UserResponseModel;
  headerTitle: string;
  userRights: any = [];
  userRolesList: any;
  formSubmitted: boolean;
  showEdit: boolean;
  getRolesSubscription: ISubscription;
  getPermissionsSubscription: ISubscription;
  getUserIdSubscription: ISubscription;
  permission: Permissions[] = [];
  subscriptionList: ISubscription[] = [];

  userForm = this.formBuilder.group({
    dateAndTime: [{ value: '', disabled: true }],
    createdBy: [{ value: '', disabled: true }],
    userId: [''],
    role: ['', Validators.required],
    employeeId: ['', Validators.required],
    firstName: ['', Validators.required],
    email: ['', Validators.compose([Validators.required, Validators.pattern(this.emailValidation)])],
    profilePermission: this.formBuilder.array([])
  });

  get form() {
    return this.userForm.controls;
  }

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private datePipe: DatePipe,
    private userCreationService: UserCreationService
  ) { }

  ngOnInit() {
    this.page = this.activatedRoute.snapshot.url[0].path;
    this.setPageView();
    this.getUserRoles();
    this.getAllUserPermissions();
  }

  ngOnDestroy() {
    this.subscriptionList.forEach(subscription => {
      if (subscription) {
        subscription.unsubscribe();
      }
    });
  }

  setPageView() {

    this.showEdit = false;

    if (this.page === 'edit-user') {
      this.id = this.activatedRoute.snapshot.url[1].path;
      this.getUserDetails(this.id);
      this.headerTitle = 'Edit User';
    }
    else if (this.page === 'view-user') {
      this.id = this.activatedRoute.snapshot.url[1].path;
      this.getUserDetails(this.id);
      this.headerTitle = 'View User';
      this.userForm.disable();
      this.showEdit = true;
    }
    else {
      this.headerTitle = 'User Creation';
      this.id = 0;
      this.userForm.get('dateAndTime').setValue(this.datePipe.transform(new Date(), 'MMM d, y, h:mm a'));
      this.getUserId();
    }
  }

  getUserId() {
    this.getUserIdSubscription = this.userCreationService.getUserId()
      .subscribe(response => {
        if (response) {
          this.userForm.get('userId').setValue(response);
        }
      });

    this.subscriptionList.push(this.getUserIdSubscription);
  }

  getUserRoles() {
    this.getRolesSubscription = this.userCreationService.getAllActiveRoles()
      .subscribe(response => {
        if (response) {
          this.userRolesList = response;
        }
      });

    this.subscriptionList.push(this.getRolesSubscription);
  }

  getAllUserPermissions() {
    this.getPermissionsSubscription = this.userCreationService.getAllUserRights()
      .subscribe(response => {
        if (response) {
          this.userRights = response;
        }
      });
    this.subscriptionList.push(this.getPermissionsSubscription);
  }

  getUserDetails(id) {
    this.userCreationService.getUserDetailsbyID(id)
      .subscribe((response) => {
        if (response) {
          this.userContent = response;
          this.setDataToEdit();
        }
      });
  }

  setDataToEdit() {
    this.userForm.get('dateAndTime').setValue(this.datePipe.transform(this.userContent.createdAt, 'MMM d, y, h:mm a'));
    this.userForm.get('createdBy').setValue(this.userContent.createdBy);
    this.userForm.get('userId').setValue(this.userContent.userId);
    this.userForm.get('role').setValue(this.userContent.profilepermission[0].roleId);
    this.userForm.get('employeeId').setValue(this.userContent.employeeId);
    this.userForm.get('firstName').setValue(this.userContent.firstName);
    this.userForm.get('email').setValue(this.userContent.email);
    this.setPermissions();
  }

  setPermissions() {
    const permission = this.userContent.profilepermission[0].profilePermissions;
    const item = permission.split(',');
    const array = this.userForm.controls.profilePermission as FormArray;
    item.forEach(ele => {
      if (+ele.split(':')[1].split('"')[0] !== 0 && +ele.split(':')[1].split('}')[0] !== 0) {
        array.push(new FormControl(ele.split('"')[1]));
      }
    });

    return array;
  }

  enableEdit() {
    this.userForm.enable();
    this.userForm.controls['dateAndTime'].disable();
    this.userForm.controls['createdBy'].disable();
    this.page = 'edit-user';
    this.setPageView();
  }

  redirectToUserList() {
    this.router.navigate([`/app/superadmin/admin-panel`]);
  }

  saveUser(userForm) {
    this.formSubmitted = true;

    if (userForm.valid) {
      const addUser = new AddUser();
      addUser.firstName = this.userForm.get('firstName').value;
      addUser.email = this.userForm.get('email').value;
      addUser.profilePermission = this.getProfilepermissions();
      addUser.userName = 'User';
      addUser.password = 'password';
      addUser.role = +this.userForm.get('role').value;
      addUser.userId = this.userForm.get('userId').value;
      addUser.employeeId = this.userForm.get('employeeId').value;
      addUser.createdBy = 0;

      if (this.id > 0) {
        this.userCreationService.updateUser(addUser, this.id)
          .subscribe((response) => {
            this.redirectToUserList()
          });
      }
      else {
        this.userCreationService.saveUser(addUser)
          .subscribe((response) => {
            if (response) {
              this.redirectToUserList()
            }
          });
      }

    }
  }

  getProfilepermissions() {
    let permissions = Array<ProfilePermission>();
    permissions = [];
    const item = new ProfilePermission();
    const profilePermission = this.userForm.controls.profilePermission as FormArray;
    const object = {};
    for (const index in this.userRights) {
      if (profilePermission?.value?.length > 0) {

        const right = this.userRights[index].value;
        const data = profilePermission.value?.find(x => x === right);
        object[right] = data ? 1 : 0;

      }
    }
    item.roleId = +this.userForm.get('role').value;
    const role = this.userRolesList.find(x => x.id === item?.roleId);
    item.description = role?.value;
    item.profilePermissions = JSON.stringify(object);
    permissions.push(item);
    return permissions;
  }

  onChecked(e) {
    const profilePermission: FormArray = this.userForm.get('profilePermission') as FormArray;
    if (e.target.checked) {
      profilePermission.push(new FormControl(e.target.value));
    } else {
      let i = 0;
      profilePermission.controls.forEach((item: FormControl) => {
        if (item.value === e.target.value) {
          profilePermission.removeAt(i);
          return;
        }
        i++;
      });
    }
  }

  hasValueSelected(value) {
    const profilePermission: FormArray = this.userForm.get('profilePermission') as FormArray;
    return profilePermission.controls.findIndex(x => x.value === value) !== -1;
  }

}
