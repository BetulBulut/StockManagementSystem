import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatDialogModule, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';

import { StockType, StockTypeService } from '../../services/stock-type.service';

@Component({
  selector: 'app-stock-type-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  templateUrl: './stock-type-form.component.html'
})
export class StockTypeFormComponent {
  stockTypeForm: FormGroup;
  isEditMode = false;

  constructor(
    private fb: FormBuilder,
    private service: StockTypeService,
    private dialogRef: MatDialogRef<StockTypeFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: StockType | null
  ) {
    this.stockTypeForm = this.fb.group({
      name: ['', Validators.required]
    });

    if (data) {
      this.isEditMode = true;
      this.stockTypeForm.patchValue(data);
    }
  }

  onSubmit(): void {
    if (this.stockTypeForm.invalid) return;

    const formValue = this.stockTypeForm.value;

    if (this.isEditMode && this.data?.id) {
      const updated: StockType = { ...formValue, id: this.data.id };
      this.service.update(updated).subscribe(() => this.dialogRef.close(true));
    } else {
      this.service.create(formValue).subscribe(() => this.dialogRef.close(true));
    }
  }

  close(): void {
    this.dialogRef.close(false);
  }
}
