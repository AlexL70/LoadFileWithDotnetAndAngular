import { HttpClient, HttpRequest, HttpEventType } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { File } from './../models/File';

@Injectable({
  providedIn: 'root'
})
export class FileService {
  private readonly filesEndPoint: string = '/api/files';
  constructor(private http: HttpClient) { }

  getFiles(): Observable<File[]> {
    return <Observable<File[]>> this.http.get(this.filesEndPoint);
  }

  upload(userId: number, file: Blob,
    progressCallback: (HttpUploadProgressEvent) => void,
    completeCallback: (HttpEvent) => void) {
    const formData = new FormData();
    formData.append('file', file );
    const req = new HttpRequest('POST', `${this.filesEndPoint}/${userId}`,
      formData, { reportProgress: true } );
    return this.http.request(req)
      .subscribe(event => {
        switch (event.type) {
          case HttpEventType.UploadProgress:
            progressCallback(event);
          break;

          case HttpEventType.Response:
            completeCallback(event);
          break;
        }
    });
  }

}
