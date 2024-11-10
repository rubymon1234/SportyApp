import { Injectable } from '@angular/core';
import { environment } from '../env/environment';
import { LoginRequest } from '../Interfaces/login-request';
import { Observable, map } from 'rxjs';
import { AuthResponse } from '../Interfaces/auth-response';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiUrl: string = environment.apiUrl;
  private tokenKey = 'token';
  httpOptions = {
    headers: new HttpHeaders({
      'Access-Control-Allow-Origin':'*',
    })
  };
  constructor(private http: HttpClient) { }

  login(data: LoginRequest): Observable<AuthResponse> {
    return this.http
      .post<AuthResponse>(`${this.apiUrl}Account/login`, data,this.httpOptions)
      .pipe(
        map((response) => {
          if (response.isSuccess) {
            localStorage.setItem(this.tokenKey, response.token);
          }
          return response;
        })
      );
  }
  getUserDetail = () => {
    const token = this.getToken();
    if (!token) return null;
    const decodedToken: any = jwtDecode(token);
    const userDetail = {
      id: decodedToken.nameid,
      fullName: decodedToken.name,
      email: decodedToken.email,
      roles: decodedToken.role || [],
    };

    return userDetail;
  };
  isLoggedIn = (): boolean => {
    const token = this.getToken();
    if (!token) return false;
    return !this.isTokenExpired();
  };
  public isAdminLogin()  {
    var data = this.getUserDetail();

    if(data?.roles =='Admin'){
      return "Admin";
    }else {
      return "User";
    }
  }
  private isTokenExpired() {
    const token = this.getToken();
    if (!token) return true;
    const decoded = jwtDecode(token);
    const isTokenExpired = Date.now() >= decoded['exp']! * 1000;
    if (isTokenExpired) this.logout();
    return isTokenExpired;
  }
  logout = (): void => {
    localStorage.removeItem(this.tokenKey);
  };
  private getToken = (): string | null =>
    localStorage.getItem(this.tokenKey) || '';
}
