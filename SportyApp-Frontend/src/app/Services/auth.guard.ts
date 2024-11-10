import { Injectable, ErrorHandler } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateFn, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { AuthService } from '../Services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGaurd implements CanActivate {
  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private matSnackBar: MatSnackBar,
    private authService:AuthService
  ) { }
  canActivate(route: ActivatedRouteSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    const allowedRoles = route.data['roles'] as Array<string>;
    if (localStorage.getItem('token')) {
        return true;
    } else {
      this.matSnackBar.open("Permission Denied", 'Close', {
        duration: 5000,
        horizontalPosition: 'center',
      });
      this.router.navigate(['login']);
      return false;
    }

  }
}
