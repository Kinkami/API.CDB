import { Component } from '@angular/core';
import { timeout } from 'rxjs/operators';
import { CdbService, CalculoCdbResponse } from '../calculo-cdb/cdb.service';

@Component({
  selector: 'app-calculo-cdb',
  templateUrl: './calculo-cdb.component.html',
  styleUrls: ['./calculo-cdb.component.css']
})
export class CalculoCdbComponent {
  meses: number = 0;
  valor: number = 0;
  valorBruto?: number;
  valorLiquido?: number;
  error?: string;

  constructor(private cdbService: CdbService) { }

  calcular(): void {
    this.cdbService.calcularCdb(this.meses, this.valor).pipe(
      timeout(5000)
    ).subscribe({
      next: (response: CalculoCdbResponse) => {
        this.valorBruto = response.valorBruto;
        this.valorLiquido = response.valorLiquido;
        this.error = undefined;
      },
      error: (error) => {
        this.error = 'Erro ao calcular o CDB. Por favor, tente novamente.';
      },
    });
  }
}
