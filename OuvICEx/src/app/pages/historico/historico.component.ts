import { Component, OnInit } from '@angular/core';
import { Post } from '../../models/post';
import { Filter } from '../../models/filter';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GetPostsService } from 'src/app/services/posts/get-posts.service';
import { DepartmentService } from 'src/app/services/department/department.service';
import { Department } from 'src/app/models/department';

@Component({
  selector: 'app-historico',
  templateUrl: './historico.component.html',
  styleUrls: ['./historico.component.css']
})
export class HistoricoComponent implements OnInit {

  constructor(private getPostsService: GetPostsService, private getDepartmentsService: DepartmentService, private formBuilder: FormBuilder) { }
  posts: Post[] = [];
  who: string = "Todas as Postagens";
  warningText: String = ""
  filter: Filter = new Filter;
  departments = ['']



  FilterForm!: FormGroup;

  createForm(filter: Filter){
    this.FilterForm = this.formBuilder.group({
      context: [filter.context],
      authorDepartamentName: [filter.authorDepartamentName],
      targetDepartamentName: [filter.targetDepartamentName],
      status: [filter.status],
      startDate: [filter.startDate],
      endDate: [filter.endDate]
    })
  }

  fetchDepartments(){
    this.getDepartmentsService.getDepartaments().subscribe((result: Department[])=>{
      this.departments = [];
      result.forEach(element =>{
        if(element['name'] != '' && element['name'] != null){
          this.departments.push(element['name']);
        }
        
      })
      console.log(this.departments);
    });
  }

  filterPost(post: Post): boolean{
    console.log('filtrando');
    console.log(post);
    console.log(this.filter);
    if(this.filter.authorDepartamentName != "" && this.filter.authorDepartamentName != null){
      if(post.authorDepartamentName != this.filter.authorDepartamentName){
        return false;
      }
    }

    if(this.filter.targetDepartamentName != "" && this.filter.targetDepartamentName != null){
      if(post.targetDepartamentName != this.filter.targetDepartamentName){
        return false;
      }
    }

    if(this.filter.context != "" && this.filter.context != null){
      if(post.context != this.filter.context){
        return false;
      }
    }

    if(this.filter.status != "" && this.filter.status != null ){
      if(post.status != this.filter.status){
        return false;
      }
    }
    return true;
  }

  processPosts(result: Post[]){
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
        if(post.title == ""){
          post.title = post.context;
        }
        post.createdAt = new Date(post.createdAt).toLocaleString()
        if(this.filterPost(post)){
          this.posts.push(post);
        }
      }
      if(this.posts.length == 0){
        this.warningText = "Nenhuma publicação foi encontrada.";
      }
      else{
        this.warningText = "";
      }
  }


  ngOnInit(): void {
    this.fetchDepartments();
    this.createForm(new Filter());
    this.toggle();
    

    /*let d = new Post();
    d.title = 'k';
    d.authorDepartamentName = 'e';
    d.text = 'f';
    d.context = 'g';
    d.createdAt = '2';
    d.status = "Resolvido";
    d.isVisible = true;
    d.targetDepartamentName = 'h';

    let a = new Post();
    a.title = 'kf';
    a.authorDepartamentName = 'ed';
    a.text = 'ff';
    a.context = 'g';
    a.createdAt = '2';
    a.status = "Resolvido";
    a.isVisible = true;
    a.targetDepartamentName = 'h';

    let b = new Post();
    b.title = 'kfd';
    b.authorDepartamentName = 'esd';
    b.text = 'fff';
    b.context = 'g';
    b.createdAt = '2';
    b.status = "Resolvido";
    b.isVisible = true;
    b.targetDepartamentName = 'h';



    this.posts = [d, a, b];*/
    if(this.posts.length == 0){
      this.warningText = "Nenhuma publicação foi encontrada.";
    }
    else{
      this.warningText = "";
    }
    console.log('oi');


  }

  onSubmit() {
    // aqui você pode implementar a logica para fazer seu formulário salvar
    console.log("Filtrou");
    console.log(this.FilterForm.controls);
    this.filter = new Filter();
    this.filter.authorDepartamentName = this.FilterForm.controls['authorDepartamentName'].value
    this.filter.targetDepartamentName = this.FilterForm.controls['targetDepartamentName'].value
    this.filter.context = this.FilterForm.controls['context'].value
    this.filter.status = this.FilterForm.controls['status'].value
    console.log(this.filter);
    if(this.who == "Todas as Postagens"){
      this.getPostsService.getPosts().subscribe((result: Post[]) => {
        this.processPosts(result);
      });
      console.log(this.posts);
  
    }
    else{
      this.getPostsService.getUserPosts().subscribe((result: Post[]) => {
        this.processPosts(result);
      });
      console.log(this.posts);
  
    }

    // Usar o método reset para limpar os controles na tela
    // this.reclameForm.reset(new Reclame());
  }

  public toggle(){
    if(this.who == "Todas as Postagens"){
      this.who = "Minhas Postagens";
      this.getPostsService.getUserPosts().subscribe((result: Post[]) => {
        this.processPosts(result);
      });
      console.log(this.posts);
  
    }
    else{
      this.who = "Todas as Postagens";
      this.getPostsService.getPosts().subscribe((result: Post[]) => {
        this.processPosts(result);
      });
      console.log(this.posts);
  
    }

  }

}
