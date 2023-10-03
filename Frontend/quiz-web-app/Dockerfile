# Using node:16-alpine as the base image
FROM node:16-alpine

# Create and set /app as the default work directory
WORKDIR /app

# Copy package.json and package-lock.json first for caching
COPY package*.json ./

# Install npm dependencies
RUN npm install

# Copy the rest of the project files
COPY public/ ./public/
COPY src/ ./src/

# Expose the port of your application to bind with the host port
EXPOSE 3000

# Start your app
CMD ["npm", "start"]