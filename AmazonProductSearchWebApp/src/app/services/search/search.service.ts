import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from '../config.service';
import { SuggestionRequest } from '../../models/request/suggestion-request.model';
import { BehaviorSubject, Observable } from 'rxjs';
import { SearchRequest } from '../../models/request/search-request.model';
import { SuggestionResponse } from '../../models/respone/suggestion-response.model';
import { AmazonProduct } from '../../models/domain/amazon-product.model';
import { SearchResponse } from '../../models/respone/search-response.model';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  private filteredProductsSubject = new BehaviorSubject<AmazonProduct[]>([]);
  filteredProducts$ = this.filteredProductsSubject.asObservable();
  constructor(private http: HttpClient, private configService: ConfigService) { }

  apiUrl_search = this.configService.getBaseApiUrl() + '/api/search/search';
  apiUrl_suggestion = this.configService.getBaseApiUrl() + '/api/search/suggestion';

  searchAmazonProduct(req: SearchRequest): Observable<any> {
    return this.http.post<SearchResponse>(this.apiUrl_search, req);
  }

  getSuggestions(req: SuggestionRequest): Observable<any> {
    const params = this.buildParamsSuggestion(req);
    const url = `${this.apiUrl_suggestion}?${params}`;

    return this.http.get<SuggestionResponse>(url);
  }

  updateFilteredProducts(products: any[]): void {
    this.filteredProductsSubject.next(products);
  }

  private buildParamsSuggestion(req: SuggestionRequest): string {
    const params = new URLSearchParams();
    params.set('limit', req.limit.toString());
    params.set('alias', req.alias);
    params.set('prefix', req.prefix);
    if (req.suffix) {
      params.set('suffix', req.suffix);
    }

    return params.toString();
  }
}
