import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vendor-budget-details',
  templateUrl: './vendor-budget-details.component.html',
  styleUrls: ['./vendor-budget-details.component.css']
})
export class VendorBudgetDetailsComponent implements OnInit {

  constructor(
    private router: Router,
  ) { }

  ngOnInit(): void {
  }

  nextStep(){
    this.router.navigate([`/app/superadmin/vendor-management/videolinks`]);
  }

}
