import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EstatisticaComponent } from './estatistica/estatistica.component';
import { HistoricoComponent } from './historico/historico.component';
import { HomeComponent } from './home/home.component';
import { ReclameComponent } from './reclame/reclame.component';

const routes: Routes = [
  {path: "home", component: HomeComponent},
  {path: "historico", component: HistoricoComponent},
  {path: "estatisticas", component: EstatisticaComponent},
  {path: "reclame", component: ReclameComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
