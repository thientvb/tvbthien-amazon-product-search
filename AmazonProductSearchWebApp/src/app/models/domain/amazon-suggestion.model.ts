export interface AmazonSuggestion {
  suggType: string;
  type: string;
  value: string;
  refTag: string | null;
  candidateSources: string | null;
  strategyId: string | null;
  strategyApiType: string | null;
  prior: number;
  ghost: boolean;
  help: boolean;
}
