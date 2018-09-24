import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { reducer } from './state/basket.reducer';
import { BasketEffects } from './state/basket.effects';
import { BasketSummaryComponent } from './components/basket-summary/basket-summary.component';
import { SharedModule } from '../../shared/shared.module';
import { BasketService } from './basket.service';

@NgModule({
  imports: [
    SharedModule,
    StoreModule.forFeature('basket', reducer),
    EffectsModule.forFeature(
      [BasketEffects]
    ),
  ],
  providers: [BasketService],
  declarations: [
    BasketSummaryComponent
  ],
  exports: [BasketSummaryComponent]
})
export class BasketModule { }
