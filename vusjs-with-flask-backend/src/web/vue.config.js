const path = require("path")
const { defineConfig } = require('@vue/cli-service')

module.exports = defineConfig({
  devServer: {
    proxy: {
      // proxy all requests starting with /api to jsonplaceholder
      '^/api': {
        target: 'http://localhost:5000',
        changeOrigin: true,
        pathRewrite: {
          '^/api': '/api'
        }
      }
    }
  },
  transpileDependencies: true,
  outputDir: path.resolve(__dirname, "./../dist"),
  assetsDir: 'static'
})
