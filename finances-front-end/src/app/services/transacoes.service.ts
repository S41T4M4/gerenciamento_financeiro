import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class TransacoesService {
apiUrl = 'https://localhost:7199/api/transacoes'
  constructor(private http: HttpClient) { }
  

  getTransacoesRecorrentes():Observable<any>{
    return this.http.get<any>(`${this.apiUrl}/get_transacoes_recorrentes`)
  }
}
