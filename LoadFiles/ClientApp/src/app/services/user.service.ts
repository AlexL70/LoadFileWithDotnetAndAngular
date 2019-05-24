import { KeyValuePair } from './../models/KeyValuePair';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private http: HttpClient
  ) { }

  getUsers(): Observable<KeyValuePair[]> {
    return <Observable<KeyValuePair[]>> this.http.get('/api/myusers');
  }
}
