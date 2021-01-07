import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sidebar-menu',
  templateUrl: './sidebar-menu.component.html'
})
export class SidebarMenuComponent implements OnInit {

  userRole: string;
  userName: string;

  constructor(
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.userRole = '1';
    this.userName = 'Jon Snow';
  }

  navigateToHome() {
    this.router.navigate([`/app/superadmin`]);
  }

  logOut(){
    this.router.navigate([`/`]);
  }

}
