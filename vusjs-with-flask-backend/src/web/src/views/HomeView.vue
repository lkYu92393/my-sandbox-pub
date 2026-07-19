<template>
  <div id="home">
    <div>
      AI Training
    </div>
    <div>
      Current progress: {{ progress }}
    </div>
    <div>
      <select v-model="choice">
        <option v-for="item in itemList" :key=item.key :value=item.key>{{ item.text }}</option>
      </select>
    </div>
    <div v-if="hasAPI">
      <button @click="startGrading">Start</button>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  data() {
    return {
      progress: 'x/y'
      , hasAPI: false
      , itemList: [
        { key: "ein", text: "Choice 1" }
        , { key: "zwei", text: "Choice 2" }
        , { key: "drei", text: "Choice 3" }
      ]
      , choice: "drei"
    }
  },
  methods: {
    getProgress() {
      const path = `/api/progress`
      axios.get(path)
        .then(response => {
          this.progress = response.data.progress
          this.hasAPI = true
        })
        .catch(error => {
          console.log(error)
        })
    },
    startGrading() {
      this.$router.push({ path: '/grading' })
    }
  },
  created() {
    this.getProgress()
  }
}
</script>

<style>
#home {
  display: grid;
  grid-template-rows: 1fr 1fr 1fr;
  grid-template-columns: 1fr;
  row-gap: 10px;
}
</style>
