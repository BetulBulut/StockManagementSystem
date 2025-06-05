import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable, forkJoin } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { StockTypeService } from '../../stock-type/services/stock-type.service';
import { StockUnitService } from '../../stock-unit/services/stock-unit-service';


export interface Stock {
  id: number;
  stockTypeId: number;
  stockUnitId: number;
  class: string;
  quantity: number;
  shelfInfo: string;
  cabinetInfo: string;
  criticalQuantity: number;
  insertedDate: string;
  updatedDate: string;
  isActive: boolean;
  stockTypeName?: string; // eklendi
  stockUnitCode?: string; // eklendi
  stockUnitDescription?: string; // eklendi
}

@Injectable({
  providedIn: 'root'
})
export class StockService {
  private apiUrl = `${environment.apiUrl}/Stock`; 

  constructor(
    private http: HttpClient,
    private stockTypeService: StockTypeService,
    private stockUnitService: StockUnitService 
  ) {}

  getAll(): Observable<Stock[]> {
  return this.http.get<any>(this.apiUrl).pipe(
    map(res => res.response || [])
  );
}

  getById(id: number): Observable<Stock> {
    return this.http.get<Stock>(`${this.apiUrl}/${id}`);
  }

  getAllWithNames(): Observable<Stock[]> {
    return forkJoin({
      stocks: this.http.get<any>(this.apiUrl).pipe(map(res => res.response || [])),
      stockUnits: this.stockUnitService.getAll(),
      types: this.stockTypeService.getAll(),
    }).pipe(
      map(({ stocks, types ,stockUnits}) =>
        stocks.map((stock: Stock) => ({
          ...stock,
          stockTypeName: types.find(t => t.id === stock.stockTypeId)?.name || '',
          stockUnitCode: stockUnits.find(su => su.id === stock.stockUnitId)?.code || '',
          stockUnitDescription: stockUnits.find(su => su.id === stock.stockUnitId)?.description || ''
        }))
      )
    );
  }

  create(stock: Stock): Observable<Stock> {
    return this.http.post<Stock>(this.apiUrl, stock);
  }

  update(stock: Stock): Observable<Stock> {
    return this.http.put<Stock>(this.apiUrl, stock);
  }

  toggleActive(id: number): Observable<void> {
    return this.http.patch<void>(`${this.apiUrl}/${id}/toggle-active`, {});
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
