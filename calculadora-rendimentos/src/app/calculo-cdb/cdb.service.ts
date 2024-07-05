import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CdbService {
  private apiUrl = 'http://localhost:5000/api/Cdb';
  constructor(private http: HttpClient) { }

  calcularCdb(meses: number, valor: number): Observable<CalculoCdbResponse> {
    const params = new HttpParams()
      .set('meses', meses.toString())
      .set('valorInicial', valor.toString());

    return this.http.get<CalculoCdbResponse>(`${this.apiUrl}/calcularCdb`, { params });
  }
}

export interface CalculoCdbResponse {
  valorBruto: number;
  valorLiquido: number;
}
