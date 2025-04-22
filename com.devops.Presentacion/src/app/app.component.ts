import { Component } from '@angular/core';
import { UsuarioService } from './services/usuario.service';
import { NavbarComponent } from './components/navbar/navbar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [NavbarComponent],
  template: '<app-navbar></app-navbar>'
})
export class AppComponent {}
