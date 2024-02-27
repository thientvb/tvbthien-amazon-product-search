import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SearchBarComponent } from './components/shared/search-bar/search-bar.component';
import { ProductListComponent } from './components/product-list/product-list/product-list.component';
import { ConfigService } from './services/config.service';
import { ProductService } from './services/product/product.service';
import { SearchService } from './services/search/search.service';
import { TrendingService } from './services/trending/trending.service';
import { FormsModule } from '@angular/forms';
import { FilterAdvanceComponent } from './components/product-list/product-list/filter-advance/filter-advance.component';

@NgModule({
  declarations: [
    AppComponent,
    SearchBarComponent,
    ProductListComponent,
    FilterAdvanceComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [
    ConfigService,
    ProductService,
    SearchService,
    TrendingService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
