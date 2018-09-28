-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Sep 28, 2018 at 08:04 PM
-- Server version: 5.7.23
-- PHP Version: 7.2.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

--
-- Database: `chan_lee`
--
CREATE DATABASE IF NOT EXISTS `chan_lee` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `chan_lee`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(32) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `name`) VALUES
(1, 'Harry Potter'),
(2, 'Hermione Granger'),
(3, 'Aegon Targaryen'),
(4, 'Cersei Lannister'),
(5, 'Aria Stark'),
(6, 'Captain America'),
(7, 'Aria Stark'),
(8, 'Ron'),
(9, 'Jamey Lannister'),
(10, 'John'),
(11, 'John'),
(12, 'John'),
(13, 'John'),
(14, 'John'),
(15, 'John');

-- --------------------------------------------------------

--
-- Table structure for table `specialtys`
--

CREATE TABLE `specialtys` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialtys`
--

INSERT INTO `specialtys` (`id`, `name`) VALUES
(1, 'Color'),
(2, 'Highlight'),
(3, 'Corrective Color'),
(4, 'Conditioning Texture Treatment'),
(5, 'Blow Dry & Style'),
(6, 'Updo'),
(8, 'John'),
(9, 'John'),
(10, 'John'),
(11, 'John'),
(12, 'John'),
(13, 'John');

-- --------------------------------------------------------

--
-- Table structure for table `specialtys_stylists`
--

CREATE TABLE `specialtys_stylists` (
  `id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialtys_stylists`
--

INSERT INTO `specialtys_stylists` (`id`, `specialty_id`, `stylist_id`) VALUES
(2, 4, 2),
(3, 4, 6),
(4, 2, 4),
(5, 5, 6),
(6, 6, 2),
(7, 6, 4);

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(32) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`id`, `name`) VALUES
(2, 'Chandler'),
(4, 'Monica'),
(5, 'Joey'),
(6, 'John'),
(7, 'John'),
(8, 'John'),
(9, 'John'),
(10, 'John'),
(11, 'John'),
(12, 'John');

-- --------------------------------------------------------

--
-- Table structure for table `stylists_clients`
--

CREATE TABLE `stylists_clients` (
  `id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists_clients`
--

INSERT INTO `stylists_clients` (`id`, `stylist_id`, `client_id`) VALUES
(1, 2, 1),
(2, 5, 8),
(3, 6, 8),
(4, 0, 9),
(5, 2, 9);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialtys`
--
ALTER TABLE `specialtys`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialtys_stylists`
--
ALTER TABLE `specialtys_stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists_clients`
--
ALTER TABLE `stylists_clients`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `specialtys`
--
ALTER TABLE `specialtys`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `specialtys_stylists`
--
ALTER TABLE `specialtys_stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `stylists_clients`
--
ALTER TABLE `stylists_clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
