import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { RestaurantComponent } from './restaurant/restaurant.component';
import { RestaurantService } from './services/restaurant.service';
import { RestaurantInfoComponent } from './restaurant-info/restaurant-info.component';

@NgModule({
  declarations: [
    AppComponent,
    ToolbarComponent,
    RestaurantComponent,
    RestaurantInfoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production })
  ],
  providers: [RestaurantService],
  bootstrap: [AppComponent]
})
export class AppModule { }
