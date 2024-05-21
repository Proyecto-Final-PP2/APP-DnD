# Usar una imagen base de Node.js
FROM node:14-alpine

# Establecer el directorio de trabajo
WORKDIR /app

# Copiar package.json y package-lock.json
COPY package*.json ./

# Instalar dependencias
RUN npm install

# Copiar todo el código fuente
COPY . .

# Construir la aplicación
RUN npm run build

# Instalar globalmente `serve` para servir la aplicación
RUN npm install -g serve

# Exponer el puerto que se usará
EXPOSE 3000

# Comando para iniciar la aplicación
CMD ["serve", "-s", "build", "-l", "3000"]
