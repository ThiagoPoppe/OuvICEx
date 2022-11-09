import { Component, OnInit } from '@angular/core';
import { Post } from '../../models/post';
import { StatsForm } from '../../models/statsForm';
import { GetPostsService } from '../../services/posts/get-posts.service';
import {Chart} from 'chart.js';
import { registerables } from 'chart.js'
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-estatistica',
  templateUrl: './estatistica.component.html',
  styleUrls: ['./estatistica.component.css']
})
export class EstatisticaComponent implements OnInit {



  constructor(private getPostsService: GetPostsService, private formBuilder: FormBuilder) { }
  posts: Post[] = [];
  public chart: any;
  private type = 0
  data = [''];

  FilterForm!: FormGroup;

  createForm(stat: StatsForm){
    this.FilterForm = this.formBuilder.group({
      type: [stat.type],
    })
  }

  ngOnInit(): void {

    this.createForm(new StatsForm());
    this.getPostsService.getPosts().subscribe((result: Post[]) => {this.posts = result;});

    Chart.register(...registerables);
    this.data=['1', '1', '1']
    
    this.chart = new Chart("chart", {
      type: 'bar', //this denotes tha type of chart

      data: {// values on X-Axis
        labels: ['Eu', 'Sou um', 'Gráfico' ], 
	       datasets: [
          {
            label: "Issues",
            data: this.data,
            backgroundColor: 'blue'
          },
        ]
      },
      options: {
        aspectRatio:1.5,
        plugins: {
          title: {
              display: true,
              text: 'Escolha o seu Gráfico',
              padding: {
                  bottom: 10
              }
          }
        }
      }
      
    });
  }

  private getDepartmentStats(): number[] {
    return [1, 4];
  }

  public onSubmit(){
    console.log(this.FilterForm.controls["type"]);
    this.type = this.FilterForm.controls["type"]["value"];
  }

  private getStatusData(posts: Post[]): string[]{
    let data = [0,0,0]
    for(let post of posts){
      data[Number(post.status)] += 1;
    }
    let array = data.map(num => {
      return num.toString();
    });
    return array;
  }

  public showStatus(): void {
    this.chart.destroy();
    this.data = this.getStatusData(this.posts);
    this.chart = new Chart("chart", {
      type: 'bar', //this denotes tha type of chart

      data: {// values on X-Axis
        labels: ['Resolvido', 'Não Resolvido', 'Pendente' ], 
	       datasets: [
          {
            label: "Issues",
            data: this.data,
            backgroundColor: 'blue'
          },
        ]
      },
      options: {
        aspectRatio:1.5,
        plugins: {
          title: {
              display: true,
              text: 'Situação Atual das Reclamações Enviadas',
              padding: {
                  bottom: 10
              }
          }
        }
      }
      
    });
  }

  private getContextData(posts: Post[]): string[]{
    let data = [0,0,0]
    for(let post of posts){
      data[Number(post.context)] += 1;
    }
    let array = data.map(num => {
      return num.toString();
    });
    return array;
  }

  public showContext(): void{
    this.chart.destroy();
    this.data = this.getContextData(this.posts);
    this.chart = new Chart("chart", {
      type: 'bar', //this denotes tha type of chart

      data: {// values on X-Axis
        labels: ['Sugestões', 'Elogios', 'Reclamções' ], 
	       datasets: [
          {
            label: "Issues",
            data: this.data,
            backgroundColor: 'green'
          },
        ]
      },
      options: {
        aspectRatio:1.5,
        plugins: {
          title: {
              display: true,
              text: 'Contexto das Reclamações Enviadas',
              padding: {
                  bottom: 10
              }
          }
        }
      }
      
    });
  }

}
