import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../../models/user'

@Component({
  selector: 'app-registre',
  templateUrl: './registre.component.html',
  styleUrls: ['./registre.component.css']
})
export class RegistreComponent implements OnInit {
  registreForm!: FormGroup;
  
  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.createForm(new User()); 
  }

  createForm(user: User){
    this.registreForm = this.formBuilder.group({
      email: [user.email],
      password: [user.password],
      userDepartment: [user.userDepartment],
      admin: [user.admin]
    })
  }

  onSubmit() {
    // aqui você pode implementar a logica para fazer seu formulário salvar
    console.log("Enviou cadastro");

    // Usar o método reset para limpar os controles na tela
    // this.reclameForm.reset(new Reclame());
  }

}
