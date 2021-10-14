import { Page } from "./menu-model";


export const Menu_Items: Page[] = [
  {
    name: 'Main',
    menu: [
      {
        title: 'Summary',
        link: '/overview',
        icon: 'assets/icons/overview.svg',
        active: true
      }
    ]
  },
  {
    name: 'Cases',
    menu: [
      {
        title: 'Testing',
        link: '',
        icon: 'assets/icons/allPayment.svg'
      },
      {
        title: 'Cases',
        link: '',
        icon: 'assets/icons/reconcilledPayment.svg'
      },
      {
        title: 'Health Care',
        link: '',
        icon: 'assets/icons/unReconcilledPayment.svg'
      },
      {
        title: 'Vaccination',
        link: '',
        icon: 'assets/icons/manualSettlement.svg'
      },
      {
        title: 'Deaths',
        link: '',
        icon: 'assets/icons/allOrder.svg'
      }
    ]
  },
  // {
  //   name: 'Orders',
  //   menu: [
  //     {
  //       title: 'All Orders',
  //       link: '',
  //       icon: 'assets/icons/allOrder.svg'
  //     },
  //     {
  //       title: 'Pending Orders',
  //       link: '',
  //       icon: 'assets/icons/pendingOrder.svg'
  //     },
  //     {
  //       title: 'Reconciled Orders',
  //       link: '',
  //       icon: 'assets/icons/reconcilledOrder.svg'
  //     }
  //   ]
  // },
  // {
  //   name: '',
  //   menu: [
  //     {
  //       title: 'Merchant Profile',
  //       link: '',
  //       icon: 'assets/icons/merchant.svg'
  //     }
  //   ]
  // }
]
