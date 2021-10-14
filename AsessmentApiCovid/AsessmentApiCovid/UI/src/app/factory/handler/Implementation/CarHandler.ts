import { Car } from "../../Implementation/car";
import { Vehicle } from "../../IVehincle";
import { VehicleHandler } from "../VehicleHandler";

export class CarHandler  extends VehicleHandler{

  public createVehicle(): Vehicle {
      return new Car();
  }
}
