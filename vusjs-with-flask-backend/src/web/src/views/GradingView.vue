<template>
  <div>
    <div v-if="recordID">
      {{ fromTime }}
      {{ toTime }}
    </div>
    <div>
      <GraphComp id="y" color="#ff0000" :data="y" />
      <button @click="submit">SUBMIT AND CONTINUE</button>&nbsp;
      <button @click="end">END</button>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import GraphComp from '@/components/GraphComp.vue'

export default {
  components: {
    GraphComp
  },
  data () {
    return {
      recordID: "",
      fromTime: '1970-01-01 00:00:00',
      toTime: '1970-01-01 00:30:00',
      y: {},
    }
  },
  methods: {
    getData () {
      const path = `/api/random`
      axios.get(path)
        .then(response => {
          this.recordID = response.data.recordID
          this.fromTime = response.data.fromTime
          this.toTime = response.data.toTime
          this.y = (JSON.parse(response.data.data))['y']
        })
        .catch(error => {
          console.log(error)
        })
    },
    submit () {
      const totalField = document.querySelectorAll("div.choice").length
      const inputElem = document.getElementsByTagName("input")
      const inputElemArray = Array.prototype.slice.call(inputElem).filter(elem => elem.checked)

      if (inputElemArray.length < totalField) {
        const filledParams = inputElemArray.map(elem => elem.id.split("_")[0])
        alert(`Not all graded yet (Following are filled: ${filledParams.join(",")}). Please check.`)
        return
      }

      const body = {
        "recordID": this.recordID
      }
      inputElemArray.forEach(elem => {
        let pieces = elem.id.split('_')
        body[pieces[0]] = pieces[1]
      })

      const path = `/api/random`
      axios.post(path, { body: body })
        .then(() => {
          window.scroll(0, 0)
          window.location.reload()
        })
        .catch(() => {
          window.scroll(0, 0)
          window.location.reload()
        })
    },
    end () {
          this.$router.push({ path: '/' })
    }
  },
  mounted () {
    this.getData()
  }
}
</script>
