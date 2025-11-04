CREATE DATABASE  IF NOT EXISTS `restaurant` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `restaurant`;
-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: localhost    Database: restaurant
-- ------------------------------------------------------
-- Server version	8.0.43

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `activity_logs`
--

DROP TABLE IF EXISTS `activity_logs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `activity_logs` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `log_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `username` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `role` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `action` text COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=224 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `activity_logs`
--

LOCK TABLES `activity_logs` WRITE;
/*!40000 ALTER TABLE `activity_logs` DISABLE KEYS */;
INSERT INTO `activity_logs` VALUES (1,'2025-10-01 11:14:02','admin','Admin','Logged out'),(2,'2025-10-01 11:44:36','admin','Admin','Logged out'),(3,'2025-10-01 11:45:17','admin','Admin','Logged out'),(4,'2025-10-01 12:10:05','admin','Admin','Logged out'),(5,'2025-10-01 12:11:08','admin','Admin','Logged out'),(6,'2025-10-01 13:33:52','admin','Admin','Logged out'),(7,'2025-10-01 13:35:11','admin','Admin','Logged out'),(8,'2025-10-01 13:45:22','admin','Admin','Logged out'),(9,'2025-10-01 13:53:37','admin','Admin','Logged out'),(10,'2025-10-01 13:54:04','user','User','Logged out'),(11,'2025-10-01 14:13:58','admin','Admin','Logged out'),(12,'2025-10-01 14:51:36','admin','Admin','Logged out'),(13,'2025-10-01 18:59:01','admin','Admin','Logged out'),(14,'2025-10-07 19:55:54','admin','Admin','Logged out'),(15,'2025-10-07 21:06:59','admin','Admin','Logged out'),(16,'2025-10-09 19:45:04','admin','Admin','Logged out'),(17,'2025-10-09 20:01:35','admin','Admin','Logged out'),(18,'2025-10-10 09:13:10','admin','Admin','Logged out'),(19,'2025-10-21 13:43:46','admin','Admin','Logged out'),(20,'2025-10-21 18:47:47','admin','Admin','Logged out'),(21,'0000-00-00 00:00:00','user','cashier','Applied discount: 0'),(22,'0000-00-00 00:00:00','user','cashier','Created an order with total of 30'),(23,'0000-00-00 00:00:00','user','cashier','Created an order with total of 30'),(24,'0000-00-00 00:00:00','user','cashier','Created an order with total of 60'),(25,'0000-00-00 00:00:00','user','cashier','Applied discount: 0'),(26,'0000-00-00 00:00:00','user','cashier','Applied discount: 0'),(27,'0000-00-00 00:00:00','user','cashier','Created an order with total of 30'),(28,'0000-00-00 00:00:00','user','cashier','Applied discount: 0'),(29,'0000-00-00 00:00:00','user','cashier','Applied discount: 0'),(30,'0000-00-00 00:00:00','user','cashier','Applied discount: 20% Type: Senior'),(31,'0000-00-00 00:00:00','user','cashier','Applied discount: 20% Type: PWD'),(32,'2025-10-22 11:04:46','admin','admin','Logged in'),(33,'2025-10-22 11:04:57','admin','Admin','Logged out'),(34,'2025-10-22 11:05:04','user','cashier','Logged in'),(35,'2025-10-22 11:05:11','user','cashier','Logged out'),(36,'0000-00-00 00:00:00','user','cashier','Logged in'),(37,'0000-00-00 00:00:00','user','cashier','Logged out'),(38,'0000-00-00 00:00:00','admin','admin','Logged in'),(39,'0000-00-00 00:00:00','user','cashier','Logged in'),(40,'0000-00-00 00:00:00','user','cashier','Applied discount: 20% Type: Senior'),(41,'0000-00-00 00:00:00','user','cashier','Created an order with total of 96'),(42,'0000-00-00 00:00:00','user','cashier','Logged in'),(43,'0000-00-00 00:00:00','user','cashier','Applied discount: 20% Type: Senior'),(44,'0000-00-00 00:00:00','user','cashier','Created an order with total of 80'),(45,'0000-00-00 00:00:00','user','cashier','Logged out'),(46,'0000-00-00 00:00:00','admin','admin','Logged in'),(47,'0000-00-00 00:00:00','user','cashier','Logged in'),(48,'0000-00-00 00:00:00','user','cashier','Logged in'),(49,'0000-00-00 00:00:00','user','cashier','Logged in'),(50,'0000-00-00 00:00:00','user','cashier','Logged in'),(51,'0000-00-00 00:00:00','user','cashier','Logged in'),(52,'0000-00-00 00:00:00','user','cashier','Logged in'),(53,'0000-00-00 00:00:00','user','cashier','Logged in'),(54,'0000-00-00 00:00:00','user','cashier','Logged in'),(55,'0000-00-00 00:00:00','user','cashier','Logged in'),(56,'0000-00-00 00:00:00','user','cashier','Created an order with total of 150'),(57,'0000-00-00 00:00:00','user','cashier','Logged in'),(58,'0000-00-00 00:00:00','admin','admin','Logged in'),(59,'0000-00-00 00:00:00','user','cashier','Logged in'),(60,'0000-00-00 00:00:00','user','cashier','Created an order with total of 30'),(61,'0000-00-00 00:00:00','user','cashier','Logged out'),(62,'0000-00-00 00:00:00','admin','admin','Logged in'),(63,'2025-10-22 13:16:25','admin','Admin','Logged out'),(64,'0000-00-00 00:00:00','admin','admin','Logged in'),(65,'0000-00-00 00:00:00','admin','admin','Logged in'),(66,'0000-00-00 00:00:00','admin','admin','Logged in'),(67,'0000-00-00 00:00:00','admin','admin','Logged in'),(68,'0000-00-00 00:00:00','admin','admin','Logged in'),(69,'0000-00-00 00:00:00','admin','admin','Logged in'),(70,'0000-00-00 00:00:00','admin','admin','Logged in'),(71,'0000-00-00 00:00:00','admin','admin','Logged in'),(72,'0000-00-00 00:00:00','user','cashier','Logged in'),(73,'0000-00-00 00:00:00','user','cashier','Applied discount: 20% Type: Senior'),(74,'0000-00-00 00:00:00','user','cashier','Logged out'),(75,'0000-00-00 00:00:00','admin','admin','Logged in'),(76,'2025-10-22 15:35:55','admin','Admin','Logged out'),(77,'0000-00-00 00:00:00','user','cashier','Logged in'),(78,'0000-00-00 00:00:00','user','cashier','Logged out'),(79,'0000-00-00 00:00:00','admin','admin','Logged in'),(80,'2025-10-22 17:28:10','admin','Admin','Logged out'),(81,'0000-00-00 00:00:00','admin','admin','Logged in'),(82,'0000-00-00 00:00:00','admin','admin','Logged in'),(83,'0000-00-00 00:00:00','admin','admin','Logged in'),(84,'0000-00-00 00:00:00','admin','admin','Logged in'),(85,'0000-00-00 00:00:00','admin','admin','Logged in'),(86,'0000-00-00 00:00:00','admin','admin','Logged in'),(87,'0000-00-00 00:00:00','admin','admin','Logged in'),(88,'0000-00-00 00:00:00','admin','admin','Logged in'),(89,'0000-00-00 00:00:00','admin','admin','Logged in'),(90,'0000-00-00 00:00:00','admin','admin','Logged in'),(91,'0000-00-00 00:00:00','admin','admin','Logged in'),(92,'0000-00-00 00:00:00','admin','admin','Logged in'),(93,'2025-10-28 21:29:57','admin','Admin','Logged out'),(94,'0000-00-00 00:00:00','admin','admin','Logged in'),(95,'2025-10-28 22:08:57','admin','Admin','Logged out'),(96,'0000-00-00 00:00:00','admin','admin','Logged in'),(97,'2025-10-28 22:10:35','admin','Admin','Logged out'),(98,'0000-00-00 00:00:00','admin','admin','Logged in'),(99,'0000-00-00 00:00:00','admin','admin','Logged in'),(100,'0000-00-00 00:00:00','admin','admin','Logged in'),(101,'0000-00-00 00:00:00','admin','admin','Logged in'),(102,'0000-00-00 00:00:00','admin','admin','Logged in'),(103,'0000-00-00 00:00:00','admin','admin','Logged in'),(104,'0000-00-00 00:00:00','admin','admin','Logged in'),(105,'0000-00-00 00:00:00','admin','admin','Logged in'),(106,'0000-00-00 00:00:00','admin','admin','Logged in'),(107,'0000-00-00 00:00:00','admin','admin','Logged in'),(108,'0000-00-00 00:00:00','admin','admin','Logged in'),(109,'0000-00-00 00:00:00','admin','admin','Logged in'),(110,'0000-00-00 00:00:00','admin','admin','Logged in'),(111,'0000-00-00 00:00:00','admin','admin','Logged in'),(112,'0000-00-00 00:00:00','admin','admin','Logged in'),(113,'0000-00-00 00:00:00','admin','admin','Logged in'),(114,'0000-00-00 00:00:00','admin','admin','Logged in'),(115,'0000-00-00 00:00:00','admin','admin','Logged in'),(116,'0000-00-00 00:00:00','admin','admin','Logged in'),(117,'0000-00-00 00:00:00','admin','admin','Logged in'),(118,'0000-00-00 00:00:00','admin','admin','Logged in'),(119,'0000-00-00 00:00:00','admin','admin','Logged in'),(120,'0000-00-00 00:00:00','admin','admin','Logged in'),(121,'0000-00-00 00:00:00','admin','admin','Logged in'),(122,'0000-00-00 00:00:00','admin','admin','Logged in'),(123,'0000-00-00 00:00:00','admin','admin','Logged in'),(124,'0000-00-00 00:00:00','admin','admin','Logged in'),(125,'0000-00-00 00:00:00','admin','admin','Logged in'),(126,'0000-00-00 00:00:00','admin','admin','Logged in'),(127,'0000-00-00 00:00:00','admin','admin','Logged in'),(128,'0000-00-00 00:00:00','admin','admin','Logged in'),(129,'0000-00-00 00:00:00','admin','admin','Logged in'),(130,'0000-00-00 00:00:00','admin','admin','Logged in'),(131,'0000-00-00 00:00:00','admin','admin','Logged in'),(132,'0000-00-00 00:00:00','admin','admin','Logged in'),(133,'0000-00-00 00:00:00','admin','admin','Logged in'),(134,'0000-00-00 00:00:00','admin','admin','Logged in'),(135,'0000-00-00 00:00:00','admin','admin','Logged in'),(136,'0000-00-00 00:00:00','admin','admin','Logged in'),(137,'0000-00-00 00:00:00','admin','admin','Logged in'),(138,'0000-00-00 00:00:00','admin','admin','Logged in'),(139,'0000-00-00 00:00:00','admin','admin','Logged in'),(140,'0000-00-00 00:00:00','admin','admin','Logged in'),(141,'0000-00-00 00:00:00','admin','admin','Logged in'),(142,'0000-00-00 00:00:00','admin','admin','Logged in'),(143,'0000-00-00 00:00:00','admin','admin','Logged in'),(144,'0000-00-00 00:00:00','admin','admin','Logged in'),(145,'0000-00-00 00:00:00','admin','admin','Logged in'),(146,'0000-00-00 00:00:00','admin','admin','Logged in'),(147,'2025-10-31 12:48:06','admin','Admin','Logged out'),(148,'0000-00-00 00:00:00','admin','admin','Logged in'),(149,'0000-00-00 00:00:00','admin','admin','Logged in'),(150,'0000-00-00 00:00:00','admin','admin','Logged in'),(151,'0000-00-00 00:00:00','admin','admin','Logged in'),(152,'0000-00-00 00:00:00','admin','admin','Logged in'),(153,'0000-00-00 00:00:00','user','cashier','Logged in'),(154,'0000-00-00 00:00:00','user','cashier','Created an order with total of 1000000'),(155,'0000-00-00 00:00:00','admin','admin','Logged in'),(156,'0000-00-00 00:00:00','admin','admin','Logged in'),(157,'0000-00-00 00:00:00','admin','admin','Logged in'),(158,'0000-00-00 00:00:00','admin','admin','Logged in'),(159,'2025-11-02 20:49:52','admin','Admin','Logged out'),(160,'0000-00-00 00:00:00','admin','admin','Logged in'),(161,'0000-00-00 00:00:00','user','cashier','Logged in'),(162,'0000-00-00 00:00:00','user','cashier','Created an order with total of 4000000'),(163,'0000-00-00 00:00:00','user','cashier','Created an order with total of 15000000'),(164,'0000-00-00 00:00:00','user','cashier','Created an order with total of 14000000'),(165,'0000-00-00 00:00:00','user','cashier','Created an order with total of 95'),(166,'0000-00-00 00:00:00','user','cashier','Logged out'),(167,'0000-00-00 00:00:00','admin','admin','Logged in'),(168,'0000-00-00 00:00:00','user','cashier','Logged in'),(169,'0000-00-00 00:00:00','user','cashier','Created an order with total of 15000200'),(170,'0000-00-00 00:00:00','user','cashier','Logged out'),(171,'0000-00-00 00:00:00','admin','admin','Logged in'),(172,'0000-00-00 00:00:00','admin','admin','Logged in'),(173,'2025-11-02 21:38:58','admin','Admin','Logged out'),(174,'0000-00-00 00:00:00','admin','admin','Logged in'),(175,'2025-11-02 21:50:56','admin','Admin','Logged out'),(176,'0000-00-00 00:00:00','admin','admin','Logged in'),(177,'2025-11-02 21:51:11','admin','Admin','Logged out'),(178,'0000-00-00 00:00:00','admin','admin','Logged in'),(179,'2025-11-02 22:20:29','admin','Admin','Logged out'),(180,'0000-00-00 00:00:00','admin','admin','Logged in'),(181,'2025-11-02 22:21:14','admin','Admin','Logged out'),(182,'0000-00-00 00:00:00','admin','admin','Logged in'),(183,'2025-11-02 22:30:28','admin','Admin','Logged out'),(184,'0000-00-00 00:00:00','admin','admin','Logged in'),(185,'2025-11-02 22:36:07','admin','Admin','Logged out'),(186,'0000-00-00 00:00:00','user','cashier','Logged in'),(187,'0000-00-00 00:00:00','user','cashier','Logged out'),(188,'0000-00-00 00:00:00','admin','admin','Logged in'),(189,'2025-11-02 22:38:17','admin','Admin','Logged out'),(190,'0000-00-00 00:00:00','admin','admin','Logged in'),(191,'2025-11-02 22:41:15','admin','Admin','Logged out'),(192,'0000-00-00 00:00:00','admin','admin','Logged in'),(193,'2025-11-02 22:41:46','admin','Admin','Logged out'),(194,'0000-00-00 00:00:00','admin','admin','Logged in'),(195,'0000-00-00 00:00:00','admin','admin','Logged in'),(196,'2025-11-02 23:16:11','admin','Admin','Logged out'),(197,'0000-00-00 00:00:00','admin','admin','Logged in'),(198,'2025-11-03 13:33:42','admin','Admin','Logged out'),(199,'0000-00-00 00:00:00','admin','admin','Logged in'),(200,'2025-11-03 13:40:38','admin','Admin','Logged out'),(201,'0000-00-00 00:00:00','admin','admin','Logged in'),(202,'2025-11-03 13:44:58','admin','Admin','Logged out'),(203,'0000-00-00 00:00:00','admin','admin','Logged in'),(204,'2025-11-03 13:46:19','admin','Admin','Logged out'),(205,'0000-00-00 00:00:00','admin','admin','Logged in'),(206,'2025-11-03 13:59:05','admin','Admin','Logged out'),(207,'0000-00-00 00:00:00','admin','admin','Logged in'),(208,'2025-11-03 14:08:19','admin','Admin','Logged out'),(209,'0000-00-00 00:00:00','admin','admin','Logged in'),(210,'2025-11-03 14:09:07','admin','Admin','Logged out'),(211,'0000-00-00 00:00:00','admin','admin','Logged in'),(212,'2025-11-03 14:39:34','admin','Admin','Logged out'),(213,'0000-00-00 00:00:00','user','cashier','Logged in'),(214,'0000-00-00 00:00:00','user','cashier','Created an order with total of 30'),(215,'0000-00-00 00:00:00','user','cashier','Logged in'),(216,'0000-00-00 00:00:00','user','cashier','Logged in'),(217,'0000-00-00 00:00:00','admin','admin','Logged in'),(218,'0000-00-00 00:00:00','admin','admin','Logged in'),(219,'2025-11-03 21:05:23','admin','Admin','Logged out'),(220,'0000-00-00 00:00:00','admin','admin','Logged in'),(221,'0000-00-00 00:00:00','admin','admin','Logged in'),(222,'0000-00-00 00:00:00','admin','admin','Logged in'),(223,'2025-11-05 00:21:07','admin','Admin','Logged out');
/*!40000 ALTER TABLE `activity_logs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `admin`
--

DROP TABLE IF EXISTS `admin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `admin` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `Password` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Username` (`Username`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `admin`
--

LOCK TABLES `admin` WRITE;
/*!40000 ALTER TABLE `admin` DISABLE KEYS */;
INSERT INTO `admin` VALUES (1,'admin','admin');
/*!40000 ALTER TABLE `admin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `archived_users`
--

DROP TABLE IF EXISTS `archived_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `archived_users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `password` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `role` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `date_created` datetime NOT NULL,
  `archived_date` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `archived_users`
--

LOCK TABLES `archived_users` WRITE;
/*!40000 ALTER TABLE `archived_users` DISABLE KEYS */;
/*!40000 ALTER TABLE `archived_users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `CategoryName` (`CategoryName`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'Desserts'),(2,'Drinks'),(3,'Foods'),(4,'Snacks_Sides');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `desserts`
--

DROP TABLE IF EXISTS `desserts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `desserts` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `ItemName` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `ItemPrice` int NOT NULL,
  `ImagePath` varchar(255) COLLATE utf8mb4_general_ci DEFAULT 'N/A',
  `DateAdded` datetime DEFAULT CURRENT_TIMESTAMP,
  `ItemId` int DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `desserts`
--

LOCK TABLES `desserts` WRITE;
/*!40000 ALTER TABLE `desserts` DISABLE KEYS */;
INSERT INTO `desserts` VALUES (1,'Fruit Salad',30,'N/A','2025-10-30 11:28:23',1),(2,'Halo Haloggggcc',25,'N/A','2025-10-30 11:28:23',2);
/*!40000 ALTER TABLE `desserts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `drinks`
--

DROP TABLE IF EXISTS `drinks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `drinks` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `ItemName` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `ItemPrice` int NOT NULL,
  `ImagePath` varchar(255) COLLATE utf8mb4_general_ci DEFAULT 'N/A',
  `DateAdded` datetime DEFAULT CURRENT_TIMESTAMP,
  `ItemId` int DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `drinks`
--

LOCK TABLES `drinks` WRITE;
/*!40000 ALTER TABLE `drinks` DISABLE KEYS */;
INSERT INTO `drinks` VALUES (1,'Wintermelon',20,'N/A','2025-10-30 11:28:16',1),(2,'Chocolate',20,'N/A','2025-10-30 11:28:16',2);
/*!40000 ALTER TABLE `drinks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `foods`
--

DROP TABLE IF EXISTS `foods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `foods` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `ItemName` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `ItemPrice` double NOT NULL,
  `ImagePath` varchar(255) COLLATE utf8mb4_general_ci DEFAULT 'N/A',
  `DateAdded` datetime DEFAULT CURRENT_TIMESTAMP,
  `ItemId` int DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `foods`
--

LOCK TABLES `foods` WRITE;
/*!40000 ALTER TABLE `foods` DISABLE KEYS */;
INSERT INTO `foods` VALUES (1,'Burger',30.5,NULL,'2025-10-30 11:27:56',1),(2,'Hotdog',20.3,'N/A','2025-10-30 11:27:56',2),(3,'Fries',20,'N/A','2025-10-30 11:27:56',3),(4,'CheeseCake',30,NULL,'2025-10-30 11:27:56',4),(10,'Kaoruko Waguri',1000000,'C:\\Users\\rosales\\Downloads\\kaoruko beauty.jpeg','2025-10-31 13:49:21',NULL),(11,'Arisu Sakayanagi',1000000,'C:\\Users\\rosales\\Downloads\\arisu sakayanagi.png','2025-10-31 13:56:24',NULL);
/*!40000 ALTER TABLE `foods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `loginlogs`
--

DROP TABLE IF EXISTS `loginlogs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `loginlogs` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `DateLogin` date NOT NULL,
  `TimeLogin` time NOT NULL,
  `Role` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=292 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `loginlogs`
--

LOCK TABLES `loginlogs` WRITE;
/*!40000 ALTER TABLE `loginlogs` DISABLE KEYS */;
INSERT INTO `loginlogs` VALUES (1,'admin','2025-10-01','10:28:33','Role here'),(2,'admin','2025-10-01','10:28:52','Role here'),(3,'admin','2025-10-01','10:37:24','Role here'),(4,'admin','2025-10-01','10:38:55','Role here'),(5,'admin','2025-10-01','10:42:23','Role here'),(6,'admin','2025-10-01','10:56:43','Role here'),(7,'admin','2025-10-01','10:59:15','Role here'),(8,'admin','2025-10-01','10:59:34','Role here'),(9,'admin','2025-10-01','10:59:45','Role here'),(10,'admin','2025-10-01','11:00:02','Role here'),(11,'admin','2025-10-01','11:05:05','Role here'),(12,'admin','2025-10-01','11:10:51','Role here'),(13,'admin','2025-10-01','11:11:36','Role here'),(14,'admin','2025-10-01','11:13:52','Role here'),(15,'admin','2025-10-01','11:15:59','Role here'),(16,'admin','2025-10-01','11:17:19','Role here'),(17,'admin','2025-10-01','11:21:45','Role here'),(18,'admin','2025-10-01','11:26:00','Role here'),(19,'admin','2025-10-01','11:39:01','Role here'),(20,'admin','2025-10-01','11:39:24','Role here'),(21,'admin','2025-10-01','11:39:38','Role here'),(22,'admin','2025-10-01','11:40:15','Role here'),(23,'admin','2025-10-01','11:41:09','Role here'),(24,'admin','2025-10-01','11:41:56','Role here'),(25,'admin','2025-10-01','11:44:17','Role here'),(26,'admin','2025-10-01','11:44:39','Role here'),(27,'admin','2025-10-01','11:51:29','Role here'),(28,'admin','2025-10-01','12:09:43','Role here'),(29,'admin','2025-10-01','12:10:10','Role here'),(30,'admin','2025-10-01','13:30:55','Role here'),(31,'admin','2025-10-01','13:31:54','Role here'),(32,'user','2025-10-01','13:33:06','Role here'),(33,'admin','2025-10-01','13:33:32','Role here'),(34,'user','2025-10-01','13:34:01','Role here'),(35,'admin','2025-10-01','13:34:39','Role here'),(36,'user','2025-10-01','13:35:22','Role here'),(37,'admin','2025-10-01','13:36:23','Role here'),(38,'user','2025-10-01','13:36:54','Role here'),(39,'user','2025-10-01','13:42:24','Role here'),(40,'admin','2025-10-01','13:44:46','Role here'),(41,'user','2025-10-01','13:49:33','Role here'),(42,'admin','2025-10-01','13:53:17','Role here'),(43,'user','2025-10-01','13:53:48','Role here'),(44,'user','2025-10-01','13:54:57','Role here'),(45,'user','2025-10-01','13:59:26','Role here'),(46,'user','2025-10-01','14:04:04','Role here'),(47,'admin','2025-10-01','14:12:53','Role here'),(48,'user','2025-10-01','14:14:20','Role here'),(49,'user','2025-10-01','14:25:57','Role here'),(50,'user','2025-10-01','14:37:42','Role here'),(51,'user','2025-10-01','14:40:44','Role here'),(52,'user','2025-10-01','14:42:00','Role here'),(53,'admin','2025-10-01','14:50:21','Role here'),(54,'user','2025-10-01','14:51:53','Role here'),(55,'user','2025-10-01','15:01:37','Role here'),(56,'admin','2025-10-01','15:03:45','Role here'),(57,'user','2025-10-01','18:35:34','Role here'),(58,'user','2025-10-01','18:44:01','Role here'),(59,'admin','2025-10-01','18:51:08','Role here'),(60,'user','2025-10-07','18:20:16','Role here'),(61,'admin','2025-10-07','19:55:26','Role here'),(62,'admin','2025-10-07','20:19:41','Role here'),(63,'admin','2025-10-07','20:51:21','Role here'),(64,'admin','2025-10-07','20:59:09','Role here'),(65,'admin','2025-10-07','21:01:17','Role here'),(66,'admin','2025-10-07','21:02:33','Role here'),(67,'admin','2025-10-07','21:05:08','Role here'),(68,'admin','2025-10-07','21:13:30','Role here'),(69,'admin','2025-10-09','19:44:42','Role here'),(70,'admin','2025-10-09','19:50:11','Role here'),(71,'admin','2025-10-10','09:03:41','Role here'),(72,'admin','2025-10-10','09:04:57','Role here'),(73,'admin','2025-10-10','09:12:36','Role here'),(74,'admin','2025-10-10','09:13:17','Role here'),(75,'admin','2025-10-13','19:52:10','Role here'),(76,'admin','2025-10-13','19:57:56','Role here'),(77,'admin','2025-10-21','13:42:32','admin'),(78,'admin','2025-10-21','13:43:13','admin'),(79,'admin','2025-10-21','14:04:52','admin'),(80,'admin','2025-10-21','14:05:54','admin'),(81,'admin','2025-10-21','18:06:37','admin'),(82,'admin','2025-10-21','18:07:18','admin'),(83,'admin','2025-10-21','18:12:51','admin'),(84,'admin','2025-10-21','18:16:52','admin'),(85,'admin','2025-10-21','18:18:09','admin'),(86,'admin','2025-10-21','18:31:41','admin'),(87,'admin','2025-10-21','18:33:19','admin'),(88,'admin','2025-10-21','18:36:09','admin'),(89,'admin','2025-10-21','18:45:28','admin'),(90,'admin','2025-10-21','18:46:32','admin'),(91,'user','2025-10-21','18:47:54','cashier'),(92,'user','2025-10-21','19:04:40','cashier'),(93,'user','2025-10-21','19:11:58','cashier'),(94,'user','2025-10-21','20:14:23','cashier'),(95,'user','2025-10-21','20:16:20','cashier'),(96,'user','2025-10-21','20:21:59','cashier'),(97,'user','2025-10-21','20:50:49','cashier'),(98,'user','2025-10-22','08:51:13','cashier'),(99,'user','2025-10-22','08:56:22','cashier'),(100,'user','2025-10-22','08:57:01','cashier'),(101,'user','2025-10-22','08:57:38','cashier'),(102,'user','2025-10-22','08:58:49','cashier'),(103,'user','2025-10-22','08:59:45','cashier'),(104,'user','2025-10-22','09:12:45','cashier'),(105,'user','2025-10-22','09:44:51','cashier'),(106,'user','2025-10-22','10:23:34','cashier'),(107,'admin','2025-10-22','10:28:53','admin'),(108,'user','2025-10-22','10:31:24','cashier'),(109,'user','2025-10-22','10:34:01','cashier'),(110,'user','2025-10-22','10:38:27','cashier'),(111,'admin','2025-10-22','10:43:16','admin'),(112,'user','2025-10-22','10:46:32','cashier'),(113,'admin','2025-10-22','10:46:48','admin'),(114,'admin','2025-10-22','11:04:46','admin'),(115,'user','2025-10-22','11:05:04','cashier'),(116,'user','2025-10-22','11:05:23','cashier'),(117,'admin','2025-10-22','11:05:36','admin'),(118,'user','2025-10-22','11:06:48','cashier'),(119,'user','2025-10-22','11:14:00','cashier'),(120,'admin','2025-10-22','11:15:40','admin'),(121,'user','2025-10-22','11:35:57','cashier'),(122,'user','2025-10-22','11:37:06','cashier'),(123,'user','2025-10-22','11:37:45','cashier'),(124,'user','2025-10-22','11:38:08','cashier'),(125,'user','2025-10-22','11:38:28','cashier'),(126,'user','2025-10-22','11:39:14','cashier'),(127,'user','2025-10-22','11:48:51','cashier'),(128,'user','2025-10-22','11:49:07','cashier'),(129,'user','2025-10-22','12:18:40','cashier'),(130,'user','2025-10-22','12:24:39','cashier'),(131,'admin','2025-10-22','12:29:29','admin'),(132,'user','2025-10-22','13:13:21','cashier'),(133,'admin','2025-10-22','13:16:02','admin'),(134,'admin','2025-10-22','14:17:00','admin'),(135,'admin','2025-10-22','14:26:14','admin'),(136,'admin','2025-10-22','14:33:26','admin'),(137,'admin','2025-10-22','14:46:28','admin'),(138,'admin','2025-10-22','14:57:11','admin'),(139,'admin','2025-10-22','14:58:37','admin'),(140,'admin','2025-10-22','15:00:44','admin'),(141,'admin','2025-10-22','15:02:32','admin'),(142,'user','2025-10-22','15:25:55','cashier'),(143,'admin','2025-10-22','15:35:01','admin'),(144,'user','2025-10-22','15:36:03','cashier'),(145,'admin','2025-10-22','15:36:23','admin'),(146,'admin','2025-10-22','17:28:11','admin'),(147,'admin','2025-10-27','19:11:49','admin'),(148,'admin','2025-10-28','09:03:18','admin'),(149,'admin','2025-10-28','13:30:52','admin'),(150,'admin','2025-10-28','13:32:08','admin'),(151,'admin','2025-10-28','13:41:22','admin'),(152,'admin','2025-10-28','13:44:45','admin'),(153,'admin','2025-10-28','13:45:46','admin'),(154,'admin','2025-10-28','14:15:32','admin'),(155,'admin','2025-10-28','14:22:17','admin'),(156,'admin','2025-10-28','14:25:08','admin'),(157,'admin','2025-10-28','21:28:54','admin'),(158,'admin','2025-10-28','22:07:56','admin'),(159,'admin','2025-10-28','22:09:33','admin'),(160,'admin','2025-10-28','22:23:48','admin'),(161,'admin','2025-10-28','22:25:40','admin'),(162,'admin','2025-10-28','22:30:48','admin'),(163,'admin','2025-10-28','22:39:50','admin'),(164,'admin','2025-10-28','22:41:07','admin'),(165,'admin','2025-10-28','22:47:53','admin'),(166,'admin','2025-10-28','22:48:47','admin'),(167,'admin','2025-10-28','22:49:41','admin'),(168,'admin','2025-10-28','23:18:09','admin'),(169,'admin','2025-10-28','23:18:41','admin'),(170,'admin','2025-10-28','23:19:20','admin'),(171,'admin','2025-10-28','23:29:13','admin'),(172,'admin','2025-10-28','23:45:40','admin'),(173,'admin','2025-10-29','00:03:18','admin'),(174,'admin','2025-10-29','00:06:44','admin'),(175,'admin','2025-10-29','00:17:16','admin'),(176,'admin','2025-10-29','12:01:24','admin'),(177,'admin','2025-10-30','10:57:42','admin'),(178,'admin','2025-10-30','11:04:18','admin'),(179,'admin','2025-10-30','11:06:42','admin'),(180,'admin','2025-10-30','11:27:40','admin'),(181,'admin','2025-10-30','20:42:17','admin'),(182,'admin','2025-10-30','20:43:05','admin'),(183,'admin','2025-10-30','21:07:02','admin'),(184,'admin','2025-10-30','21:09:26','admin'),(185,'admin','2025-10-30','21:13:23','admin'),(186,'admin','2025-10-30','21:22:20','admin'),(187,'admin','2025-10-30','21:33:45','admin'),(188,'admin','2025-10-30','21:45:55','admin'),(189,'admin','2025-10-30','21:51:27','admin'),(190,'admin','2025-10-30','22:59:23','admin'),(191,'admin','2025-10-30','23:18:30','admin'),(192,'admin','2025-10-30','23:36:55','admin'),(193,'admin','2025-10-30','23:40:24','admin'),(194,'admin','2025-10-31','01:49:31','admin'),(195,'admin','2025-10-31','01:52:19','admin'),(196,'admin','2025-10-31','02:57:44','admin'),(197,'admin','2025-10-31','02:59:24','admin'),(198,'admin','2025-10-31','11:21:51','admin'),(199,'admin','2025-10-31','11:24:51','admin'),(200,'admin','2025-10-31','11:26:44','admin'),(201,'admin','2025-10-31','11:33:07','admin'),(202,'admin','2025-10-31','11:35:48','admin'),(203,'admin','2025-10-31','11:42:45','admin'),(204,'admin','2025-10-31','11:50:41','admin'),(205,'admin','2025-10-31','12:10:45','admin'),(206,'admin','2025-10-31','12:22:52','admin'),(207,'admin','2025-10-31','12:34:35','admin'),(208,'admin','2025-10-31','12:47:50','admin'),(209,'admin','2025-10-31','12:48:08','admin'),(210,'admin','2025-10-31','12:53:35','admin'),(211,'admin','2025-10-31','12:56:04','admin'),(212,'admin','2025-10-31','13:08:27','admin'),(213,'admin','2025-10-31','13:49:07','admin'),(214,'user','2025-10-31','13:53:40','cashier'),(215,'admin','2025-10-31','13:54:24','admin'),(216,'admin','2025-10-31','13:55:38','admin'),(217,'admin','2025-10-31','14:04:22','admin'),(218,'admin','2025-11-02','20:49:45','admin'),(219,'admin','2025-11-02','20:49:58','admin'),(220,'user','2025-11-02','20:50:37','cashier'),(221,'admin','2025-11-02','20:51:55','admin'),(222,'user','2025-11-02','20:56:56','cashier'),(223,'admin','2025-11-02','20:57:33','admin'),(224,'admin','2025-11-02','21:38:15','admin'),(225,'admin','2025-11-02','21:50:51','admin'),(226,'admin','2025-11-02','21:50:57','admin'),(227,'admin','2025-11-02','22:20:23','admin'),(228,'admin','2025-11-02','22:20:30','admin'),(229,'admin','2025-11-02','22:30:20','admin'),(230,'admin','2025-11-02','22:35:57','admin'),(231,'user','2025-11-02','22:36:13','cashier'),(232,'admin','2025-11-02','22:36:25','admin'),(233,'admin','2025-11-02','22:41:08','admin'),(234,'admin','2025-11-02','22:41:16','admin'),(235,'admin','2025-11-02','22:59:53','admin'),(236,'admin','2025-11-02','23:15:00','admin'),(237,'admin','2025-11-03','13:33:09','admin'),(238,'admin','2025-11-03','13:37:39','admin'),(239,'admin','2025-11-03','13:44:50','admin'),(240,'admin','2025-11-03','13:45:00','admin'),(241,'admin','2025-11-03','13:58:19','admin'),(242,'admin','2025-11-03','14:08:13','admin'),(243,'admin','2025-11-03','14:08:28','admin'),(244,'admin','2025-11-03','14:34:14','admin'),(245,'user','2025-11-03','20:17:00','cashier'),(246,'user','2025-11-03','20:40:36','cashier'),(247,'user','2025-11-03','20:48:19','cashier'),(248,'admin','2025-11-03','20:58:18','admin'),(249,'admin','2025-11-03','21:05:17','admin'),(250,'admin','2025-11-03','21:06:42','admin'),(251,'admin','2025-11-03','21:19:18','admin'),(252,'admin','2025-11-03','21:26:10','admin'),(253,'user','2025-11-04','23:00:27','cashier'),(254,'user','2025-11-04','23:05:04','cashier'),(255,'user','2025-11-04','23:06:32','cashier'),(256,'user','2025-11-04','23:10:57','cashier'),(257,'user','2025-11-04','23:11:57','cashier'),(258,'user','2025-11-04','23:12:36','cashier'),(259,'user','2025-11-04','23:15:58','cashier'),(260,'user','2025-11-04','23:17:44','cashier'),(261,'user','2025-11-04','23:19:01','cashier'),(262,'user','2025-11-04','23:20:35','cashier'),(263,'user','2025-11-04','23:22:50','cashier'),(264,'user','2025-11-04','23:25:00','cashier'),(265,'user','2025-11-04','23:26:19','cashier'),(266,'user','2025-11-04','23:26:51','cashier'),(267,'user','2025-11-04','23:27:48','cashier'),(268,'user','2025-11-04','23:28:54','cashier'),(269,'user','2025-11-04','23:31:01','cashier'),(270,'user','2025-11-04','23:32:18','cashier'),(271,'user','2025-11-04','23:34:31','cashier'),(272,'user','2025-11-04','23:35:47','cashier'),(273,'user','2025-11-04','23:37:18','cashier'),(274,'user','2025-11-04','23:38:11','cashier'),(275,'user','2025-11-04','23:40:38','cashier'),(276,'user','2025-11-04','23:41:52','cashier'),(277,'user','2025-11-04','23:42:48','cashier'),(278,'user','2025-11-04','23:47:48','Cashier'),(279,'user','2025-11-04','23:49:28','Cashier'),(280,'user','2025-11-04','23:49:39','Cashier'),(281,'user','2025-11-04','23:50:46','Cashier'),(282,'user','2025-11-04','23:53:44','Cashier'),(283,'user','2025-11-04','23:58:18','Cashier'),(284,'admin','2025-11-05','00:00:51','Admin'),(285,'admin','2025-11-05','00:12:32','Cashier'),(286,'user','2025-11-05','00:15:08','Admin'),(287,'admin','2025-11-05','00:21:02','Admin'),(288,'user','2025-11-05','00:21:11','Cashier'),(289,'user','2025-11-05','00:22:13','Cashier'),(290,'admin','2025-11-05','00:22:26','Admin'),(291,'admin','2025-11-05','00:23:29','Admin');
/*!40000 ALTER TABLE `loginlogs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_items`
--

DROP TABLE IF EXISTS `order_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_items` (
  `id` int NOT NULL AUTO_INCREMENT,
  `order_id` int NOT NULL,
  `item_name` varchar(150) COLLATE utf8mb4_general_ci NOT NULL,
  `price` decimal(10,2) NOT NULL DEFAULT '0.00',
  `quantity` int NOT NULL DEFAULT '1',
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `order_id` (`order_id`),
  CONSTRAINT `fk_orderitems_orders` FOREIGN KEY (`order_id`) REFERENCES `orders` (`ID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_items`
--

LOCK TABLES `order_items` WRITE;
/*!40000 ALTER TABLE `order_items` DISABLE KEYS */;
INSERT INTO `order_items` VALUES (1,28,'Burger',30.00,2,'2025-11-02 20:57:20'),(2,28,'Hotdog',20.00,2,'2025-11-02 20:57:20'),(3,28,'Fries',20.00,2,'2025-11-02 20:57:20'),(4,28,'CheeseCake',30.00,2,'2025-11-02 20:57:20'),(5,28,'Kaoruko Waguri',1000000.00,7,'2025-11-02 20:57:20'),(6,28,'Arisu Sakayanagi',1000000.00,8,'2025-11-02 20:57:20');
/*!40000 ALTER TABLE `order_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `order_date` date NOT NULL,
  `order_time` time NOT NULL,
  `username` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `total_amount` int NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES (1,'2025-10-01','13:33:17','user',0),(2,'2025-10-01','13:34:12','user',0),(3,'2025-10-01','13:43:29','user',0),(4,'2025-10-01','13:43:32','user',0),(5,'2025-10-01','13:43:35','user',0),(6,'2025-10-01','13:49:51','user',75),(7,'2025-10-01','13:49:56','user',100),(8,'2025-10-01','13:50:29','user',100),(9,'2025-10-01','13:50:35','user',100),(10,'2025-10-01','14:14:44','user',200),(11,'2025-10-01','15:03:31','user',145),(12,'2025-10-01','18:50:05','user',165),(13,'2025-10-22','09:00:51','user',100),(14,'2025-10-22','09:12:51','user',30),(15,'2025-10-22','09:13:15','user',30),(16,'2025-10-22','09:44:57','user',30),(17,'2025-10-22','10:23:44','user',60),(18,'2025-10-22','10:31:31','user',30),(19,'2025-10-22','11:07:13','user',96),(20,'2025-10-22','11:14:17','user',80),(21,'2025-10-22','12:18:49','user',150),(22,'2025-10-22','13:14:24','user',30),(23,'2025-10-31','13:54:02','user',1000000),(24,'2025-11-02','20:50:46','user',4000000),(25,'2025-11-02','20:51:01','user',15000000),(26,'2025-11-02','20:51:22','user',14000000),(27,'2025-11-02','20:51:43','user',95),(28,'2025-11-02','20:57:20','user',15000200),(29,'2025-11-03','20:17:06','user',30);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pending_menu_inserts`
--

DROP TABLE IF EXISTS `pending_menu_inserts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pending_menu_inserts` (
  `id` int NOT NULL AUTO_INCREMENT,
  `ItemName` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `ItemPrice` decimal(10,2) NOT NULL,
  `ImagePath` text COLLATE utf8mb4_general_ci,
  `CategoryTable` varchar(100) COLLATE utf8mb4_general_ci NOT NULL,
  `DateAdded` datetime NOT NULL,
  `Processed` tinyint(1) DEFAULT '0',
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pending_menu_inserts`
--

LOCK TABLES `pending_menu_inserts` WRITE;
/*!40000 ALTER TABLE `pending_menu_inserts` DISABLE KEYS */;
INSERT INTO `pending_menu_inserts` VALUES (1,'Kaoruko Waguri',99999999.99,'C:\\Users\\rosales\\Downloads\\kaoruko beauty.jpeg','Foods','2025-10-31 12:11:00',0,'2025-10-31 04:11:00'),(2,'Arisu',1000000.00,'C:\\Users\\rosales\\Downloads\\arisu 4k.jpg','Foods','2025-10-31 12:11:44',0,'2025-10-31 04:11:44');
/*!40000 ALTER TABLE `pending_menu_inserts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settings`
--

DROP TABLE IF EXISTS `settings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `settings` (
  `MenuItemButtonSize` int DEFAULT '100',
  `MenuItemFontSize` int DEFAULT '10',
  `EnableShortcutKeys` tinyint(1) DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settings`
--

LOCK TABLES `settings` WRITE;
/*!40000 ALTER TABLE `settings` DISABLE KEYS */;
/*!40000 ALTER TABLE `settings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `snacks_sides`
--

DROP TABLE IF EXISTS `snacks_sides`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `snacks_sides` (
  `ItemId` int NOT NULL,
  `ItemName` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `ItemPrice` decimal(10,2) NOT NULL DEFAULT '0.00',
  `ImagePath` varchar(1024) COLLATE utf8mb4_general_ci DEFAULT 'N/A',
  `DateAdded` datetime DEFAULT CURRENT_TIMESTAMP,
  `ID` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `snacks_sides`
--

LOCK TABLES `snacks_sides` WRITE;
/*!40000 ALTER TABLE `snacks_sides` DISABLE KEYS */;
/*!40000 ALTER TABLE `snacks_sides` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `Password` varchar(255) COLLATE utf8mb4_general_ci NOT NULL,
  `role` varchar(20) COLLATE utf8mb4_general_ci NOT NULL,
  `date_created` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Username` (`Username`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (7,'user','user','Cashier','2025-10-07 21:05:00'),(8,'user123','user123','User','2025-10-22 14:17:21'),(9,'alvin','alvin','User','2025-10-22 16:02:39'),(10,'admin','admin','Admin','2025-11-05 00:00:46');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-11-05  0:29:00
