import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {Home} from './home/home';
const routes: Routes = [
  {path: '', component: Home},
  {path: 'movies', loadChildren: () => import('./movies/movies-module').then(mod => mod.MoviesModule)},
  {path: 'movies', loadChildren: () => import('./account/account-module').then(mod => mod.AccountModule)},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
