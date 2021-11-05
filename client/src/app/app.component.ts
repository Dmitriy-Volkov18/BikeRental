import { HttpClient } from '@angular/common/http';
import { OnInit } from '@angular/core';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
 
  title = 'Bike Rental';

  bikes: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getBikes();
  }

  getBikes() {
    this.http.get("https://localhost:5001/bikerental/all-bikes").subscribe(response => {
      this.bikes = response;
      console.log(this.bikes);
    }, error => {
      console.log(error);
    })
  }
}
