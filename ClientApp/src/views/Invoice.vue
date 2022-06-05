<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { invoiceService } from '@/services'
import { networkRequestError, invoiceData } from '@/types'
import { useRouter, useRoute } from 'vue-router'

const route = useRoute()

if('id' in route.params) {
    getInvoice(route.params.id)
}

let invoice = ref<invoiceData[]>()
async function getInvoice(id: number) {
  const value = await invoiceService.getInvoice(id)
  if (!(value instanceof networkRequestError)) {
    invoice.value = value
  } else {
    console.error(value.message)
  }
}

async function pay(){
    const value = await invoiceService.payInvoice(route.params.id)
    if (!(value instanceof networkRequestError)) {
        invoice.value.sum = 0
    } else {
        console.error(value.message)
    }
}
</script>

<template>
  {{ invoice }}
  <br>
  <button @click="pay">Pay</button>
</template>
