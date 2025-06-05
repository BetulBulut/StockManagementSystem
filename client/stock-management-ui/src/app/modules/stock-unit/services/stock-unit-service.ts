import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, forkJoin, map } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { StockTypeService, StockType } from '../../stock-type/services/stock-type.service';

export interface StockUnit {
  id: number;
  code: string;
  stockTypeId: number;
  unit: string;
  description: string;
  purchasePrice: number;
  purchaseCurrency: string;
  salePrice: number;
  saleCurrency: string;
  paperWeight: string | null;
  insertedDate: string;
  updatedDate: string;
  isActive: boolean;
  stockTypeName?: string; // eklendi
}

@Injectable({
  providedIn: 'root'
})
export class StockUnitService {
  private apiUrl = `${environment.apiUrl}/StockUnit`;

  constructor(
    private http: HttpClient,
    private stockTypeService: StockTypeService // ekle
  ) {}

  getAll(): Observable<StockUnit[]> {
    return this.http.get<any>(this.apiUrl).pipe(
      map(res => res.response || [])
    );
  }

  getById(id: number): Observable<StockUnit> {
    return this.http.get<StockUnit>(`${this.apiUrl}/${id}`);
  }

  create(stockUnit: StockUnit): Observable<StockUnit> {
    return this.http.post<StockUnit>(this.apiUrl, stockUnit);
  }

  update(stockUnit: StockUnit): Observable<StockUnit> {
    return this.http.put<StockUnit>(this.apiUrl, stockUnit);
  }

  toggleActive(id: number): Observable<void> {
    return this.http.patch<void>(`${this.apiUrl}/${id}/toggle-active`, {});
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  getAllWithTypeNames(): Observable<StockUnit[]> {
    return forkJoin({
      units: this.http.get<any>(this.apiUrl).pipe(map(res => res.response || [])),
      types: this.stockTypeService.getAll()
    }).pipe(
      map(({ units, types }) =>
        units.map((unit: StockUnit) => ({
          ...unit,
          stockTypeName: types.find((t: StockType) => t.id === unit.stockTypeId)?.name || ''
        }))
      )
    );
  }
}