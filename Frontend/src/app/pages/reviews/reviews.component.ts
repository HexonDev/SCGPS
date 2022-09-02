import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { ReviewDto } from 'src/app/api/generated/models';
import { ReviewsService } from 'src/app/api/generated/services';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.scss']
})
export class ReviewsComponent implements OnInit, OnDestroy {

  constructor(private rote: ActivatedRoute, private reviewsService: ReviewsService) { }

  private paramsSub: Subscription | undefined;

  id: number | undefined;
  reviews: ReviewDto[] | undefined | null = [];

  ngOnInit(): void {
    this.paramsSub = this.rote.params.subscribe(params => {
      this.id = params["id"];

      this.getReviews();
    });
  }

  ngOnDestroy(): void {
    this.paramsSub?.unsubscribe();
  }

  getReviews(): void {
    this.reviewsService.apiReviewsGet$Json({ movieId: this.id }).subscribe(res => {
      this.reviews = res.reviews;
    });
  }
}
