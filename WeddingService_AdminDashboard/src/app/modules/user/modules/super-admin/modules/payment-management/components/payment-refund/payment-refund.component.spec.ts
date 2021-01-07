import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentRefundComponent } from './payment-refund.component';

describe('PaymentRefundComponent', () => {
  let component: PaymentRefundComponent;
  let fixture: ComponentFixture<PaymentRefundComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PaymentRefundComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PaymentRefundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
