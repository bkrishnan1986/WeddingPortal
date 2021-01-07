import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {

  constructor(
    private router: Router,
  ) { }

  ngOnInit(): void { }

  navigateToAdminPanel() {
    this.router.navigate([`/app/superadmin/admin-panel`]);
  }

  navigateToVendorDashboard() {
    this.router.navigate([`/app/superadmin/vendor-management`]);
  }

  navigateToLead() {
    this.router.navigate([`/app/superadmin/lead-management/create-lead`]);
  }
}
