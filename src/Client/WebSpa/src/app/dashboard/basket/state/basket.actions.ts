import { Basket, AddBasketItemCommand, DeleteBasketItemCommand, SetBasketItemUnitsCommand, BasketItem, ClearBasketCommand } from '../basket';

/* NgRx */
import { Action } from '@ngrx/store';

export enum BasketActionTypes {
  Load = '[Basket] Load',
  LoadSuccess = '[Basket] Load Success',
  LoadFail = '[Basket] Load Fail',
  AddBasketItem = '[Basket] Add Basket Item',
  AddBasketItemSuccess = '[Basket] Add Basket Item Success',
  DeleteBasketItem = '[Basket] Delete Basket Item',
  DeleteBasketItemSuccess = '[Basket] Delete Basket Item Success',
  SetBasketItemUnits = '[Basket] Set Basket Item Units',
  SetBasketItemUnitsSuccess = '[Basket] Set Basket Item Units Success',
  ClearBasket = '[Basket] Clear Basket',
  ClearBasketSuccess = '[Basket] Clear Basket Success',
}

// Action Creators

export class Load implements Action {
  readonly type = BasketActionTypes.Load;

  constructor(public payload: number) { }
}

export class LoadSuccess implements Action {
  readonly type = BasketActionTypes.LoadSuccess;

  constructor(public payload: Basket) { }
}

export class ClearBasket implements Action {
  readonly type = BasketActionTypes.ClearBasket;

  constructor(public payload: ClearBasketCommand) { }
}

export class ClearBasketSuccess implements Action {
  readonly type = BasketActionTypes.ClearBasketSuccess;

  constructor(public payload: Basket) { }
}

export class AddBasketItem implements Action {
  readonly type = BasketActionTypes.AddBasketItem;

  constructor(public payload: AddBasketItemCommand) { }
}

export class AddBasketItemSuccess implements Action {
  readonly type = BasketActionTypes.AddBasketItemSuccess;

  constructor(public payload: BasketItem) { }
}


export class DeleteBasketItem implements Action {
  readonly type = BasketActionTypes.DeleteBasketItem;

  constructor(public payload: DeleteBasketItemCommand) { }
}

export class DeleteBasketItemSuccess implements Action {
  readonly type = BasketActionTypes.DeleteBasketItemSuccess;

  constructor(public payload: number) { }
}

export class SetBasketItemUnits implements Action {
  readonly type = BasketActionTypes.SetBasketItemUnits
  constructor(public payload: SetBasketItemUnitsCommand) { }
}

export class SetBasketItemUnitsSuccess implements Action {
  readonly type = BasketActionTypes.SetBasketItemUnitsSuccess;

  constructor(public payload: BasketItem) { }
}

// Union the valid types
export type BasketActions = Load
  | LoadSuccess
  | AddBasketItem
  | AddBasketItemSuccess
  | DeleteBasketItem
  | DeleteBasketItemSuccess
  | SetBasketItemUnits
  | SetBasketItemUnitsSuccess
  | ClearBasket
  | ClearBasketSuccess

