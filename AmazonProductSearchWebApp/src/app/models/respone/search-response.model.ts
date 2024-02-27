import { AmazonProduct } from "../domain/amazon-product.model";

export interface SearchResponse {
  amazonProducts: AmazonProduct[];
}
