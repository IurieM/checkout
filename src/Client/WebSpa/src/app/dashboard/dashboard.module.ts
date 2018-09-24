import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { BasketModule } from './basket/basket.module';
import { DashboardComponent } from './dashboard.component';
import { MenuComponent } from './menu.component';
import { DashboardRoutingModule } from './dashboard-routing.module';

@NgModule({
    imports: [
        SharedModule,
        BasketModule,
        DashboardRoutingModule
    ],
    declarations: [
        DashboardComponent,
        MenuComponent,
    ],
    exports: [
        SharedModule,
        BasketModule,
        DashboardComponent,
        MenuComponent,
        DashboardRoutingModule
    ]
})
export class DashboardModule { }
