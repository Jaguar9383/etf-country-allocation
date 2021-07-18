import { Country } from "./country";

export class CountryAllocation{
    country: Country;
    allocation: number;

    constructor(country: Country, allocation: number){
        this.country = country;
        this.allocation = allocation;
    }
}