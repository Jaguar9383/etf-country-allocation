import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Country } from '../models/country';

@Component({
  selector: 'app-countries-component',
  templateUrl: './countries.component.html'
})

export class CountriesComponent{
    countries: Country[] = null;
    newCountry: string = "";

    constructor(private http: HttpClient){}

    ngOnInit(): void{
      this.UpdateCountryList();
    }

    addCountry(){
      this.http.post('/api/countries/add', { name: this.newCountry }, { responseType: 'text'}).subscribe(response => {
        this.UpdateCountryList();
      })
    }

    UpdateCountryList(){
      this.http.get('/api/countries').subscribe((response:Country[]) => {
        this.countries = response;
      });
    }
}