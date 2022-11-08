import { Component, OnInit } from '@angular/core';
import { Post } from '../models/post';
import { Filter } from '../models/filter';
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
  who: string = "Todas as Postagens";



  FilterForm!: FormGroup;

  createForm(filter: Filter){
    this.FilterForm = this.formBuilder.group({
      context: [filter.context],
      authorDepartment: [filter.authorDepartment],
      targetDepartment: [filter.targetDepartment],
      isResolved: [filter.isResolved],
      startDate: [filter.startDate],
      endDate: [filter.endDate]
    })
  }


  ngOnInit(): void {
    this.createForm(new Filter());
    this.getPostsService.getPosts().subscribe((result: Post[]) => {
      this.posts = [];
      for(let post of result){
        if(post.context == '0'){
          post.context = "Sugestão";
        }
        else if(post.context == '1'){
          post.context = "Elogio";
        }
        else if(post.context = '2'){
          post.context = "Reclamação";
        }
        else{
          post.context = "Context Não Informado";
        }

        if(post.status == '0'){
          post.status = "Resolvido";
        }
        else if(post.status == '1'){
          post.status = "Não Resolvido";
        }
        else if(post.status == '2'){
          post.status = "Em Progresso";
        }
        else{
          post.status = "Status Não Informado"
        }
        post.createdAt = new Date(post.createdAt).toLocaleString()
        this.posts.push(post);
      }
      console.log(this.posts)
    });
    console.log(this.posts);


    let d = new Post();
    d.title = 'k';
    d.authorDepartamentName = 'e';
    d.text = 'f';
    d.context = 'g';
    d.createdAt = '2';
    d.status = "Resolvido";
    d.isVisible = true;
    d.targetDepartamentName = 'h';



    this.posts = [d];
    console.log('oi');


  }

  onSubmit() {
    // aqui você pode implementar a logica para fazer seu formulário salvar
    console.log("Filtrou");
    console.log(this.FilterForm.controls);

    // Usar o método reset para limpar os controles na tela
    // this.reclameForm.reset(new Reclame());
  }

  public toggle(){
    if(this.who == "Todas as Postagens"){
      this.who = "Minhas Postagens";
    }
    else{
      this.who = "Todas as Postagens";
    }

  }

}
