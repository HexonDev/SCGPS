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

import { ReviewDto } from '../models/review-dto';
import { ReviewsDto } from '../models/reviews-dto';

@Injectable({
  providedIn: 'root',
})
export class ReviewsService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiReviewsGet
   */
  static readonly ApiReviewsGetPath = '/api/Reviews';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiReviewsGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiReviewsGet$Plain$Response(params?: {
    movieId?: number;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<ReviewsDto>> {

    const rb = new RequestBuilder(this.rootUrl, ReviewsService.ApiReviewsGetPath, 'get');
    if (params) {
      rb.query('movieId', params.movieId, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ReviewsDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiReviewsGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiReviewsGet$Plain(params?: {
    movieId?: number;
    context?: HttpContext
  }
): Observable<ReviewsDto> {

    return this.apiReviewsGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<ReviewsDto>) => r.body as ReviewsDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiReviewsGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiReviewsGet$Json$Response(params?: {
    movieId?: number;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<ReviewsDto>> {

    const rb = new RequestBuilder(this.rootUrl, ReviewsService.ApiReviewsGetPath, 'get');
    if (params) {
      rb.query('movieId', params.movieId, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<ReviewsDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiReviewsGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiReviewsGet$Json(params?: {
    movieId?: number;
    context?: HttpContext
  }
): Observable<ReviewsDto> {

    return this.apiReviewsGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<ReviewsDto>) => r.body as ReviewsDto)
    );
  }

  /**
   * Path part for operation apiReviewsPost
   */
  static readonly ApiReviewsPostPath = '/api/Reviews';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiReviewsPost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiReviewsPost$Plain$Response(params?: {
    context?: HttpContext
    body?: ReviewDto
  }
): Observable<StrictHttpResponse<ReviewDto>> {

    const rb = new RequestBuilder(this.rootUrl, ReviewsService.ApiReviewsPostPath, 'post');
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
        return r as StrictHttpResponse<ReviewDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiReviewsPost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiReviewsPost$Plain(params?: {
    context?: HttpContext
    body?: ReviewDto
  }
): Observable<ReviewDto> {

    return this.apiReviewsPost$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<ReviewDto>) => r.body as ReviewDto)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiReviewsPost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiReviewsPost$Json$Response(params?: {
    context?: HttpContext
    body?: ReviewDto
  }
): Observable<StrictHttpResponse<ReviewDto>> {

    const rb = new RequestBuilder(this.rootUrl, ReviewsService.ApiReviewsPostPath, 'post');
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
        return r as StrictHttpResponse<ReviewDto>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiReviewsPost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiReviewsPost$Json(params?: {
    context?: HttpContext
    body?: ReviewDto
  }
): Observable<ReviewDto> {

    return this.apiReviewsPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<ReviewDto>) => r.body as ReviewDto)
    );
  }

}
