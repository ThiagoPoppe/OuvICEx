import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HistoricoComponent } from './pages/historico/historico.component';
import { EstatisticaComponent } from './pages/estatistica/estatistica.component';
import { ReclameComponent } from './pages/reclame/reclame.component';
import { HomeComponent } from './pages/home/home.component';
import { RegistreComponent } from './pages/registre/registre.component';


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
