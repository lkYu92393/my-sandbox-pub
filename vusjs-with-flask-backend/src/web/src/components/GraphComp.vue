<script>
import Chart from 'chart.js/auto'
// import moment from 'moment'

export default {
  data() {
    return {
      choices: [
        { id: this.id + "_A1", value: "A1", text: "A1 - Good" }
        , { id: this.id + "_A2", value: "A2", text: "A2 - Excellent" }
        , { id: this.id + "_B1", value: "B1", text: "B1 - Too High" }
        , { id: this.id + "_B2", value: "B2", text: "B2 - Too Low" }
        , { id: this.id + "_B3", value: "B3", text: "B3 - Too much fluctuation" }
      ],
      hasData: false
    }
  },
  props: {
    id: String
    , data: Object
    , color: String
  },
  watch: {
    data(newData) {
      console.log(newData)
      this.hasData = true
      new Chart(
        this.$refs.graph,
        {
          type: 'line',
          options: {
            //Boolean - Whether the line is curved between points
            bezierCurve: false,
            elements: {
              line: {
                tension: 0
              }
            }
          },
          data: {
            labels: Object.keys(newData),
            datasets: [
              {
                backgroundColor: this.color,
                borderColor: this.color,
                label: this.id,
                data: Object.keys(newData).map(key => newData[key])
              }
            ]
          }
        }
      );
    }
  }
}
</script>

<template>
  <div>
    <canvas ref="graph" :id="id"></canvas>
    <section v-if="hasData">
      <div class="section-title">Grading for {{ id.toUpperCase() }}:</div>
      <div class="choice">
        <div v-for="choice in choices" :key="choice.value">
          <input type="radio" :id="choice.id" :name="this.id" :value="choice.value">
          <label :for="choice.id">{{ choice.text }}</label>&nbsp;
        </div>
      </div>
    </section>
  </div>
</template>

<style>
div.section-title {
  margin: 0 0 10px 0;
}

div.choice {
  display: grid;
  grid-template-rows: 1fr 1fr 1fr 1fr;
  grid-template-columns: 1fr 1fr 1fr;
  row-gap: 10px;
}
</style>
