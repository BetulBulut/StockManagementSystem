import { Component, OnInit } from '@angular/core';
import { StockType, StockTypeService } from '../../services/stock-type.service';
import { StockTypeFormComponent } from '../stock-type-form/stock-type-form.component';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-stock-type-list',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatTableModule,
    MatDialogModule
  ],
  templateUrl: './stock-type-list.component.html',
})
export class StockTypeListComponent implements OnInit {
  stockTypes: StockType[] = [];
  displayedColumns: string[] = ['index', 'name', 'isActive', 'actions'];

  constructor(
    private stockTypeService: StockTypeService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadStockTypes();
  }

  loadStockTypes(): void {
    this.stockTypeService.getAll().subscribe({
      next: (data) => this.stockTypes = data,
      error: (err) => console.error('Listeleme hatası:', err)
    });
  }

  toggleStatus(stockType: StockType): void {
    console.log('Toggling status for:', stockType.id);
    if (!stockType.id) return;
    this.stockTypeService.toggleStatus(stockType.id).subscribe({
      next: () => this.loadStockTypes(),
      error: (err) => console.error('Durum değiştirme hatası:', err)
    });
  }

  edit(stockType: StockType): void {
    const dialogRef = this.dialog.open(StockTypeFormComponent, {
      width: '400px',
      data: stockType
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) this.loadStockTypes();
    });
  }

  addNew(): void {
    const dialogRef = this.dialog.open(StockTypeFormComponent, {
      width: '400px',
      data: null
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) this.loadStockTypes();
    });
  }

  delete(stockType: StockType): void {
    if (!stockType.id) return;
    if (!stockType.isActive) {
      alert('Only active stock types can be deleted.');
      return;
    }
    const confirmDelete = confirm(`Are you sure you want to delete "${stockType.name}"?`);
    if (!confirmDelete) return;

    this.toggleStatus(stockType);
  }
}
