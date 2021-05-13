import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';

import { CurrencyKitComponent } from './currency-kit.component';

describe('CurrencyKitComponent', () => {
  let component: CurrencyKitComponent;
  let fixture: ComponentFixture<CurrencyKitComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ CurrencyKitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrencyKitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
