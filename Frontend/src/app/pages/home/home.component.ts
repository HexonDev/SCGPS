import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MovieDto } from 'src/app/api/generated/models';
import { MoviesService } from 'src/app/api/generated/services';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private moviesService: MoviesService, private snackBar: MatSnackBar) { }

  movies: MovieDto[] | null | undefined = [];
  movieTitle: string | undefined;
  
  ngOnInit(): void {
    this.getMovies();
  }

  addMovie(): void {
    if((this.movieTitle?.length ?? 0) === 0){
      this.snackBar.open("Movie title cannot be empty!", "Ok");
      return;
    }

    this.moviesService.apiMoviesPost$Json({ body: { title: this.movieTitle }}).subscribe(res => {
      this.getMovies();
    })
  }

  getMovies(): void {
    this.moviesService.apiMoviesGet$Json().subscribe(res => {
      this.movies = res.movies;
    })
  }
}
