import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddBikeFormComponent } from './add-bike-form/add-bike-form.component';
import { RentedBikesComponent } from './rented-bikes/rented-bikes.component';
import { FreeBikesComponent } from './free-bikes/free-bikes.component';

@NgModule({
  declarations: [
    AppComponent,
    AddBikeFormComponent,
    RentedBikesComponent,
    FreeBikesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
