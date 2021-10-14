import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'component-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  titleName: string;
  constructor() { }

  ngOnInit(): void {
    this.titleName = ''
  }
  ngDoCheck() {
    // if(location.pathname === '/survey-question'){
    //   this.titleName = 'Simple Survey Question';

    // } else {
    //   this.titleName = 'Survey Application';
    // }
  }

}
