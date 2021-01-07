import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vendor-wallet',
  templateUrl: './vendor-wallet.component.html',
  styleUrls: ['./vendor-wallet.component.css']
})
export class VendorWalletComponent implements OnInit {
  users: User[];

  cols: any[];
  constructor() { }

  ngOnInit(): void {
    this.users = [
      { leadDate: '1', leadID: '112233445566', leadAssignedDate: '  5/1/2020', leadAmount: '350', details: 'Lorem', eventDate: 'Lorem', eventLocation: 'Lorem' },
      { leadDate: '1', leadID: '112233445566', leadAssignedDate: '  5/1/2020', leadAmount: '350', details: 'Lorem', eventDate: 'Lorem', eventLocation: 'Lorem' },
      { leadDate: '1', leadID: '112233445566', leadAssignedDate: '  5/1/2020', leadAmount: '350', details: 'Lorem', eventDate: 'Lorem', eventLocation: 'Lorem' },
      { leadDate: '1', leadID: '112233445566', leadAssignedDate: '  5/1/2020', leadAmount: '350', details: 'Lorem', eventDate: 'Lorem', eventLocation: 'Lorem' },

    ];
    this.cols = [
      { field: 'leadDate', header: 'Lead Date' },
      { field: 'leadDate', header: 'Lead ID' },
      { field: 'leadAssignedDate', header: 'Lead Assigned Date' },
      { field: 'leadAmount', header: 'Lead Amount (CPC/Commission)' },
      { field: 'details', header: 'Details' },
      { field: 'eventDate', header: 'Event Date' },
      { field: 'eventLocation', header: 'Event Location' },
    ];
  }

}
export interface User {
  leadDate;
  leadID;
  leadAssignedDate;
  leadAmount;
  details;
  eventDate;
  eventLocation;
}