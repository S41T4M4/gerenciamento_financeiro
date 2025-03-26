import { Component } from '@angular/core';
import { CotacaoCardComponent } from '../cotacao-card/cotacao-card.component';
import { CotacaoService } from '../../services/cotacao.service';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from "../dashboard/dashboard.component";
import { Despesa } from '../../models/despesa-model';
import { DespesaService } from '../../services/despesa.service';
import { MetasFinanceirasComponent } from "../metas-financeiras/metas-financeiras.component";
import { MinhasContasComponent } from "../minhas-contas/minhas-contas.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CotacaoCardComponent, CommonModule, DashboardComponent, MetasFinanceirasComponent, MinhasContasComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  transactions: any[] = [];
  despesas: Despesa[] = [];
  dolarDecimal: number = 0;
  euroDecimal: number = 0;
  lastFiveDespesas: Despesa[] = [];
  
  constructor(private cotacaoService: CotacaoService, private despesaService: DespesaService) { }

  ngOnInit(){
    this.getCotacaoDolar();
     this.getCotacaoEuro();
     this.getDespesas();
     
    
    }
   
  getDespesas(){
    this.despesaService.getAllDespesas().subscribe(
      (data) => {
        this.despesas = data;
        
      }
    )
  }
  getLasteDespesas(){
    this.despesaService.getAllDespesas().subscribe(
      (data) => {
        this.despesas = data;
        

      }
    )
  }
  getCotacaoDolar(){
    this.cotacaoService.getCotacaoDolar().subscribe(
      (data) => {
        this.dolarDecimal = data.valor;
  
      }
    )
   }
   getCotacaoEuro(){
    this.cotacaoService.getCotacaoEuro().subscribe(
      (data)=>{
        this.euroDecimal = data.valor;
      }
    )
   }
}
