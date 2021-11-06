import { Component, OnInit } from '@angular/core';
import { BikeType } from '../_enums/bikeTypes';
import { Bike } from '../_models/Bike';
import { BikeService } from '../_services/bike.service';

@Component({
  selector: 'app-free-bikes',
  templateUrl: './free-bikes.component.html',
  styleUrls: ['./free-bikes.component.css']
})
export class FreeBikesComponent implements OnInit {
  bikes: Bike[] = [];
  freeBikesCount: number = 0;

  constructor(private bikeService: BikeService) { }

  ngOnInit(): void {
    this.bikeService.refreshBikes.subscribe(() => {
      this.getFreeBikes();
    })
    this.getFreeBikes();
  }

  getFreeBikes() {
    this.bikeService.getFreeBikes().subscribe(response => {
      this.bikes = response;

      if (!this.bikes) {
        this.freeBikesCount = 0;
      }

      if (this.bikes?.length > 0) {
        this.freeBikesCount = this.bikes.length;

        this.bikes.map(bike => {
          bike.type = BikeType[bike.type] as unknown as BikeType;
        })
      }
    })
  }

  deleteBike(id: number) {
    this.bikeService.deleteBike(id).subscribe((_) => { this.getFreeBikes(); }, (error) => { console.log(error); })
  }

  changeStatus(id: number) {
    this.bikeService.changeStatus(id).subscribe((_) => {  }, (error) => { console.log(error); })
  }
}
