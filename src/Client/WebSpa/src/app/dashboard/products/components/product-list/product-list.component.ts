import { Component, OnInit } from '@angular/core';
import { ParamMap, ActivatedRoute } from '@angular/router';

import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import * as fromProduct from '../../state';
import * as productActions from '../../state/product.actions';
import { Product } from '../../product';


@Component({
  selector: 'ch-product-list',
  templateUrl: './product-list.component.html'
})
export class ProductListComponent implements OnInit {
  pageTitle = 'Products';
  products$: Observable<Product[]>;

  constructor(private store: Store<fromProduct.State>, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadCategoryProducts();
    this.products$ = this.store.pipe(select(fromProduct.getProducts));
  }

  addToBasket(product: Product): void {
    this.store.dispatch(new productActions.AddBasketProduct(product));
  }

  loadCategoryProducts() {
    let category = this.route.snapshot.paramMap.get('category');
    this.store.dispatch(new productActions.Load(category));
  }
}
