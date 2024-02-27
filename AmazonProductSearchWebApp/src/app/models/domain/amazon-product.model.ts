export interface AmazonProduct {
  id: string;
  alias: string;
  title: string;
  category: string;
  price: number;
  priceDiscounted: number | null;
  rating: number;
  description: string | null;
  brand: string | null;
  author: string | null;
  numberOfReviews: number;
  premiumBrands: string[];
  topBrands: string[];
  allDiscounts: boolean;
  todaysDeals: boolean;
  careInstructions: string[];
  fitTypes: string[];
  specialFeatures: string[];
  occasions: string[];
  businessType: string;
  colors: string[];
  themes: string[];
  isAmazonGlobalStore: boolean;
  includeOutOfStock: boolean;
  mainImage: string | null;
  images: string[];
}
