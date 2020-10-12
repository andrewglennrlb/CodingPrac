import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Project } from "../Models/Project";
import { Inject, Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}
  getAllForUserId(userId: number): Observable<Project[]> {
    return this.http.get<Project[]>(`${this.baseUrl}Project/User/${userId}`);
  }
}
