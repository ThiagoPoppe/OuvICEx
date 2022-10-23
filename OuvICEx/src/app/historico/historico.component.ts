import { Component, OnInit } from '@angular/core';
import { Post } from '../models/post';
import { GetPostsService } from '../services/get-posts.service';

@Component({
  selector: 'app-historico',
  templateUrl: './historico.component.html',
  styleUrls: ['./historico.component.css']
})
export class HistoricoComponent implements OnInit {

  constructor(private getPostsService: GetPostsService) { }
  posts: Post[] = [];

  ngOnInit(): void {
    this.getPostsService.getPosts().subscribe((result: Post[]) => {this.posts = result;console.log(this.posts)});
    console.log(this.posts);

    let a = new Post();
    a.authorDepartment = 'a';
    a.content = 'b';
    a.context = 'c';
    a.createdDate = '1';
    a.isResolved = false;
    a.isVisible = true;
    a.targetDepartment = 'd';

    this.posts = [a];


  }

}
