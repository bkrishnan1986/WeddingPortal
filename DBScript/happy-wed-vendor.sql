-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: happy-wed-vendor
-- ------------------------------------------------------
-- Server version	8.0.19

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
-- Table structure for table `asset`
--

DROP TABLE IF EXISTS `asset`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `asset` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `AssetType` int NOT NULL,
  `AssetName` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `AssetCondition` int NOT NULL,
  `Status` int NOT NULL,
  `AssociatedVendorService` int DEFAULT NULL,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Unit` int NOT NULL,
  `Quantity` decimal(5,2) NOT NULL,
  `VendorId` int NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `asset-type_idx` (`AssetType`),
  KEY `asset-condition_idx` (`AssetCondition`),
  KEY `asset-status_idx` (`Status`),
  KEY `asso-vendor-service_idx` (`AssociatedVendorService`),
  KEY `asset-unit_idx` (`Unit`),
  CONSTRAINT `asset-condition` FOREIGN KEY (`AssetCondition`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `asset-status` FOREIGN KEY (`Status`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `asset-type` FOREIGN KEY (`AssetType`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `asset-unit` FOREIGN KEY (`Unit`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `asso-vendor-service` FOREIGN KEY (`AssociatedVendorService`) REFERENCES `service` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `asset`
--

LOCK TABLES `asset` WRITE;
/*!40000 ALTER TABLE `asset` DISABLE KEYS */;
/*!40000 ALTER TABLE `asset` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `branches`
--

DROP TABLE IF EXISTS `branches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `branches` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DistrictId` int NOT NULL,
  `ListingAddress` varchar(500) DEFAULT NULL,
  `BuildingName` varchar(250) DEFAULT NULL,
  `FlatPlotDoorNo` varchar(45) DEFAULT NULL,
  `Floor` varchar(45) DEFAULT NULL,
  `StreetName` varchar(45) DEFAULT NULL,
  `LocalityName` varchar(45) DEFAULT NULL,
  `Pincode` varchar(45) DEFAULT NULL,
  `Landmark` varchar(250) DEFAULT NULL,
  `Latitude` varchar(45) DEFAULT NULL,
  `Longitude` varchar(45) DEFAULT NULL,
  `EstablishedYear` year DEFAULT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_DistrictName_idx` (`DistrictId`),
  CONSTRAINT `FK_DistrictName` FOREIGN KEY (`DistrictId`) REFERENCES `multidetail` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=58 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `branches`
--

LOCK TABLES `branches` WRITE;
/*!40000 ALTER TABLE `branches` DISABLE KEYS */;
INSERT INTO `branches` VALUES (37,18,'string','string','string','string','string','string','string','string','string','string',0000,_binary '',0,'2020-12-15 07:04:16',NULL,NULL),(38,19,'string','string','string','string','string','string','string','string','string','string',2000,_binary '',1,'2020-12-15 07:04:16',NULL,NULL),(39,20,'new address','281','string','string','string','string','string','string','string','string',2005,_binary '',1,'2020-12-15 08:44:37',NULL,NULL),(40,18,'string','string','string','string','string','string','string','string','string','string',0000,_binary '',0,'2020-12-15 09:54:44',NULL,NULL),(41,19,'string','string','string','string','string','string','string','string','string','string',1990,_binary '',1,'2020-12-15 10:04:44',NULL,NULL),(42,20,'string','string','string','string','string','string','string','string','string','string',1990,_binary '',1,'2020-12-15 11:02:44',NULL,NULL),(43,20,'string','string','string','string','string','string','string','string','string','string',1990,_binary '',1,'2020-12-15 11:03:11',NULL,NULL),(44,20,'string','string','string','string','string','string','string','string','string','string',1990,_binary '',1,'2020-12-15 11:03:47',NULL,NULL),(45,20,'string','string','string','string','string','string','string','string','string','string',1990,_binary '',1,'2020-12-15 11:05:37',NULL,NULL),(46,18,'string','string','string','string','string','string','string','string','string','string',0000,_binary '',0,'2020-12-15 11:23:25',NULL,NULL),(47,18,'string','string','string','string','string','string','string','string','string','string',0000,_binary '',1,'2020-12-15 11:24:52',NULL,NULL),(48,18,'string','string','string','string','string','string','string','string','string','string',2005,_binary '',1,'2020-12-16 06:26:26',NULL,NULL),(49,20,'string','string','string','string','string','string','string','string','string','string',1993,_binary '',1,'2020-12-16 06:32:24',NULL,NULL),(50,20,'string','string','string','string','string','string','string','string','string','string',1993,_binary '',1,'2020-12-16 06:34:29',NULL,NULL),(51,20,'string','string','string','string','string','string','string','string','string','string',2000,_binary '',1,'2020-12-16 07:10:25',NULL,NULL),(52,18,'string','string','string','string','string','string','string','string','string','string',2006,_binary '',1,'2020-12-16 07:12:39',NULL,NULL),(53,18,'string','string','string','string','string','string','string','string','string','string',0000,_binary '',0,'2020-12-18 05:17:57',NULL,NULL),(54,38,'string','string','string','string','string','string','string','string','string','string',2000,_binary '',1,'2020-12-18 05:17:57',NULL,NULL),(55,18,'string','string','string','string','string','string','string','string','string','string',0000,_binary '',0,'2020-12-18 05:56:18',NULL,NULL),(56,38,'string','string','string','string','string','string','string','string','string','string',2000,_binary '',1,'2020-12-18 05:56:18',NULL,NULL),(57,18,'string','string','string','string','string','string','string','string','string','string',0000,_binary '',0,'2020-12-18 05:58:34',NULL,NULL);
/*!40000 ALTER TABLE `branches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `branchserviceoffered`
--

DROP TABLE IF EXISTS `branchserviceoffered`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `branchserviceoffered` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ServiceId` int NOT NULL,
  `BranchId` int NOT NULL,
  `ContactPerson` varchar(45) DEFAULT NULL,
  `PrimaryMobileNumber` varchar(45) DEFAULT NULL,
  `EmailId` varchar(45) DEFAULT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_BranchId_idx` (`BranchId`),
  KEY `FK_Service_idx` (`ServiceId`),
  CONSTRAINT `FK_Branch` FOREIGN KEY (`BranchId`) REFERENCES `branches` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_Service` FOREIGN KEY (`ServiceId`) REFERENCES `multidetail` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `branchserviceoffered`
--

LOCK TABLES `branchserviceoffered` WRITE;
/*!40000 ALTER TABLE `branchserviceoffered` DISABLE KEYS */;
INSERT INTO `branchserviceoffered` VALUES (13,14,37,'new','8888','string',_binary '',0,'2020-12-15 07:04:16',NULL,NULL),(14,15,38,'new1','47895','string',_binary '',1,'2020-12-15 07:04:16',NULL,NULL),(15,16,39,'arun','string','string',_binary '',1,'2020-12-15 08:44:37',NULL,NULL),(16,15,40,'new','8888','string',_binary '',0,'2020-12-15 09:54:44',NULL,NULL),(17,14,41,'string','string','string',_binary '',1,'2020-12-15 10:04:44',NULL,NULL),(18,15,42,'newdata','string','string',_binary '',1,'2020-12-15 11:02:44',NULL,NULL),(19,15,43,'newdata','string','string',_binary '',1,'2020-12-15 11:03:11',NULL,NULL),(20,15,44,'newdata','string','string',_binary '',1,'2020-12-15 11:03:47',NULL,NULL),(21,15,45,'newdata','string','string',_binary '',1,'2020-12-15 11:05:37',NULL,NULL),(22,14,46,'new','8888','string',_binary '',0,'2020-12-15 11:23:25',NULL,NULL),(23,15,47,'string','string','string',_binary '',1,'2020-12-15 11:24:52',NULL,NULL),(24,14,48,'new person','string','string',_binary '',1,'2020-12-16 06:26:26',NULL,NULL),(25,15,49,'string','string','string',_binary '',1,'2020-12-16 06:32:24',NULL,NULL),(26,15,50,'string','string','string',_binary '',1,'2020-12-16 06:34:29',NULL,NULL),(27,14,51,'string','string','string',_binary '',1,'2020-12-16 07:10:25',NULL,NULL),(28,14,52,'string','string','string',_binary '',1,'2020-12-16 07:12:39',NULL,NULL),(29,14,53,'new','8888','string',_binary '',0,'2020-12-18 05:17:57',NULL,NULL),(30,46,54,'string','47895','string',_binary '',1,'2020-12-18 05:17:57',NULL,NULL),(31,14,55,'new','8888','string',_binary '',0,'2020-12-18 05:56:18',NULL,NULL),(32,46,56,'string','47895','string',_binary '',1,'2020-12-18 05:56:18',NULL,NULL),(33,14,57,'new','8888','string',_binary '',0,'2020-12-18 05:58:34',NULL,NULL),(34,15,57,'new','12345','string',_binary '',0,'2020-12-18 05:58:34',NULL,NULL);
/*!40000 ALTER TABLE `branchserviceoffered` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categorydetails`
--

DROP TABLE IF EXISTS `categorydetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categorydetails` (
  `CategoryId` int NOT NULL AUTO_INCREMENT,
  `ServiceType` int DEFAULT NULL,
  `VendorId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `VendorName` varchar(500) DEFAULT NULL,
  `VendorStatus` int NOT NULL,
  `VendorStatusName` varchar(45) NOT NULL,
  `WebsiteLink` varchar(500) DEFAULT NULL,
  `FacebookLink` varchar(500) DEFAULT NULL,
  `InstagramLink` varchar(500) DEFAULT NULL,
  `PinterestLink` varchar(500) DEFAULT NULL,
  `TwitterHandle` varchar(500) DEFAULT NULL,
  `ProfilePicture` varchar(500) DEFAULT NULL,
  `VideoLink` varchar(45) DEFAULT NULL,
  `CategoryMode` int NOT NULL,
  `CategoryModeName` varchar(45) DEFAULT NULL,
  `Active` bit(1) DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`CategoryId`),
  KEY `FK_ServiceType_idx` (`ServiceType`),
  CONSTRAINT `FK_ServiceType` FOREIGN KEY (`ServiceType`) REFERENCES `branchserviceoffered` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=58 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorydetails`
--

LOCK TABLES `categorydetails` WRITE;
/*!40000 ALTER TABLE `categorydetails` DISABLE KEYS */;
INSERT INTO `categorydetails` VALUES (50,13,'HW011','Satheesh',6,'Active','newlink','fblink','string','string','string','D:\\HappyWedding\\Profilepics\\smiley1.jpg','videolink',16,'CPL',_binary '',1,'2020-12-15 08:15:29',NULL,NULL),(51,14,'HW012','Suresh',7,'Churned','weblink','fblink','string','string','string','D:\\HappyWedding\\Profilepics\\smiley1.jpg','videolink',17,'Commission Mode',_binary '',1,'2020-12-15 08:16:11',NULL,NULL),(57,15,'HW013','Anil',6,'Active','\"new\"','\"string\"','\"string\"','\"string\"','\"string\"','D:\\HappyWedding\\Profilepics\\smiley1.jpg','\"newvideo\"',16,'CPL',_binary '',1,'2020-12-16 07:31:22',NULL,NULL);
/*!40000 ALTER TABLE `categorydetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `commentreply`
--

DROP TABLE IF EXISTS `commentreply`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `commentreply` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ReviewId` int NOT NULL,
  `CommentReply` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Type` int NOT NULL,
  `ParentCommentId` int DEFAULT NULL,
  `ParentReplyId` int DEFAULT NULL,
  `ApprovalStatus` int NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_commentreply_ReviewId_idx` (`ReviewId`),
  KEY `FK_commentreply_Type_idx` (`Type`),
  KEY `FK_commentreply_ApprovalStatus_idx` (`ApprovalStatus`),
  CONSTRAINT `FK_commentreply_ApprovalStatus` FOREIGN KEY (`ApprovalStatus`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_commentreply_ReviewId` FOREIGN KEY (`ReviewId`) REFERENCES `review` (`Id`),
  CONSTRAINT `FK_commentreply_Type` FOREIGN KEY (`Type`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commentreply`
--

LOCK TABLES `commentreply` WRITE;
/*!40000 ALTER TABLE `commentreply` DISABLE KEYS */;
/*!40000 ALTER TABLE `commentreply` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event`
--

DROP TABLE IF EXISTS `event`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `event` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `EventType` int NOT NULL,
  `EventName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CoverPhoto` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Location` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `EventDate` datetime NOT NULL,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `EstimatedPrice` decimal(8,2) DEFAULT NULL,
  `VendorId` int NOT NULL,
  `ApprovalStatus` int NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `event-type_idx` (`EventType`),
  KEY `FK_event_ApprovalStatus_idx` (`ApprovalStatus`),
  CONSTRAINT `event-type` FOREIGN KEY (`EventType`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_event_ApprovalStatus` FOREIGN KEY (`ApprovalStatus`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event`
--

LOCK TABLES `event` WRITE;
/*!40000 ALTER TABLE `event` DISABLE KEYS */;
/*!40000 ALTER TABLE `event` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventphoto`
--

DROP TABLE IF EXISTS `eventphoto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `eventphoto` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `EventId` int NOT NULL,
  `Photo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `eventphoto-eventid_idx` (`EventId`),
  CONSTRAINT `eventphoto-eventid` FOREIGN KEY (`EventId`) REFERENCES `event` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventphoto`
--

LOCK TABLES `eventphoto` WRITE;
/*!40000 ALTER TABLE `eventphoto` DISABLE KEYS */;
/*!40000 ALTER TABLE `eventphoto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventtagdata`
--

DROP TABLE IF EXISTS `eventtagdata`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `eventtagdata` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `EventId` int NOT NULL,
  `TagId` int NOT NULL,
  `TagName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_eventtagdata_EventId_idx` (`EventId`),
  CONSTRAINT `FK_eventtagdata_EventId` FOREIGN KEY (`EventId`) REFERENCES `event` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventtagdata`
--

LOCK TABLES `eventtagdata` WRITE;
/*!40000 ALTER TABLE `eventtagdata` DISABLE KEYS */;
/*!40000 ALTER TABLE `eventtagdata` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gallery`
--

DROP TABLE IF EXISTS `gallery`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `gallery` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `EventId` int NOT NULL,
  `Title` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `PhotoPath` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `VideoPath` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `VendorId` int NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int DEFAULT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `event-id_idx` (`EventId`),
  CONSTRAINT `event-id` FOREIGN KEY (`EventId`) REFERENCES `event` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gallery`
--

LOCK TABLES `gallery` WRITE;
/*!40000 ALTER TABLE `gallery` DISABLE KEYS */;
/*!40000 ALTER TABLE `gallery` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `multicode`
--

DROP TABLE IF EXISTS `multicode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `multicode` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Code` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `SystemCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Description` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `IsRequired` bit(1) DEFAULT b'0',
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `multicode`
--

LOCK TABLES `multicode` WRITE;
/*!40000 ALTER TABLE `multicode` DISABLE KEYS */;
INSERT INTO `multicode` VALUES (21,'Service Type','Service Type','Services',_binary '',_binary '',1,'2020-12-09 07:17:02',NULL,NULL),(22,'City','City','City',_binary '',_binary '',1,'2020-12-09 07:17:32',NULL,NULL),(23,'Package Type','Package Type','Package Type',_binary '',_binary '',1,'2020-12-09 07:18:03',NULL,NULL),(24,'Approval Status','Approval Status','Approval Status',_binary '',_binary '',1,'2020-12-09 07:20:14',NULL,NULL),(25,'Payament Status','Payament Status','Paymanet Status',_binary '',_binary '',1,'2020-12-09 07:20:32',NULL,NULL),(26,'Control Type','Control Type','Control Type',_binary '',_binary '',1,'2020-12-09 07:21:00',NULL,NULL),(27,'Validity unit','Validity unit','Validity Unit',_binary '',_binary '',1,'2020-12-09 07:21:25',NULL,NULL),(28,'Catering','Catering','Catering',_binary '',_binary '',1,'2020-12-09 07:24:09',NULL,NULL),(29,'Experience Unit','Experience Unit','Experience Unit',_binary '',_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(30,'Currency','Currency','Currency',_binary '',_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(31,'Mode','Mode','Mode',_binary '',_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(32,'Rate Type','Rate Type','Rate Type',_binary '',_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(33,'Offer Type','Offer Type','Offer Type',_binary '',_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(34,'Validity Unit','Validity Unit','Validity Unit',_binary '',_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(35,'Benefits','Benefits','Benefits',_binary '',_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(36,'Package Type','Package Type','Package Type',_binary '',_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(37,'Payment Status','Payment Status','Payment Statss',_binary '',_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(38,'Topup Type','TopUp Type','TopUp Type',_binary '',_binary '',1,'2020-05-20 00:00:00',NULL,NULL);
/*!40000 ALTER TABLE `multicode` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `multidetail`
--

DROP TABLE IF EXISTS `multidetail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `multidetail` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MultiCodeId` int NOT NULL,
  `Value` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Description` varchar(500) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `code_id_idx` (`MultiCodeId`),
  CONSTRAINT `code_id` FOREIGN KEY (`MultiCodeId`) REFERENCES `multicode` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `multidetail`
--

LOCK TABLES `multidetail` WRITE;
/*!40000 ALTER TABLE `multidetail` DISABLE KEYS */;
INSERT INTO `multidetail` VALUES (14,21,'Bridal Wear','Bridal',_binary '',1,'2020-12-09 07:22:53',NULL,NULL),(15,21,'Groom Wear','Groom',_binary '',1,'2020-12-09 07:23:07',NULL,NULL),(16,21,'Photography','Photography',_binary '',1,'2020-12-09 07:23:30',NULL,NULL),(17,21,'Catering','Catering',_binary '',1,'2020-12-09 07:23:43',NULL,NULL),(18,22,'TVM','TVM',_binary '',1,'2020-12-09 07:24:42',NULL,NULL),(19,22,'Kollam','Kollam',_binary '',1,'2020-12-09 07:24:55',NULL,NULL),(20,22,'Kottayam','Kottayam',_binary '',1,'2020-12-09 07:25:13',NULL,NULL),(21,28,'Chinese','Chinese',_binary '',1,'2020-12-09 07:25:52',NULL,NULL),(22,28,'Arabic','Arabic',_binary '',1,'2020-12-09 07:26:14',NULL,NULL),(23,28,'South Indian','South Indian',_binary '',1,'2020-12-09 07:26:37',NULL,NULL),(24,28,'North Indian','North Indian',_binary '',1,'2020-12-09 07:26:53',NULL,NULL),(25,26,'Select','Select',_binary '',1,'2020-12-10 05:57:15',NULL,NULL),(26,26,'Checkbox','Checkbox',_binary '',1,'2020-12-10 05:57:34',NULL,NULL),(27,26,'Radio Button','Radio Button',_binary '',1,'2020-12-10 05:58:18',NULL,NULL),(28,29,'Year','Year',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(29,29,'Month','Month',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(30,30,'Rupees','Rupees',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(31,30,'Dollar','Dollar',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(32,31,'CPL','CPL',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(33,31,'Commision','Commision',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(34,32,'per hour','per hour',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(35,32,'per day','per day',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(36,32,'Monsoon','Monsoon',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(37,32,'Summer','Summer',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(38,34,'Months','Months',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(39,24,'Pending','Pending',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(40,24,'Approved','Approved',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(41,35,'Cost Per Lead','Cost Per Lead',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(42,35,'Photos','Photos',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(43,35,'Videos','Videos',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(44,35,'Profile Pictures','Profile Pictures',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(45,36,'Generic','Generic',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(46,36,'Specific','Specific',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(47,37,'Pending','Pending',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(48,37,'Hold','Hold',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(49,37,'Pending','Pending',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(50,37,'Approved','Approved',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(51,38,'Weekly','Weekly',_binary '',1,'2020-05-06 00:00:00',NULL,NULL),(52,38,'Monthly','Monthly',_binary '',1,'2020-05-06 00:00:00',NULL,NULL);
/*!40000 ALTER TABLE `multidetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `offer`
--

DROP TABLE IF EXISTS `offer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `offer` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `OfferName` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Type` int NOT NULL,
  `Price` decimal(8,2) NOT NULL,
  `Validity` int NOT NULL,
  `ValidityUnit` int NOT NULL,
  `VendorId` int DEFAULT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `val-unit_idx` (`Type`),
  KEY `val-unit_idx1` (`ValidityUnit`),
  CONSTRAINT `off-type` FOREIGN KEY (`Type`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `val-unit` FOREIGN KEY (`ValidityUnit`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `offer`
--

LOCK TABLES `offer` WRITE;
/*!40000 ALTER TABLE `offer` DISABLE KEYS */;
INSERT INTO `offer` VALUES (6,'Monsoon Bonanza',36,5000.00,3,38,1,_binary '',1,'2020-05-20 00:00:00',NULL,NULL);
/*!40000 ALTER TABLE `offer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `profilepictures`
--

DROP TABLE IF EXISTS `profilepictures`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `profilepictures` (
  `ProflePictureId` int NOT NULL AUTO_INCREMENT,
  `ProfilePicturePath` varchar(250) DEFAULT NULL,
  `CategoryId` int DEFAULT NULL,
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`ProflePictureId`),
  KEY `FK_profilepictures_categoryid_idx` (`CategoryId`),
  CONSTRAINT `FK_profilepictures_categoryid` FOREIGN KEY (`CategoryId`) REFERENCES `categorydetails` (`CategoryId`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profilepictures`
--

LOCK TABLES `profilepictures` WRITE;
/*!40000 ALTER TABLE `profilepictures` DISABLE KEYS */;
INSERT INTO `profilepictures` VALUES (43,'D:\\HappyWedding\\Profilepics\\smiley1.jpg',50,1,'2020-12-15 08:15:29',NULL,NULL),(44,'D:\\HappyWedding\\Profilepics\\smiley1.jpg',51,1,'2020-12-15 08:16:11',NULL,NULL),(45,'D:\\HappyWedding\\Profilepics\\smiley1.jpg',57,1,'2020-12-16 07:31:22',NULL,NULL);
/*!40000 ALTER TABLE `profilepictures` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `review`
--

DROP TABLE IF EXISTS `review`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `review` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ReferenceId` int NOT NULL,
  `Email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ReviewType` int NOT NULL,
  `EmailOf` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Rating` tinyint DEFAULT NULL,
  `ReviewedBy` int NOT NULL,
  `ApprovalStatus` int NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Review-Reviewtype_idx` (`ReviewType`),
  KEY `Review-ApprovalStatus_idx` (`ApprovalStatus`),
  CONSTRAINT `Review-ApprovalStatus` FOREIGN KEY (`ApprovalStatus`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `Review-Reviewtype` FOREIGN KEY (`ReviewType`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `review`
--

LOCK TABLES `review` WRITE;
/*!40000 ALTER TABLE `review` DISABLE KEYS */;
/*!40000 ALTER TABLE `review` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `service`
--

DROP TABLE IF EXISTS `service`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `service` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ServiceType` int NOT NULL,
  `ServiceMode` int NOT NULL,
  `ServiceName` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Description` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Experience` decimal(4,2) DEFAULT NULL,
  `ExperienceUnit` int DEFAULT NULL,
  `Award` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `RateType` int DEFAULT NULL,
  `PriceRangeStart` decimal(8,2) DEFAULT NULL,
  `PriceRangeEnd` decimal(8,2) DEFAULT NULL,
  `Currency` int DEFAULT NULL,
  `PhotoPath` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `LocationId` int NOT NULL,
  `VendorId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `VendorName` varchar(500) DEFAULT NULL,
  `VendorStatus` int NOT NULL,
  `VendorStatusName` varchar(45) NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `service-type_idx` (`ServiceType`),
  KEY `service-experience-unit_idx` (`ExperienceUnit`),
  KEY `service-ratetype_idx` (`RateType`),
  KEY `service-currency_idx` (`Currency`),
  KEY `service-Mode_idx` (`ServiceMode`),
  KEY `service-type-location_idx` (`LocationId`),
  CONSTRAINT `service-currency` FOREIGN KEY (`Currency`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `service-experience-unit` FOREIGN KEY (`ExperienceUnit`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `service-Mode` FOREIGN KEY (`ServiceMode`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `service-ratetype` FOREIGN KEY (`RateType`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `service-type` FOREIGN KEY (`ServiceType`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `service-type-location` FOREIGN KEY (`LocationId`) REFERENCES `multidetail` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `service`
--

LOCK TABLES `service` WRITE;
/*!40000 ALTER TABLE `service` DISABLE KEYS */;
INSERT INTO `service` VALUES (4,14,32,'Bridal Wear','Bridal Wear',5.00,28,NULL,35,15000.00,35000.00,30,NULL,18,'HW011','Satheesh',6,'Active',_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(5,15,32,'Groom Wear','Bridal Wear',5.00,28,NULL,35,20000.00,30000.00,30,NULL,19,'HW011','Satheesh',6,'Active',_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(6,16,33,'Photography','Bridal Wear',5.00,28,NULL,35,20000.00,30000.00,30,NULL,18,'HW012','Suresh',6,'Active',_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(7,16,33,'Bridal Wear','Bridal Wear',5.00,28,NULL,35,20000.00,30000.00,30,NULL,19,'HW012','Suresh',7,'Churned',_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(8,16,33,'Bridal Wear','Bridal Wear',5.00,28,NULL,35,20000.00,30000.00,30,NULL,20,'HW012','Suresh',7,'Churned',_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(9,16,33,'Bridal Wear','Bridal Wear',5.00,28,NULL,35,20000.00,30000.00,30,NULL,18,'HW013','Anil',6,'Active',_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(10,16,33,'Bridal Wear','Bridal Wear',5.00,28,NULL,35,20000.00,30000.00,30,NULL,20,'HW014','Aswin',8,'Inactive',_binary '',1,'2020-05-20 00:00:00',NULL,NULL);
/*!40000 ALTER TABLE `service` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `serviceanswer`
--

DROP TABLE IF EXISTS `serviceanswer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `serviceanswer` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `QuestionId` int NOT NULL,
  `ControlType` int NOT NULL,
  `Answer` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `questionid_idx` (`QuestionId`),
  KEY `controltype_idx` (`ControlType`),
  CONSTRAINT `controltype` FOREIGN KEY (`ControlType`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `questionid` FOREIGN KEY (`QuestionId`) REFERENCES `servicequestion` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `serviceanswer`
--

LOCK TABLES `serviceanswer` WRITE;
/*!40000 ALTER TABLE `serviceanswer` DISABLE KEYS */;
INSERT INTO `serviceanswer` VALUES (5,27,25,'Chinese',_binary '',1,'2020-12-10 05:59:22',NULL,NULL),(6,27,25,'Arabic',_binary '',1,'2020-12-10 05:59:22',NULL,NULL),(7,27,25,'South Indian',_binary '',1,'2020-12-10 05:59:22',NULL,NULL),(8,28,27,'200',_binary '',1,'2020-12-10 06:00:55',NULL,NULL),(9,28,27,'400',_binary '',1,'2020-12-10 06:00:55',NULL,NULL),(10,28,27,'500',_binary '',1,'2020-12-10 06:00:55',NULL,NULL),(11,29,26,'Veg',_binary '',1,'2020-12-10 00:00:00',NULL,NULL),(12,29,26,'Non-Veg',_binary '',1,'2020-12-10 00:00:00',NULL,NULL);
/*!40000 ALTER TABLE `serviceanswer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `serviceoffered`
--

DROP TABLE IF EXISTS `serviceoffered`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `serviceoffered` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ServiceId` int NOT NULL,
  `OfferedServiceId` int NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_ServiceId_idx` (`ServiceId`),
  KEY `FK_OfferedServiceId_idx` (`OfferedServiceId`),
  CONSTRAINT `FK_OfferedServiceId` FOREIGN KEY (`OfferedServiceId`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_ServiceId` FOREIGN KEY (`ServiceId`) REFERENCES `service` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `serviceoffered`
--

LOCK TABLES `serviceoffered` WRITE;
/*!40000 ALTER TABLE `serviceoffered` DISABLE KEYS */;
/*!40000 ALTER TABLE `serviceoffered` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `servicequestion`
--

DROP TABLE IF EXISTS `servicequestion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `servicequestion` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Question` varchar(1000) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ServiceType` int NOT NULL,
  `IsForVendor` bit(1) NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `servicetype_idx` (`ServiceType`),
  CONSTRAINT `servicetype` FOREIGN KEY (`ServiceType`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servicequestion`
--

LOCK TABLES `servicequestion` WRITE;
/*!40000 ALTER TABLE `servicequestion` DISABLE KEYS */;
INSERT INTO `servicequestion` VALUES (27,'Specialization',17,_binary '',_binary '',1,'2020-12-10 05:55:01',NULL,NULL),(28,'How many serves',17,_binary '',_binary '',1,'2020-12-10 05:55:41',NULL,NULL),(29,'Which Type of Dish Serve',17,_binary '\0',_binary '',1,'2020-12-10 00:00:00',NULL,NULL);
/*!40000 ALTER TABLE `servicequestion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `servicesubscription`
--

DROP TABLE IF EXISTS `servicesubscription`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `servicesubscription` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ServiceId` int NOT NULL,
  `Subscription` int NOT NULL,
  `SubscribedOn` datetime NOT NULL,
  `Expiry` datetime NOT NULL,
  `PaidAmount` decimal(8,2) NOT NULL,
  `PaymentStatus` int NOT NULL,
  `WalletBalance` decimal(8,2) DEFAULT NULL,
  `WalletStatus` int NOT NULL,
  `WalletStatusName` varchar(45) NOT NULL,
  `ApprovalStatus` int NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `vendor-subid_idx` (`Subscription`),
  KEY `vendorsub-paystatus_idx` (`PaymentStatus`),
  KEY `service-ServiceId_idx` (`ServiceId`),
  KEY `servicesub-ApprovalStatus_idx` (`ApprovalStatus`),
  CONSTRAINT `service-ServiceId` FOREIGN KEY (`ServiceId`) REFERENCES `service` (`Id`),
  CONSTRAINT `service-subid` FOREIGN KEY (`Subscription`) REFERENCES `subscription` (`Id`),
  CONSTRAINT `servicesub-ApprovalStatus` FOREIGN KEY (`ApprovalStatus`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `servicesub-paystatus` FOREIGN KEY (`PaymentStatus`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servicesubscription`
--

LOCK TABLES `servicesubscription` WRITE;
/*!40000 ALTER TABLE `servicesubscription` DISABLE KEYS */;
INSERT INTO `servicesubscription` VALUES (10,4,4,'2020-05-16 15:11:16','2021-05-16 15:11:16',2500.00,47,2500.00,1,'Deduct',39,_binary '',1,'2020-12-16 15:16:12',NULL,NULL),(11,5,5,'2020-05-16 15:11:16','2021-05-16 15:11:16',2500.00,47,1500.00,3,'Free',39,_binary '',1,'2020-12-16 15:16:28',NULL,NULL),(15,7,6,'2020-12-17 17:13:33','2021-12-17 17:13:33',2000.00,47,0.00,2,'Hold',39,_binary '',1,'2020-12-18 05:05:02',NULL,NULL),(16,7,6,'2020-12-17 17:13:33','2021-12-17 17:13:33',2000.00,47,0.00,4,'Paused',39,_binary '',1,'2020-12-18 05:05:35',NULL,NULL),(17,6,7,'2020-12-17 00:00:00','2021-12-15 00:00:00',2000.00,47,0.00,4,'Paused',39,_binary '',1,'2020-12-18 05:05:40',NULL,NULL),(18,7,6,'2020-12-17 17:13:33','2021-12-17 17:13:33',2000.00,47,0.00,2,'Hold',39,_binary '',1,'2020-12-18 05:14:20',NULL,NULL),(19,6,7,'2020-12-17 00:00:00','2021-12-15 00:00:00',2000.00,47,0.00,3,'Free',39,_binary '',1,'2020-12-18 05:14:20',NULL,NULL),(20,7,6,'2020-12-17 17:13:33','2021-12-17 17:13:33',2000.00,47,0.00,3,'Free',39,_binary '',1,'2020-12-18 05:16:30',NULL,NULL),(21,6,7,'2020-12-17 00:00:00','2021-12-15 00:00:00',2000.00,47,0.00,3,'Free',39,_binary '',1,'2020-12-18 05:16:30',NULL,NULL);
/*!40000 ALTER TABLE `servicesubscription` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `servicetopup`
--

DROP TABLE IF EXISTS `servicetopup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `servicetopup` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ServiceId` int NOT NULL,
  `TopUpId` int NOT NULL,
  `TopUpOn` datetime NOT NULL,
  `Expiry` datetime NOT NULL,
  `PaidAmount` decimal(8,2) NOT NULL,
  `PaymentStatus` int NOT NULL,
  `WalletBalance` decimal(8,2) DEFAULT NULL,
  `WalletStatus` int NOT NULL,
  `WalletStatusName` varchar(45) NOT NULL,
  `ApprovalStatus` int NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_servicetopup_ServiceId_idx` (`ServiceId`),
  KEY `FK_servicetopup_TopUpId_idx` (`TopUpId`),
  KEY `FK_servicetopup_PaymentStatus_idx` (`PaymentStatus`),
  KEY `FK_servicetopup_ApprovalStatus_idx` (`ApprovalStatus`),
  CONSTRAINT `FK_servicetopup_ApprovalStatus` FOREIGN KEY (`ApprovalStatus`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_servicetopup_PaymentStatus` FOREIGN KEY (`PaymentStatus`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_servicetopup_ServiceId` FOREIGN KEY (`ServiceId`) REFERENCES `service` (`Id`),
  CONSTRAINT `FK_servicetopup_TopUpId` FOREIGN KEY (`TopUpId`) REFERENCES `topup` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `servicetopup`
--

LOCK TABLES `servicetopup` WRITE;
/*!40000 ALTER TABLE `servicetopup` DISABLE KEYS */;
INSERT INTO `servicetopup` VALUES (9,4,7,'2020-05-16 16:33:13','2021-12-16 16:33:13',1500.00,49,NULL,1,'Deduct',39,_binary '',1,'2020-12-16 16:34:44',NULL,NULL),(10,5,8,'2020-05-16 16:33:13','2021-12-16 16:33:13',1500.00,49,NULL,2,'Hold',39,_binary '',1,'2020-12-16 16:34:55',NULL,NULL),(19,5,8,'2020-12-18 05:06:01','2020-12-18 05:06:01',3000.00,47,NULL,2,'Hold',39,_binary '',1,'2020-12-18 05:09:03',NULL,NULL),(20,5,8,'2020-12-18 05:06:01','2020-12-18 05:06:01',3000.00,47,NULL,3,'Free',39,_binary '',1,'2020-12-18 05:09:23',NULL,NULL),(21,6,7,'2020-12-18 05:06:01','2020-12-18 05:06:01',3000.00,47,NULL,3,'Free',39,_binary '',1,'2020-12-18 05:09:23',NULL,NULL),(22,5,8,'2020-12-18 05:06:01','2020-12-18 05:06:01',3000.00,47,NULL,4,'Paused',39,_binary '',1,'2020-12-18 05:17:06',NULL,NULL),(23,6,7,'2020-12-18 05:06:01','2020-12-18 05:06:01',3000.00,47,NULL,4,'Paused',39,_binary '',1,'2020-12-18 05:17:06',NULL,NULL);
/*!40000 ALTER TABLE `servicetopup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subcategory`
--

DROP TABLE IF EXISTS `subcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subcategory` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CategoryId` int DEFAULT NULL,
  `SubCategoryType` int DEFAULT NULL,
  `SubCategoryValue` varchar(45) DEFAULT NULL,
  `Active` bit(1) DEFAULT b'1',
  `CreatedBy` int DEFAULT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_subcategory_idx` (`SubCategoryType`),
  KEY `FK_category_idx` (`CategoryId`),
  CONSTRAINT `FK_category` FOREIGN KEY (`CategoryId`) REFERENCES `categorydetails` (`CategoryId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_subcategory` FOREIGN KEY (`SubCategoryType`) REFERENCES `multidetail` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subcategory`
--

LOCK TABLES `subcategory` WRITE;
/*!40000 ALTER TABLE `subcategory` DISABLE KEYS */;
INSERT INTO `subcategory` VALUES (3,50,17,'Chinese',_binary '',1,'2020-12-15 08:15:29',NULL,NULL),(4,51,17,'Chinese',_binary '',1,'2020-12-15 08:16:11',NULL,NULL);
/*!40000 ALTER TABLE `subcategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subscription`
--

DROP TABLE IF EXISTS `subscription`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subscription` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ParentsubscriptionId` int DEFAULT NULL,
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Description` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Mode` int NOT NULL,
  `RegistrationFee` decimal(8,2) NOT NULL,
  `ServiceFee` decimal(8,2) NOT NULL,
  `CGST_RatePercentage` int DEFAULT NULL,
  `CGSTAmount` decimal(8,2) DEFAULT NULL,
  `SGST_RatePercentage` int DEFAULT NULL,
  `SGSTAmount` decimal(8,2) DEFAULT NULL,
  `IGST_RatePercentage` int DEFAULT NULL,
  `IGSTAmount` decimal(8,2) DEFAULT NULL,
  `GST_RatePercentage` int DEFAULT NULL,
  `GSTAmount` decimal(8,2) DEFAULT NULL,
  `CPLAmount` decimal(8,2) DEFAULT NULL,
  `CommissionAmount` decimal(8,2) DEFAULT NULL,
  `TotalPrice` decimal(8,2) NOT NULL,
  `Validity` int NOT NULL,
  `ValidityUnit` int NOT NULL,
  `ApprovalStatus` int NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `validityunit_idx` (`ValidityUnit`),
  KEY `FK_ParentsubscriptionId_idx` (`ParentsubscriptionId`),
  KEY `FK_ApprovalStatus_idx` (`ApprovalStatus`),
  KEY `FK_Mode_idx` (`Mode`),
  CONSTRAINT `FK_ApprovalStatus` FOREIGN KEY (`ApprovalStatus`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_Mode` FOREIGN KEY (`Mode`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_ParentsubscriptionId` FOREIGN KEY (`ParentsubscriptionId`) REFERENCES `subscription` (`Id`),
  CONSTRAINT `FK_validityunit` FOREIGN KEY (`ValidityUnit`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subscription`
--

LOCK TABLES `subscription` WRITE;
/*!40000 ALTER TABLE `subscription` DISABLE KEYS */;
INSERT INTO `subscription` VALUES (4,NULL,'Ruby','Ruby',32,8000.00,1500.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,9500.00,6,38,39,_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(5,NULL,'Sapphire','Sapphire',32,8000.00,1500.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,9500.00,6,38,39,_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(6,4,'Ruby-new','Ruby-new',32,8000.00,1500.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,9500.00,6,38,39,_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(7,5,'Sapphire-new','sapphire-new',32,6000.00,1500.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,7500.00,6,38,39,_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(8,5,'Sapphire-new','sapphire-new',32,6000.00,1500.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,7500.00,6,38,39,_binary '',1,'2020-05-20 00:00:00',NULL,NULL),(9,5,'Sapphire-new','sapphire-new',32,6000.00,1500.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,7500.00,6,38,39,_binary '',1,'2020-05-20 00:00:00',NULL,NULL);
/*!40000 ALTER TABLE `subscription` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subscriptionbenefit`
--

DROP TABLE IF EXISTS `subscriptionbenefit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subscriptionbenefit` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SubscriptionId` int NOT NULL,
  `Benefit` int NOT NULL,
  `Count` int DEFAULT NULL,
  `ApprovalStatus` int NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `bene-subid_idx` (`SubscriptionId`),
  KEY `bene-ApprovalStatus_idx` (`ApprovalStatus`),
  KEY `bene-benefit_idx` (`Benefit`),
  CONSTRAINT `bene-ApprovalStatus` FOREIGN KEY (`ApprovalStatus`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `bene-benefit` FOREIGN KEY (`Benefit`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `bene-subid` FOREIGN KEY (`SubscriptionId`) REFERENCES `subscription` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subscriptionbenefit`
--

LOCK TABLES `subscriptionbenefit` WRITE;
/*!40000 ALTER TABLE `subscriptionbenefit` DISABLE KEYS */;
INSERT INTO `subscriptionbenefit` VALUES (11,4,41,0,39,_binary '',1,'2020-05-02 00:00:00',NULL,NULL),(12,4,42,2,39,_binary '',1,'2020-05-02 00:00:00',NULL,NULL),(13,4,43,1,39,_binary '',1,'2020-05-02 00:00:00',NULL,NULL),(14,5,42,2,39,_binary '',1,'2020-05-02 00:00:00',NULL,NULL),(15,5,43,2,39,_binary '',1,'2020-05-02 00:00:00',NULL,NULL);
/*!40000 ALTER TABLE `subscriptionbenefit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subscriptionlocation`
--

DROP TABLE IF EXISTS `subscriptionlocation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subscriptionlocation` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SubscriptionId` int NOT NULL,
  `LocationId` int NOT NULL,
  `CategoryId` int NOT NULL,
  `PackageType` int NOT NULL,
  `Mode` int DEFAULT NULL,
  `RegistrationFee` decimal(8,2) DEFAULT NULL,
  `ServiceFee` decimal(8,2) DEFAULT NULL,
  `CGST_RatePercentage` int DEFAULT NULL,
  `CGSTAmount` decimal(8,2) DEFAULT NULL,
  `SGST_RatePercentage` int DEFAULT NULL,
  `SGSTAmount` decimal(8,2) DEFAULT NULL,
  `IGST_RatePercentage` int DEFAULT NULL,
  `IGSTAmount` decimal(8,2) DEFAULT NULL,
  `GST_RatePercentage` int DEFAULT NULL,
  `GSTAmount` decimal(8,2) DEFAULT NULL,
  `CPLAmount` decimal(8,2) DEFAULT NULL,
  `CommissionAmount` decimal(8,2) DEFAULT NULL,
  `TotalPrice` decimal(8,2) NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_subscriptionId_idx` (`SubscriptionId`),
  KEY `FK_LocationId_idx` (`LocationId`),
  KEY `FK_CategoryId_idx` (`CategoryId`),
  KEY `FK_PackageType_idx` (`PackageType`),
  KEY `FK_subscriptionlocation_Mode_idx` (`Mode`),
  CONSTRAINT `FK_subscriptionlocation_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_subscriptionlocation_LocationId` FOREIGN KEY (`LocationId`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_subscriptionlocation_Mode` FOREIGN KEY (`Mode`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_subscriptionlocation_PackageType` FOREIGN KEY (`PackageType`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_subscriptionlocation_SubscriptionId` FOREIGN KEY (`SubscriptionId`) REFERENCES `subscription` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subscriptionlocation`
--

LOCK TABLES `subscriptionlocation` WRITE;
/*!40000 ALTER TABLE `subscriptionlocation` DISABLE KEYS */;
INSERT INTO `subscriptionlocation` VALUES (3,4,18,14,45,32,4500.00,500.00,0,0.00,0,0.00,0,0.00,0,0.00,0.00,0.00,5000.00,_binary '',1,'2020-12-16 15:09:50',NULL,NULL),(4,5,19,15,46,32,4500.00,500.00,0,0.00,0,0.00,0,0.00,0,0.00,0.00,0.00,5000.00,_binary '',1,'2020-12-16 15:10:14',NULL,NULL),(5,6,18,14,46,32,5000.00,500.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,5500.00,_binary '',1,'2020-10-10 00:00:00',NULL,NULL),(6,4,19,15,46,32,5000.00,500.00,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,5500.00,_binary '',1,'2020-10-10 00:00:00',NULL,NULL);
/*!40000 ALTER TABLE `subscriptionlocation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subscriptionoffer`
--

DROP TABLE IF EXISTS `subscriptionoffer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subscriptionoffer` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `SubscriptionId` int NOT NULL,
  `OfferId` int NOT NULL,
  `ApprovalStatus` int NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `subid-off_idx` (`SubscriptionId`),
  KEY `suboff-offid_idx` (`OfferId`),
  KEY `suboff-ApprovalStatus_idx` (`ApprovalStatus`),
  CONSTRAINT `subid-off` FOREIGN KEY (`SubscriptionId`) REFERENCES `subscription` (`Id`),
  CONSTRAINT `suboff-ApprovalStatus` FOREIGN KEY (`ApprovalStatus`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `suboff-offid` FOREIGN KEY (`OfferId`) REFERENCES `offer` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subscriptionoffer`
--

LOCK TABLES `subscriptionoffer` WRITE;
/*!40000 ALTER TABLE `subscriptionoffer` DISABLE KEYS */;
/*!40000 ALTER TABLE `subscriptionoffer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suggestionlist`
--

DROP TABLE IF EXISTS `suggestionlist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suggestionlist` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `subscriptionId` int NOT NULL,
  `VendorId` int NOT NULL,
  `Description` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ApprovalStatus` int NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_subscriptionId_idx` (`subscriptionId`),
  KEY `FK_ApprovalStatus_idx` (`ApprovalStatus`),
  CONSTRAINT `FK_suggestionlist_ApprovalStatus` FOREIGN KEY (`ApprovalStatus`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_suggestionlist_subscriptionId` FOREIGN KEY (`subscriptionId`) REFERENCES `subscription` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suggestionlist`
--

LOCK TABLES `suggestionlist` WRITE;
/*!40000 ALTER TABLE `suggestionlist` DISABLE KEYS */;
/*!40000 ALTER TABLE `suggestionlist` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `topup`
--

DROP TABLE IF EXISTS `topup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `topup` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TopUpType` int NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Description` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Mode` int NOT NULL,
  `Price` decimal(8,2) NOT NULL,
  `CGST_RatePercentage` int DEFAULT NULL,
  `CGSTAmount` decimal(8,2) DEFAULT NULL,
  `SGST_RatePercentage` int DEFAULT NULL,
  `SGSTAmount` decimal(8,2) DEFAULT NULL,
  `IGST_RatePercentage` int DEFAULT NULL,
  `IGSTAmount` decimal(8,2) DEFAULT NULL,
  `GST_RatePercentage` int DEFAULT NULL,
  `GSTAmount` decimal(8,2) DEFAULT NULL,
  `CPLAmount` decimal(8,2) DEFAULT NULL,
  `CommissionAmount` decimal(8,2) DEFAULT NULL,
  `TotalPrice` decimal(8,2) NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_topup_TopUpType_idx` (`TopUpType`),
  KEY `FK_topup_Mode_idx` (`Mode`),
  CONSTRAINT `FK_topup_Mode` FOREIGN KEY (`Mode`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_topup_TopUpType` FOREIGN KEY (`TopUpType`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `topup`
--

LOCK TABLES `topup` WRITE;
/*!40000 ALTER TABLE `topup` DISABLE KEYS */;
INSERT INTO `topup` VALUES (7,51,'Ruby TopUp','Ruby TopUp',32,3000.00,0,0.00,0,0.00,0,0.00,0,0.00,2500.00,0.00,55000.00,_binary '',1,'2020-12-16 16:24:49',NULL,NULL),(8,52,'Ruby TopUp','Ruby TopUp',32,4500.00,0,0.00,0,0.00,0,0.00,0,0.00,2500.00,0.00,75000.00,_binary '',1,'2020-12-16 16:25:39',NULL,NULL);
/*!40000 ALTER TABLE `topup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `topupbenefit`
--

DROP TABLE IF EXISTS `topupbenefit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `topupbenefit` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `TopUpId` int NOT NULL,
  `Benefit` int NOT NULL,
  `Count` int DEFAULT NULL,
  `ApprovalStatus` int NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_topupbenefit_TopUpId_idx` (`TopUpId`),
  KEY `FK_topupbenefit_ApprovalStatus_idx` (`ApprovalStatus`),
  KEY `FK_topupbenefit_Benefit_idx` (`Benefit`),
  CONSTRAINT `FK_topupbenefit_ApprovalStatus` FOREIGN KEY (`ApprovalStatus`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_topupbenefit_Benefit` FOREIGN KEY (`Benefit`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_topupbenefit_TopUpId` FOREIGN KEY (`TopUpId`) REFERENCES `topup` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `topupbenefit`
--

LOCK TABLES `topupbenefit` WRITE;
/*!40000 ALTER TABLE `topupbenefit` DISABLE KEYS */;
INSERT INTO `topupbenefit` VALUES (11,7,42,2,49,_binary '',1,'2020-12-16 16:29:11',NULL,NULL),(12,7,43,2,49,_binary '',1,'2020-12-16 16:29:21',NULL,NULL);
/*!40000 ALTER TABLE `topupbenefit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendorquestionanswers`
--

DROP TABLE IF EXISTS `vendorquestionanswers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vendorquestionanswers` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `VendorLeadId` varchar(50) NOT NULL,
  `QuestionId` int NOT NULL,
  `AnswerId` int NOT NULL,
  `Vendoranswervalue` varchar(45) DEFAULT NULL,
  `IsForVendor` bit(1) NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_QusId_idx` (`QuestionId`),
  KEY `FK_AnsId_idx` (`AnswerId`),
  CONSTRAINT `FK_AnsId` FOREIGN KEY (`AnswerId`) REFERENCES `serviceanswer` (`Id`),
  CONSTRAINT `FK_QusId` FOREIGN KEY (`QuestionId`) REFERENCES `servicequestion` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendorquestionanswers`
--

LOCK TABLES `vendorquestionanswers` WRITE;
/*!40000 ALTER TABLE `vendorquestionanswers` DISABLE KEYS */;
INSERT INTO `vendorquestionanswers` VALUES (16,'HW011',27,5,'',_binary '',_binary '',1,'2020-12-10 06:03:02',NULL,NULL),(17,'HW011',27,6,'',_binary '',_binary '',1,'2020-12-10 06:03:02',NULL,NULL),(18,'HW012',28,9,'',_binary '',_binary '',1,'2020-12-10 06:03:38',NULL,NULL),(19,'HW010',29,11,NULL,_binary '\0',_binary '',1,'2020-12-10 00:00:00',NULL,NULL);
/*!40000 ALTER TABLE `vendorquestionanswers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `vendorserviceutilisation`
--

DROP TABLE IF EXISTS `vendorserviceutilisation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `vendorserviceutilisation` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ServiceSubscriptionId` int DEFAULT NULL,
  `ServiceTopupId` int DEFAULT NULL,
  `Benefit` int NOT NULL,
  `VendorId` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `UtilityCount` int NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Utilisation_Service_idx` (`ServiceSubscriptionId`),
  KEY `FK_Utilisation_ServiceTopup_idx` (`ServiceTopupId`),
  KEY `FK_Utilisation_Benefit_idx` (`Benefit`),
  CONSTRAINT `FK_Utilisation_Benefit` FOREIGN KEY (`Benefit`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_Utilisation_ServiceSubscription` FOREIGN KEY (`ServiceSubscriptionId`) REFERENCES `servicesubscription` (`Id`),
  CONSTRAINT `FK_Utilisation_ServiceTopup` FOREIGN KEY (`ServiceTopupId`) REFERENCES `servicetopup` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `vendorserviceutilisation`
--

LOCK TABLES `vendorserviceutilisation` WRITE;
/*!40000 ALTER TABLE `vendorserviceutilisation` DISABLE KEYS */;
/*!40000 ALTER TABLE `vendorserviceutilisation` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-01-01 14:16:03
