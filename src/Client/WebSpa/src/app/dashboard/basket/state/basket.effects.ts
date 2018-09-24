import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { mergeMap, map } from 'rxjs/operators';

import { Action } from '@ngrx/store';
import { Actions, Effect, ofType } from '@ngrx/effects';
import * as basketActions from './basket.actions';
import { BasketService } from '../basket.service';
import { AddBasketItemCommand, GetUserBasketQuery, DeleteBasketItemCommand, SetBasketItemUnitsCommand, BasketItem, ClearBasketCommand } from '../basket';

@Injectable()
export class BasketEffects {

  constructor(private basketService: BasketService,
    private actions$: Actions) { }

  @Effect()
  loadBasket$: Observable<Action> = this.actions$.pipe(
    ofType(basketActions.BasketActionTypes.Load),
    map((action: basketActions.Load) => action.payload),
    mergeMap((userId: number) =>
      this.basketService.getBasket(userId).pipe(
        map(basket => (new basketActions.LoadSuccess(basket)))
      )
    )
  );

  @Effect()
  addBasketItem: Observable<Action> = this.actions$.pipe(
    ofType(basketActions.BasketActionTypes.AddBasketItem),
    map((action: basketActions.AddBasketItem) => action.payload),
    mergeMap((command: AddBasketItemCommand) =>
      this.basketService.addBasketItem(command).pipe(
        map((basketItem: BasketItem) => (new basketActions.AddBasketItemSuccess(basketItem)))
      )
    )
  );

  @Effect()
  deleteBasketItem: Observable<Action> = this.actions$.pipe(
    ofType(basketActions.BasketActionTypes.DeleteBasketItem),
    map((action: basketActions.DeleteBasketItem) => action.payload),
    mergeMap((command: DeleteBasketItemCommand) =>
      this.basketService.deleteBasketItem(command).pipe(
        map((itemId: number) => (new basketActions.DeleteBasketItemSuccess(itemId))),
      )
    )
  );

  @Effect()
  setBasketItemUnits: Observable<Action> = this.actions$.pipe(
    ofType(basketActions.BasketActionTypes.SetBasketItemUnits),
    map((action: basketActions.SetBasketItemUnits) => action.payload),
    mergeMap((command: SetBasketItemUnitsCommand) =>
      this.basketService.setBasketItemUnits(command).pipe(
        map((basketItem: BasketItem) => (new basketActions.SetBasketItemUnitsSuccess(basketItem))),
      )
    )
  );

  @Effect()
  clearBasket: Observable<Action> = this.actions$.pipe(
    ofType(basketActions.BasketActionTypes.ClearBasket),
    map((action: basketActions.ClearBasket) => action.payload),
    mergeMap((command: ClearBasketCommand) =>
      this.basketService.clearBasket(command).pipe(
        map((basket) => (new basketActions.ClearBasketSuccess(basket))),
      )
    )
  );
}
