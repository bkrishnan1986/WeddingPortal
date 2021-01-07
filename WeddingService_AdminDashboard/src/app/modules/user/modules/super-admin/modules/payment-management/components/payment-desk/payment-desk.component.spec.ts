import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentDeskComponent } from './payment-desk.component';

describe('PaymentDeskComponent', () => {
  let component: PaymentDeskComponent;
  let fixture: ComponentFixture<PaymentDeskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PaymentDeskComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PaymentDeskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
