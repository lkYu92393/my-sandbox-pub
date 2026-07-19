FROM nikolaik/python-nodejs:python3.10-nodejs16-slim
RUN apt update
RUN apt install bash

RUN mkdir /app

WORKDIR /app
COPY requirements.txt requirements.txt
RUN pip install -r requirements.txt
RUN pip install memcache
RUN pip install python-memcached
COPY src/ /app/

WORKDIR /app/web
RUN npm install
RUN npm run build

WORKDIR /app
RUN pip install waitress
CMD ["waitress-serve", "--listen=*:8080", "wsgi:app"]