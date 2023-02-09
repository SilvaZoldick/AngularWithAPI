import { ActivatedRoute, Router } from '@angular/router';
import { Component, Input } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { MovieService } from 'src/app/services/movie.service';
import IMovie from 'src/app/models/Movie';

@Component({
  selector: 'app-movie',
  templateUrl: './movie.component.html',
  styleUrls: ['./movie.component.css']
})
export class MovieComponent {
  @Input()
  pageName: string = "";

  id: number | null = 0;
  movieForm: any = new FormGroup({
    title: new FormControl(null),
    gender: new FormControl(null),
    duration: new FormControl(null)
  });
  isDisabled: boolean = false;

  constructor(
    private service: MovieService,
    private route: ActivatedRoute,
    private router: Router
  ){}

  ngOnInit(){
    this.isDisabled = this.pageName == "Details";
    this.FillMovieForm();
  }
  FillMovieForm(){
    const paramId = this.route.snapshot.paramMap.get("id");
    if (paramId != null){
      this.id = parseInt(paramId);
      this.service.getMovieById(this.id).subscribe((result) => {
        this.GenerateFormControl(result);
      });
    }
  }
  GenerateFormControl(result: IMovie){
    if (this.pageName != "Create") {
      this.movieForm = new FormGroup({
        title: new FormControl({value: result.title, disabled: this.isDisabled}),
        gender: new FormControl({value: result.gender, disabled: this.isDisabled}),
        duration: new FormControl({value: result.duration, disabled: this.isDisabled}),
      });
    }
  }

  OnCreateMovie(): void{
    const movie: IMovie = this.movieForm.value;
    this.service.postMovie(movie).subscribe((result) => {
      alert("Movie registered!")
      this.router.navigate([`/movies/${result.id}`]);
    });
  }
  OnEditMovie(){
    this.router.navigate([`/movies/edit/${this.id}`], { relativeTo: this.route })
  }
  OnSaveMovie(): void{
    if(this.id == 0){
      this.service.postMovie(this.movieForm).subscribe((result) => {
        alert("Movie created");
        this.router.navigate([`/movies/${result.id}`]);
      })
    }
    else{
      this.service.putMovie(this.movieForm).subscribe((result) => {
        alert("Movie edited");
        this.router.navigate([`/movies/${result.id}`]);
      });
    }
  }
  OnCancel(): void {
    this.router.navigate(['/movies'])
  }
}
