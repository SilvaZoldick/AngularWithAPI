import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs';
import IMovie from '../models/Movie';

const token: string | null = 'Bearer ' + localStorage.getItem('token');

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': token
  })
}

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  private readonly apiSource = 'http://localhost:5021/api/v1/Movies';

  constructor(private http: HttpClient) {
  }
  getMovies(): Observable<IMovie[]>{
    return this.http.get<IMovie[]>(this.apiSource, httpOptions);
  }
  getMovieById(id: number): Observable<IMovie>{
    const url = `${this.apiSource}/${id}`
    return this.http.get<IMovie>(url, httpOptions);
  }
  postMovie(movie: IMovie): Observable<IMovie>{
    return this.http.post<IMovie>(this.apiSource, movie, httpOptions);
  }
  putMovie(movie: IMovie): Observable<IMovie>{
    const url = `${this.apiSource}/${movie.id}`
    return this.http.put<IMovie>(url, movie, httpOptions);
  }
  deleteMovie(id: number): Observable<any>{
    const url = `${this.apiSource}/${id}`
    return this.http.delete<IMovie>(url, httpOptions);
  }
}
