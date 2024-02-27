import { SearchService } from './../../../services/search/search.service';
import { TrendingService } from './../../../services/trending/trending.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AmazonAlias } from '../../../models/domain/amazon-alias.model';
import { ProductService } from '../../../services/product/product.service';
import { TrendingResponse } from '../../../models/respone/trending-response.model';
import { MySuggestion } from '../../../models/domain/my-suggestion.model';
import { SearchRequest } from '../../../models/request/search-request.model';
import { SuggestionRequest } from '../../../models/request/suggestion-request.model';
import { SuggestionResponse } from '../../../models/respone/suggestion-response.model';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})
export class SearchBarComponent implements OnInit {
  @Output() searchEvent = new EventEmitter<string>();
  aliasSelected: string = 'aps';
  aliases: AmazonAlias[] = [];
  trendingSuggestions: TrendingResponse[] = [];
  mySuggestions: MySuggestion[] = [];
  suggestionResponse: SuggestionResponse | null = null;
  showTrendingSuggestions = false;
  showAmazonLens = false;
  query = '';
  constructor(private productService: ProductService,
    private trendingService: TrendingService,
    private searchService: SearchService,
  ) {}

  ngOnInit(): void {
    this.productService.getAliases().subscribe(
      (data) => {
        this.aliases = data;
      },
      (error) => {
        console.error('Error fetching aliases:', error);
      }
    );
    this.trendingService.getTrendingData().subscribe(
      (data) => {
        this.trendingSuggestions = data;
      },
      (error) => {
        console.error('Error fetching Trending Data:', error);
      }
    );
    this.loadMySuggestions();
  }

  onSearchChange(value: string) {
    this.searchEvent.emit(value);
  }

  onInputChange(): void {
    console.log('Query:', this.query);
  }

  saveTrendingSuggestion(keyword: string): void {
    if (keyword && !this.mySuggestions.find(ts => ts.keyword.toLowerCase() === keyword.toLowerCase() && ts.alias === this.aliasSelected)) {
      this.mySuggestions.unshift({keyword: keyword.toLowerCase(), alias: this.aliasSelected});
      localStorage.setItem('mySuggestions', JSON.stringify(this.mySuggestions));
    }
  }

  removeMySuggestion(index: number): void {
    if (index >= 0 && index < this.mySuggestions.length) {
      this.mySuggestions.splice(index, 1);
      localStorage.setItem('mySuggestions', JSON.stringify(this.mySuggestions));
    }
  }

  loadMySuggestions(): void {
    // Load trending suggestions from local storage
    const storedMySuggestions = localStorage.getItem('mySuggestions');
    if (storedMySuggestions) {
      this.mySuggestions = JSON.parse(storedMySuggestions);
    }
  }

  searchProduct(keyword: string) {
    const req: SearchRequest = {
      alias: this.aliasSelected,
      searchText: keyword,
      title: null,
      category: null,
      priceMin: null,
      priceMax: null,
      rating: null,
      brands: null,
      premiumBrands: null,
      topBrands: null,
      allDiscounts: null,
      todaysDeals: null,
      careInstructions: null,
      fitTypes: null,
      specialFeatures: null,
      occasions:  null,
      businessType:  null,
      colors: null,
      themes: null,
      isAmazonGlobalStore: null,
      includeOutOfStock: null,
      skip: 0,
      take: 20
    };
    this.searchService.searchAmazonProduct(req).subscribe(
      (data) => {
        this.query = keyword;
        this.searchService.updateFilteredProducts(data.amazonProducts);
        this.saveTrendingSuggestion(this.query);
      },
      (error) => {
        console.error('Search error:', error);
      }
    );
  }

  onChangeTextSearch(keyword: string) {
    if (keyword) {
      const req: SuggestionRequest = {
        limit: 11,
        alias: this.aliasSelected,
        prefix: keyword,
        suffix: ''
      };
      this.searchService.getSuggestions(req).subscribe(
        (data) => {
          this.suggestionResponse = data;
        },
        (error) => {
          console.error('Search error:', error);
        }
      );
    } else {
      this.suggestionResponse = null;
    }
  }

  openTrendingSuggestions() {
    this.showTrendingSuggestions = true;
  }

  closeTrendingSuggestions() {
    setTimeout(() => {
      this.showTrendingSuggestions = false;
    }, 250);
  }

  openAmazonLens() {
    this.showAmazonLens = true;
    this.showTrendingSuggestions = false;
  }

  closeAmazonLens() {
    setTimeout(() => {
      this.showAmazonLens = false;
    }, 250);
  }
}
