import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
  })

export class CategoriaService {
    apiUrl = "https://localhost:7199/api/categoria";
    constructor(private http: HttpClient) { }

    getAllCategorias(): Observable<any> {
        return this.http.get<any>(`${this.apiUrl}/get_all_categorias`);
    }
}