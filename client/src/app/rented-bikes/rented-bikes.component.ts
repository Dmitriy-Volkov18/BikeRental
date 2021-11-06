import { Component, OnInit } from '@angular/core';
import { BikeType } from '../_enums/bikeTypes';
import { Bike } from '../_models/Bike';
import { BikeService } from '../_services/bike.service';

@Component({
  selector: 'app-rented-bikes',
  templateUrl: './rented-bikes.component.html',
  styleUrls: ['./rented-bikes.component.css']
})
export class RentedBikesComponent implements OnInit {
  bikes: Bike[] = [];
  totalCost: number = 0;
  rentedBikesCount: number = 0;

  constructor(private bikeService: BikeService) { }

  ngOnInit(): void {
    this.bikeService.refreshBikes.subscribe(() => {
      this.getRentedBikes();
    })
    this.getRentedBikes();
  }

  getRentedBikes() {
    this.bikeService.getRentedBikes().subscribe(response => {
      this.bikes = response;

      if (!this.bikes) {
        this.rentedBikesCount = 0;
        this.totalCost = 0;
      }

      if (this.bikes?.length > 0) {
        this.rentedBikesCount = this.bikes.length;

        this.bikes.map(bike => {
          bike.type = BikeType[bike.type] as unknown as BikeType;
        })

        this.totalCost = this.getTotalPrice(this.bikes);
      }
    })
  }

  changeStatus(id: number) {
    this.bikeService.changeStatus(id).subscribe((_) => {}, (error) => { console.log(error); })
  }

  getTotalPrice(items: Bike[]) {
    return items.reduce((total, item) => item.price + total, 0)
  }
}
