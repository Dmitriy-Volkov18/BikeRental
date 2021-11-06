import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { Bike } from './_models/Bike';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  constructor() {}

  ngOnInit(): void {
  }

}
