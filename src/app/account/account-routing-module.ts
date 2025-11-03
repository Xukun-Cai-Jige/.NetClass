import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Account } from './account';
import { Login } from './login/login';
import { Register } from './register/register';

const routes: Routes = [
  {
    path: '', component: Account,
    children:[
      {path: 'login', component: Login},
      {path: 'register', component: Register}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
