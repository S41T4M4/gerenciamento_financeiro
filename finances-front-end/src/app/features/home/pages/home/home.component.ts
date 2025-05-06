import { Component } from '@angular/core';
import { ContasService } from '../../../../services/contas.service';
import { CommonModule } from '@angular/common';
import { MenuComponent } from '../../../../components/menu/menu.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  contas: any[] = [];
  isSaldoModalVisible = false;
 
  isPreviewVisible: boolean = false;
  constructor(private contaService: ContasService) {}

  ngOnInit(): void {
    this.contaService.getAllContas().subscribe(
      (data) => {
        this.contas = data;
      }
    );
  }
 
  showSaldoModal() {
    this.isSaldoModalVisible = true;
   
  }

  hideSaldoModal() {
    this.isSaldoModalVisible = false;
  }
}
