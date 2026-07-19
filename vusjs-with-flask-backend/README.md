# vuejs-with-flask-backend

A project to learn how to utilize vuejs as front end framework while leaving nodejs serve alone. Turns out with `npm run build`, the vuejs web can be made into a simple website. From there, this can be paired with flask.

Using this as my reference: https://codeburst.io/full-stack-single-page-application-with-vue-js-and-flask-b1e036315532

## Frontend / Vue JS setting

In vue.config.js, added the following property
`proxy`: For development use. Redirect api request to backend server.
`outputDir`: Control the build location.
`assetsDir`: Move the assets, like js and css to this path since flask use static folder to serve static folder.

## Backend setting

Use catch-all path (`@app.route('/', defaults={'path': ''})` and `@app.route('/<path:path>')`) to reroute traffic to vuejs router.
Use api prefix for all api route.