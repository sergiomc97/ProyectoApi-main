
# Proyecto API NASA

Aplicacion WPF de la API de la NASA para mostrar y obtener imágenes y datos astronómicos. Podrás navegar fácilmente por la aplicación y acceder a la información de tu interés.

La aplicación proporciona varias funciones útiles, podrás visualizar imágenes espectaculares de la NASA, entre otras:

-Asteroids - NeoWs: Esta sección de la API de la NASA proporciona información sobre asteroides cercanos a la Tierra. Funcion incluida:

-   Visualización de información detallada sobre un asteroide específico, como su tamaño, velocidad y distancia a la Tierra.
### Uso Pagina Asteroids:
En esta pagina se muestran los datos mas relevantes spbre una coleccion de asteroides, haciendo click en el boton Siguiente se puede ir cambiando de asteroide. 
## Screenshots Asteroids

![App Screenshot](https://github.com/sergiomc97/ProyectoApi-main/blob/main/capturas/Captura7.png?raw=true)

-Earth: La sección de la API de la NASA dedicada a tomar imagenes a la Tierra.Las imágenes de Landsat se proporcionan al público como un proyecto conjunto entre la NASA y el USGS. Esta API funciona con la API de Google Earth Engine y actualmente solo admite imágenes de Landsat 8 con nitidez panorámica. Este punto final recupera la imagen de Landsat 8 para la ubicación y la fecha proporcionadas. Es posible que el recurso solicitado no esté disponible para la fecha exacta de la solicitud. Funcion incluida:

-   Búsqueda de imágenes de la Tierra por ubicación.
### Uso Pagina EARTH:
Podemos buscar en el cuadro de busqueda una ciudad, seleccionarla en el ComboBox y aparecera una imagen de la vista satelital de la ubicacion seleccionada
## Screenshots EARTH

![App Screenshot](https://github.com/sergiomc97/ProyectoApi-main/blob/main/capturas/Captura8.png?raw=true)

-EPIC API: La API de la NASA EPIC proporciona imágenes espectaculares de la Tierra desde una perspectiva única.Funcion incluida:

-   Visualización de imágenes de la Tierra desde el punto de vista del satélite DSCOVR.
-   Creación de animaciones a partir de imágenes tomadas en diferentes momentos.
### Uso Pagina EPIC:
En esta pagina, se muestra una imagen de la tierra, al hacer click en el boton, la tierra va girando.
## Screenshots EPIC

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
## Screenshots ROVER

![App Screenshot](https://github.com/sergiomc97/ProyectoApi-main/blob/main/capturas/Captura10.png?raw=true)

-APOD (Astronomy Picture of the Day) es una sección muy popular de la API de la NASA que proporciona una imagen diferente de nuestro universo cada día, junto con una explicación escrita por un astrónomo profesional.
-   Búsqueda de imágenes de APOD por fecha.

### Uso Pagina APOD:
En esta pagina, se muestra la imagen astronomica del dia, ademas te permite seleccionar otra fecha.
## Screenshots APOD

![App Screenshot](https://github.com/sergiomc97/ProyectoApi-main/blob/main/capturas/Captura5.png?raw=true)

## Capturas del Login:

![App Screenshot](https://github.com/sergiomc97/ProyectoApi-main/blob/main/capturas/Captura1.png?raw=true)
![App Screenshot](https://github.com/sergiomc97/ProyectoApi-main/blob/main/capturas/Captura2.png?raw=true)
![App Screenshot](https://github.com/sergiomc97/ProyectoApi-main/blob/main/capturas/Captura3.png?raw=true)


# Para programadores:
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





## Clase ControllerApi.cs


<table id="MethodList" class="table is-hoverable">
                <tbody>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/e53717c6-ee74-73a0-eb5c-503a65aa427c.htm">GetAsteroids</a>
                  </td>
                  <td>
            Este método llama a la API Near Earth Object Web Service (NeoWs) de la NASA
            para obtener información sobre los asteroides cercanos a la Tierra y devuelve
            una lista de objetos Asteroide que contienen información sobre cada asteroide.
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/3a9a2ae9-5c48-1e83-3e6f-fcf4807a15e1.htm">GetImage</a>
                  </td>
                  <td>
            Devuelve una imagen desde una url
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/8cd1a0c4-46b4-8ee5-a7a9-9528921971e1.htm">GetImageList<span id="LSTACD0D1AF_0" data-languagespecifictext="cs=()|vb=|cpp=()|nu=()|fs=()">()</span></a>
                  </td>
                  <td>
            Este método devuelve una lista de imágenes de fondo de pantalla de la API EPIC de la NASA.
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/fc230db8-96e1-bea6-5579-0b03c218ca29.htm">GetImageList(String)</a>
                  </td>
                  <td>
            Este método devuelve una lista de imágenes de la API Mars Rover Photos de la NASA.
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/d82a708b-74b2-9277-7953-c3d2d31c498d.htm">GetJson</a>
                  </td>
                  <td>
            Este método hace una solicitud HTTP GET a una URL específica y devuelve el contenido como un objeto JsonDocument.
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/0cefc3ad-669f-7eee-9587-9d813e1532cc.htm">GetStrings<span id="LSTACD0D1AF_1" data-languagespecifictext="cs=()|vb=|cpp=()|nu=()|fs=()">()</span></a>
                  </td>
                  <td>
            Este método devuelve una lista de imagenes que representan las imágenes más recientes de la API EPIC de la NASA.
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/a9a11176-26a1-abec-8cf7-da1db8f56de6.htm">GetStrings(String)</a>
                  </td>
                  <td>
            Este método devuelve una lista de cadenas que representan las imágenes de la API Mars Rover Photos de la NASA.
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/f6be97d1-f060-29da-d199-ef578a757ca4.htm">SetBackground</a>
                  </td>
                  <td>
            Este método establece la imagen de fondo de una Grid (cuadrícula)
            y la ajusta a su tamaño original.
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/6397c4f1-190c-74bf-cb52-d59ff23b40c4.htm">SetBackgroundStretch</a>
                  </td>
                  <td>
            Este método establece la imagen de fondo de una Grid (cuadrícula)
            y la ajusta para que cubra toda la cuadrícula sin deformar la imagen.
            </td>
                </tr>
              </tbody></table>

## Clase ControllerBD.cs

<table id="MethodList" class="table is-hoverable">
                <tbody><tr>
                  <td>
                    <a href="Documentation1/Help/html/7c4953a2-1f44-f6d2-33be-a39215304684.htm">CifrarContrasena</a>
                  </td>
                  <td>
            Este método cifra una contraseña utilizando el algoritmo SHA256.(sacado de stackoverflow)
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/b9a9e5c4-d8ec-3b3a-c382-3f9e40d7fde0.htm">ComprobarCredenciales</a>
                  </td>
                  <td>
            Este método comprueba las credenciales de un usuario en la tabla User de la base de datos.
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/219d563e-bf6a-a505-485c-eae60f985efe.htm">conectar</a>
                  </td>
                  <td>
            Este método establece la conexión a la base de datos SQLite.
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/f3f02114-edf9-fd34-688c-d0efdf5370c4.htm">consulta</a>
                  </td>
                  <td>
            Este método consulta un usuario por su ID en la tabla User de la base de datos.
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/4a1f1a15-225f-cd16-d78b-c92ab3040c11.htm">ContarFavoritos</a>
                  </td>
                  <td>
            Este método cuenta el número de registros de favoritos en la tabla Favoritos de la base de datos correspondientes a un usuario específico.
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/22739397-c272-93b8-d8cf-31b0dd21c2b5.htm">Create</a>
                  </td>
                  <td>
            Este método crea un nuevo registro de usuario en la tabla User de la base de datos.
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/4094eef4-9346-8f25-5fbc-fa2214b4f06a.htm">DeleteFav</a>
                  </td>
                  <td>
            Este método elimina los favoritos de un usuario de la tabla Favoritos de la base de datos.
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/31e18e61-4245-5a17-7089-ee473173f978.htm">DeleteUser</a>
                  </td>
                  <td>
            Este método elimina un registro de usuario de la tabla User de la base de datos.
            </td>
                </tr>
                <tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/abd7cf29-a5a1-4e92-e5a2-c23ddd9ed173.htm">GetUsuarios</a>
                  </td>
                  <td>
            Este método obtiene una lista de todos los usuarios almacenados en la tabla User de la base de datos.
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/44d0f868-ef9a-c56f-5dcf-d4f42c260250.htm">ImageToByte</a>
                  </td>
                  <td>
            Convierte una imagen BitmapImage a un arreglo de bytes. (sacado de stackoverflow)
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/c1bd69d2-031a-0f8b-aa3b-729d910ae10c.htm">InsertarImagen</a>
                  </td>
                  <td>
            Inserta una imagen en la base de datos de favoritos asociada a un usuario dado.
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/5c48ae9b-21ee-3235-1fb3-c51b74f39927.htm">ObtenerImagen</a>
                  </td>
                  <td>
            Obtiene una lista de imágenes almacenadas en la base de datos de favoritos para un usuario dado.
            </td>
                </tr>
                <tr>
                  <td>
                    <a href="Documentation1/Help/html/cc0fb2c4-312e-2bd0-d405-a7323420d67c.htm">ToImage</a>
                  </td>
                  <td>
            Convierte un objeto Stream a un objeto BitmapImage.
            </td>
              </tbody></table>

## Esquema base de datos

![App Screenshot](https://github.com/sergiomc97/ProyectoApi-main/blob/main/capturas/Captura11.png?raw=true)