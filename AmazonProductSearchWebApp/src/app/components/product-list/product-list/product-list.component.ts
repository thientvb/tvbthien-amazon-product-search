import { SearchService } from './../../../services/search/search.service';
import { Component, OnInit } from '@angular/core';
import { AmazonProduct } from '../../../models/domain/amazon-product.model';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  constructor(private searchService: SearchService) { }
  filteredProducts: AmazonProduct[] = [];
  ngOnInit() {
    this.searchService.filteredProducts$.subscribe((products) => {
      this.filteredProducts = products;
    });
  }

  getProductIntegerPart(price: number): string {
    return Math.floor(price).toString();
  }

  getProductDecimalPart(price: number): string {
    const decimalPart = price % 1;
    return decimalPart ? decimalPart.toFixed(2).split('.')[1] : '00';
  }
}
