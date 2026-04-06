import { Component, Input, OnInit } from '@angular/core';
import { GameService } from '../../services/game.service';

@Component({
  selector: 'app-game-board',
  templateUrl: './game-board.component.html',
  styleUrls: ['./game-board.component.css']
})
export class GameBoardComponent implements OnInit {
  @Input() player1: string = '';
  @Input() player2: string = '';

  moves: any[] = []; 
  p1Score: number = 0;
  p2Score: number = 0;
  currentTurn: number = 1;
  p1Move: string = '';
  p2Move: string = '';
  winnerName: string = '';
  isSaving: boolean = false;

  constructor(private gameService: GameService) {}

  ngOnInit() {
    this.gameService.getMoves().subscribe({
      next: (data: any) => { this.moves = data; },
      error: () => {
        this.moves = [
          { name: 'Rock', kills: 'Scissors' },
          { name: 'Paper', kills: 'Rock' },
          { name: 'Scissors', kills: 'Paper' }
        ];
      }
    });
  }

  seleccionarMovimiento(movimiento: string) {
    if (this.isSaving) return;

    if (this.currentTurn === 1) {
      this.p1Move = movimiento;
      this.currentTurn = 2;
    } else {
      this.p2Move = movimiento;
      this.compararMovimientos();
    }
  }

  compararMovimientos() {
    if (this.isSaving) return;

    const p1Gana = this.moves.find(m => m.name === this.p1Move && m.kills === this.p2Move);
    const p2Gana = this.moves.find(m => m.name === this.p2Move && m.kills === this.p1Move);

    if (p1Gana) this.p1Score++;
    else if (p2Gana) this.p2Score++;

    if (this.p1Score >= 3 || this.p2Score >= 3) {
      this.isSaving = true;
      this.winnerName = this.p1Score >= 3 ? this.player1 : this.player2;

      this.gameService.saveWinner(this.winnerName).subscribe({
        next: () => {
          console.log('Victoria registrada correctamente');
        },
        error: () => {
          this.isSaving = false;
        }
      });
      return;
    }

    this.currentTurn = 1;
    this.p1Move = '';
    this.p2Move = '';
  }

  reiniciarPartida() {
    window.location.reload();
  }
}