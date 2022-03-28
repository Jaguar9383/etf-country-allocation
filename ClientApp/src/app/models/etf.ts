import { CountryAllocation } from "./country-allocation";

export class Etf{
    id: string;
    name: string;
    dataUrl: string;
    autoUpload: boolean;
    allocations: CountryAllocation[];
}