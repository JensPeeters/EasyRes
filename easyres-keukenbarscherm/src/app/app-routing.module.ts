import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MsalGuard } from './guard/msal.guard';

import { KeukenComponent } from './keuken/keuken.component';
import { BarComponent } from './bar/bar.component';
import { StartComponent } from './start/start.component';


const routes: Routes = [
  {path: 'start', component: StartComponent},
  {path: 'keuken', component: KeukenComponent, /**canActivate: [MsalGuard]*/},
{path: 'bar', component: BarComponent, /*canActivate: [MsalGuard]*/},
  {path: '', redirectTo: 'start', pathMatch: 'full'},
  {path: '**', redirectTo: 'start', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
