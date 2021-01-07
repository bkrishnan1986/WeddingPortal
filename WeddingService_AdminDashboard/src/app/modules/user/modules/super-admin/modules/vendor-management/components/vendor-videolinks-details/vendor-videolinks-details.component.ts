import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-vendor-videolinks-details',
  templateUrl: './vendor-videolinks-details.component.html',
  styleUrls: ['./vendor-videolinks-details.component.css']
})
export class VendorVideolinksDetailsComponent implements OnInit {

  constructor(
    private router: Router,
  ) { }

  ngOnInit(): void {
  }

  nextStep(){
    this.router.navigate([`/app/superadmin/vendor-management/videolinks`]);
  }

}
