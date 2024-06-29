-- phpMyAdmin SQL Dump
-- version 5.0.3
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 29-06-2024 a las 05:41:29
-- Versión del servidor: 10.4.14-MariaDB
-- Versión de PHP: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `farmacia`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `producto`
--

CREATE TABLE `producto` (
  `Producto_id` int(11) NOT NULL,
  `Tipo` varchar(80) COLLATE utf8_spanish_ci NOT NULL,
  `Nombre` varchar(80) COLLATE utf8_spanish_ci NOT NULL,
  `Cantidad_stock` int(11) NOT NULL,
  `Precio` float NOT NULL,
  `codigo` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `producto`
--

INSERT INTO `producto` (`Producto_id`, `Tipo`, `Nombre`, `Cantidad_stock`, `Precio`, `codigo`) VALUES
(1, 'Esteroide', 'Prednisona', 56, 8.36, 878),
(2, 'analgesico', 'ibuprofeno', 45, 96, 789),
(3, 'antialergico', 'Loratadina', 500, 1, 123),
(4, 'antialergico', 'cetrizina', 120, 1, 1234),
(5, 'antialergico', 'levocetrizina', 441, 1.2, 452),
(6, 'antialergico', 'fexofenadina', 123, 0.3, 415),
(7, 'Antihipertensivos', 'losartan', 450, 5.3, 559),
(8, 'antihipertensivos', 'carvedinaol', 458, 4.5, 4586),
(9, 'antihipertensivos', 'labeltalol', 124, 4.5, 8962),
(10, 'antihipertensivos', 'Nifedipino', 458, 7.5, 445),
(11, 'antibiotico', 'Cefadroxilo', 4785, 0.85, 450),
(12, 'antibiotico', 'amoxicilina', 652, 5, 895),
(13, 'antibiotico', 'ampicilina', 895, 6, 965),
(14, 'antibiotico', 'azitromicina', 658, 6.8, 5324),
(15, 'diureticos', 'espironolactona', 4587, 8.6, 254),
(16, 'diureticos', 'furomesida', 321, 0.8, 958),
(17, 'AINES', 'Naproxeno', 58, 2, 657),
(18, 'AINES', 'Diclofenac', 89, 0.9, 5748),
(19, 'AINES', 'Ketoprofeno', 8554, 0.6, 7814),
(20, 'AINES', 'Meloxicam', 4581, 0.96, 78952);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `user_id` int(11) NOT NULL,
  `username` varchar(80) COLLATE utf8_spanish_ci NOT NULL,
  `password` varchar(20) COLLATE utf8_spanish_ci NOT NULL,
  `fullname` varchar(80) COLLATE utf8_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`user_id`, `username`, `password`, `fullname`) VALUES
(11, 'Ariana', 'ari48', 'Ariana Rivera'),
(12, 'Maria', 'mariposa21', 'Maria Lopez'),
(13, 'Alberto', 'Beltran11', 'Alberto beltran'),
(14, 'carmen45', 'ola12', 'Carmen perez'),
(15, 'Victor', 'perro21', 'Victor Martinez');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `producto`
--
ALTER TABLE `producto`
  ADD PRIMARY KEY (`Producto_id`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`user_id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `producto`
--
ALTER TABLE `producto`
  MODIFY `Producto_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
