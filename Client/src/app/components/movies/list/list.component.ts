import IMovie from 'src/app/models/Movie';
import { MovieDialogComponent } from './../../shared/movie-dialog/movie-dialog.component';
import { ActivatedRoute, Router } from '@angular/router';
import { Component } from '@angular/core';
import { MovieService } from 'src/app/services/movie.service';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent {

  movieList: IMovie[] = [];
  displayedColumns: string[] = ['title', 'gender', 'duration', 'actions'];

  constructor(
    private service: MovieService,
    private router: Router,
    private route: ActivatedRoute,
    public dialog: MatDialog
    ){}

  ngOnInit() : void{
    this.service.getMovies().subscribe((result) => {
      this.movieList = result;
    });
  }
  openDialog(movie: IMovie | null) {
    const dialogRef = this.dialog.open(MovieDialogComponent, {
      data: movie != null ?
      movie: {
        id: 0,
        title: '',
        gender: 0,
        duration: 0
      }
    });
    dialogRef.afterClosed().subscribe(result => {
    });
  }
  OnDeleteMovie(id?: number){
    if(confirm("Do you really wanna delete this movie?")){
      this.service.deleteMovie(id!).subscribe((result) => {
        window.location.reload();
      });
    }
  }
}
