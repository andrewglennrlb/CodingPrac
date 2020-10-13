import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Project } from '../Models/Project';
import { ProjectService } from '../services/ProjectService';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  providers: [ProjectService],
  styleUrls: ['./fetch-data.component.css']
})
export class FetchDataComponent {
  public projects: Project[];
  date = new FormControl(new Date());

  constructor(private projectService: ProjectService) {
    this.projectService.getAllForUserId(1).subscribe(result => {
      this.projects = result;
    }, error => console.error(error));
  }
}

