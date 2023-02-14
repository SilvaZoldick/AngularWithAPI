import MovieResponse from 'src/app/models/movies/MovieResponse';
import { MovieService } from 'src/app/services/movie.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Component, Inject, OnInit } from '@angular/core';
import Movie from 'src/app/models/movies/Movie';

@Component({
  selector: 'app-movie-dialog',
  templateUrl: './movie-dialog.component.html',
  styleUrls: ['./movie-dialog.component.css']
})
export class MovieDialogComponent implements OnInit {
  isChange!: boolean;
  constructor(
    private service: MovieService,
    public MatDialogRef: MatDialogRef<Movie>,
    @Inject(MAT_DIALOG_DATA) public data: MovieResponse
  ) { }

  ngOnInit(): void{
    this.isChange = this.data.id != 0;
  }
  onCreate(){
    this.service.postMovie(this.data).subscribe((result) => {
      console.log(this.data)
      alert("Movie created");
    });
  }
  onSave(){
    this.service.putMovie(this.data.id, this.data).subscribe((result) => {
      console.log(this.data)
      alert("Movie updated");
    });
  }
  onCancel(){
    this.MatDialogRef.close();
  }
}
