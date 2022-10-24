import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HistoricoComponent } from './historico/historico.component';
import { EstatisticaComponent } from './estatistica/estatistica.component';
import { ReclameComponent } from './reclame/reclame.component';
import { HomeComponent } from './home/home.component';
import { RegistreComponent } from './registre/registre.component';


@NgModule({
  declarations: [
    AppComponent,
    HistoricoComponent,
    EstatisticaComponent,
    ReclameComponent,
    HomeComponent,
    RegistreComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
