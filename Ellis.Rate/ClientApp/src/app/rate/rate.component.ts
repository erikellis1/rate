import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-rate',
  templateUrl: './rate.component.html',
  styleUrls: ['./rate.component.css']
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
    if (this.currentName === null) { return; }
    if (this.currentRating === null) { return; }

    this.http.post<RatedItemViewModel>(this.baseUrl + 'api/rate',
      {
         name: this.currentName,
         rating: this.currentRating
      })
      .subscribe(result => {
        this.ratings.push({ id: result.id, name: result.name, rating: result.rating });
      }, error => console.error(error));

    this.currentRating = null;
    this.currentName = null;
  }

  update(rating: RatedItemViewModel) {
    this.http.put<RatedItemViewModel>(this.baseUrl + 'api/rate/' + rating.id,
        {
          name: rating.name,
          rating: rating.rating
        })
      .subscribe(result => {
        rating.name = result.name;
        rating.rating = result.rating;
      }, error => console.error(error));

  }

  delete(rating: RatedItemViewModel) {
    this.http.delete(this.baseUrl + 'api/rate/' + rating.id)
      .subscribe(result => {
        this.ratings = this.ratings.filter(x => x !== rating);
      }, error => console.error(error));

  }
}

interface RatedItemViewModel {
  id?: number;
  name: string;
  rating?: number;
}
