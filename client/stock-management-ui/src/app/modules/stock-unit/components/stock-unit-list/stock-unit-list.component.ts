import { Component, OnInit } from '@angular/core';
import { StockUnit, StockUnitService } from '../../services/stock-unit-service';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { StockUnitFormComponent } from '../stock-unit-form/stock-unit-form.component';

@Component({
  selector: 'app-stock-unit-list',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatTableModule,
    MatDialogModule
  ],
  templateUrl: './stock-unit-list.component.html',
})
export class StockUnitListComponent implements OnInit {
  stockUnits: StockUnit[] = [];
  displayedColumns: string[] = [
    'index',
    'code',
    'unit',
    'description',
    'purchasePrice',
    'purchaseCurrency',
    'salePrice',
    'saleCurrency',
    'paperWeight',
    'isActive',
    'actions'
  ];

  constructor(
    private stockUnitService: StockUnitService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadStockUnits();
  }

  loadStockUnits(): void {
    this.stockUnitService.getAllWithTypeNames().subscribe({
      next: (data) => this.stockUnits = data,
      error: (err) => console.error('Listeleme hatası:', err)
    });
  }

  toggleActive(stockUnit: StockUnit): void {
    if (!stockUnit.id) return;
    this.stockUnitService.toggleActive(stockUnit.id).subscribe({
      next: () => this.loadStockUnits(),
      error: (err) => console.error('Durum değiştirme hatası:', err)
    });
  }

edit(stockUnit: StockUnit): void {
  const dialogRef = this.dialog.open(StockUnitFormComponent, {
    width: '500px',
    data: stockUnit
  });

  dialogRef.afterClosed().subscribe((result) => {
    if (result) this.loadStockUnits();
  });
}

addNew(): void {
  const dialogRef = this.dialog.open(StockUnitFormComponent, {
    width: '500px',
    data: null
  });

  dialogRef.afterClosed().subscribe((result) => {
    if (result) this.loadStockUnits();
  });
}

  getCurrencySymbol(currency: string): string {
    switch (currency) {
      case 'TRY': return '₺';
      case 'USD': return '$';
      case 'EUR': return '€';
      case 'GBP': return '£';
      case 'JPY': return '¥';
      case 'AUD': return 'A$';
      case 'CAD': return 'C$';
      case 'CHF': return '₣';
      case 'CNY': return '¥';
      case 'SEK': return 'kr';
      case 'NZD': return 'NZ$';
      case 'MXN': return 'Mex$';
      case 'SGD': return 'S$';
      case 'HKD': return 'HK$';
      case 'NOK': return 'kr';
      case 'KRW': return '₩';
      default: return currency;
    }
  }
}
