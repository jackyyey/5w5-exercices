import { Component, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, FormsModule, RouterModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {
  sucrees: boolean = false;
  salee: boolean = false;
  protected readonly title = signal('guards');


  ngOnInit(): void {
    this.getState();
  }
  saveState(){
    localStorage.setItem("sel",JSON.stringify(this.salee));
    localStorage.setItem("sucre",JSON.stringify(this.sucrees));
  }

  getState(){
    try{
      this.sucrees = JSON.parse(localStorage.getItem("sucre")!);
      this.salee = JSON.parse(localStorage.getItem("sel")!);
    }
    catch{
      console.log("no value lol");
    }
  }
}
