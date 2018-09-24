export class Basket {
    id: number;
    basketItems: BasketItem[];
    constructor()
    {
        this.basketItems = [];
    }
}

export class BasketItem {
    constructor(
        public itemId: number,
        public name: string,
        public price: number,
        public units: number = 1) { }
}

export class GetUserBasketQuery {
    constructor(public userId: number) { }
}

export class ClearBasketCommand {
    constructor(public basketId: number) { }
}

export class AddBasketItemCommand {
    constructor(public basketId: number, public item: BasketItem) { }
}

export class DeleteBasketItemCommand {
    constructor(public basketId: number, public itemId: number) { }
}

export class SetBasketItemUnitsCommand {
    constructor(public basketId: number, public itemId: number, public units: number) { }
}