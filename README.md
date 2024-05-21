
---

# DungeonPedia

DungeonPedia es una aplicación web dedicada a proporcionar información detallada sobre criaturas, monstruos y demás entidades fantásticas que se encuentran comúnmente en juegos de rol como Dungeons & Dragons.

## Descripción

Este repositorio contiene el código fuente tanto para el frontend como para el backend de DungeonPedia.

## Instalación

Sigue estos pasos para configurar y ejecutar la aplicación en tu máquina local:

1. Clona este repositorio en tu máquina local.

```bash
git clone https://github.com/Proyecto-Final-PP2/APP-DnD.git
```

2. Navega hasta el directorio del proyecto.

```bash
cd APP-DnD
```

3. Construye las imágenes de Docker.

```bash
docker-compose build
```

## Uso

Una vez que hayas construido las imágenes de Docker, puedes iniciar la aplicación con el siguiente comando:

```bash
docker-compose up
```

Esto iniciará tanto el backend como el frontend de DungeonPedia. El backend estará disponible en `http://localhost:8080` y el frontend en `http://localhost:3000`.

## Contribución

Si deseas contribuir a este proyecto, sigue estos pasos:

1. Haz un fork del repositorio.
2. Crea una nueva rama para tu función o corrección de bug: `git checkout -b nombre-de-la-rama`.
3. Realiza tus cambios y haz commit de ellos: `git commit -m "Descripción de tus cambios"`.
4. Sube tu rama al repositorio remoto: `git push origin nombre-de-la-rama`.
5. Abre un pull request en GitHub.

## Créditos

Este proyecto fue creado por [tu nombre] y está inspirado en el juego de rol Dungeons & Dragons.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo `LICENSE` para obtener más detalles.

---
