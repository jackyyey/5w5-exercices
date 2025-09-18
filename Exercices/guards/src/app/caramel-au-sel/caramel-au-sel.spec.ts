import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CaramelAuSel } from './caramel-au-sel';

describe('CaramelAuSel', () => {
  let component: CaramelAuSel;
  let fixture: ComponentFixture<CaramelAuSel>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CaramelAuSel]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CaramelAuSel);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
