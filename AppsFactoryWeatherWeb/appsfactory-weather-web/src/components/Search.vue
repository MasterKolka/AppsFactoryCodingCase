<template>
<form v-on:submit.prevent>
    <div class="input-group">
        <input type="text" v-model="searchStr" class="form-control" placeholder="Enter full city name or german zip code">
        <div class="input-group-append">
            <button class="btn btn-secondary" type="submit" v-on:click="click">
                <i class="fa fa-search"></i>
            </button>
        </div>
  </div>
</form>
</template>

<script lang="ts">
import { Component, Prop, Vue } from 'vue-property-decorator';

@Component
export default class Search extends Vue {
    private searchStr: string = '';
    private click() {
        this.$emit('searchClicked', this.searchStr);
    }
}
</script>