export interface weatherData {
    dateTime: Date
    temperatureC: number
    temperatureF: number
    city: string
    summary: string | null
}

export interface invoiceData {
    Id: number
    Date: Date
    DueDate: Date
    Sum: number
    Customer: string
}

export class BaseError extends Error {
    constructor(error: unknown) {
        super(error + '')
    }
}
export class networkRequestError extends BaseError { }