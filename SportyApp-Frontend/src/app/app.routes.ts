import { Routes } from '@angular/router';
import { LoginComponent } from '../app/Account/Login/login.component';
import { RegisterComponent } from '../app/Account/Register/register.component';
import { HomeComponent } from '../app/Home/Home/home.component';
import { AdminHomeComponent } from '../app/Admin/home/home.component';
import { AuthGaurd} from '../app/Services/auth.guard';

export const routes: Routes = [

  {
    path: '',
    component: LoginComponent,
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'admin-home',
    component: AdminHomeComponent,canActivate: [AuthGaurd] ,data: { roles: ['admin'] }
  },
  {
    path: 'home',
    component: HomeComponent,canActivate: [AuthGaurd],data: { roles: ['user'] }
  },
  {
    path: 'register',
    component: RegisterComponent
  },
];
