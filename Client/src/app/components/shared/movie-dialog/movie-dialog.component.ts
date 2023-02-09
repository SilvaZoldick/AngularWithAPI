import { MovieService } from 'src/app/services/movie.service';
import { HttpClient } from '@angular/common/http';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Component, Inject, OnInit } from '@angular/core';
import IMovie from 'src/app/models/Movie';

@Component({
  selector: 'app-movie-dialog',
  templateUrl: './movie-dialog.component.html',
  styleUrls: ['./movie-dialog.component.css']
})
export class MovieDialogComponent implements OnInit {
  isChange!: boolean;
  constructor(
    private service: MovieService,
    public MatDialogRef: MatDialogRef<IMovie>,
    @Inject(MAT_DIALOG_DATA) public data: IMovie,
  ) { }

  ngOnInit(): void{
    console.log(this.data.id)
    this.isChange = this.data.id != 0;
  }
  onCreate(){
    this.service.postMovie(this.data).subscribe((result) => {
      alert("Movie created");
    });
    this.MatDialogRef.close();
  }
  onSave(){
    this.service.putMovie(this.data).subscribe((result) => {
      alert("Movie updated");
    });
    this.MatDialogRef.close();
  }
  onCancel(){
    this.MatDialogRef.close();
  }
}
