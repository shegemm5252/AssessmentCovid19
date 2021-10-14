import { Vehicle } from "../IVehincle"

export abstract class VehicleHandler {

  //This is the method real handlers need to implement
  public abstract createVehicle(): Vehicle

  //This is the method we care about, the rest of the business logic resides here
  public moveVehicle(): void {
      const myVehicle = this.createVehicle()
      myVehicle.move()
  }
}
