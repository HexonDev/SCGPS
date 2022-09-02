/* tslint:disable */
/* eslint-disable */
import { MovieDto } from './movie-dto';
export interface MoviesDto {
  errorCode?: null | string;
  errorDescription?: null | string;
  isSucceded?: null | boolean;
  movies?: null | Array<MovieDto>;
  time?: null | string;
}
