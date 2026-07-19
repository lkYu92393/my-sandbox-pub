// Tried reusing chart in vuejs. Turns out it will result in too much revursion if changing the data.

<script>
import Chart from 'chart.js/auto'

export default {
  data () {
    return {
      chart: null
    }
  }
  ,mounted () {
    const ctx = this.$refs.graph

    const data = [
      { year: 2010, count: 10 },
      { year: 2011, count: 20 },
      { year: 2012, count: 15 },
      { year: 2013, count: 25 },
      { year: 2014, count: 22 },
      { year: 2015, count: 30 },
      { year: 2016, count: 28 },
    ];

    this.chart = new Chart(
      ctx,
      {
        type: 'bar',
        data: {
          labels: data.map(row => row.year),
          datasets: [
            {
              label: 'Acquisitions by year',
              data: data.map(row => row.count)
            }
          ]
        }
      }
    );
  }
  ,methods: {
    serveData () {
      console.log("TEST")
      // const fakeData = [
      //   { year: 2010, count: Math.random() },
      //   { year: 2011, count: Math.random() },
      //   { year: 2012, count: Math.random() },
      //   { year: 2013, count: Math.random() },
      //   { year: 2014, count: Math.random() },
      //   { year: 2015, count: Math.random() },
      //   { year: 2016, count: Math.random() },
      // ];

      // this.labels = fakeData.map(row => row.year)
      // this.data = fakeData.map(row => row.count)

      this.chart.data.labels.pop()
      this.chart.data.datasets.forEach(dataset => dataset.data.pop())

      // this.chart.data.labels.push(this.labels)
      // this.chart.data.datasets = [{
      //   data: this.data
      // }]

      console.log("BEFORE UPDATE")
      this.chart.update()
    }
  }
}
</script>

<template>
  <div>
    <canvas ref="graph"></canvas>
    <button @click="serveData">TEST</button>
  </div>
</template>

<style></style>
