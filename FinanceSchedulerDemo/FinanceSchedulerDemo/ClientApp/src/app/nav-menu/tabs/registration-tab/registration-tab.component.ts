import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-registration-tab',
  templateUrl: './registration-tab.component.html',
  styleUrls: ['./registration-tab.component.css']
})
export class RegistrationTabComponent implements OnInit {
  @Output() registrationRequested = new EventEmitter<null>();

  constructor() { }

  ngOnInit(): void {
  }

  public onRegistrationRequested(): void {
    this.registrationRequested.emit();
  }
}
