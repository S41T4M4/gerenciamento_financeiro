import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class CotacaoService {

  constructor(private http : HttpClient) { }

  url = "https://localhost:7199/api/cotacao";

  getCotacaoDolar():Observable<any>{
    return this.http.get<any>(`${this.url}/cotacao_dolar`);
  }

  getCotacaoEuro(): Observable<any> {
    return this.http.get<any>(`${this.url}/cotacao_euro`);
  }
}
