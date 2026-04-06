import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-start-game',
  templateUrl: './start-game.component.html',
  styleUrls: ['./start-game.component.css']
})
export class StartGameComponent {
  player1Name: string = '';
  player2Name: string = '';

  @Output() onStart = new EventEmitter<any>();

  iniciarBatalla() {
    if (this.player1Name && this.player2Name) {
  
      this.onStart.emit({ p1: this.player1Name, p2: this.player2Name });
    } else {
      alert('¡Guerreros, identifíquense!');
    }
  }
}