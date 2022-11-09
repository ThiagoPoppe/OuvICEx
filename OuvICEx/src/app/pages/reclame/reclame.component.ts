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
      authorDepartamentId: [reclame.authorDepartamentId],
      targetDepartamentId: [reclame.targetDepartamentId],
      userId: [reclame.userId]
    })
  }

  onSubmit() {
    var newReclame = new Reclame()
    newReclame.title = this.reclameForm.value.title
    newReclame.text = this.reclameForm.value.text;
    newReclame.context = Number(this.reclameForm.value.context);
    newReclame.authorDepartamentId = Number(this.reclameForm.value.authorDepartamentId);
    newReclame.targetDepartamentId = Number(this.reclameForm.value.targetDepartamentId);
    newReclame.permissionToPublicate = this.reclameForm.value.permissionToPublicate;
    newReclame.userId = Number(this.reclameForm.value.userId);

    console.log(newReclame)
    this.createPostService.createPost(newReclame).subscribe(res => console.log(res));

    alert('Postagem realizada com sucesso.');

    // Usar o método reset para limpar os controles na tela
    this.reclameForm.reset(new Reclame());
  }
}
