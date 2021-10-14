import { Component, OnInit, ViewChild } from '@angular/core';
import { ChartDataSets } from 'chart.js';
import { Color, Label } from 'ng2-charts';
import { Responses } from '../models/response';
import { CoreService } from '../services/core-services';



@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  listOfTransaction = Array<any>();

  isLoading = false;
  options = {
    tooltip: {
      trigger: 'axis',
      axisPointer: {
        type: 'cross',
        label: {
          backgroundColor: '#6a7985'
        }
      }
    },
    // legend: {
    //   data: ['X-1', 'X-2', 'X-3', 'X-4', 'X-5']
    // },
    grid: {
      left: '3%',
      right: '4%',
      bottom: '3%',
      containLabel: true
    },
    xAxis: [
      {
        type: 'category',
        boundaryGap: false,
        data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
      }
    ],
    yAxis: [
      {
        type: 'value'
      }
    ],
    series: [
      {
        name: 'X-1',
        type: 'line',
        stack: 'counts',
        areaStyle: { normal: {} },
        data: [120, 132, 101, 134, 90, 230, 210]
      },
      {
        name: 'X-2',
        type: 'line',
        stack: 'counts',
        areaStyle: { normal: {} },
        data: [220, 182, 191, 234, 290, 330, 310]
      },
      {
        name: 'X-3',
        type: 'line',
        stack: 'counts',
        areaStyle: { normal: {} },
        data: [150, 232, 201, 154, 190, 330, 410]
      },
      {
        name: 'X-4',
        type: 'line',
        stack: 'counts',
        areaStyle: { normal: {} },
        data: [320, 332, 301, 334, 390, 330, 320]
      },
      {
        name: 'X-5',
        type: 'line',
        stack: 'counts',
        label: {
          normal: {
            show: true,
            position: 'top'
          }
        },
        areaStyle: { normal: {} },
        data: [820, 932, 901, 934, 1290, 1330, 1320]
      }
    ]
  };

  lineChartData: ChartDataSets[] = [
    { data: [85, 72, 78, 75, 77, 75], label: 'Crude oil prices' },
  ];
  lineChartLabels: Label[] = ['January', 'February', 'March', 'April', 'May', 'June'];

  lineChartOptions = {
    responsive: true,
  };

  lineChartColors: Color[] = [
    {
      borderColor: 'black',
      backgroundColor: 'rgba(255,255,0,0.28)',
    },
  ];

  lineChartLegend = true;
  lineChartPlugins = [];
  lineChartType = 'line';

  firstDailyDoseSummary: string;
  secondDailyDoseSummary: string;

  totalFirstDoseSummary: string;
  totalSecondDoseSummary: string;

  totalMonthFirstDoseSummary: string;
  totalMonthSecondSummary: string;

  constructor(private api: CoreService) { }

  ngOnInit(): void {
    this.GetFirstDoseDailyPeopleVaccinated();
    this.GetSecondDoseDailyPeopleVaccinated();
    this.GetSecondDosePeopleVaccinated();
    this.GetFirstDosePeopleVaccinated();
    this.GetMonthSecondDosePeopleVaccinated();
    this.GetMonthFirstDosePeopleVaccinated();
  }

  async GetFirstDoseDailyPeopleVaccinated() {
    this.api.SummaryDailyFirstDose().subscribe((res: Responses<{ firstDoseSummary: any }>) => {
      this.firstDailyDoseSummary = this.NumberWithCommas(res.detail.firstDoseSummary);
    });
  }

  async GetSecondDoseDailyPeopleVaccinated() {
    this.api.SummaryDailySecondDose().subscribe((res: Responses<{ secondDoseSummary: any }>) => {
      this.secondDailyDoseSummary = this.NumberWithCommas(res.detail.secondDoseSummary);
    });
  }

  async GetSecondDosePeopleVaccinated() {
    this.api.SummaryForSecondDose().subscribe((res: Responses<{ secondDoseSummary: any }>) => {
      this.totalSecondDoseSummary = this.NumberWithCommas(res.detail.secondDoseSummary);
    });
  }

  async GetMonthFirstDosePeopleVaccinated() {
    this.api.SummaryMonthFirstDose().subscribe((res: Responses<{ firstDoseSummary: any }>) => {
      this.totalMonthFirstDoseSummary = this.NumberWithCommas(res.detail.firstDoseSummary);
    });
  }

  async GetMonthSecondDosePeopleVaccinated() {
    this.api.SummaryMonthSecondDose().subscribe((res: Responses<{ secondDoseSummary: any }>) => {
      console.log(res);
      this.totalMonthSecondSummary = this.NumberWithCommas(res.detail.secondDoseSummary);
    });
  }

  async GetFirstDosePeopleVaccinated() {
    this.api.SummaryForFirstDose().subscribe((res: Responses<{ firstDoseSummary: any }>) => {
      this.totalFirstDoseSummary = this.NumberWithCommas(res.detail.firstDoseSummary);
    });
  }


  NumberWithCommas(x): string {
    const parts = x.toString().split('.');
    parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ',');
    return parts.join('.');
  }
}
