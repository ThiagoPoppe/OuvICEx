import { Injectable } from '@angular/core';
import { Post } from '../models/post';
import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class GetPostsService {

  url = "SearchPosts/get_posts_based_on_selection_filter";
  constructor(private http: HttpClient) { }



  public getPosts(): Observable<Post[]>{
    return this.http.get<Post[]>(`${environment.apiUrl}/${this.url}`);
  }

}
