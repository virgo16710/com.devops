import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { LoginComponent } from '../login/login.component';
import { RegistroComponent } from '../registro/registro.component';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [CommonModule, LoginComponent, RegistroComponent],
  template: '',
})
export class NavbarComponent {
  mostrarLogin = false;
  mostrarRegistro = false;

  toggleLogin() {
    this.mostrarLogin = !this.mostrarLogin;
    this.mostrarRegistro = false;
  }
  toggleRegistro() {
    this.mostrarRegistro = !this.mostrarRegistro;
    this.mostrarLogin = false;
  }
}
