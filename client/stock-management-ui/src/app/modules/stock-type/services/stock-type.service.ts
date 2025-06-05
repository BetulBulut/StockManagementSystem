import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../../../environments/environment';

export interface StockType {
  id?: number;
  name: string;
  isActive?: boolean;
}


@Injectable({
  providedIn: 'root'
})
export class StockTypeService {
  private apiUrl = `${environment.apiUrl}/StockType`;
  constructor(private http: HttpClient) {}


 getAll(): Observable<StockType[]> {
  return this.http.get<any>(this.apiUrl).pipe(
    map(res => (res.response || []).map((item: any) => ({
      ...item,
      isActive: item.isActive ?? true
    })))
  );
}

  create(stockType: { name: string }): Observable<void> {
    return this.http.post<void>(this.apiUrl, stockType);
  }

  update(stockType: StockType): Observable<void> {
    return this.http.put<void>(this.apiUrl, stockType);
  }

  toggleStatus(id: number): Observable<void> {
    return this.http.patch<void>(`${this.apiUrl}/${id}/toggle-active`, {});
  }

}
