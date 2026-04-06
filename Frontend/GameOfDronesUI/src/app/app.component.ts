import { Component } from '@angular/core';
import { GameService } from './services/game.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  currentScreen: string = 'START';
  p1: string = '';
  p2: string = '';
  winner: string = '';

  constructor(private gameService: GameService) {}

  goToGame(data: any) {
    this.p1 = data.p1;
    this.p2 = data.p2;
    this.currentScreen = 'PLAYING';
  }

  showWinner(winnerName: string) {
    this.winner = winnerName;
    this.currentScreen = 'WINNER';

    this.gameService.saveWinner(winnerName).subscribe({
      next: () => console.log('¡Victoria registrada en SQL Server!'),
      error: (err) => console.error('Error al conectar con el Backend:', err)
    });
  }
}