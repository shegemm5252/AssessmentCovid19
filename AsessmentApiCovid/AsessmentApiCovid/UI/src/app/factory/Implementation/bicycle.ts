import { Vehicle } from "../IVehincle";

export class Bicycle implements Vehicle {

  public move(): void {
      console.log("Moving the bicycle!")
  }
}
