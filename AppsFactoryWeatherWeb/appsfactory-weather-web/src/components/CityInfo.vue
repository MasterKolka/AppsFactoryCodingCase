<template>
    <div class="container">
        <div class="row">
            <div class="col-sm"><h4>{{ c.city }}</h4></div>
        </div>
        <div class="row mt-3"></div>
        <div class="row">
            <div class="col-sm-2" v-for="(forecast, index) in c.forecast" :key="index">
                <Forecast :f="forecast" />
            </div>
        </div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';
import Forecast from './Forecast.vue';

@Component({
  components: {
    Forecast,
  },
})
export default class CityInfo extends Vue {
  @Prop() private c!: object;
}
</script>