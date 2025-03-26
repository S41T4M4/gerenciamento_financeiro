import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent {
  buttonsAppear = false;

  toggleMenu() {
    this.buttonsAppear = !this.buttonsAppear;

  }
  myMenuFunction() {
    console.log('Menu toggled');
  }
}
