import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { takeWhile } from 'rxjs/operators';

import * as fromBasket from '../../state';
import * as fromProduct from '../../../products/state';
import * as basketActions from '../../state/basket.actions';
import { BasketItem, SetBasketItemUnitsCommand, Basket, DeleteBasketItemCommand, AddBasketItemCommand, ClearBasketCommand } from '../../basket';
import { AuthService } from '../../../../shared/services/auth.service';
import { Product } from '../../../products/product';
import { AlertService } from '../../../../shared/services/alert-service';

@Component({
  selector: 'ch-basket-summary',
  templateUrl: './basket-summary.component.html'
})
export class BasketSummaryComponent implements OnInit {
  pageTitle = 'Basket Summary';
  basket: Basket = new Basket();
  componentActive = true;

  constructor(private basketStore: Store<fromBasket.State>, private productStore: Store<fromProduct.State>, private authService: AuthService, private alertService: AlertService) { }

  ngOnInit(): void {
    this.basketStore.dispatch(new basketActions.Load(this.authService.currentUser.id));
    this.basketStore.pipe(
      select(fromBasket.getBasket),
      takeWhile(() => this.componentActive))
      .subscribe(basket => this.basket = basket || new Basket());
    this.basketProductAddedSubcription();
  }

  incrementUnits(item: BasketItem) {
    let itemUnits = item.units + 1;
    this.dispachBasketUnitsCommand(item.itemId, itemUnits);
  }

  decrementUnits(item: BasketItem) {
    if (item.units <= 1) {
      return;
    }

    let itemUnits = item.units - 1;
    this.dispachBasketUnitsCommand(item.itemId, itemUnits);
  }

  clearBasket() {
    let command = new ClearBasketCommand(this.basket.id);
    this.basketStore.dispatch(new basketActions.ClearBasket(command));
  }

  deleteBasketItem(item: BasketItem) {
    let command = new DeleteBasketItemCommand(this.basket.id, item.itemId);
    this.basketStore.dispatch(new basketActions.DeleteBasketItem(command));
  }

  private basketProductAddedSubcription() {
    this.productStore.pipe(
      select(fromProduct.basketProductAdded),
      takeWhile(() => this.componentActive))
      .subscribe(product => {
        if (!product) {
          return;
        }

        let productExists = this.basket.basketItems.some(item => item.itemId === product.id);
        if (productExists) {
          this.alertService.openError("Product already added")
          return;
        }
        this.dispachAddBasketItemCommand(product);
      });
  }

  private dispachAddBasketItemCommand(product: Product) {
    let basketItem = new BasketItem(product.id, product.name, product.price);
    let command = new AddBasketItemCommand(this.basket.id, basketItem);
    this.basketStore.dispatch(new basketActions.AddBasketItem(command));
  }

  private dispachBasketUnitsCommand(itemId: number, itemUnits: number) {
    let command = new SetBasketItemUnitsCommand(this.basket.id, itemId, itemUnits);
    this.basketStore.dispatch(new basketActions.SetBasketItemUnits(command));
  }
}
