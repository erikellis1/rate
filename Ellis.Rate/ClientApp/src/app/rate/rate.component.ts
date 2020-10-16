import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-rate',
  templateUrl: './rate.component.html'
})
export class RateComponent {
  public currentName: string;
  public currentRating: number;

  public ratings: RatedItemViewModel[];

  http: HttpClient;
  baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;

    this.getAll();
  }

  getAll() {
    this.http.get<RatedItemViewModel[]>(this.baseUrl + 'api/rate').subscribe(result => {
      this.ratings = result;
    }, error => console.error(error));
  }

  add() {

    this.ratings.push({ id: 10, name: this.currentName, rating: this.currentRating });

    this.currentRating = null;
    this.currentName = null;

  }
  
}

interface RatedItemViewModel { 
  id?: number;
  name: string;
  rating?: number;
}
