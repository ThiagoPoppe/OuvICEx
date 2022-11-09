import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { User } from 'src/app/models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  url = "User"
  constructor(private http: HttpClient) { }



  public getUser(): Observable<User[]>{
    console.log(`${environment.apiUrl}/${this.url}`);

    let a = this.http.get<User[]>(`${environment.apiUrl}/${this.url}`);
    console.log(a);
    return a;
  }

}
