import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { SaldoCardComponent } from '../../components/saldo-card/saldo-card.component';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    HomeRoutingModule,
    SaldoCardComponent
  ]
})
export class HomeModule { }
