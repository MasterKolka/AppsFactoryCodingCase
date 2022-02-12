<template>
    <div class="container">
        <div class="row">
            <div class="col-sm"><h4>Last viewed forecasts</h4></div>
        </div>
        <div class="row">            
            <div class="col-sm-2" v-for="(ch, index) in h" :key="index">
                <div class="container">
                    <div class="row"><div class="history-datarow">{{ ch.city }}</div></div>
                    <div class="row"><div class="history-datarow"><h4><i :class="'wi wi-' + ch.forecast[0].weatherKind"/></h4></div></div>
                    <div class="row"><div class="history-datarow"><i class="wi wi-thermometer"/> {{ ch.forecast[0].avgTemperature - 273 }}<i class="wi wi-celsius"/></div></div>
                    <div class="row"><div class="history-datarow"><i class="wi wi-humidity"/> {{ ch.forecast[0].avgHumidity }}%</div></div>
                    <div class="row"><div class="history-datarow"><i class="wi wi-barometer"/> {{ ch.forecast[0].avgPressure }}hPa</div></div>
                    <div class="row"><div class="history-datarow"><i class="wi wi-windy"/> {{ ch.forecast[0].windSpeed }}m/s <i :class="'wi wi-wind wi-towards-' + ch.forecast[0].windDirection"/></div></div>
                    <div class="row mt-3"></div>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class History extends Vue {
  @Prop() private h!: object[];
}
</script>

<style>
.history-datarow {
  min-width: max-content;
  font-size: 10pt
}
</style>