import { Component, OnInit } from '@angular/core';
import { Menu_Items } from './app-menu';
import { Page } from './menu-model';

@Component({
  selector: 'app-side',
  templateUrl: './side.component.html',
  styleUrls: ['./side.component.scss']
})
export class SideComponent implements OnInit {

  ListMenu: Page[];
  constructor() {
    this.ListMenu = Menu_Items;
  }

  ngOnInit(): void {
  }

}
