import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DataService } from '../shared/common/data.service';
import { WeatherForecast } from '../shared/models/weatherForecast';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  results$: Observable<WeatherForecast[]>;
  selectedDay: WeatherForecast;
  location = 'Belfast';

  constructor(private data: DataService) { }

  ngOnInit() {
    this.results$ = this.data.getWeatherForecast(this.location);
  }

  getIcon(state: string) {
    return `https://www.metaweather.com/static/img/weather/${state}.svg`;
  }

  onSelect(forecast: WeatherForecast): void {
    this.selectedDay = forecast;
  }

  closeDetail(): void {
    this.selectedDay = null;
  }

}
