/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpContext } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { MovieDto } from '../models/movie-dto';
import { MovieTitleDto } from '../models/movie-title-dto';
import { MoviesDto } from '../models/movies-dto';
import { Order } from '../models/order';

@Injectable({
  providedIn: 'root',
})
export class MoviesService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiMoviesGet
   */
  static readonly ApiMoviesGetPath = '/api/Movies';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiMoviesGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiMoviesGet$Plain$Response(params?: {
    title?: string;
    orderBy?: string;
    year?: string;
    order?: Order;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<MoviesDto>> {

    const rb = new RequestBuilder(this.rootUrl, MoviesService.ApiMoviesGetPath, 'get');
    if (params) {
      rb.query('title', params.title, {});
      rb.query('orderBy', params.orderBy, {});
      rb.query('year', params.year, {});
      rb.query('order', params.order, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<MoviesDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiMoviesGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiMoviesGet$Plain(params?: {
    title?: string;
    orderBy?: string;
    year?: string;
    order?: Order;
    context?: HttpContext
  }
): Observable<MoviesDto> {

    return this.apiMoviesGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<MoviesDto>) => r.body as MoviesDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiMoviesGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiMoviesGet$Json$Response(params?: {
    title?: string;
    orderBy?: string;
    year?: string;
    order?: Order;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<MoviesDto>> {

    const rb = new RequestBuilder(this.rootUrl, MoviesService.ApiMoviesGetPath, 'get');
    if (params) {
      rb.query('title', params.title, {});
      rb.query('orderBy', params.orderBy, {});
      rb.query('year', params.year, {});
      rb.query('order', params.order, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<MoviesDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiMoviesGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiMoviesGet$Json(params?: {
    title?: string;
    orderBy?: string;
    year?: string;
    order?: Order;
    context?: HttpContext
  }
): Observable<MoviesDto> {

    return this.apiMoviesGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<MoviesDto>) => r.body as MoviesDto)
    );
  }

  /**
   * Path part for operation apiMoviesPost
   */
  static readonly ApiMoviesPostPath = '/api/Movies';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiMoviesPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiMoviesPost$Plain$Response(params?: {
    context?: HttpContext
    body?: MovieTitleDto
  }
): Observable<StrictHttpResponse<MovieDto>> {

    const rb = new RequestBuilder(this.rootUrl, MoviesService.ApiMoviesPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<MovieDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiMoviesPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiMoviesPost$Plain(params?: {
    context?: HttpContext
    body?: MovieTitleDto
  }
): Observable<MovieDto> {

    return this.apiMoviesPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<MovieDto>) => r.body as MovieDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiMoviesPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiMoviesPost$Json$Response(params?: {
    context?: HttpContext
    body?: MovieTitleDto
  }
): Observable<StrictHttpResponse<MovieDto>> {

    const rb = new RequestBuilder(this.rootUrl, MoviesService.ApiMoviesPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<MovieDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiMoviesPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiMoviesPost$Json(params?: {
    context?: HttpContext
    body?: MovieTitleDto
  }
): Observable<MovieDto> {

    return this.apiMoviesPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<MovieDto>) => r.body as MovieDto)
    );
  }

}
