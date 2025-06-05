import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';

import { Stock, StockService } from '../../services/stock-service';
import { StockType, StockTypeService } from '../../../stock-type/services/stock-type.service';
import { StockUnit, StockUnitService } from '../../../stock-unit/services/stock-unit-service';

@Component({
  selector: 'app-stock-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  providers: [StockService],
  templateUrl: './stock-form.component.html'
})
export class StockFormComponent implements OnInit {
  stockForm: FormGroup;
  isEditMode = false;
  stockTypes: StockType[] = [];
  stockUnits: StockUnit[] = []; // ekle

  constructor(
    private fb: FormBuilder,
    private service: StockService,
    private stockTypeService: StockTypeService,
    private stockUnitService: StockUnitService, // ekle
    private dialogRef: MatDialogRef<StockFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Stock | null
  ) {
    this.stockForm = this.fb.group({
      stockTypeId: ['', Validators.required],
      stockUnitId: ['', Validators.required],
      class: ['', Validators.required],
      quantity: [0, [Validators.required, Validators.min(0)]],
      shelfInfo: [''],
      cabinetInfo: [''],
      criticalQuantity: [0, [Validators.required, Validators.min(0)]],
      isActive: [true]
    });
  }

  ngOnInit(): void {
    this.stockTypeService.getAll().subscribe(types => this.stockTypes = types);
    this.stockUnitService.getAll().subscribe(units => this.stockUnits = units); // ekle
    if (this.data) {
      this.isEditMode = true;
      this.stockForm.patchValue(this.data);
    }
  }

  onSubmit(): void {
    if (this.stockForm.invalid) return;

    const formValue = this.stockForm.value;

    if (this.isEditMode && this.data?.id) {
      const updated: Stock = { ...formValue, id: this.data.id, insertedDate: this.data.insertedDate, updatedDate: new Date().toISOString() };
      this.service.update(updated).subscribe(() => this.dialogRef.close(true));
    } else {
      this.service.create(formValue).subscribe(() => this.dialogRef.close(true));
    }
  }

  close(): void {
    this.dialogRef.close(false);
  }
}
