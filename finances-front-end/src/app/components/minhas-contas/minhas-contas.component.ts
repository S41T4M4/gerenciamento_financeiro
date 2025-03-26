import { Component } from '@angular/core';
import { Conta } from '../../models/contas-model';
import { Categoria } from '../../models/categoria-model';
import { Receita } from '../../models/receita-model';
import { ContasService } from '../../services/contas.service';
import { ReceitaService } from '../../services/receita.service';
import { DespesaService } from '../../services/despesa.service';
import { CategoriaService } from '../../services/categoria.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SaldoCardComponent } from '../saldo-card/saldo-card.component';


@Component({
  selector: 'app-minhas-contas',
  standalone: true,
  imports: [FormsModule, CommonModule, SaldoCardComponent],
  templateUrl: './minhas-contas.component.html',
  styleUrl: './minhas-contas.component.css'
})
export class MinhasContasComponent {
  contas: Conta[] = [];
  categorias: Categoria[] = [];
  receitas: Receita[] = [];
  showForm: boolean = false; 
  novaReceita: Receita = {
    id_receita: 0,
    id_conta: 0,
    valor: 0,
    descricao: '',
    recorrente: false
  };
  showButtonReceita: boolean = true;
  showFormDespesa: boolean = false;
  novaDespesa: any = {
    id_despesa: 0,
    id_conta: 0,
    id_categoria: 0,
    data_despesa: new Date(),
    valor: 0,
    descricao: '',
    recorrente: false
  }
 

  constructor(private contasService: ContasService, private receitaService: ReceitaService, private despesaService: DespesaService, private categoriaService: CategoriaService) { }

  ngOnInit() {
    this.getAllContas();
    this.getAllCategorias();
  }

  getAllContas() {
    this.contasService.getAllContas().subscribe((data) => {
      this.contas = data;
    });
  }
  getAllCategorias() {
    this.categoriaService.getAllCategorias().subscribe((data) => {
      this.categorias = data;
    });
  }

  toggleForm() {
    this.showForm = !this.showForm;
    
  }
  toggleFormDespesa() {
    this.showFormDespesa = !this.showFormDespesa;
    this.showButtonReceita = false;
    
  }

  addNewReceita(): void {
    console.log("Enviando:", this.novaReceita);
    
    if (!this.novaReceita.valor || !this.novaReceita.descricao || !this.novaReceita.id_conta) {
      window.alert('Preencha todos os campos!');
      return;
    }
  
    this.receitaService.AddNewReceita(this.novaReceita).subscribe(
      () => {
        console.log('id_conta: ', this.novaReceita.id_conta); 
        console.log('Receita adicionada com sucesso!');
        this.getAllContas();
        this.showForm = false;
        this.novaReceita = { id_receita: 0, id_conta: 0, valor: 0, descricao: '', recorrente: false };
      },
      (error) => {
        console.error("Erro ao adicionar receita:", error);
        window.alert('Erro ao adicionar receita');
      }
    );
  }
  addNewDespesa(): void {
    console.log("Enviando:", this.novaDespesa);

    if (!this.novaDespesa.valor || !this.novaDespesa.descricao || !this.novaDespesa.id_conta || !this.novaDespesa.id_categoria) {
      window.alert('Preencha todos os campos!');
      return;
    }

    this.despesaService.addNewDespesa(this.novaDespesa).subscribe(
      () => {
        
        console.log('Receita adicionada com sucesso!');
        this.getAllContas();
        this.showForm = false;
        this.novaDespesa = { id_despesa: 0, id_conta: 0, valor: 0, descricao: '',id_categoria:0,data_despesa:new Date(), recorrente: false };
      },
      (error) => {
        console.error("Erro ao adicionar receita:", error);
        window.alert('Erro ao adicionar receita');
      }
    );
  }
  
}
