import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BikeService } from '../_services/bike.service';

@Component({
  selector: 'app-add-bike-form',
  templateUrl: './add-bike-form.component.html',
  styleUrls: ['./add-bike-form.component.css']
})
export class AddBikeFormComponent {
  @ViewChild("addBikeForm") addBikeForm!: NgForm;

  bikeTypes = [
    { key: "0", value: "Road" },
    { key: "1", value: "Mountain" },
    { key: "2", value: "Touring" },
    { key: "3", value: "Track" },
    { key: "4", value: "Bmx" },
    { key: "5", value: "Hybrid" },
    { key: "6", value: "Cruiser" },
    { key: "7", value: "Folding" },
    { key: "8", value: "Kids" },
  ];

  selectedElement = {
    key: "0",
    Name: "Road"
  };

  constructor(private bikeService: BikeService) { }

  onSubmit() {
    this.bikeService.addBike(this.addBikeForm.value).subscribe(_ => {
      this.reset();
    }, error => {
      console.log(error);
    });
  }

  reset() {
    this.addBikeForm.controls['name'].reset();
    this.addBikeForm.controls['price'].reset();

    this.selectedElement = {
      key: "0",
      Name: "Road"
    };
  }
}
