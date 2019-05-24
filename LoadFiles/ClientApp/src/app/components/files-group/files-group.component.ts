import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-files-group',
  templateUrl: './files-group.component.html',
  styleUrls: ['./files-group.component.css']
})
export class FilesGroupComponent implements OnInit {
  files: File[];

  constructor() { }

  ngOnInit() { }

}
