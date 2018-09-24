import { Product } from '../product';

import { Action } from '@ngrx/store';

export enum ProductActionTypes {
  Load = '[Product] Load',
  LoadSuccess = '[Product] Load Success',
  AddBasketProduct = '[Product] Add Basket Product'
}

export class Load implements Action {
  readonly type = ProductActionTypes.Load;
  constructor(public payload: string) { }
}

export class LoadSuccess implements Action {
  readonly type = ProductActionTypes.LoadSuccess;

  constructor(public payload: Product[]) { }
}

export class AddBasketProduct implements Action {
  readonly type = ProductActionTypes.AddBasketProduct;

  constructor(public payload: Product) { }
}


export type ProductActions = Load
  | LoadSuccess
  | AddBasketProduct