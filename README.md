
# Proyecto API NASA

Aplicacion WPF  para acceder a la API de la NASA para mostrar y obtener, imágenes y datos astronómicos. Utilizando la interfaz gráfica de usuario de WPF, podrás navegar fácilmente por la aplicación y acceder a la información de tu interés.

La aplicación proporciona varias funciones útiles, podrás visualizar imágenes espectaculares de la NASA, entre otras:

-Asteroids - NeoWs: Esta sección de la API de la NASA proporciona información sobre asteroides cercanos a la Tierra. Algunas de las funciones que incluye:
-   Visualización de información detallada sobre un asteroide específico, como su tamaño, velocidad y distancia a la Tierra.


-Earth: La sección de la API de la NASA dedicada a tomar imagenes a la Tierra 

-   Búsqueda de imágenes de la Tierra por ubicación.

-EPIC API: La API de la NASA EPIC proporciona imágenes espectaculares de la Tierra desde una perspectiva única.

-   Visualización de imágenes de la Tierra desde el punto de vista del satélite DSCOVR.
-   Creación de animaciones a partir de imágenes tomadas en diferentes momentos.

-Mars Rover Photos: Esta sección de la API de la NASA proporciona imágenes tomadas por los rovers que exploran Marte.:
-   Búsqueda de imágenes por fecha, rover o cámara.
-   Visualización de imágenes en alta resolución de la superficie de Marte.

-APOD (Astronomy Picture of the Day) es una sección muy popular de la API de la NASA que proporciona una imagen diferente de nuestro universo cada día, junto con una explicación escrita por un astrónomo profesional.
-   Búsqueda de imágenes de APOD por fecha: buscar imágenes de APOD de días anteriores,

## Screenshots

![App Screenshot](https://github.com/[sergiomc97]/[ProyectoApi-main]/capturas/Captura1.png?raw=true)
![App Screenshot](https://github.com/[sergiomc97]/[ProyectoApi-main]/capturas/Captura2.png?raw=true)
![App Screenshot](https://github.com/[sergiomc97]/[ProyectoApi-main]/capturas/Captura3.png?raw=true)
![App Screenshot](https://github.com/[sergiomc97]/[ProyectoApi-main]/capturas/Captura4.png?raw=true)
![App Screenshot](https://github.com/[sergiomc97]/[ProyectoApi-main]/capturas/Captura5.png?raw=true)
![App Screenshot](https://github.com/[sergiomc97]/[ProyectoApi-main]/capturas/Captura6.png?raw=true)




## API Reference


#### Imagen del dia
##### Consulta para obtener la Imagen del dia

```http
  GET https://api.nasa.gov/planetary/apod?api_key={key}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `key`      | `string` | **Required**. API KEY personal |

#### EARTH
##### Consulta para obtener la vista satelital de una ubicacion

```http
  GET https://api.nasa.gov/planetary/earth/imagery?lon={lon}&lat={lat}&api_key={key}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `key`      | `string` | **Required**. API KEY personal |
| `lat`      | `string` | Longitud de la ubicacion |
| `lon`      | `string` | Latitud de la ubicacion |

#### EPIC
##### Obtiene imagenes del del satélite DSCOVR

```http
  GET https://epic.gsfc.nasa.gov/archive/natural/{("yyyy/MM/dd")}/jpg/{imagenes[i]}.jpg
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `imagen`      | `string` | Direccion a la imagen |

#### ASTEROIDS
##### Obtiene datos de asteroides cercanos a la tierra

```http
  GET http://api.nasa.gov/neo/rest/v1/neo/browse?page=0&size=20&api_key={key}"

```

#### ROVER
##### Obtiene imagenes de las camaras del rover curiosity en marte

```http
  GET https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/
$"photos?earth_date={}&camera={}&api_key={key}"

```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `key`      | `string` | **Required**. API KEY personal |
| `date`      | `string` | Fecha de la imagen |
| `camera`      | `string` | Camara del rover |




