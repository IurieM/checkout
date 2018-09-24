import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SharedModule } from '../../shared/shared.module';

import { ProductListComponent } from './components/product-list/product-list.component';

/* NgRx */
import { StoreModule } from '@ngrx/store';
import { reducer } from './state/product.reducer';
import { EffectsModule } from '@ngrx/effects';
import { ProductEffects } from './state/product.effects';
import { ProductService } from './product.service';


const productRoutes: Routes = [
  { path: '', component: ProductListComponent }
];

@NgModule({
  imports: [
    SharedModule,
    RouterModule.forChild(productRoutes),
    StoreModule.forFeature('products', reducer),
    EffectsModule.forFeature(
      [ProductEffects]
    ),
  ],
  providers: [ProductService],
  declarations: [
    ProductListComponent,
  ]
})
export class ProductModule { }
