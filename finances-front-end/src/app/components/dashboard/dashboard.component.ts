import { Component } from '@angular/core';
import { Chart, CategoryScale, LinearScale, BarElement, Title, Tooltip, Legend, BarController } from 'chart.js'; 
import { DespesaService } from '../../services/despesa.service';
import { DespesaPorMes } from '../../models/despesas-por-mes-model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SaldoCardComponent } from '../saldo-card/saldo-card.component';
import { CotacaoCardComponent } from '../cotacao-card/cotacao-card.component';
import { CotacaoService } from '../../services/cotacao.service';
import { Conta } from '../../models/contas-model';
import { ContasService } from '../../services/contas.service';


Chart.register(CategoryScale, LinearScale, BarElement, BarController, Title, Tooltip, Legend);

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
  despesasPorMes: DespesaPorMes[] = [];
  chart: any;
  dolarDecimal: number = 0;
  euroDecimal: number = 0;
  contas: Conta[] = [];

  constructor(private despesaService: DespesaService, private cotacaoService: CotacaoService, private contaService: ContasService) { }

  ngOnInit() {
    this.despesaService.getDespesasByMonth().subscribe((data) => {
      this.despesasPorMes = data; 
      this.createChart();
    });

    this.getAllContas();
  }



  
   getAllContas() {
    this.contaService.getAllContas().subscribe((data) => {
      this.contas = data;
    });
  }


  getMonthNumber(mes: string): number {
    const months = [
      'janeiro', 'fevereiro', 'março', 'abril', 'maio', 'junho',
      'julho', 'agosto', 'setembro', 'outubro', 'novembro', 'dezembro'
    ];
    const monthIndex = months.findIndex((month) => mes.toLowerCase().includes(month));
    return monthIndex === -1 ? -1 : monthIndex + 1; 
  }

  createChart() {
    const currentMonth = new Date().getMonth(); 
    const lastMonth = currentMonth === 0 ? 11 : currentMonth - 1; 

    
    const currentMonthData = this.despesasPorMes.find(despesa => this.getMonthNumber(despesa.mes) === currentMonth + 1);
    const lastMonthData = this.despesasPorMes.find(despesa => this.getMonthNumber(despesa.mes) === lastMonth + 1);

    const currentMonthDespesas = currentMonthData ? currentMonthData.totalGasto : 0;
    const lastMonthDespesas = lastMonthData ? lastMonthData.totalGasto : 0;

    this.chart = new Chart('despesasChart', {
      type: 'bar',
    
      data: {
        labels: ['Mês Atual', 'Mês Anterior'],
        
        datasets: [
          {
            label: 'Despesas',
            data: [currentMonthDespesas, lastMonthDespesas],
            backgroundColor: ['#42a5f5', '#66bb6a'],
            borderColor: ['black', 'black'],
            borderWidth: 1,
            borderRadius: 5,
          },
        ],
      },
      options: {
        responsive: true,
        scales: {
          y: {
            beginAtZero: true,
            ticks: {
              stepSize: 100,
              color: 'white'
            },
            grid: {
              color: 'white'
            }
          },
          x: {
            ticks: {
              color: 'white'
            },
            grid: {
              color: 'white'
            }
          }
        },
        plugins: {
          legend: {
            labels: {
              color: 'white' 
            }
          }
        }
      },
    });
    
  }
}
