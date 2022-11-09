import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';
import { Post } from 'src/app/models/post';

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

  public getUserPosts(): Observable<Post[]>{
    let id = "1";
    console.log(`${environment.apiUrl}/${this.url}/get_all_visible_publications`);

    let a = this.http.get<Post[]>(`${environment.apiUrl}/${this.url}/get_publications_from_user/${id}`);
    console.log(a);
    return a;
  }

}
