import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Despesa } from '../models/despesa-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
  
})
export class DespesaService {

  constructor(private http: HttpClient) { }

  apiUrl = "https://localhost:7199/api/despesas";

  getAllDespesas(){
    return this.http.get<any>(`${this.apiUrl}/todas_despesas`);
  }

  addNewDespesa(despesa: Despesa): Observable<any>{
    return this.http.post<any>(`${this.apiUrl}/nova_despesa`, despesa);
  }

  getCategoriaMostUsed(): Observable<any>{
    return this.http.get<any>(`${this.apiUrl}/categoria_most_used`);
  }
  getDespesasByMonth():Observable<any>{
    return this.http.get<any>(`${this.apiUrl}/despesas_by_month`);
  }
  
}
