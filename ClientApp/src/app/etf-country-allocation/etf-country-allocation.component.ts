import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Component } from '@angular/core';
import { Country } from '../models/country';
import { Etf } from '../models/etf';
import { EtfCountryAllocation } from '../models/etf-country-allocation';

@Component({
    selector: 'app-etf-country-allocation-component',
    templateUrl: './etf-country-allocation.component.html'
})

export class EtfCountryAllocationComponent {
    private id: string;
    private etf: Etf = null;
    private allCountries: Country[];
    private allocations: EtfCountryAllocation[] = [];

    constructor(private http: HttpClient,
        private activatedRoute: ActivatedRoute) { }

    ngOnInit() {
        this.id = this.activatedRoute.snapshot.params['id'];
        this.http.get('/api/countries').subscribe((response: Country[]) => {
            this.allCountries = response;
        });

        this.http.get(`/api/etfs/${this.id}`).subscribe((etf: Etf) => {
            this.etf = etf;
        });
        this.updateAllocations();
    }

    addAllocation() {
        this.allocations.push(new EtfCountryAllocation(this.etf, this.allCountries[0]));
    }
    saveAllocation() {
        this.allocations.forEach(el => {
            el.countryid = el.country.id;
            el.etfid = el.etf.id;
        });
        this.http.post(`/api/etfcountryallocation/${this.id}`, this.allocations).subscribe(response => {
            this.updateAllocations();
        });
    }
    deleteAllocation(index){
        this.allocations.splice(index, 1);
    }
    updateAllocations() {
        this.http.get(`/api/etfcountryallocation/${this.id}`).subscribe((response: EtfCountryAllocation[]) => {
            this.allocations = response;
            this.allocations.forEach(el => el.country = this.allCountries.find(country => country.id === el.country.id));
        });
    }
}