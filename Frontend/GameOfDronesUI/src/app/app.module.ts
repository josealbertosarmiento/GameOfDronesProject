import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { StartGameComponent } from './components/start-game/start-game.component';
import { GameBoardComponent } from './components/game-board/game-board.component';
import { WinnerScreenComponent } from './components/winner-screen/winner-screen.component';

@NgModule({
  declarations: [
    AppComponent,
    StartGameComponent,
    GameBoardComponent,
    WinnerScreenComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }