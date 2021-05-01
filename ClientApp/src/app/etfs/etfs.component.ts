import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Etf } from '../models/etf';

@Component({
    selector: 'app-etfs-component',
    templateUrl: './etfs.component.html'
})

export class EtfsComponent {
    etfs: Etf[] = null;
    newEtf: string = "";

    constructor(private http: HttpClient){}

    ngOnInit(){
        this.UpdateEtfList();
    }
    addEtf(){
        this.http.post('/api/etfs/add', { name: this.newEtf }, { responseType: 'text'}).subscribe(response => {
          this.UpdateEtfList();
        })
      }
  
      UpdateEtfList(){
        this.http.get('/api/etfs').subscribe((response:Etf[]) => {
          this.etfs = response;
        });
      }
}