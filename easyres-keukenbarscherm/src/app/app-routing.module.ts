import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MsalGuard } from './guard/msal.guard';

import { KeukenComponent } from './keuken/keuken.component';
import { BarComponent } from './bar/bar.component';
import { StartComponent } from './start/start.component';
import { ControlePaneelComponent } from './controle-paneel/controle-paneel.component';
import { ReservatieLijstComponent } from './reservatie-lijst/reservatie-lijst.component';
import { FacturenComponent } from './facturen/facturen.component';


const routes: Routes = [
  {path: 'start', component: StartComponent},
  {path: 'keuken', component: KeukenComponent, canActivate: [MsalGuard]},
  {path: 'bar', component: BarComponent, canActivate: [MsalGuard]},
  {path: 'dashboard', component: ControlePaneelComponent, canActivate: [MsalGuard]},
  {path: 'facturen', component: FacturenComponent, canActivate: [MsalGuard]},
  {path: 'reservaties', component: ReservatieLijstComponent, canActivate: [MsalGuard]},
  {path: '', redirectTo: 'start', pathMatch: 'full'},
  {path: '**', redirectTo: 'start', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
