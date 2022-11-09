import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/app/services/user/user.service';
import { User } from '../../models/user'

@Component({
  selector: 'app-registre',
  templateUrl: './registre.component.html',
  styleUrls: ['./registre.component.css']
})
export class RegistreComponent implements OnInit {
  registreForm!: FormGroup;
  
  constructor(private userService: UserService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.createForm(new User()); 
  }

  createForm(user: User){
    this.registreForm = this.formBuilder.group({
      email: [user.Email],
      password: [user.Password],
      userDepartament: [user.DepartamentId],
    })
  }

  onSubmit() {
    // aqui você pode implementar a logica para fazer seu formulário salvar

    console.log("Enviou cadastro");
    var user = new User();
    user.Name = 'Giovanna Louzi'
    user.Email = 'giovannalouzi@gmail.com';
    user.Password = 'Senh@1';
    user.DepartamentId = 1;
    this.userService.postUser(user).subscribe(res => console.log(res));
    // Usar o método reset para limpar os controles na tela
    // this.reclameForm.reset(new Reclame());
  }

}
