import { Routes } from '@angular/router';
import { StockTypeListComponent } from './modules/stock-type/components/stock-type-list/stock-type-list.component';
import { StockListComponent } from './modules/stock/components/stock-list/stock-list.component';
import { IndexComponent } from './modules/index/components/index.component';
import { StockUnitListComponent } from './modules/stock-unit/components/stock-unit-list/stock-unit-list.component';

export const routes: Routes = [
  { path: '', component: IndexComponent }, 
  { path: 'stock-types', component: StockTypeListComponent },
  { path: 'stocks', component: StockListComponent }, 
  { path: 'stock-units', component: StockUnitListComponent }, 
  { path: '**', redirectTo: '' } 
];
