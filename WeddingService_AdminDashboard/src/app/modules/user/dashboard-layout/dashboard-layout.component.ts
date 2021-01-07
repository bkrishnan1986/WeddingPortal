import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import * as AdminLte from 'admin-lte';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard-layout',
  templateUrl: './dashboard-layout.component.html'
})
export class DashboardLayoutComponent implements OnInit {

  constructor(
    private router: Router
  ) { }

  ngOnInit(): void { 
    $('[data-widget="treeview"]').each(x => {
      AdminLte.Treeview._jQueryInterface.call($(this), 'init');
    });
  }
}
