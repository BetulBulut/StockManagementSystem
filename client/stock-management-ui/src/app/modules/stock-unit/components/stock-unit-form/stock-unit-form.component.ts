import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';

import { StockUnit, StockUnitService } from '../../services/stock-unit-service';
import { StockType, StockTypeService } from '../../../stock-type/services/stock-type.service';

@Component({
  selector: 'app-stock-unit-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  templateUrl: './stock-unit-form.component.html'
})
export class StockUnitFormComponent implements OnInit {
  stockUnitForm: FormGroup;
  isEditMode = false;
  stockTypes: StockType[] = [];

  constructor(
    private fb: FormBuilder,
    private stockUnitService: StockUnitService,
    private stockTypeService: StockTypeService,
    private dialogRef: MatDialogRef<StockUnitFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: StockUnit | null
  ) {
    this.stockUnitForm = this.fb.group({
      code: ['', Validators.required],
      stockTypeId: ['', Validators.required],
      unit: ['', Validators.required],
      description: [''],
      purchasePrice: [0, [Validators.required, Validators.min(0)]],
      purchaseCurrency: ['', Validators.required],
      salePrice: [0, [Validators.required, Validators.min(0)]],
      saleCurrency: ['', Validators.required],
      paperWeight: [''],
      isActive: [true]
    });
  }

  ngOnInit(): void {
    this.stockTypeService.getAll().subscribe(types => this.stockTypes = types);
    if (this.data) {
      this.isEditMode = true;
      this.stockUnitForm.patchValue(this.data);
    }
  }

  onSubmit(): void {
    if (this.stockUnitForm.invalid) return;
    const formValue = this.stockUnitForm.value;
    if (this.isEditMode && this.data?.id) {
      const updated: StockUnit = { ...formValue, id: this.data.id, insertedDate: this.data.insertedDate, updatedDate: new Date().toISOString() };
      this.stockUnitService.update(updated).subscribe(() => this.dialogRef.close(true));
    } else {
      this.stockUnitService.create(formValue).subscribe(() => this.dialogRef.close(true));
    }
  }

  close(): void {
    this.dialogRef.close(false);
  }
}
