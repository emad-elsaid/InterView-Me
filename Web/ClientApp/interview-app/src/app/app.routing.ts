import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { AuthGuardGuard } from './auth-guard.guard';
import { ScheduleComponent } from './schedule/schedule.component';
const appRoutes: Routes = [
  { path: '', component: ScheduleComponent, canActivate: [AuthGuardGuard] },
  { path: 'register', component: RegisterComponent },
  { path: 'Login', component: LoginComponent },
  // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
