import { BikeStatus } from "../_enums/bikeStatus";
import { BikeType } from "../_enums/bikeTypes";

export interface Bike {
  id: number,
  name: string,
  type: BikeType,
  price: number,
  status: BikeStatus
}
