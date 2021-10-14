import { Bicycle } from "../../Implementation/bicycle";
import { Vehicle } from "../../IVehincle";
import { VehicleHandler } from "../VehicleHandler";

export class BicycleHandler  extends VehicleHandler{

  public createVehicle(): Vehicle {
      return new Bicycle()
  }
}
