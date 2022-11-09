import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Reclame } from '../../models/reclame'
import { CreatePostService } from '../../services/posts/create-post.service';

@Component({
  selector: 'app-reclame',
  templateUrl: './reclame.component.html',
  styleUrls: ['./reclame.component.css']
})
export class ReclameComponent implements OnInit {
  reclameForm!: FormGroup;

  constructor(private createPostService: CreatePostService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.createForm(new Reclame());
  }

  createForm(reclame: Reclame){
    this.reclameForm = this.formBuilder.group({
      title: [reclame.title, [Validators.required]],
      text: [reclame.text, [Validators.required]],
      context: [reclame.context],
      permissionToPublicate: [reclame.permissionToPublicate],
      authorDepartmentId: [reclame.authorDepartmentId],
      targetDepartmentId: [reclame.targetDepartmentId],
      userId: [reclame.userId]
    })
  }

  onSubmit() {
    // aqui você pode implementar a logica para fazer seu formulário salvar
    // console.log("Enviou comentário");
    // console.log(this.reclameForm.value)

    var newReclame = new Reclame()
    newReclame.title = this.reclameForm.value.title
    newReclame.text = this.reclameForm.value.text;
    newReclame.context = Number(this.reclameForm.value.context);
    newReclame.authorDepartmentId = Number(this.reclameForm.value.authorDepartmentId);
    newReclame.targetDepartmentId = Number(this.reclameForm.value.targetDepartmentId);
    newReclame.permissionToPublicate = this.reclameForm.value.permissionToPublicate;
    newReclame.userId = Number(this.reclameForm.value.userId);

    console.log(newReclame)
    this.createPostService.createPost(newReclame).subscribe(res => console.log(res));

    // Usar o método reset para limpar os controles na tela
    // this.reclameForm.reset(new Reclame());
  }

}
