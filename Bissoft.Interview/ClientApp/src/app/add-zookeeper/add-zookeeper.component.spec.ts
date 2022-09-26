import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddZookeeperComponent } from './add-zookeeper.component';

describe('AddZookeeperComponent', () => {
  let component: AddZookeeperComponent;
  let fixture: ComponentFixture<AddZookeeperComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddZookeeperComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddZookeeperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
