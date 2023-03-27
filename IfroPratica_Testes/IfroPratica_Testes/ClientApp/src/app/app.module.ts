import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from "@angular/router";

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { RpgDataComponent } from './rpg-data/rpg-data.component';
import { RpgDataInsertComponent } from './rpg-data-insert/rpg-data-insert.component';
import { RpgDataUpdateComponent } from './rpg-data-update/rpg-data-update.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    RpgDataComponent,
    RpgDataInsertComponent,
    RpgDataUpdateComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'rpg-list', component: RpgDataComponent },
      { path: 'rpg-list/insert', component: RpgDataInsertComponent },
      { path: 'rpg-list/update/:id', component: RpgDataUpdateComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
