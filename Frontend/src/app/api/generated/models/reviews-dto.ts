/* tslint:disable */
/* eslint-disable */
import { ReviewDto } from './review-dto';
export interface ReviewsDto {
  errorCode?: null | string;
  errorDescription?: null | string;
  isSucceded?: null | boolean;
  reviews?: null | Array<ReviewDto>;
  time?: null | string;
}
