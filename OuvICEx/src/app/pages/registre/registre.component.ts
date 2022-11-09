import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/app/services/user/user.service';
import { User } from '../../models/user'
import { DepartmentService } from '../../services/department/department.service';
import { Department } from '../../models/department';


@Component({
  selector: 'app-registre',
  templateUrl: './registre.component.html',
  styleUrls: ['./registre.component.css']
})
export class RegistreComponent implements OnInit {
  registreForm!: FormGroup;
  departments: Department[] = [];
  
  constructor(private userService: UserService, private getDepartmentsService: DepartmentService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.fetchDepartments();
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

  fetchDepartments(){
    this.getDepartmentsService.getDepartaments().subscribe((result: Department[])=>{
      this.departments = [];
      result.forEach(element =>{
        if(element['name'] != '' && element['name'] != null){
          this.departments.push(element);
        }
      })
      console.log(this.departments);
    });
  }

  onSubmit() {
    // aqui você pode implementar a logica para fazer seu formulário salvar

    var newUser = new User();
    newUser.Name = this.registreForm.value.name;
    newUser.Email = this.registreForm.value.email;
    newUser.Password = this.registreForm.value.password;
    newUser.DepartamentId = Number(this.registreForm.value.userDepartament);

    console.log(newUser)
    this.userService.postUser(newUser).subscribe(res => console.log(res));
    
    this.registreForm.reset(new User());
  }
}