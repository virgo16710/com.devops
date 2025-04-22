import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { Usuario } from '../Models/usuario.model';
import { HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})

export class UsuarioService
{
  constructor(private http: HttpClient) { }
  crearUsuario(usuario: any): Observable<any> {
    return this.http.post('https://localhost:44300/api/usuario/registrar', usuario);
  }

  login(userName: string, password: string): Observable<string> {
    const params = new HttpParams()
      .set('userName', userName)
      .set('password', password);

    return this.http.get<string>(
      'https://localhost:44300/api/usuario/login',
      { params }
    );
  }
    CrearRol(Nombre: string): Observable<any> {
      const token = localStorage.getItem('token');
      const headers = new HttpHeaders()
        .set('Authorization', `Bearer ${token}`)
        .set('Content-Type','application/json');
      const body = { Nombre };
      return this.http.post('https://localhost:44300/api/usuario/CrearRol', body,{headers});
      };
  }


