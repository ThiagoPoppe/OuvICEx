import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Reclame } from '../models/reclame'

@Component({
  selector: 'app-reclame',
  templateUrl: './reclame.component.html',
  styleUrls: ['./reclame.component.css']
})
export class ReclameComponent implements OnInit {
  reclameForm!: FormGroup;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.createForm(new Reclame()); 
  }

  createForm(reclame: Reclame){
    this.reclameForm = this.formBuilder.group({
      content: [reclame.content, [Validators.required]],
      context: [reclame.context],
      authorDepartment: [reclame.authorDepartment],
      targetDepartment: [reclame.targetDepartment],
      identify: [reclame.identify]
    })
  }

  onSubmit() {
    // aqui você pode implementar a logica para fazer seu formulário salvar
    console.log("Enviou comentário");

    // Usar o método reset para limpar os controles na tela
    // this.reclameForm.reset(new Reclame());
  }

}
