FROM microsoft/dotnet:1.1.0-sdk-projectjson
# Dockerfile for package SchoolBusClient

# install rlwrap
 
RUN apt-get update \
 && apt-get upgrade -y --force-yes \
 && apt-get install rlwrap bzip2 \
 && rm -rf /var/lib/apt/lists/*;

# install Node.js

RUN curl https://deb.nodesource.com/node_6.x/pool/main/n/nodejs/nodejs_6.7.0-1nodesource1~jessie1_amd64.deb > node.deb \
 && dpkg -i node.deb \
 && rm node.deb

RUN apt-get update \
 && apt-get upgrade -y --force-yes \
 && rm -rf /var/lib/apt/lists/*;

# copy Node.js packages

COPY /package.json /app/src/ 
WORKDIR /app/src

ENV NODE_ENV production

RUN npm install

# copy the full source
COPY . /app/src 

# compile the source

RUN ./node_modules/.bin/gulp --production  

# End of Node.js portion.
