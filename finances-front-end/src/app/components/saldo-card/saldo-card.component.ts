import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-saldo-card',
    templateUrl: './saldo-card.component.html',
    styleUrl: './saldo-card.component.css',
    standalone: true
})
export class SaldoCardComponent {
@Input() conta!:{nome_conta:string,saldo:number};
}
