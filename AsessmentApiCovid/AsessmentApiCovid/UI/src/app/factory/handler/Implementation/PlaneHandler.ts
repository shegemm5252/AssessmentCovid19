import { Plane } from "../../Implementation/plane";
import { Vehicle } from "../../IVehincle";
import { VehicleHandler } from "../VehicleHandler";

export class PlaneHandler extends VehicleHandler{

  public createVehicle(): Vehicle {
      return new Plane()
  }
}
