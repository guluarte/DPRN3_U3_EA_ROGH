Programación NET III

Evidencia  de aprendizaje.  Manipulación  de datos

El propósito de la evidencia de aprendizaje es que desarrolles un programa en VB.NET que manipule una base de datos MySQL,  retomando como base el  caso práctico  realizado en la  evidencia de aprendizaje de la unidad 2  Diseño de interfaces mediante .NET. Una vez recuperado el caso, realiza los siguientes pasos:
1.	Elabora el código SQL para crear la tabla dentro de la base de datos que hayas mencionado en tu planteamiento del problema, recuerda que tu tabla debe contener una Primary key  con la cual identificarás los registros que guardes y actualices desde el formulario que vas a crear.
Código SQL de la tabla:


--
-- Base de datos: `dbcontactos`
-- Estructura de tabla para la tabla `contactos`
--
CREATE TABLE IF NOT EXISTS `contactos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(150) DEFAULT NULL,
  `Edad` int(3) DEFAULT NULL,
  `Sexo` set('MASCULINO','FEMENINO') DEFAULT NULL,
  `Direccion` varchar(250) DEFAULT NULL,
  `Telefono` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=17 ;

--
-- Volcado de datos para la tabla `contactos`
--

INSERT INTO `contactos` (`Id`, `Nombre`, `Edad`, `Sexo`, `Direccion`, `Telefono`) VALUES
(15, 'RODOLFO GULUARTE', 28, 'MASCULINO', 'DEL MESON 256', '123456');



2.  Desarrolla  el formulario  (retomar de la evidencia)  y los componentes necesarios los cuales solo serán TextBox y Buttons, para interactuar con la tabla  que creaste en el paso anterior. Deberás tener en cuenta para el desarrollo de tu formulario los estándares de usabilidad  revisados   en la Unidad 2.
Interfaz de la aplicación:


 
3.  Desarrolla  el código VB .NET para conectarte a la base de datos y para cada botón de acción en tu formulario realizar las acciones:
a.  Insertar
b.  Actualizar y
c.   Seleccionar (leer información) un registro de la tabla de la base de datos que creaste. 
No olvides realizar los mensajes que vera el usuario si es que las acciones se realizaron de manera correcta o si hay  algún error.
4.  Graba  un video con tu celular o cámara de video donde muestres y expliques la conexión a datos mediante tu formulario.   En el video deberá conformarse de los siguientes pasos:
a.  Insertar un registro. 
b.  Leer la información del registro.
c.   Actualizar la información del  mismo registro.



Dirección del video: https://www.youtube.com/watch?v=yD_nY3-qK40&feature=youtu.be 

Autor: Rodolfo Guluarte Hale

---------------