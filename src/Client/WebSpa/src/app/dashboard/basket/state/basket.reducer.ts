import { Basket } from '../basket';
import { BasketActionTypes, BasketActions } from './basket.actions';

export interface BasketState {
  basket: Basket;
}

const initialState: BasketState = {
  basket: null,
};

export function reducer(state: BasketState = initialState, action: BasketActions): BasketState {

  switch (action.type) {

    case BasketActionTypes.LoadSuccess:
      return {
        basket: action.payload,
      };

    case BasketActionTypes.AddBasketItemSuccess:
      var newBasket = Object.assign({}, state.basket);
      newBasket.basketItems.push(action.payload);
      return {
        basket: newBasket
      };

    case BasketActionTypes.DeleteBasketItemSuccess:
      var newBasket = Object.assign({}, state.basket);
      var itemIndex = newBasket.basketItems.findIndex(item => item.itemId == action.payload);
      newBasket.basketItems.splice(itemIndex, 1);
      return {
        basket: newBasket
      };

    case BasketActionTypes.SetBasketItemUnitsSuccess:
      var newBasket = Object.assign({}, state.basket);
      var itemIndex = newBasket.basketItems.findIndex(item => item.itemId == action.payload.itemId);
      newBasket.basketItems[itemIndex].units = action.payload.units;
      return {
        basket: newBasket
      };

    case BasketActionTypes.ClearBasketSuccess:
      return {
        basket: action.payload
      };

    default:
      return state;
  }
}
