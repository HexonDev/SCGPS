import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.scss']
})
export class MovieComponent implements OnInit {

  @Input()
  title: string | null | undefined;

  @Input()
  year: string | null | undefined;

  @Input()
  actors: string | null | undefined;

  @Input()
  genres: string | null | undefined;

  @Input()
  plot: string | null | undefined;

  @Input()
  id: number | null | undefined;

  @Input()
  poster: string | null | undefined;

  @Input()
  rating: number | null | undefined;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  navigateToReviews(){
    this.router.navigate(["/reviews", this.id])
  }
}
