import { AmazonSuggestion } from "../domain/amazon-suggestion.model.js";

export interface SuggestionResponse {
  alias: string;
  prefix: string;
  suffix: string;
  suggestions: AmazonSuggestion[];
  responseId: string;
}
