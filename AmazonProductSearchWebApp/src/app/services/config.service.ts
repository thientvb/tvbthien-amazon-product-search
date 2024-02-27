import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {
  private readonly baseApiUrl = 'https://localhost:44348';

  getBaseApiUrl(): string {
    return this.baseApiUrl;
  }
}
