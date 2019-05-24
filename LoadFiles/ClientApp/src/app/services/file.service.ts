import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileService {
  private readonly filesEndPoint: string = '/api/files';
  constructor(private http: HttpClient) { }

  getFiles(): Observable<File[]> {
    return <Observable<File[]>> this.http.get(this.filesEndPoint);
  }
}
