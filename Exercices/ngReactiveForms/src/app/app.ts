import { Component, OnInit, signal } from '@angular/core';
import { MatFormField, MatFormFieldModule } from '@angular/material/form-field';
import { MatInput, MatInputModule } from '@angular/material/input';
import { RouterOutlet } from '@angular/router';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  Validators,
} from "@angular/forms";
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-root',
  imports: [MatInputModule, MatFormFieldModule, ReactiveFormsModule, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  protected readonly title = signal('ngReactiveForms');

  form: FormGroup;
  formData?: Data;
  
  ngOnInit(): void {
    this.form.valueChanges.subscribe((v)=>{
      this.formData = v;
    })
  }
   
  constructor(private fb: FormBuilder){
    this.form = this.fb.group({
    animalfavoris: ["",Validators.required, this.chatValidator],
    chatinfo: ["",Validators.required, this.q2Validator]
  });
  }

  chatValidator(control: AbstractControl): ValidationErrors | null {
  // On récupère la valeur du champ texte
  const chat = control.value;
  // On regarde si le champ est rempli avant de faire la validation
  if (!chat) {
    return null;
  }
  // On fait notre validation
  const isValid = chat.includes('chat');
  return isValid ? null : { chatValidator: true };
}
q2Validator(control: AbstractControl): ValidationErrors | null {
  // On récupère la valeur du champ texte
  const ouinon = control.value;
  // On regarde si le champ est rempli avant de faire la validation
  if (!ouinon) {
    return null;
  }
  // On fait notre validation
  const isValid = ouinon.includes("oui");
  return isValid ? null : { chatValidator: true };
}
}

interface Data{
  animalpreferer?: string | null;
  q2?: string | null;
}
