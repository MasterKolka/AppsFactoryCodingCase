<template>
  <div class="container d-flex h-100 flex-column" style="padding: 15px">
    <div :class="'row ' + (cityData.city == null ? 'h-25' : '')">
      <div class="col align-self-end">
        <Search v-on:searchClicked="searchClicked"/>
      </div>
    </div>
    <div class="row mt-3"></div>
    <div class="row">
        <CityInfo :c="cityData" />
    </div>
    <div class="row mt-3"></div>
    <div class="row" v-if="history.length > 0">
        <History :h="history" />
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import Search from './components/Search.vue';
import CityInfo from './components/CityInfo.vue';
import History from './components/History.vue';
import axios from 'axios';

@Component({
  components: {
    Search,
    CityInfo,
    History,
  },
})
export default class App extends Vue {
  private cityData: object = {};
  private history: object[] = [];
  public mounted() {
    axios
      .get('https://localhost:5001/api/weather/forecast')
      .then((response) =>  { this.history = response.data.history; });
  }
  private searchClicked(searchStr: string) {
    if ((searchStr || '').length > 0) {
    axios
      .get('https://localhost:5001/api/weather/forecast?s=' + searchStr)
      .then((response) =>  { this.cityData = response.data.forecast; this.history = response.data.history; });
    }
  }
}
</script>