import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from '../config.service';
import { TrendingResponse } from '../../models/respone/trending-response.model';

@Injectable({
  providedIn: 'root'
})
export class TrendingService {

  constructor(private http: HttpClient, private configService: ConfigService) { }
  apiUrl = this.configService.getBaseApiUrl() + '/api/Trending';

  getTrendingData() {
    return this.http.get<TrendingResponse[]>(this.apiUrl);
  }
}
