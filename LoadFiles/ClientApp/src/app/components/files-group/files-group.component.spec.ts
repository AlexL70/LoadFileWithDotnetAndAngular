import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FilesGroupComponent } from './files-group.component';

describe('FilesGroupComponent', () => {
  let component: FilesGroupComponent;
  let fixture: ComponentFixture<FilesGroupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FilesGroupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FilesGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
