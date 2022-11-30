import { Injectable } from '@angular/core';
import { Reclame } from '../../models/reclame';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

@Injectable({
  providedIn: 'root'
})

export class CreatePostService {
  url = "Publication"
  constructor(private http: HttpClient) { }

  public createPost(reclame: Reclame): Observable<Reclame>{
    console.log(`${environment.apiUrl}/${this.url}/create_publication`);

    let a = this.http.post<Reclame>(`${environment.apiUrl}/${this.url}/create_publication`, reclame, httpOptions);
    console.log(a);
    return a;
  }

}
