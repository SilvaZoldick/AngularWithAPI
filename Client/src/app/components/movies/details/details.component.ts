import { ActivatedRoute, Router } from '@angular/router';
import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { MovieService } from 'src/app/services/movie.service';
import IMovie from 'src/app/models/Movie';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
  movieForm: any;
  isDisabled = true;
  constructor(
    private service: MovieService,
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ){}
  ngOnInit(){
    const id = this.route.snapshot.paramMap.get("id");
    this.service.getMovieById(parseInt(id!)).subscribe((result) => {
      this.FillMovieForm(result);
    })
  }
  OnEditMovie(id: number){
    this.router.navigate([`/movies/edit/${id}`], { relativeTo: this.route })
  }
  FillMovieForm(result: IMovie){
    this.movieForm = new FormGroup({
      title: new FormControl(result.title),
      gender: new FormControl(result.gender),
      duration: new FormControl(result.duration)
    });
  }
}
