import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserResponseModel } from '../../models/user-response.model';
import { UserCreationService } from '../../services/user-creation.service';
import { SubscriptionLike as ISubscription } from 'rxjs';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent implements OnInit, OnDestroy {

  deleteUserSubscription: ISubscription;
  getAllActiveUsersSubscription: ISubscription;
  usersList: UserResponseModel[] = [];
  subscriptionList: ISubscription[] = [];

  constructor(
    private router: Router,
    private userCreationService: UserCreationService
  ) { }

  ngOnInit(): void {
    this.getAllActiveUsers();
  }

  ngOnDestroy() {
    this.subscriptionList.forEach(subscription => {
      if (subscription) {
        subscription.unsubscribe();
      }
    });
  }

  getAllActiveUsers() {
    this.getAllActiveUsersSubscription = this.userCreationService.getAllActiveUsers()
      .subscribe((response) => {
        if (response) {
          this.usersList = response;
        }
      });

    this.subscriptionList.push(this.getAllActiveUsersSubscription);
  }

  addNewUser() {
    this.router.navigate([`/app/superadmin/admin-panel/create-user`]);
  }

  viewUser(userId) {
    this.router.navigate([`/app/superadmin/admin-panel/view-user/` + userId]);
  }

  editUser(userId) {
    this.router.navigate([`/app/superadmin/admin-panel/edit-user/` + userId]);
  }

  deleteUser(profileId) {
    this.deleteUserSubscription = this.userCreationService.deleteUserbyID(profileId)
      .subscribe((response) => {
        this.getAllActiveUsers()
      });
    this.subscriptionList.push(this.deleteUserSubscription);
  }
}

