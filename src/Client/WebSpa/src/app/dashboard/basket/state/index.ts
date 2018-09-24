import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromBasket from './basket.reducer';

export interface State {
    basket: fromBasket.BasketState;
}

// Selector functions
const getProductFeatureState = createFeatureSelector<fromBasket.BasketState>('basket');

export const getBasket = createSelector(
    getProductFeatureState,
    state => state.basket
);


