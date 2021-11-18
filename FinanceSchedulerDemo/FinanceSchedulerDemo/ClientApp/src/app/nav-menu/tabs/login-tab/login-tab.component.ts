import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-login-tab',
  templateUrl: './login-tab.component.html',
  styleUrls: ['./login-tab.component.css']
})
export class LoginTabComponent implements OnInit {
  @Output() loginRequested = new EventEmitter<null>();

  constructor() { }

  ngOnInit(): void {
  }

  public onLoginRequested(): void {
    this.loginRequested.emit();
  }
}
