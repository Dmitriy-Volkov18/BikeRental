import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BikeService } from '../_services/bike.service';

@Component({
  selector: 'app-add-bike-form',
  templateUrl: './add-bike-form.component.html',
  styleUrls: ['./add-bike-form.component.css']
})
export class AddBikeFormComponent implements OnInit {
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

  editMode: boolean = false;
  editId: number = 0;

  constructor(private bikeService: BikeService) { }

  ngOnInit(): void {
    this.bikeService.refreshUpdateBikes.subscribe(response => {
      this.editMode = true;
      var key = "";

      this.bikeTypes.forEach(type => {
        key = type.key;
        this.editId = response.id;
      })
      
      this.addBikeForm.controls['name'].setValue(response.currentValues.name);
      this.addBikeForm.controls['type'].setValue(key);
      this.addBikeForm.controls['price'].setValue(response.currentValues.price);
    })
  }

  onSubmit() {
    if (this.editMode) {
      this.bikeService.updateBike(this.editId, this.addBikeForm.value).subscribe(_ => {
        this.bikeService.refreshBikes.next();
        this.reset();
        this.editMode = false;
      }, error => {
        console.log(error);
      });
    } else {
      this.bikeService.addBike(this.addBikeForm.value).subscribe(_ => {
        this.reset();
        this.editMode = false;
      }, error => {
        console.log(error);
      });
    }

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
