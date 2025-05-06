import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MetasFinanceiras } from '../../models/metas-financeiras-model';
import { MetasService } from '../../services/metas.service';
import { ContasService } from '../../services/contas.service';
import { Conta } from '../../models/contas-model';
import { MenuComponent } from "../menu/menu.component";

@Component({
  selector: 'app-metas-financeiras',
  standalone: true,
  imports: [CommonModule, FormsModule, MenuComponent],
  templateUrl: './metas-financeiras.component.html',
  styleUrl: './metas-financeiras.component.css'
})
export class MetasFinanceirasComponent {
  showAddMetaModal: boolean = false;
  contas: Conta[] = [];
  metas: MetasFinanceiras[] = [];
  modalAberto: boolean = false;

  
  tempMeta: MetasFinanceiras = {
      id_meta: 0,
      descricao: "",
      valor_meta: 0,
      valor_atual: 0,
      prazo: new Date()
  }
  toggleAddMetaModal() {
    
    this.showAddMetaModal = !this.showAddMetaModal;
  }

  constructor(private metasService: MetasService, private contasService: ContasService){}
  
  saldo: number = 0;
  priority: string = "";
    
  ngOnInit(){
      this.getAllMetas();
      this.getAllContas();
  }
  
  getAllMetas(){
      this.metasService.getAllMetas().subscribe((data) => {
          this.metas = data;
      });
  }
  
  getAllContas() {
      this.contasService.getAllContas().subscribe((data) => {
          this.contas = data;
          this.saldo = this.contas.reduce((acc, conta) => acc + conta.saldo, 0); 
      });
  }
  

  
  removeMeta(id_meta: number):void {

      this.metasService.removeMeta(id_meta).subscribe(() => {
          this.metas = this.metas.filter(m => m.id_meta !== id_meta);
      });
  }
  
  addNewMeta():void{
     
      if (this.tempMeta.valor_meta <= 0) {
      
  
          alert("Preencha todos os campos corretamente!");
          return;
      }
      debugger
  
      this.metasService.addNewMeta(this.tempMeta).subscribe(() => {
          console.log(this.tempMeta);
          this.getAllMetas();
          this.closeModal();
          this.tempMeta = { id_meta: 0, descricao: "", valor_meta: 0, valor_atual: 0, prazo: new Date() };
      });
  }
  
  openModal(): void {
      this.modalAberto = true;
  }
  
  closeModal(): void {
      this.modalAberto = false;
  }
  }
  