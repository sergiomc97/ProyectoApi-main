
# Proyecto API NASA

Aplicacion WPF de la API de la NASA para mostrar y obtener imágenes y datos astronómicos. Podrás navegar fácilmente por la aplicación y acceder a la información de tu interés.

La aplicación proporciona varias funciones útiles, podrás visualizar imágenes espectaculares de la NASA, entre otras:

-Asteroids - NeoWs: Esta sección de la API de la NASA proporciona información sobre asteroides cercanos a la Tierra. Funcion incluida:

-   Visualización de información detallada sobre un asteroide específico, como su tamaño, velocidad y distancia a la Tierra.
### Uso Pagina Asteroids:
En esta pagina se muestran los datos mas relevantes spbre una coleccion de asteroides, haciendo click en el boton Siguiente se puede ir cambiando de asteroide. 
## Screenshots

![App Screenshot](https://github.com/sergiomc97/ProyectoApi-main/blob/main/capturas/Captura7.png?raw=true)

-Earth: La sección de la API de la NASA dedicada a tomar imagenes a la Tierra.Las imágenes de Landsat se proporcionan al público como un proyecto conjunto entre la NASA y el USGS. Esta API funciona con la API de Google Earth Engine y actualmente solo admite imágenes de Landsat 8 con nitidez panorámica. Este punto final recupera la imagen de Landsat 8 para la ubicación y la fecha proporcionadas. Es posible que el recurso solicitado no esté disponible para la fecha exacta de la solicitud. Funcion incluida:

-   Búsqueda de imágenes de la Tierra por ubicación.
### Uso Pagina EARTH:
Podemos buscar en el cuadro de busqueda una ciudad, seleccionarla en el ComboBox y aparecera una imagen de la vista satelital de la ubicacion seleccionada
## Screenshots

![App Screenshot](https://github.com/sergiomc97/ProyectoApi-main/blob/main/capturas/Captura8.png?raw=true)

-EPIC API: La API de la NASA EPIC proporciona imágenes espectaculares de la Tierra desde una perspectiva única.Funcion incluida:

-   Visualización de imágenes de la Tierra desde el punto de vista del satélite DSCOVR.
-   Creación de animaciones a partir de imágenes tomadas en diferentes momentos.
### Uso Pagina EPIC:
En esta pagina, se muestra una imagen de la tierra, al hacer click en el boton, la tierra va girando.
## Screenshots

![App Screenshot](https://github.com/sergiomc97/ProyectoApi-main/blob/main/capturas/Captura9.png?raw=true)


-Mars Rover Photos: Esta sección de la API de la NASA proporciona imágenes tomadas por los rovers que exploran Marte. Funciones incluidas:
-   Búsqueda de imágenes por fecha o cámara.
-   Visualización de imágenes en alta resolución de la superficie de Marte.

### Uso Pagina ROVER:
En esta pagina, podemos seleccionar una fecha y camara del rover curiosity en marte y nos mostrara fotos de marte. Las camaras disponibles son:

-   FHAZ: Cámara frontal para evitar peligros
-   RHAZ: Cámara trasera para evitar peligros
-   MAST: Cámara de mástil
-   CHEMCAM: Complejo de cámara y quimica
-   MAHLI: Captador manual de imágenes de marte
-   MARDI: Cámara de descenso a marte
-   NAVCAM: Cámara de navegación

Se puede avanzar y retroceder entre las distintas fotos devueltas de la api usando los botones anterior y siguiente.
## Screenshots

![App Screenshot](https://github.com/sergiomc97/ProyectoApi-main/blob/main/capturas/Captura10.png?raw=true)

-APOD (Astronomy Picture of the Day) es una sección muy popular de la API de la NASA que proporciona una imagen diferente de nuestro universo cada día, junto con una explicación escrita por un astrónomo profesional.
-   Búsqueda de imágenes de APOD por fecha.

### Uso Pagina APOD:
En esta pagina, se muestra la imagen astronomica del dia, ademas te permite seleccionar otra fecha.
## Screenshots

![App Screenshot](https://github.com/sergiomc97/ProyectoApi-main/blob/main/capturas/Captura5.png?raw=true)

## Capturas del Login:

![App Screenshot](https://github.com/sergiomc97/ProyectoApi-main/blob/main/capturas/Captura1.png?raw=true)
![App Screenshot](https://github.com/sergiomc97/ProyectoApi-main/blob/main/capturas/Captura2.png?raw=true)
![App Screenshot](https://github.com/sergiomc97/ProyectoApi-main/blob/main/capturas/Captura3.png?raw=true)



## Consultas a la API usadas:


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
  GET https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/$"photos?earth_date={}&camera={}&api_key={key}"

```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `key`      | `string` | **Required**. API KEY personal |
| `date`      | `string` | Fecha de la imagen |
| `camera`      | `string` | Camara del rover |




