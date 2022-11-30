import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EstatisticaComponent } from './pages/estatistica/estatistica.component';
import { HistoricoComponent } from './pages/historico/historico.component';
import { HomeComponent } from './pages/home/home.component';
import { ReclameComponent } from './pages/reclame/reclame.component';
import { RegistreComponent } from './pages/registre/registre.component';

const routes: Routes = [
  {path: "", component: HomeComponent},
  {path: "historico", component: HistoricoComponent},
  {path: "estatisticas", component: EstatisticaComponent},
  {path: "reclame", component: ReclameComponent},
  {path: "registre", component: RegistreComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
