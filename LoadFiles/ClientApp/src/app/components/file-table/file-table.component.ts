import { Component, OnInit } from '@angular/core';
import { FileService } from 'src/app/services/file.service';

@Component({
  selector: 'app-file-table',
  templateUrl: './file-table.component.html',
  styleUrls: ['./file-table.component.css']
})
export class FileTableComponent implements OnInit {
  files: File[];

  constructor(
    private fileService: FileService
  ) { }

  ngOnInit() {
    this.fileService.getFiles()
      .subscribe(files => this.files = files);
  }

}
