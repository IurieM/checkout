import { createFeatureSelector, createSelector } from '@ngrx/store';
import * as fromProducts from './product.reducer';

export interface State {
    products: fromProducts.ProductState;
}

// Selector functions
const getProductFeatureState = createFeatureSelector<fromProducts.ProductState>('products');

export const getProducts = createSelector(
    getProductFeatureState,
    state => state.products
);


export const basketProductAdded = createSelector(
    getProductFeatureState,
    state => state.basketProduct
);