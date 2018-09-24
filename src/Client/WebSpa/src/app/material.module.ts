import { NgModule } from '@angular/core';
import {
    MatCardModule, MatIconModule, MatInputModule,
    MatButtonModule, MatListModule, MatSnackBarModule
} from '@angular/material';

@NgModule({
    imports: [MatCardModule, MatIconModule, MatInputModule,
        MatButtonModule, MatListModule, MatSnackBarModule],
    exports: [MatCardModule, MatIconModule, MatInputModule,
        MatButtonModule, MatListModule, MatSnackBarModule],
})
export class MaterialModule { }
