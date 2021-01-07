import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WalletRuleViewComponent } from './wallet-rule-view.component';

describe('WalletRuleViewComponent', () => {
  let component: WalletRuleViewComponent;
  let fixture: ComponentFixture<WalletRuleViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WalletRuleViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WalletRuleViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
