import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeSummary } from './employee-summary';

describe('EmployeeSummary', () => {
  let component: EmployeeSummary;
  let fixture: ComponentFixture<EmployeeSummary>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EmployeeSummary],
    }).compileComponents();

    fixture = TestBed.createComponent(EmployeeSummary);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
