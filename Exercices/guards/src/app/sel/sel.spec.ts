import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Sel } from './sel';

describe('Sel', () => {
  let component: Sel;
  let fixture: ComponentFixture<Sel>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Sel]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Sel);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
