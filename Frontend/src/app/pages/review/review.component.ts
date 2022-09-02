import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ReviewDto } from 'src/app/api/generated/models';
import { ReviewsService } from 'src/app/api/generated/services';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.scss']
})
export class ReviewComponent implements OnInit {

  constructor(private router: Router, private rote: ActivatedRoute, private reviewsService: ReviewsService, private snackBar: MatSnackBar) { }

  private paramsSub: Subscription | undefined;

  id: number | undefined;
  reviewText: string | undefined;

  ngOnInit(): void {
    this.paramsSub = this.rote.params.subscribe(params => {
      this.id = params["id"];
    });
  }

  ngOnDestroy(): void {
    this.paramsSub?.unsubscribe();
  }

  addReview(): void {
    this.reviewsService.apiReviewsPost$Json({ body: {
      movieId: this.id,
      reviewText: this.reviewText
    }}).subscribe(res => {
      this.snackBar.open("Success!", "Ok");
      this.router.navigate(["home"]);
    });
  }
}
