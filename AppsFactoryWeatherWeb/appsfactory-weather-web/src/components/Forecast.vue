<template>
  <div class="container">
    <div class="row"><div class="datarow"><h5>{{ f.date | moment("dddd") }}</h5></div></div>
    <div class="row"><div class="datarow"><h5>{{ f.date | moment("Do MMMM") }}</h5></div></div>
    <div class="row"><div class="datarow"><h4><i :class="'wi wi-' + f.weatherKind"/></h4></div></div>
    <div class="row"><div class="datarow"><i class="wi wi-thermometer"/> {{ f.avgTemperature - 273 }}<i class="wi wi-celsius"/></div></div>
    <div class="row"><div class="datarow"><i class="wi wi-humidity"/> {{ f.avgHumidity }}%</div></div>
    <div class="row"><div class="datarow"><i class="wi wi-barometer"/> {{ f.avgPressure }}hPa</div></div>
    <div class="row"><div class="datarow"><i class="wi wi-windy"/> {{ f.windSpeed }}m/s <i :class="'wi wi-wind wi-towards-' + f.windDirection"/></div></div>
    <div class="row mt-3"></div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class Forecast extends Vue {
  @Prop() private f!: object;
}
</script>

<style>
.datarow {
  min-width: max-content;
}
</style>
