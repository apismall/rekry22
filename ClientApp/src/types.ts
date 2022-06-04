export interface weatherData {
    dateTime: Date
    temperatureC: number
    temperatureF: number
    city: string
    summary: string | null
}

export class BaseError extends Error {
	constructor(error: unknown) {
		super(error+'')
	}
}
export class networkRequestError extends BaseError {}