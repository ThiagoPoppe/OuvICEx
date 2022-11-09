import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { User } from 'src/app/models/user';
import { BehaviorSubject, map } from 'rxjs';
import { Router } from '@angular/router';
import { LocalStorageService } from '../local-storage/local-storage.service';

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
  private userSubject: BehaviorSubject<User>;
  public user: Observable<User>;
  url = "User"
  constructor(
    private router: Router,
    private http: HttpClient,
    private localStorageService: LocalStorageService
  ) {
      this.userSubject = new BehaviorSubject<User>(this.localStorageService.get('user'));
      this.user = this.userSubject.asObservable();
  }

  public get userValue(): User {
    return this.userSubject.value;
  }

  public postUser(user: User) : Observable<User> {
    console.log(`${environment.apiUrl}/${this.url}`);
    console.log("entrei no post");
    console.log(user);
    let a = this.http.post<User>(`${environment.apiUrl}/${this.url}`, user, httpOptions);
    console.log(a);
    return a;
  }

  login(email: string, password: string) {
    return this.http.post<User>(`${environment.apiUrl}/${this.url}/authenticate`, { email, password })
        .pipe(map((user: User) => {
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            this.localStorageService.set('user', user);
            this.userSubject.next(user);
            return user;
        }));
  } 

  logout() {
    // remove user from local storage and set current user to null
    localStorage.removeItem('user');
    this.userSubject.next(null);
    this.router.navigate(['/account/login']);
}

register(user: User) {
    return this.http.post(`${environment.apiUrl}/users/register`, user);
}

  public getUser(): Observable<User[]>{
    console.log(`${environment.apiUrl}/${this.url}`);

    let a = this.http.get<User[]>(`${environment.apiUrl}/${this.url}`);
    console.log(a);
    return a;
  }

}
