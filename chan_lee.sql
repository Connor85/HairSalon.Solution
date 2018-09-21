-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Sep 21, 2018 at 11:38 PM
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
  `name` varchar(255) NOT NULL,
  `appointment` varchar(255) NOT NULL,
  `stylist_id` int(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `name`, `appointment`, `stylist_id`) VALUES
(1, 'Harry Potter', '2018/09/28', 1),
(2, 'Hermione Granger', '2018/09/29', 1),
(3, 'Aegon Targaryen', '2018/09/24', 2),
(4, 'Cersei Lannister', '2018/09/25', 2),
(5, 'Aria Stark', '2018/09/30', 1),
(6, 'Captain America', '2019/01/01', 4),
(7, 'Aria Stark', '2018/09/31', 2);

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(32) NOT NULL,
  `name` varchar(255) NOT NULL,
  `income` int(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`id`, `name`, `income`) VALUES
(2, 'Chandler', 40000),
(4, 'Monica', 30000),
(5, 'Joey', 30000);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(32) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
