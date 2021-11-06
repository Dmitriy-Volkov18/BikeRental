import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { environment } from '../../environments/environment';
import { Bike } from '../_models/Bike';
import { tap } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class BikeService {
  baseUrl: string = environment.httpUrl;
  private _refreshedBikes$ = new Subject<void>();

  constructor(private http: HttpClient) { }

  get refreshBikes() {
    return this._refreshedBikes$;
  }

  getFreeBikes(): Observable<Bike[]> {
    return this.http.get<Bike[]>(this.baseUrl + "free-bikes");
  }

  getRentedBikes(): Observable<Bike[]> {
    return this.http.get<Bike[]>(this.baseUrl + "rented-bikes");
  }

  addBike(newBike: Bike): Observable<Bike> {
    return this.http.post<Bike>(this.baseUrl, newBike).pipe(
      tap(() => {
        this.refreshBikes.next();
      }));
  }

  deleteBike(id: number): Observable<Bike> {
    return this.http.delete<Bike>(this.baseUrl + id);
  }

  changeStatus(id: number): Observable<Bike> {
    return this.http.put<Bike>(this.baseUrl + "change-bike-status/" + id, {}).pipe(
      tap(() => {
        this.refreshBikes.next();
      }));
  }
}
