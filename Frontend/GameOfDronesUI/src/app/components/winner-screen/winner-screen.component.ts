import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-winner-screen',
  templateUrl: './winner-screen.component.html',
  styleUrls: ['./winner-screen.component.css']
})
export class WinnerScreenComponent {
  @Input() winnerName: string = '';
  @Output() onRestart = new EventEmitter<void>();

  resetGame() {
    this.onRestart.emit();
  }
}