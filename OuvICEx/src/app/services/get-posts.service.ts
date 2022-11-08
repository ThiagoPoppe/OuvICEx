import { Injectable } from '@angular/core';
import { Post } from '../models/post';
import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class GetPostsService {

  url = "Publication"
  constructor(private http: HttpClient) { }



  public getPosts(): Observable<Post[]>{
    console.log(`${environment.apiUrl}/${this.url}/get_all_visible_publications`);

    let a = this.http.get<Post[]>(`${environment.apiUrl}/${this.url}/get_all_visible_publications`);
    console.log(a);
    return a;
  }

}
