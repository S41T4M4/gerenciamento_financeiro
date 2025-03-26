import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-cotacao-card',
  standalone: true,
  templateUrl: './cotacao-card.component.html',
  styleUrl: './cotacao-card.component.css'
})
export class CotacaoCardComponent {
@Input() titulo: string = '';
@Input() valor: number = 0;
@Input() icon: string = '';


}
