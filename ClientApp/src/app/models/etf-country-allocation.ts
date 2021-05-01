import { Country } from "./country";
import { Etf } from "./etf";
export class EtfCountryAllocation{
    etf: Etf;
    country: Country;
    allocation: number;
    public etfid: string;
    public countryid: string;

    constructor(etf: Etf, country: Country, allocation: number = 0){
        this.etf = etf;
        this.country = country;
        this.allocation = allocation;
    }
}