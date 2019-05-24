import { UserDropdownComponent } from './../user-dropdown/user-dropdown.component';
import { FileService } from './../../services/file.service';
import { Component, OnInit, ViewChild, ElementRef, isDevMode } from '@angular/core';

@Component({
  selector: 'app-load-file',
  templateUrl: './load-file.component.html',
  styleUrls: ['./load-file.component.css']
})
export class LoadFileComponent implements OnInit {
  progress: number = null;
  @ViewChild('fileInput') fileInput: ElementRef;
  userId: number = null;

  constructor(private fileService: FileService) { }

  ngOnInit() {}

  uploadFile() {
    console.log('Upload File!');
    const nativeELement: HTMLInputElement = this.fileInput.nativeElement;
    const file = nativeELement.files[0];
    this.fileService.upload(this.userId, file,
      event => {
        // Compute and show the % done:
        this.progress = Math.round(100 * event.loaded / event.total);
        if (isDevMode) {
          console.log(`File "${file.name}" is ${this.progress}% uploaded.`);
        }
      },
      event => { //  this.photos.push(event.body);
      });
  }

  onUserChanged(newUserId: number) {
    if (isDevMode) {
      console.log(`User change cought! User Id = ${newUserId}`);
    }
    this.userId = newUserId;
  }

}
