import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { CountryAllocation } from '../models/country-allocation';
import { Etf } from '../models/etf';
import { EtfAllocation } from '../models/etf-allocation';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  private etfAllocationList: EtfAllocation[] = [];
  private allEtfs: Etf[];
  result: Array<CountryAllocation> = new Array<CountryAllocation>();
  //resultNew: Array<CountryAllocation> = new Array<CountryAllocation>();

  constructor(private http: HttpClient){}

  ngOnInit(){
    this.http.get('/api/etfs').subscribe((response:Etf[]) => {
      this.allEtfs = response;
    })
  }

  addEtfAllocation(){
    console.log(this.etfAllocationList);
    this.etfAllocationList.push(new EtfAllocation(this.allEtfs[0], 0));
    console.log(this.etfAllocationList);
  }

  deleteEtfAllocation(index){
    this.etfAllocationList.splice(index, 1);
  }

  calculateAllocation(){
    this.result = [];
    this.etfAllocationList.forEach(etfAlloc => etfAlloc.etf.allocations.forEach(countryAlloc => {
      this.result.push(new CountryAllocation(countryAlloc.country, countryAlloc.allocation * etfAlloc.allocation / 100));
    }));
    this.result.sort((a, b) => b.allocation - a.allocation);
    // this.resultNew.reduce((res, value) => {
    //   if(res[value.country.id]){
    //     res[value.country.id] = new CountryAllocation(value.country, 0);
    //     this.result.push(res[value.country.id]);
    //   }
    //   res[value.country.id].allocation += value.allocation;
    //   return res;
    // }, {});
    //console.log(this.result);
  }
}
