import { Routes } from '@angular/router';
import { MinhasContasComponent } from './components/minhas-contas/minhas-contas.component';
import { MetasFinanceirasComponent } from './components/metas-financeiras/metas-financeiras.component';



export const routes: Routes = [
    {path: '', loadChildren: () => import('./features/home/home.module').then(m => m.HomeModule) },
    {path: 'minhas-contas', component: MinhasContasComponent},
    {path: 'metas-financeiras', component: MetasFinanceirasComponent},

   
];
