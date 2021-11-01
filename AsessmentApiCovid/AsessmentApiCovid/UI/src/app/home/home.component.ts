import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import { BaseChartDirective, Color, Label } from 'ng2-charts';
import { Notification } from 'rxjs';
import { Nation, Responses } from '../models/response';
import { CoreService } from '../services/core-services';



@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  @ViewChild(BaseChartDirective) chartWidget: BaseChartDirective;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  listOfTransaction = Array<any>();

  isLoading = false;




  public barChartOptions: ChartOptions = {
    responsive: true,
    // We use these empty structures as placeholders for dynamic theming.
    scales: { xAxes: [{}], yAxes: [{}] },
  };
  public barChartLabels: Label[] = [];
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;

  public barChartData: ChartDataSets[] = [
    { data: [], label: 'Dose one' },
    { data: [], label: 'Dose two' }
  ];

  firstDailyDoseSummary: string;
  secondDailyDoseSummary: string;

  totalFirstDoseSummary: string;
  totalSecondDoseSummary: string;

  totalMonthFirstDoseSummary: string;
  totalMonthSecondSummary: string;
  nations = [];
  firstDoseList = [];
  SecondDoseList = [];
  SelectedCountry: Nation;
  SelectedDose: string;
  Dose = [
    'All',
    'First Dose',
    'Second Dose'
  ];
  typeOfGraph: ChartType[] = [
    'bar',
    'line',
    'radar',
    'pie', 'polarArea', 'doughnut', 'bubble', 'scatter'
  ];
  SelectedtypeOfGraph: ChartType;
  graphData = [];
  dataSource: MatTableDataSource<any>;
  // tslint:disable-next-line: max-line-length
  displayedColumns: string[] = ['date', 'areaCode', 'newPeopleVaccinatedFirstDoseByPublishDate', 'cumPeopleVaccinatedFirstDoseByPublishDate'];
  constructor(private api: CoreService, public changeDef: ChangeDetectorRef) { }

  ngOnInit(): void {
    // this.GetFirstDoseDailyPeopleVaccinated();
    // this.GetSecondDoseDailyPeopleVaccinated();
    // this.GetSecondDosePeopleVaccinated();
    // this.GetFirstDosePeopleVaccinated();
    // this.GetMonthSecondDosePeopleVaccinated();
    // this.GetMonthFirstDosePeopleVaccinated();
    this.GetNation();
    this.SelectedDose = this.Dose[0];
    this.SelectedtypeOfGraph = this.typeOfGraph[0];

  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  public chartClicked({ event, active }: { event: MouseEvent, active: {}[] }): void {
    console.log(this.barChartData[0].hidden);
    if (this.barChartData[0].hidden && !this.barChartData[1].hidden) {
      this.SelectedDose = 'Second Dose';
    } else if (!this.barChartData[0].hidden && this.barChartData[1].hidden) {
      this.SelectedDose = 'First Dose';
    } else {
      this.SelectedDose = 'All';
    }
  }

  public chartHovered({ event, active }: { event: MouseEvent, active: {}[] }): void {
    // console.log(event, active);
  }

  public randomize(args: ChartType): void {
    this.barChartType = this.SelectedtypeOfGraph;
    this.chartWidget.update();
  }
  async GetFirstDoseDailyPeopleVaccinated() {
    this.api.SummaryDailyFirstDose(this.SelectedCountry.id).subscribe((res: Responses<{ firstDoseSummary: any }>) => {
      this.firstDailyDoseSummary = this.NumberWithCommas(res.detail.firstDoseSummary);
      this.GetSecondDoseDailyPeopleVaccinated();
    });
  }

  async GetNation() {
    this.api.Nation().subscribe((res: Responses<Array<Nation>>) => {
      this.nations = res.detail;

      this.SelectedCountry = this.nations[0];

      this.onselectionChange('');
    });
  }

  async GetVaccinatedDataFirsDose() {
    this.api.GetVaccinatedDataFirsDose(this.SelectedCountry.id).subscribe((res: Responses<Array<object>>) => {
      this.firstDoseList = res.detail;
      this.dataSource = new MatTableDataSource(this.firstDoseList);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      this.GetVaccinatedDataSecondDose();
    });
  }

  dataTranposed(dataFirstDose: any[], dataSecondDose: any[]): void {
    const listMonth = dataFirstDose.map(x =>
      (new Date(x.date).getMonth()))
      .filter((value, index, categoryArray) => categoryArray.indexOf(value) === index)
      .sort((a, b) => a - b);

    const dataFirst = [];
    this.barChartLabels = [];
    this.barChartData[0].data = [];
    this.barChartData[1].data = [];
    const list: { date: number, amount: number, totalDose1: number, totalDose2: number }[] = [];
    const listValue = [];

    listMonth.forEach((itm) => {
      const i = { date: itm, amount: 0, totalDose1: 0, totalDose2: 0 };
      list.push(i);
    });



    list.forEach(item => {
      const d = dataFirstDose.filter((value) => (new Date(value.date).getMonth()) === item.date);

      let total = 0;

      d.forEach((itms) => {
        total += itms.cumPeopleVaccinatedFirstDoseByPublishDate ?? 0;
      });
      item.totalDose1 = total;
    });

    const listMonthDose = dataSecondDose.map(x =>
      (new Date(x.date).getMonth()))
      .filter((value, index, categoryArray) => categoryArray.indexOf(value) === index)
      .sort((a, b) => a - b);

    listMonthDose.forEach((itm) => {
      if (list.find(x => x.date === itm) === undefined) {
        const i = { date: itm, amount: 0, totalDose1: 0, totalDose2: 0 };
        list.push(i);
      }

    });

    list.forEach(item => {
      const d = dataSecondDose.filter((value) => (new Date(value.date).getMonth()) === item.date);

      let total = 0;

      d.forEach((itms) => {
        total += itms.cumPeopleVaccinatedSecondDoseByPublishDate ?? 0;
      });
      item.totalDose2 = total;
    });

    list.filter((value, index, categoryArray) => categoryArray.indexOf(value) === index);
    list.sort((a, b) => a.date - b.date);
    list.forEach((itm) => {
      this.barChartLabels.push(this.getMonthName(itm.date));
      this.barChartData[0].data.push(itm.totalDose1);
      this.barChartData[1].data.push(itm.totalDose2);
    });

    console.log(list);

  }

  getMonthName(month: number) {
    // tslint:disable-next-line: max-line-length
    const months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
    return months[month];
  }

  async GetVaccinatedDataSecondDose() {
    this.api.GetVaccinatedDataSecondDose(this.SelectedCountry.id).subscribe((res: Responses<Array<object>>) => {
      this.SecondDoseList = res.detail;
      this.dataTranposed(this.firstDoseList, this.SecondDoseList);
    });
  }



  // async GetFirstDoseDailyPeopleVaccinated() {
  //   this.api.SummaryDailyFirstDose().subscribe((res: Responses<{ firstDoseSummary: any }>) => {
  //     this.firstDailyDoseSummary = this.NumberWithCommas(res.detail.firstDoseSummary);
  //   });
  // }

  async GetSecondDoseDailyPeopleVaccinated() {
    this.api.SummaryDailySecondDose(this.SelectedCountry.id).subscribe((res: Responses<{ secondDoseSummary: any }>) => {
      this.secondDailyDoseSummary = this.NumberWithCommas(res.detail.secondDoseSummary);
      this.GetFirstDosePeopleVaccinated();
    });
  }

  async GetSecondDosePeopleVaccinated() {
    this.api.SummaryForSecondDose(this.SelectedCountry.id).subscribe((res: Responses<{ secondDoseSummary: any }>) => {
      this.totalSecondDoseSummary = this.NumberWithCommas(res.detail.secondDoseSummary);
      this.GetVaccinatedDataFirsDose();
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
    this.api.SummaryForFirstDose(this.SelectedCountry.id).subscribe((res: Responses<{ firstDoseSummary: any }>) => {
      this.totalFirstDoseSummary = this.NumberWithCommas(res.detail.firstDoseSummary);
      this.GetSecondDosePeopleVaccinated();
    });
  }


  NumberWithCommas(x): string {
    if (x === undefined) {
      return '0';
    }
    const parts = x.toString().split('.');
    parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ',');
    return parts.join('.');
  }

  onselectionChange(args) {

    this.SummaryFirstDoseMonth(this.SelectedCountry.id);
  }

  onChangeDose(args) {

    console.log(args);
    if (args.value === 'All') {
      this.barChartData[0].hidden = false;
      this.barChartData[1].hidden = false;
    } else if (args.value === 'First Dose') {
      this.barChartData[0].hidden = false;
      this.barChartData[1].hidden = true;
    } else {
      this.barChartData[0].hidden = true;
      this.barChartData[1].hidden = false;
    }

    this.chartWidget.update();
  }

  SummarySecondDoseMonth(code: string) {
    this.api.SummarySecondDoseMonth(code).subscribe((res: Responses<{ secondDoseSummary: any }>) => {
      this.GetFirstDoseDailyPeopleVaccinated();
      this.totalMonthSecondSummary = this.NumberWithCommas(res.detail.secondDoseSummary);
      this.changeDef.detectChanges();
    });
  }

  SummaryFirstDoseMonth(code: string) {
    this.api.SummaryFirstDoseMonth(code).subscribe((res: Responses<{ firstDoseSummary: any }>) => {
      this.totalMonthFirstDoseSummary = this.NumberWithCommas(res.detail.firstDoseSummary);
      this.SummarySecondDoseMonth(this.SelectedCountry.id);
    });
  }
}
