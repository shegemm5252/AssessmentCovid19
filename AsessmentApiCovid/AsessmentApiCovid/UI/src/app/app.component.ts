import { Component } from '@angular/core';
import { CarHandler } from './factory/handler/Implementation/CarHandler';
import { PlaneHandler } from './factory/handler/Implementation/PlaneHandler';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'angular-covid19-tracker2';

  ngOnInit() {
    const planes = new PlaneHandler()
    const cars = new CarHandler()

    planes.moveVehicle()
    cars.moveVehicle()
  }
}
