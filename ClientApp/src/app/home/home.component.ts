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

  constructor(private http: HttpClient){}

  ngOnInit(){
    this.http.get('/api/etfs').subscribe((response:Etf[]) => {
      this.allEtfs = response;
    })
  }

  addEtfAllocation(){
    this.etfAllocationList.push(new EtfAllocation(this.allEtfs[0], 0));
  }

  deleteEtfAllocation(index){
    this.etfAllocationList.splice(index, 1);
  }

  calculateAllocation(){
    let allAllocations: CountryAllocation[] = [];
    let result: CountryAllocation[] = [];
    this.etfAllocationList.forEach(etfAlloc => etfAlloc.etf.allocations.forEach(countryAlloc => {
      allAllocations.push(new CountryAllocation(countryAlloc.country, countryAlloc.allocation * etfAlloc.allocation / 100));
    }));
    allAllocations.reduce(function(res, value) {
      if (!res[value.country.id]) {
        res[value.country.id] = value;
        result.push(res[value.country.id])
      }
      res[value.country.id].allocation += value.allocation;
      return res;
    }, {});
    this.result = result.sort((a, b) => b.allocation - a.allocation);
  }
}
