import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'app-saldo-card',
    templateUrl: './saldo-card.component.html',
    styleUrl: './saldo-card.component.css',
    standalone: true,
    imports: [CommonModule, FormsModule]
})
export class SaldoCardComponent {
@Input() conta!:{nome_conta:string,saldo:number};
}
