import { Etf } from "./etf";

export class EtfAllocation {
    etf: Etf;
    allocation: number;

    constructor(etf: Etf, allocation: number) {
        this.etf = etf;
        this.allocation = allocation;
    }
}
