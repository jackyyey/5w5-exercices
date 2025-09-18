import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Bonbon } from './bonbon';

describe('Bonbon', () => {
  let component: Bonbon;
  let fixture: ComponentFixture<Bonbon>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Bonbon]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Bonbon);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
