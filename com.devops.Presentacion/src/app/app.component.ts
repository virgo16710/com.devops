import { Component } from '@angular/core';
import { UsuarioService } from './services/usuario.service';
import { Usuario } from './Models/usuario.model';
import { FormsModule } from '@angular/forms'
@Component({
  standalone:true,
  selector: 'app-root',
  imports:[FormsModule],
  templateUrl: './app.component.html',
})
export class AppComponent {
  usuario: Usuario = {
    nombre: '',
    apellido: '',
    userName: '',
    email: '',
    password: ''
  };

  constructor(private usuarioService: UsuarioService) { }

  crearUsuario() {
    this.usuarioService.crearUsuario(this.usuario).subscribe({
      next: res => {
        alert('Usuario creado con éxito');
        console.log(res);
      },
      error: err => {
        alert('Error al crear usuario');
        console.error(err);
      }
    });
  }
}
