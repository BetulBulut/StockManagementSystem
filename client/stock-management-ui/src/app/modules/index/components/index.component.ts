 import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  imports: [CommonModule, RouterModule],
  standalone: true
})
export class IndexComponent {
  constructor(private router: Router, private http: HttpClient) {}

  goToStockTypes() {
    this.router.navigate(['/stock-types']);
  }

  goToStocks() {
    this.router.navigate(['/stocks']);
  }
   goToStockUnits() {
    this.router.navigate(['/stock-units']);
  }
}