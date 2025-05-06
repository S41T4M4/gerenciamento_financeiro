import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MetasFinanceiras } from '../models/metas-financeiras-model';



@Injectable({
  providedIn: 'root'
})
export class MetasService {
 apiUrl = "https://localhost:7199/api/metas_financeiras";



  constructor(private http: HttpClient) { }

    getAllMetas(): Observable<any> {
        return this.http.get<any>(`${this.apiUrl}/get_all_metas`);
    }

    removeMeta(id_meta:number):Observable<any>{
        return this.http.delete<any>(`${this.apiUrl}/remove_meta_financeira/${id_meta}`);
    }
    addNewMeta(meta: MetasFinanceiras):Observable<any>{
        console.log(meta);
        return this.http.post<any>(`${this.apiUrl}/new_meta_financeira`, meta);
    }

 


}
