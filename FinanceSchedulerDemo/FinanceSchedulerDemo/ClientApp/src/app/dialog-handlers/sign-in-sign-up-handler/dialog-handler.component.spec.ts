import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogHandlerComponent } from './dialog-handler.component';

describe('DialogHandlerComponent', () => {
  let component: DialogHandlerComponent;
  let fixture: ComponentFixture<DialogHandlerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DialogHandlerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogHandlerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
