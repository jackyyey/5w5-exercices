import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerreDEau } from './verre-deau';

describe('VerreDEau', () => {
  let component: VerreDEau;
  let fixture: ComponentFixture<VerreDEau>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [VerreDEau]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VerreDEau);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
