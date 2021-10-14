import { Vehicle } from "../IVehincle";

export class Plane implements Vehicle {

  public move(): void {
      console.log("Flying the plane!")
  }
}
