import { Vehicle } from "../IVehincle";

export class Car implements Vehicle {

  public move(): void {
      console.log("Moving the car!")
  }
}
