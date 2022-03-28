import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CountriesComponent } from './countries/countries.component';
import { EtfsComponent } from './etfs/etfs.component';
import { EtfSettingsComponent } from './etf-settings/etf-settings.component';
import { EtfCountryAllocationComponent } from "./etf-country-allocation/etf-country-allocation.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CountriesComponent,
    EtfsComponent,
    EtfSettingsComponent,
    EtfCountryAllocationComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgSelectModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'countries', component: CountriesComponent },
      { path: 'etfs', component: EtfsComponent },
      { path: 'etfs/etf-settings/:id', component: EtfSettingsComponent },
      { path: 'etfs/etf-country-allocation/:id', component: EtfCountryAllocationComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
