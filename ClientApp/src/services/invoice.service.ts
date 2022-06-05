import { networkRequestError, invoiceData } from '@/types'
import axios, { AxiosResponse } from 'axios'

export async function getInvoices(): Promise<invoiceData[] | networkRequestError> {
    //const url = import.meta.env.BASE_URL + "/weatherforecast"
    const url = "https://localhost:7033/invoice/list"
    try {
        const response = await axios.get<invoiceData[]>(url)
        return response.data
    } catch (error) {
        return new networkRequestError(error)
    }
}

export async function getInvoice(id: number): Promise<invoiceData[] | networkRequestError> {
    //const url = import.meta.env.BASE_URL + "/weatherforecast"
    const url = `https://localhost:7033/invoice/get/${id}`
    try {
        const response = await axios.get<invoiceData[]>(url)
        return response.data
    } catch (error) {
        return new networkRequestError(error)
    }
}

export async function payInvoice(id: number): Promise<boolean | networkRequestError> {
    //const url = import.meta.env.BASE_URL + "/weatherforecast"
    const url = `https://localhost:7033/invoice/delete/${id}`
    try {
        const response = await axios.patch<boolean>(url)
        return response.data
    } catch (error) {
        return new networkRequestError(error)
    }
}