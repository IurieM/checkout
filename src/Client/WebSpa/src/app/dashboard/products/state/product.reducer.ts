import { Product } from '../product';
import { ProductActionTypes, ProductActions } from './product.actions';

// State for this feature (Product)
export interface ProductState {
  products: Product[];
  basketProduct: Product;
}

const initialState: ProductState = {
  products: [],
  basketProduct: null
};

export function reducer(state = initialState, action: ProductActions): ProductState {

  switch (action.type) {
    case ProductActionTypes.LoadSuccess:
      return {
        ...state,
        products: action.payload
      };
    case ProductActionTypes.AddBasketProduct:
      return {
        ...state,
        basketProduct: action.payload
      };

    default:
      return state;
  }
}
