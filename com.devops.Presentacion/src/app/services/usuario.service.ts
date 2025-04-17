import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario } from '../Models/usuario.model';

@Injectable({
  providedIn: 'root'
})

export class UsuarioService
{
  private apiUrl = "https://localhost:7141/Registrar";
  constructor(private http: HttpClient) { }
  crearUsuario(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(this.apiUrl, usuario);
  }

}
