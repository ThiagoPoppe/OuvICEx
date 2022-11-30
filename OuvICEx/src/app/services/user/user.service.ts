import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { User } from 'src/app/models/user';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})

export class UserService {
  url = "User"
  constructor(private http: HttpClient) { }

  public postUser(user: User) : Observable<User> {
    console.log(`${environment.apiUrl}/${this.url}`);
    let a = this.http.post<User>(`${environment.apiUrl}/${this.url}`, user, httpOptions);
    console.log(a);
    return a;
  }

  public getUser(): Observable<User[]>{
    console.log(`${environment.apiUrl}/${this.url}`);

    let a = this.http.get<User[]>(`${environment.apiUrl}/${this.url}`);
    console.log(a);
    return a;
  }

}