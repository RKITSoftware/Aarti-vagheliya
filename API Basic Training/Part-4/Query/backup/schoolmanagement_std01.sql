CREATE DATABASE  IF NOT EXISTS `schoolmanagement` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `schoolmanagement`;
-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: schoolmanagement
-- ------------------------------------------------------
-- Server version	8.0.27

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
-- Table structure for table `std01`
--

DROP TABLE IF EXISTS `std01`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `std01` (
  `d01f01` int DEFAULT NULL COMMENT 'StudentID',
  `d01f02` varchar(50) DEFAULT NULL COMMENT 'FirstName',
  `d01f03` varchar(50) DEFAULT NULL COMMENT 'LastName',
  `d01f04` date DEFAULT NULL COMMENT 'DateOfBirth',
  `d01f05` varchar(10) DEFAULT NULL COMMENT 'Gender',
  `d01f06` varchar(30) DEFAULT NULL COMMENT 'Email',
  `d01f07` varchar(30) DEFAULT NULL COMMENT 'ContactNumber',
  `d01f08` int DEFAULT NULL,
  UNIQUE KEY `idx_UniqueEmail` (`d01f06`),
  KEY `idx_FirstName` (`d01f02`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `std01`
--

LOCK TABLES `std01` WRITE;
/*!40000 ALTER TABLE `std01` DISABLE KEYS */;
INSERT INTO `std01` VALUES (1,'Arti','Vagheliya','2002-09-25','Female','arti@gmail.com','+91 1234567891',90),(2,'Ishika','Jethwa','2002-09-15','Female','ishika@gmail.com','+91 1234564491',92),(3,'Dimple','Mithiya','2002-08-25','Female','dimple@gmail.com','+91 1234789891',85),(4,'Krinsi','Kayada','2001-09-25','Female','krinsi@gmail.com','+91 9834567891',80),(5,'Yashvi',NULL,'2001-04-15','Female','yashvi@gmail.com','+91 9834567121',85);
/*!40000 ALTER TABLE `std01` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-01-15 18:25:35
