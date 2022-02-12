import Vue from 'vue';
import App from './App.vue';
import BootstrapVue from 'bootstrap-vue';
import moment from 'vue-moment';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';
import 'weather-icons-npm/css/weather-icons.min.css';
import 'weather-icons-npm/css/weather-icons-wind.min.css';
import 'font-awesome/css/font-awesome.min.css';
import './assets/css/site.css';

Vue.config.productionTip = false;
Vue.use(BootstrapVue);
Vue.use(moment as any);

new Vue({
  render: (h) => h(App),
}).$mount('#app');
