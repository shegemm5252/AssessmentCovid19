import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';


const routes: Routes =[
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full',
  }, {
    path: '',
    component: HomeComponent,

  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    useHash: false
 })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
