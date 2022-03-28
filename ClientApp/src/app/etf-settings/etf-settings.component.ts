import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Etf } from '../models/etf';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-etf-settings-component',
    templateUrl: './etf-settings.component.html'
})

export class EtfSettingsComponent {
    id: string = null;
    dataUrl: string = null;
    autoUpload: boolean = false;
    etf: Etf = null;

    constructor(private http: HttpClient, private activatedRoute: ActivatedRoute) {}

    ngOnInit() {
        this.id = this.activatedRoute.snapshot.params['id'];
        this.getEtfSettings();
    }

    getEtfSettings() {
        this.http.get(`/api/etfs/${this.id}`).subscribe((response: Etf) => {
            this.etf = response;
            this.dataUrl = response.dataUrl;
            this.autoUpload = response.autoUpload;
        });
    }

    saveEtfSettings() {
        this.etf.dataUrl = this.dataUrl;
        this.etf.autoUpload = this.autoUpload;
        this.http.put(`/api/etfs/${this.id}`, this.etf).subscribe((response: any) => {
            console.log(response);
        });
    }
}