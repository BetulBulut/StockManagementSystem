import { Component, OnInit } from '@angular/core';
import { Stock, StockService } from '../../services/stock-service';
import { StockFormComponent } from '../stock-form/stock-form.component';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-stock-list',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatTableModule,
    MatDialogModule
  ],
  templateUrl: './stock-list.component.html',
})
export class StockListComponent implements OnInit {
  stocks: Stock[] = [];
  displayedColumns: string[] = [
    'index',
    'class',
    'quantity',
    'shelfInfo',
    'cabinetInfo',
    'criticalQuantity',
    'isActive',
    'actions'
  ];

  constructor(
    private stockService: StockService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadStocks();
  }

  loadStocks(): void {
    this.stockService.getAllWithNames().subscribe({
      next: (data) => this.stocks = data,
      error: (err) => console.error('Listeleme hatası:', err)
    });
  }

  toggleActive(stock: Stock): void {
    if (!stock.id) return;
    this.stockService.toggleActive(stock.id).subscribe({
      next: () => this.loadStocks(),
      error: (err) => console.error('Durum değiştirme hatası:', err)
    });
  }

  edit(stock: Stock): void {
    const dialogRef = this.dialog.open(StockFormComponent, {
      width: '400px',
      data: stock
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) this.loadStocks();
    });
  }

  addNew(): void {
    const dialogRef = this.dialog.open(StockFormComponent, {
      width: '400px',
      data: null
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) this.loadStocks();
    });
  }
}
