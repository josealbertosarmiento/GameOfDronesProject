import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private apiUrl = 'https://localhost:7262/api/game'; 

  constructor(private http: HttpClient) { }

  getMoves(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/moves`);
  }

  saveWinner(name: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/save-winner`, { name });
  }
}