import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from '../config.service';
import { AmazonAlias } from '../../models/domain/amazon-alias.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  constructor(private http: HttpClient, private configService: ConfigService) { }

  private apiUrl = this.configService.getBaseApiUrl() + '/api/Product/aliases';

  getAliases() {
    return this.http.get<AmazonAlias[]>(this.apiUrl);
  }
}
