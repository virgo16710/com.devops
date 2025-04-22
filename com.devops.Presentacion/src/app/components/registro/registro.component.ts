import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { UsuarioService } from '../../services/usuario.service';

@Component({
  selector: 'app-registro',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './registro.component.html',
})
export class RegistroComponent {
  usuario = {
    nombre: '',
    apellido: '',
    userName: '',
    password: '',
    email: '',
    comunaId: '',//opcional
  }
  constructor(private usuarioService: UsuarioService) { }
  registrar() {
    this.usuarioService.crearUsuario(this.usuario)
      .subscribe({
        next: () => {
          alert('Usuario registrado exitosamente');
          location.reload();
        },
        error: error => {
          console.error('Error al registrar el usuario:', error);
          alert('Error al registrar el usuario');
        }
      });
  }
}
