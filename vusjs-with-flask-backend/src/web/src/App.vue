<template>
  <router-view/>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
* {
  margin: 0;
  padding: 0;
}

#app {
  background-color: lightgray;
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  min-height: calc(100vh - 60px);
  padding: 30px 0;
}

#app > div {
  width: min(800px, 100vw);
  /* height: 100%; */
  margin: 0 auto;
  padding: 20px 10px;
  background-color: white;
  border-radius: 2px;
  box-shadow: 2px 5px 5px 0px rgba(0, 0, 0, 0.50);
}

button {
  border: none;
  color: white;
  background-color: dodgerblue;
  padding: 10px 40px;
  cursor: pointer;
  border-radius: 30px;
}
</style>
