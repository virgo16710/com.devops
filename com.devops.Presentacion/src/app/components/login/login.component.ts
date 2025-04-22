import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UsuarioService } from '../../services/usuario.service';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html',
})
export class LoginComponent {
  usuario = { userName: '', password: '' };
  constructor(private usuarioService: UsuarioService) { }
  login() {
    this.usuarioService.login(this.usuario.userName, this.usuario.password)
      .subscribe({
        next: token => {
          localStorage.setItem('token', token);
          alert('Login exitoso');
          location.reload();
        },
        error: error => {
          console.error('Error al iniciar sesión:', error);
          alert('Error al iniciar sesión');
        }
      });
  }
}
