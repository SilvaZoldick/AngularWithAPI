import { Observable, tap } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { LoginResponse } from '../models/LoginResponse';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  apiSource = 'http:localhost:5021/api/v1/auth';

  constructor(private http: HttpClient){}

  login(email: string, password: string): Observable<LoginResponse>{
    return this.http.post<LoginResponse>(`${this.apiSource}/login`, { email, password})
      .pipe(
        tap({
          next: p => this.setToken(p.token)
        }
      )
    );
  }
  isLoggedIn(){
    return localStorage.getItem('token') != null;
  }
  logout(){
    localStorage.removeItem('token');
  }
  private setToken(token: string){
    localStorage.setItem('token', token);
  }
}
