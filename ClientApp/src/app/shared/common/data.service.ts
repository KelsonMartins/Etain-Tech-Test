import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Location } from '../models/location';
import { WeatherForecast } from '../models/weatherForecast';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  location: Location[];
  apiBaseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiBaseUrl = `${baseUrl}api/weatherforecast`;
  }

  getLocation(query: string): Observable<Location[]> {
    const url = `${this.apiBaseUrl}/location/${query}`;

    return this.http.get<Location[]>(url)
      .pipe(
        catchError(
          (error: any): Observable<Location[]> => {
            // Log to console
            console.error(error);
            // Let the app keep running by returning an empty result.
            return of([]);
          }));
  }

  getWeatherForecast(query: string): Observable<WeatherForecast[]> {
    const url = `${this.apiBaseUrl}/${query}`;

    return this.http.get<WeatherForecast[]>(url)
      .pipe(
        catchError(
          (error: any): Observable<WeatherForecast[]> => {
            // Log to console
            console.error(error);
            // Let the app keep running by returning an empty result.
            return of([]);
          }));
  }

}
