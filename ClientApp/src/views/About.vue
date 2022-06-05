<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { invoiceService } from '@/services'
import { networkRequestError, invoiceData } from '@/types'

onMounted(() => {
  getInvoice()
})

let invoices = ref<invoiceData[]>()
async function getInvoice() {
  const value = await invoiceService.getInvoices()
  if (!(value instanceof networkRequestError)) {
    invoices.value = value
  } else {
    console.error(value.message)
  }
}
</script>

<template>
  <table>
    <thead>
      <tr>
        <th>customer</th>
        <th>date</th>
        <th>dueDate</th>
        <th>id</th>
        <th>sum</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="invoice in invoices" :key="invoice.id" @click="$router.push(`/invoice/${invoice.id}`)">
        <td>{{invoice.customer}}</td>
        <td>{{invoice.date}}</td>
        <td>{{invoice.dueDate}}</td>
        <td>{{invoice.id}}</td>
        <td>{{invoice.sum}}</td>
      </tr>
    </tbody>
  </table>
</template>

<style>
  td {
    padding-left: 20px;
    padding-right: 20px;
    cursor: pointer;
  }
</style>
