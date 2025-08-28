import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { lastValueFrom } from 'rxjs';
const DOMAIN = "http://localhost:5091/";
@Component({
  selector: 'app-root',
  imports: [RouterOutlet,FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  resultat = "";
  username = "";
  token = "";
  dataName = "";
  protected readonly title = signal('ngMVCEtWebAPI');
  constructor(public httpclient: HttpClient){
  };
  

  async TestPublic(){
    let x = await lastValueFrom(this.httpclient.get<any>(DOMAIN+"api/Account/PublicTest"));
    this.resultat = x;
  }

  async TestPrivate(){
    try{
      let x = await lastValueFrom(this.httpclient.get<any>(DOMAIN+"api/Account/PrivateTest"));
      this.resultat = x;
    }
    catch(exception: any){
      this.resultat = exception.message;
    }
    
  }

  async Enregistrer(){
    try{
      await lastValueFrom(this.httpclient.post<any>(DOMAIN+"api/Account/Register",{username: this.username, email: "salut", password: "Salut0!", passwordConfirm: "Salut0!"}));
      this.resultat = "Compte enregistré";
    }
    catch{
      this.resultat = "Something went wrong";
    }

  }

  async Login(){
    try{
     let x = await lastValueFrom(this.httpclient.post<any>(DOMAIN+"api/Account/Login",{username: this.username, password: "Salut0!"}));
     this.resultat = "Connecté"
     this.token = x.token;
     sessionStorage.setItem("token", this.token);
    }
    catch{
      this.resultat = "loguin failled";
    }
  }

  async addData(){
    try{
      await lastValueFrom(this.httpclient.post<any>(DOMAIN+"api/TestDatas/CreateData", {Name: this.dataName}));
      this.resultat = "Data ajouté"
    }
    catch{
      this.resultat = "erreur dans l'Ajout d'un data";
    }
  }
  Logout(){
    sessionStorage.removeItem("token");
    this.token = "";
  }
}
