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
    a.authorDepartment = 'DCC';
    a.content = 'Salas Totalmente Defesadas';
    a.context = 'Reclamação';
    a.createdDate = '13/09/2022';
    a.isResolved = false;
    a.isVisible = true;
    a.targetDepartment = 'DCC';

    let b = new Post();
    b.authorDepartment = 'e';
    b.content = 'f';
    b.context = 'g';
    b.createdDate = '2';
    b.isResolved = false;
    b.isVisible = true;
    b.targetDepartment = 'h';

    this.posts = [a,b];
    console.log('oi');


  }

}
