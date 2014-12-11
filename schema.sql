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