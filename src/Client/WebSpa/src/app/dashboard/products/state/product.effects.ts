import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { mergeMap, map } from 'rxjs/operators';

import { ProductService } from '../product.service';

/* NgRx */
import { Action } from '@ngrx/store';
import { Actions, Effect, ofType } from '@ngrx/effects';
import * as productActions from './product.actions';

@Injectable()
export class ProductEffects {

  constructor(private productService: ProductService,
    private actions$: Actions) { }

  @Effect()
  loadProducts$: Observable<Action> = this.actions$.pipe(
    ofType(productActions.ProductActionTypes.Load),
    map((action: productActions.Load) => action.payload),
    mergeMap(category =>
      this.productService.getProducts(category).pipe(
        map(products => (new productActions.LoadSuccess(products)))
      )
    )
  );
}
