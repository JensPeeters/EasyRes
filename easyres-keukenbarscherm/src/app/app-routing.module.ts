import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { KeukenComponent } from './keuken/keuken.component';
import { BarComponent } from './bar/bar.component';


const routes: Routes = [
  {path: 'keuken', component: KeukenComponent},
  {path: 'bar', component: BarComponent},
  {path: '', redirectTo: 'keuken', pathMatch: 'full'},
  {path: '**', redirectTo: 'keuken', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
