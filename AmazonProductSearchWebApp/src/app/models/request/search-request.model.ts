export interface SearchRequest {
  alias: string | null;
  searchText: string | null;
  title: string | null;
  category: string | null;
  priceMin: number | null;
  priceMax: number | null;
  rating: number | null;
  brands: string[] | null;
  premiumBrands: string[] | null;
  topBrands: string[] | null;
  allDiscounts: boolean | null;
  todaysDeals: boolean | null;
  careInstructions: string[] | null;
  fitTypes: string[] | null;
  specialFeatures: string[] | null;
  occasions: string[] | null;
  businessType: string | null;
  colors: string[] | null;
  themes: string[] | null;
  isAmazonGlobalStore: boolean | null;
  includeOutOfStock: boolean | null;
  skip: number;
  take: number;
}
