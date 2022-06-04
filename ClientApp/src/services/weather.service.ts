import { networkRequestError, weatherData } from '@/types'
import axios, { AxiosResponse } from 'axios'

export async function getWeather(): Promise<weatherData[] | networkRequestError> {
    //const url = import.meta.env.BASE_URL + "/weatherforecast"
    const url = "https://localhost:7033/weatherforecast"
    try {
        const response = await axios.get<weatherData[]>(url)
        return response.data
    } catch (error) {
        return new networkRequestError(error)
    }
    
}