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
  etfAllocationList: EtfAllocation[] = [];
  allEtfs: Etf[];
  result: CountryAllocation[] = [];

  constructor(private http: HttpClient){}

  ngOnInit(){
    this.http.get('/api/etfs').subscribe((response:Etf[]) => {
      this.allEtfs = response;
    })
  }

  addEtfAllocation(){
    this.etfAllocationList = [...this.etfAllocationList, new EtfAllocation(null, 0)];
  }

  deleteEtfAllocation(index){
    this.etfAllocationList.splice(index, 1);
  }

  calculateAllocation(){
    let allAllocations: CountryAllocation[] = [];
    this.etfAllocationList.forEach(etfAlloc => etfAlloc.etf.allocations.forEach(countryAlloc => {
      let allocation: number = countryAlloc.allocation * etfAlloc.allocation / 100;
      var countryAllocation: CountryAllocation = new CountryAllocation(countryAlloc.country, allocation);
      allAllocations.push(countryAllocation);
    }));
    const result: any[] = Object.values(allAllocations.reduce((r, o) => (r[o.country.id]
      ? (r[o.country.id].allocation += o.allocation)
      : (r[o.country.id] = {...o}), r), {}));
    result.map(el => new CountryAllocation(el.country, el.allocation));
    this.result = result.sort((a, b) => b.allocation - a.allocation);
  }
}
