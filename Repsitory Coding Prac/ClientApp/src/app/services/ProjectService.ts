import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Project } from "../Models/Project";

export class ProjectService {

  constructor(private http: HttpClient) {}
  getAllForUserId(userId: number): Observable<Project> {
    return this.http.get<Project>(`/Project/User/${userId}`);
  }
}
