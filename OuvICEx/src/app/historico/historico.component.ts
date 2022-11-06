import { Component, OnInit } from '@angular/core';
import { Post } from '../models/post';
import { GetPostsService } from '../services/get-posts.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-historico',
  templateUrl: './historico.component.html',
  styleUrls: ['./historico.component.css']
})
export class HistoricoComponent implements OnInit {

  constructor(private getPostsService: GetPostsService, private formBuilder: FormBuilder) { }
  posts: Post[] = [];



  FilterForm!: FormGroup;

  createForm(filter: Post){
    this.FilterForm = this.formBuilder.group({
      content: [filter.content, [Validators.required]],
      context: [filter.context],
      authorDepartment: [filter.authorDepartment],
      targetDepartment: [filter.targetDepartment],
    })
  }


  ngOnInit(): void {
    this.createForm(new Post());
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

  onSubmit() {
    // aqui você pode implementar a logica para fazer seu formulário salvar
    console.log("Filtrou");

    // Usar o método reset para limpar os controles na tela
    // this.reclameForm.reset(new Reclame());
  }

}
