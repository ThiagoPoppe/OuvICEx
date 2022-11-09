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
      name: [user.Name],
      email: [user.Email],
      password: [user.Password],
      userDepartament: [user.DepartamentId],
    })
  }

  onSubmit() {
    // aqui você pode implementar a logica para fazer seu formulário salvar

    console.log("Enviou cadastro");
    var newUser = new User();
    newUser.Name = this.registreForm.value.name;
    newUser.Email = this.registreForm.value.email;
    newUser.Password = this.registreForm.value.password;
    newUser.DepartamentId = this.registreForm.value.userDepartament;
    this.userService.postUser(newUser).subscribe(res => console.log(res));
    
    this.registreForm.reset(new User());
  }

}
