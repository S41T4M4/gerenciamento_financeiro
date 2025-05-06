import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Conta } from '../models/contas-model';

@Injectable({
  providedIn: 'root'
})
export class ContasService {
 apiUrl = "https://localhost:7199/api/contas";

  constructor(private http: HttpClient) { }

  getAllContas(): Observable<Conta[]> {
    return this.http.get<Conta[]>(`${this.apiUrl}/todas_contas`);
  }
  getContaById(id: number): Observable<Conta> {
    return this.http.get<Conta>(`${this.apiUrl}/get_conta_by_id/${id}`);
  }
  updateSaldo(id: number, conta: Conta): Observable<Conta> {
    return this.http.put<Conta>(`${this.apiUrl}/update_saldo/${id}`, conta);
  }


}
