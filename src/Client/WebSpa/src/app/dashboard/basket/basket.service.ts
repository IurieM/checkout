import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Basket, AddBasketItemCommand, SetBasketItemUnitsCommand, DeleteBasketItemCommand, GetUserBasketQuery, BasketItem, ClearBasketCommand } from './basket';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BasketService {
  private basketUrl = environment.api.basket;

  constructor(private http: HttpClient) { }

  getBasket(userId: number): Observable<Basket> {
    return this.http.get<Basket>(`${this.basketUrl}/basket/user/${userId}`);
  }

  clearBasket(command: ClearBasketCommand): Observable<Basket> {
    return this.http.put<Basket>(`${this.basketUrl}/basket/clear`, command);
  }

  addBasketItem(command: AddBasketItemCommand): Observable<BasketItem> {
    return this.http.put<BasketItem>(`${this.basketUrl}/basket/item/add`, command);
  }

  deleteBasketItem(command: DeleteBasketItemCommand): Observable<BasketItem> {
    return this.http.put<BasketItem>(`${this.basketUrl}/basket/item/delete`, command);
  }

  setBasketItemUnits(command: SetBasketItemUnitsCommand): Observable<BasketItem> {
    return this.http.put<BasketItem>(`${this.basketUrl}/basket/item/units`, command);
  }
}
