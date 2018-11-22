import { Routes, RouterModule } from '@angular/router';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import {MainComponent} from './main/main.component'
import {AuthGuardGuard} from './auth-guard.guard'
import {IntivatationListComponent} from './intivatation-list/intivatation-list.component'
import { InviteUserComponent } from './invite-user/invite-user.component';
import { SentListComponent } from './sent-list/sent-list.component';
const appRoutes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: '', component: MainComponent },
  { path: 'Login', component: LoginComponent },
  { path: 'Intivatations', component: IntivatationListComponent,canActivate:[AuthGuardGuard] },
  {path:'Invite',component:InviteUserComponent,canActivate:[AuthGuardGuard]},
  {path: 'SentList',component:SentListComponent,canActivate:[AuthGuardGuard]},
  { path: '**', redirectTo: '' }
];

export const routing = RouterModule.forRoot(appRoutes);
