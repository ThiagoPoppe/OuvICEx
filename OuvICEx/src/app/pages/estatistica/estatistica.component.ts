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

  FilterForm!: FormGroup;

  createForm(stat: StatsForm){
    this.FilterForm = this.formBuilder.group({
      type: [stat.type],
    })
  }

  ngOnInit(): void {

    this.createForm(new StatsForm());
    this.getPostsService.getPosts().subscribe((result: Post[]) => {this.posts = result;console.log(this.posts)});

    let dpt = this.getDepartmentStats();
    Chart.register(...registerables);
    this.chart = new Chart("chart", {
      type: 'bar', //this denotes tha type of chart

      data: {// values on X-Axis
        labels: ['DCC', 'DQ' ], 
	       datasets: [
          {
            label: "Issues",
            data: ['1', '4'],
            backgroundColor: 'blue'
          },
        ]
      },
      options: {
        aspectRatio:1.5,
        plugins: {
          title: {
              display: true,
              text: 'Departamento Referenciado nas Reclamações Enviadas',
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

  public showDpt(): void {
    this.chart.destroy();
    this.chart = new Chart("chart", {
      type: 'bar', //this denotes tha type of chart

      data: {// values on X-Axis
        labels: ['DCC', 'DQ' ], 
	       datasets: [
          {
            label: "Issues",
            data: ['1', '4'],
            backgroundColor: 'blue'
          },
        ]
      },
      options: {
        aspectRatio:1.5,
        plugins: {
          title: {
              display: true,
              text: 'Departamento Referenciado nas Reclamações Enviadas',
              padding: {
                  bottom: 10
              }
          }
        }
      }
      
    });
  }

  public showContext(): void{
    this.chart.destroy();
    this.chart = new Chart("chart", {
      type: 'bar', //this denotes tha type of chart

      data: {// values on X-Axis
        labels: ['Reclamações', 'Elogios' ], 
	       datasets: [
          {
            label: "Issues",
            data: ['3', '2'],
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
