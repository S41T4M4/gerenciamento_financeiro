import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Receita } from '../models/receita-model';

@Injectable({
  providedIn: 'root'
})
export class ReceitaService {
apiUrl = "https://localhost:7199/api/receitas";
  constructor(private http: HttpClient) { }

  getAllReceitas(){
    return this.http.get<any>(`${this.apiUrl}/get_all_receitas`);
  }
  AddNewReceita(receita: Receita):Observable<any>{
    return this.http.post<any>(`${this.apiUrl}/new_receita`, receita);
  }

}
