import { FileTableComponent } from './../file-table/file-table.component';
import { Component, OnInit, ViewChild, isDevMode } from '@angular/core';
import { File } from './../../models/File';

@Component({
  selector: 'app-files-group',
  templateUrl: './files-group.component.html',
  styleUrls: ['./files-group.component.css']
})
export class FilesGroupComponent implements OnInit {
  @ViewChild('fileTable') fileTable: FileTableComponent;

  constructor() { }

  ngOnInit() { }

  onLoadFile(file: File) {
    if (isDevMode) {
      console.log(`File loaded: ${file.name} by user ${file.user.name}`);
    }
    this.fileTable.reloadFiles();
  }

}
