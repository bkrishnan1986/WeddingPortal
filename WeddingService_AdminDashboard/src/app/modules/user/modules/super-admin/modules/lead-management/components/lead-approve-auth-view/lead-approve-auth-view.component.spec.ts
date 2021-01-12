/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { LeadApproveAuthViewComponent } from './lead-approve-auth-view.component';

describe('LeadApproveAuthViewComponent', () => {
  let component: LeadApproveAuthViewComponent;
  let fixture: ComponentFixture<LeadApproveAuthViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LeadApproveAuthViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LeadApproveAuthViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
