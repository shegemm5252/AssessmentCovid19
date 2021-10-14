
export interface Page {
  name: string;
  menu: Array<MenuModel>;
}

export interface MenuModel {
  title: string;
  icon: string;
  link: string;
  active?: boolean;
}
