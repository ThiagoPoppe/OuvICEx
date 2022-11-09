import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { Department } from 'src/app/models/department';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  url="Departament"

  constructor(private http: HttpClient) { }

  public getDepartaments(): Observable<Department[]>{
    let a = this.http.get<Department[]>(`${environment.apiUrl}/${this.url}`);
    console.log(a);

    return a;
  }
}
