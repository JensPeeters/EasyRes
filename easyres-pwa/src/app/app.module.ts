import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { RestaurantService } from './services/restaurant.service';
import { ReservatieComponent } from './reservatie/reservatie.component';

@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    RestaurantComponent,
    ReservatieComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production })
  ],
  providers: [RestaurantService],
  bootstrap: [AppComponent]
})
export class AppModule { }
