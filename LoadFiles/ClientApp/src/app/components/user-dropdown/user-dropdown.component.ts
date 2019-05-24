import { KeyValuePair } from './../../models/KeyValuePair';
import { UserService } from './../../services/user.service';
import { Component, OnInit, Input, isDevMode, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-user-dropdown',
  templateUrl: './user-dropdown.component.html',
  styleUrls: ['./user-dropdown.component.css']
})
export class UserDropdownComponent implements OnInit {
  @Input('dropdownLabel') dropdownLabel = 'Choose User';
  @Input('resetIsVisible') resetIsVisible = true;
  @Input('resetCaption') resetCaption = 'Reset';
  @Output('userChanged') userChanged = new EventEmitter<number>();
  users: KeyValuePair[];
  userId: number;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getUsers()
      .subscribe(users => this.users = users);
  }

  onUserIdChange() {
    if (isDevMode) {
      console.log(`User id changed. New value is ${this.userId}`);
    }
    this.userChanged.emit(this.userId);
  }

  resetUserId() {
    this.userId = null;
    this.onUserIdChange();
  }
}
