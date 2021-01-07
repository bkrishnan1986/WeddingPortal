CREATE DATABASE  IF NOT EXISTS `walletpayment` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `walletpayment`;
-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: localhost    Database: walletpayment
-- ------------------------------------------------------
-- Server version	8.0.20

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
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `multicode`
--

LOCK TABLES `multicode` WRITE;
/*!40000 ALTER TABLE `multicode` DISABLE KEYS */;
INSERT INTO `multicode` VALUES (1,'Wallet Status','WALLET STATUS','Des_Wallet Status',_binary '',_binary '',1,'2020-12-21 11:30:03',NULL,NULL),(2,'Mode','MODE','Des_Mode',_binary '',_binary '',1,'2020-12-21 11:30:44',NULL,NULL),(3,'Vendor Status','VENDOR STATUS','Des_Vendor Status',_binary '',_binary '',1,'2020-12-21 11:43:50',NULL,NULL),(4,'Adjustment Type','ADJUSTMENT TYPE','Des_Adjustment Type',_binary '',_binary '',1,'2020-12-21 11:44:07',NULL,NULL),(5,'Category','CATEGORY','Des_Category',_binary '',_binary '',1,'2020-12-21 11:44:27',NULL,NULL),(6,'Payment Type','PAYMENT TYPE','Des_Payment Type',_binary '',_binary '',1,'2020-12-21 11:44:50',NULL,NULL),(7,'Payment Mode','PAYMENT MODE','Des_Payment Mode',_binary '',_binary '',1,'2020-12-21 11:45:10',NULL,NULL),(8,'Payment Status','PAYMENT STATUS','Des_PPayment Status',_binary '',_binary '',1,'2020-12-21 11:45:28',NULL,NULL),(9,'BH Status','BH STATUS','Des_BH Status',_binary '',_binary '',1,'2020-12-21 11:45:48',NULL,NULL),(10,'Package Type','PACKAGE TYPE','Des_Package Type',_binary '',_binary '',1,'2020-12-21 11:46:08',NULL,NULL),(11,'Finance Status','FINANCE STATUS','Des_Finance Status',_binary '',_binary '',1,'2020-12-21 11:46:26',NULL,NULL),(12,'Refund Type','REFUND TYPE','Des_Refund Type',_binary '',_binary '',1,'2020-12-21 11:46:45',NULL,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `multidetail`
--

LOCK TABLES `multidetail` WRITE;
/*!40000 ALTER TABLE `multidetail` DISABLE KEYS */;
INSERT INTO `multidetail` VALUES (1,1,'Deduct','Des_Deduct',_binary '',1,'2020-12-21 11:48:36',NULL,NULL),(2,1,'Hold','Des_Hold',_binary '',1,'2020-12-21 11:50:30',NULL,NULL),(3,1,'Free','Des_Free',_binary '',1,'2020-12-21 11:51:32',NULL,NULL),(4,1,'Paused','Des_Paused',_binary '',1,'2020-12-21 11:51:44',NULL,NULL),(5,1,'Released','Des_Released',_binary '',1,'2020-12-21 11:51:57',NULL,NULL),(6,1,'Churned','Des_Churned',_binary '',1,'2020-12-21 11:52:14',NULL,NULL),(7,1,'Low Balance','Des_Low Balance',_binary '',1,'2020-12-21 11:52:35',NULL,NULL),(8,1,'Zero Balance','Des_Zero Balance',_binary '',1,'2020-12-21 11:52:51',NULL,NULL),(9,2,'CPL','Des_CPL',_binary '',1,'2020-12-21 11:54:37',NULL,NULL),(10,2,'Commission','Des_Commission',_binary '',1,'2020-12-21 11:54:52',NULL,NULL),(11,2,'Both','Des_Both',_binary '',1,'2020-12-21 11:55:08',NULL,NULL),(12,3,'Active','Des_Active',_binary '',1,'2020-12-21 11:56:43',NULL,NULL),(13,3,'Inactive','Des_Inactive',_binary '',1,'2020-12-21 11:56:56',NULL,NULL),(14,3,'Churned','Des_Churned',_binary '',1,'2020-12-21 11:57:17',NULL,NULL),(15,4,'Add Wallet','Des_Add Wallet',_binary '',1,'2020-12-21 11:58:22',NULL,NULL),(16,4,'Deduct Wallet','Des_Deduct Wallet',_binary '',1,'2020-12-21 11:58:46',NULL,NULL),(17,5,'Apparels','Des_Apparels',_binary '',1,'2020-12-21 12:01:20',NULL,NULL),(18,5,'Bridal Makeup','Des_Bridal Makeup',_binary '',1,'2020-12-21 12:01:34',NULL,NULL),(19,5,'Catering','Des_Catering',_binary '',1,'2020-12-21 12:05:17',NULL,NULL),(20,5,'Decoration','Des_Decoration',_binary '',1,'2020-12-21 12:05:39',NULL,NULL),(21,5,'Event Planners','Des_Event Planners',_binary '',1,'2020-12-21 12:05:52',NULL,NULL),(22,5,'Jewellery','Des_Jewellery',_binary '',1,'2020-12-21 12:06:13',NULL,NULL),(23,5,'Photography','Des_Photography',_binary '',1,'2020-12-21 12:08:22',NULL,NULL),(24,5,'Tour Operators','Des_Tour Operators',_binary '',1,'2020-12-21 12:08:36',NULL,NULL),(25,5,'Vehicle Rentals','Des_Vehicle Rentals',_binary '',1,'2020-12-21 12:08:56',NULL,NULL),(26,5,'Wedding Venue','Des_Wedding Venue',_binary '',1,'2020-12-21 12:09:12',NULL,NULL),(27,6,'Credit','Des_Credit',_binary '',1,'2020-12-21 12:11:39',NULL,NULL),(28,6,'Debit','Des_Debit',_binary '',1,'2020-12-21 12:11:55',NULL,NULL),(29,7,'Cash','Des_Cash',_binary '',1,'2020-12-21 12:13:41',NULL,NULL),(30,7,'Online','Des_Online',_binary '',1,'2020-12-21 12:13:50',NULL,NULL),(31,7,'Cheque','Des_Cheque',_binary '',1,'2020-12-21 12:14:01',NULL,NULL),(32,8,'Paid','Des_Paid',_binary '',1,'2020-12-21 12:14:45',NULL,NULL),(33,8,'Pending','Des_Pending',_binary '',1,'2020-12-21 12:14:57',NULL,NULL),(34,9,'Approve','Des_Approve',_binary '',1,'2020-12-21 12:15:31',NULL,NULL),(35,9,'Reject','Des_Reject',_binary '',1,'2020-12-21 12:15:43',NULL,NULL),(36,10,'Subscription','Des_Subscription',_binary '',1,'2020-12-21 12:16:57',NULL,NULL),(37,10,'Top-up','Des_Top-up',_binary '',1,'2020-12-21 12:17:18',NULL,NULL),(38,11,'Approve','Des_Approve',_binary '',1,'2020-12-21 12:18:12',NULL,NULL),(39,11,'Reject','Des_Reject',_binary '',1,'2020-12-21 12:18:24',NULL,NULL),(40,12,'Online Refund','Des_Wallet Refund',_binary '',1,'2020-12-21 12:19:15',NULL,NULL),(41,12,'Cash Refund','Des_Payment Refund',_binary '',1,'2020-12-21 12:19:30',NULL,NULL);
/*!40000 ALTER TABLE `multidetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paymentbook`
--

DROP TABLE IF EXISTS `paymentbook`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paymentbook` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `EntryDate` datetime NOT NULL,
  `VendorId` int NOT NULL,
  `Package` int DEFAULT NULL,
  `PackageType` int DEFAULT NULL,
  `PaymentType` int NOT NULL,
  `PaymentAmount` decimal(8,2) NOT NULL,
  `ReceivedAmount` decimal(8,2) DEFAULT NULL,
  `PaymentStatus` int NOT NULL,
  `GST` decimal(8,2) DEFAULT NULL,
  `KFC` decimal(8,2) DEFAULT NULL,
  `TDS` decimal(8,2) DEFAULT NULL,
  `WalletBalance` decimal(8,2) NOT NULL,
  `VendorStatus` int DEFAULT NULL,
  `PaymentDate` datetime DEFAULT NULL,
  `PaymentMode` int NOT NULL,
  `PaymentRefNumber` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `PayeeName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `PaymentDocs` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `BankName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `BankState` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `BankCity` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Branch` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `BankAccountNumber` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `IFSC` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `BankCreditedDate` datetime DEFAULT NULL,
  `FinanceApprovalStatus` int DEFAULT NULL,
  `FinanceApprovalStatusDate` datetime DEFAULT NULL,
  `FinanceComment` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `TidNumber` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ChequeDate` datetime DEFAULT NULL,
  `BHStatus` int DEFAULT NULL,
  `BHStatusReason` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `BHStatusDate` datetime DEFAULT NULL,
  `BHComments` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_PB_PackageType_idx` (`PackageType`),
  KEY `FK_PB_PaymentType_idx` (`PaymentType`),
  KEY `FK_PB_PaymentStatus_idx` (`PaymentStatus`),
  KEY `FK_PB_PaymentMode_idx` (`PaymentMode`),
  KEY `FK_PB_FinanceApprovalStatus_idx` (`FinanceApprovalStatus`),
  KEY `FK_PB_BHStatus_idx` (`BHStatus`),
  CONSTRAINT `FK_PB_BHStatus` FOREIGN KEY (`BHStatus`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_PB_FinanceApprovalStatus` FOREIGN KEY (`FinanceApprovalStatus`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_PB_PackageType` FOREIGN KEY (`PackageType`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_PB_PaymentMode` FOREIGN KEY (`PaymentMode`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_PB_PaymentStatus` FOREIGN KEY (`PaymentStatus`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_PB_PaymentType` FOREIGN KEY (`PaymentType`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paymentbook`
--

LOCK TABLES `paymentbook` WRITE;
/*!40000 ALTER TABLE `paymentbook` DISABLE KEYS */;
INSERT INTO `paymentbook` VALUES (1,'2020-12-22 07:55:07',1,1,36,27,100.00,100.00,32,5.00,6.00,7.00,100.00,12,'2020-12-22 07:55:07',30,'REF-xBFf9PB2','payee01','paymentDocPath','SBI','Kerala','Trivandrum','Pattom','75395185245685245','SBI007','2020-12-22 07:55:07',38,'2020-12-22 07:55:07','financeComment01','TID007','2020-12-22 07:55:07',34,'BH Status Reason01','2020-12-22 07:55:07','BH Comments01',1,'2020-12-22 08:42:29',NULL,NULL),(2,'2020-12-22 07:55:07',1,2,36,27,300.00,300.00,32,50.00,60.00,70.00,400.00,12,'2020-12-22 07:55:07',30,'REF-xBFf9PB2','payee01','paymentDocPath','SBI','Kerala','Trivandrum','Pattom','75395185245685245','SBI007','2020-12-22 07:55:07',38,'2020-12-22 07:55:07','financeComment02','TID007','2020-12-22 07:55:07',34,'BH Status Reason02','2020-12-22 07:55:07','BH Comments02',1,'2020-12-22 08:42:33',NULL,NULL),(3,'2020-12-22 09:47:34',1,1,36,27,100.00,100.00,32,5.00,6.00,7.00,0.00,12,'2020-12-22 09:47:34',31,'REF-JcKg2dHR','payee01','paymentDocPath','SBI','Kerala','Trivandrum','Pattom','75395185245685245','SBI007','2020-12-22 09:47:34',38,'2020-12-22 09:47:34','financeComment03','TID007','2020-12-22 09:47:34',34,'BH Status Reason03','2020-12-22 09:47:34','BH Comments03',1,'2020-12-22 08:46:02',1,'2020-12-22 09:53:14'),(4,'2020-12-22 12:47:21',1,NULL,NULL,28,50.00,NULL,32,NULL,NULL,NULL,500.00,NULL,NULL,29,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,1,'2020-12-22 12:47:41',NULL,NULL);
/*!40000 ALTER TABLE `paymentbook` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `refund`
--

DROP TABLE IF EXISTS `refund`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `refund` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Activity` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `RaisedDate` datetime NOT NULL,
  `RaisedBy` int NOT NULL,
  `RefundType` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `RefundAmount` decimal(8,2) NOT NULL,
  `RefundReason` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Remarks` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `BHStatus` int DEFAULT NULL,
  `ApprovedDate` datetime DEFAULT NULL,
  `ApprovedBy` int DEFAULT NULL,
  `ApprovedAmount` decimal(8,2) DEFAULT NULL,
  `ApprovalRemarks` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Reference` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `WalletBalance` decimal(8,2) DEFAULT NULL,
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_BHStatus_idx` (`BHStatus`),
  CONSTRAINT `FK_BHStatus` FOREIGN KEY (`BHStatus`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `refund`
--

LOCK TABLES `refund` WRITE;
/*!40000 ALTER TABLE `refund` DISABLE KEYS */;
INSERT INTO `refund` VALUES (1,'activity01','2020-12-22 12:42:23',1,'Regular Refund',100.00,'Event cancelation','',34,'2020-12-22 12:45:15',1,50.00,'half Amount','',500.00,1,'2020-12-22 12:43:36',1,'2020-12-22 12:47:09');
/*!40000 ALTER TABLE `refund` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transactions` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `WalletId` int NOT NULL,
  `ReferenceNo` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Particulars` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `TransactionDate` datetime NOT NULL,
  `TransactionType` int NOT NULL,
  `Amount` decimal(8,2) NOT NULL,
  `WalletBalance` decimal(8,2) NOT NULL,
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_transactions_WalletId_idx` (`WalletId`),
  KEY `FK_transactions_TransactionType_idx` (`TransactionType`),
  CONSTRAINT `FK_transactions_TransactionType` FOREIGN KEY (`TransactionType`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_transactions_WalletId` FOREIGN KEY (`WalletId`) REFERENCES `wallet` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES (1,1,'REF-xBFf9PB2','RUBY-taken (Subscription)','2020-12-22 08:42:32',27,100.00,100.00,1,'2020-12-22 08:42:32',NULL,NULL),(2,1,'REF-xBFf9PB2','SAPHIRE-taken (Subscription)','2020-12-22 08:42:33',27,300.00,400.00,1,'2020-12-22 08:42:33',NULL,NULL),(3,1,'REF-JcKg2dHR','RUBY-taken (Subscription)','2020-12-22 09:53:26',27,100.00,500.00,1,'2020-12-22 09:53:35',NULL,NULL),(4,1,NULL,'leadIdNumber01-CPL deducted','2020-12-22 13:18:39',28,100.00,400.00,1,'2020-12-22 13:18:47',NULL,NULL),(5,1,NULL,'Wallet credited by adjustment','2020-12-22 13:38:54',27,100.00,500.00,1,'2020-12-22 13:39:14',NULL,NULL),(6,1,NULL,'Wallet debited by adjustment','2020-12-22 13:39:50',28,200.00,300.00,1,'2020-12-22 13:40:01',NULL,NULL);
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `wallet`
--

DROP TABLE IF EXISTS `wallet`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `wallet` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `VendorId` int NOT NULL,
  `Status` int NOT NULL,
  `Balance` decimal(8,2) NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `VendorId_UNIQUE` (`VendorId`),
  KEY `FK_Status_idx` (`Status`),
  CONSTRAINT `FK_Status` FOREIGN KEY (`Status`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `wallet`
--

LOCK TABLES `wallet` WRITE;
/*!40000 ALTER TABLE `wallet` DISABLE KEYS */;
INSERT INTO `wallet` VALUES (1,1,1,300.00,_binary '',1,'2020-12-21 13:50:01',1,'2020-12-21 14:25:37'),(2,2,3,0.00,_binary '',1,'2020-12-21 13:54:39',NULL,NULL);
/*!40000 ALTER TABLE `wallet` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `walletadjustment`
--

DROP TABLE IF EXISTS `walletadjustment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `walletadjustment` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `VendorId` int NOT NULL,
  `AdjustmentType` int NOT NULL,
  `AdjustmentAmount` decimal(8,2) NOT NULL,
  `Remarks` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_AdjustmentType_idx` (`AdjustmentType`),
  CONSTRAINT `FK_AdjustmentType` FOREIGN KEY (`AdjustmentType`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `walletadjustment`
--

LOCK TABLES `walletadjustment` WRITE;
/*!40000 ALTER TABLE `walletadjustment` DISABLE KEYS */;
INSERT INTO `walletadjustment` VALUES (1,1,15,100.00,'remarks01',_binary '',1,'2020-12-22 13:38:47',NULL,NULL),(2,1,16,200.00,'remarks02',_binary '',1,'2020-12-22 13:39:48',1,'2020-12-22 13:42:38');
/*!40000 ALTER TABLE `walletadjustment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `walletdeduction`
--

DROP TABLE IF EXISTS `walletdeduction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `walletdeduction` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `LeadId` int NOT NULL,
  `VendorId` int NOT NULL,
  `CustomerId` int DEFAULT NULL,
  `CategoryId` int NOT NULL,
  `InvoiceNumber` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `InvoiceDate` datetime DEFAULT NULL,
  `InvoiceAmount` decimal(8,2) DEFAULT NULL,
  `WalletBalance` decimal(8,2) NOT NULL,
  `WalletStatus` int NOT NULL,
  `DeductedAmount` decimal(8,2) NOT NULL,
  `DeductedDate` datetime NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_walletdeduction_WalletStatus_idx` (`WalletStatus`),
  KEY `FK_walletdeduction_CategoryId_idx` (`CategoryId`),
  CONSTRAINT `FK_walletdeduction_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_walletdeduction_WalletStatus` FOREIGN KEY (`WalletStatus`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `walletdeduction`
--

LOCK TABLES `walletdeduction` WRITE;
/*!40000 ALTER TABLE `walletdeduction` DISABLE KEYS */;
INSERT INTO `walletdeduction` VALUES (1,1,1,1,19,'invoiceNumber01','2020-12-22 13:21:46',100.00,400.00,1,100.00,'2020-12-22 12:54:24',_binary '',1,'2020-12-22 13:17:39',1,'2020-12-22 13:22:05');
/*!40000 ALTER TABLE `walletdeduction` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `walletrule`
--

DROP TABLE IF EXISTS `walletrule`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `walletrule` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ServiceCode` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ServiceCategory` int NOT NULL,
  `Mode` int NOT NULL,
  `CPLAmount` decimal(8,2) DEFAULT NULL,
  `CommissionAmount` decimal(8,2) DEFAULT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `ServiceCategory_UNIQUE` (`ServiceCategory`),
  KEY `FK_ServiceCategory_idx` (`ServiceCategory`),
  KEY `FK_Mode_idx` (`Mode`),
  CONSTRAINT `FK_Mode` FOREIGN KEY (`Mode`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_ServiceCategory` FOREIGN KEY (`ServiceCategory`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `walletrule`
--

LOCK TABLES `walletrule` WRITE;
/*!40000 ALTER TABLE `walletrule` DISABLE KEYS */;
INSERT INTO `walletrule` VALUES (1,'ServiceCode01',19,9,100.00,0.00,_binary '',1,'2020-12-21 14:37:31',NULL,NULL),(2,'ServiceCode02',18,10,0.00,100.00,_binary '',1,'2020-12-21 14:38:20',1,'2020-12-21 14:39:43'),(3,'ServiceCode03',17,9,200.00,0.00,_binary '',1,'2020-12-21 14:54:10',NULL,NULL);
/*!40000 ALTER TABLE `walletrule` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `walletstatus`
--

DROP TABLE IF EXISTS `walletstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `walletstatus` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `WalletId` int NOT NULL,
  `Action` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Status` int NOT NULL,
  `Reason` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `StatusDate` datetime NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_WalletId_idx` (`WalletId`),
  KEY `FK_Status_idx` (`Status`),
  CONSTRAINT `FK_WalletId` FOREIGN KEY (`WalletId`) REFERENCES `wallet` (`Id`),
  CONSTRAINT `FK_WalletStatus` FOREIGN KEY (`Status`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `walletstatus`
--

LOCK TABLES `walletstatus` WRITE;
/*!40000 ALTER TABLE `walletstatus` DISABLE KEYS */;
INSERT INTO `walletstatus` VALUES (1,1,'Wallet Created',1,'Wallet Created','2020-12-21 13:50:03',_binary '',1,'2020-12-21 13:50:03',NULL,NULL),(2,2,'Wallet Created',3,'Wallet Created','2020-12-21 13:54:42',_binary '',1,'2020-12-21 13:54:44',NULL,NULL),(3,1,'WALLET RELEASED',5,'WALLET UPDATED - RELEASED','2020-12-21 14:17:12',_binary '',1,'2020-12-21 14:17:12',NULL,NULL),(4,1,'Status Updated',1,'Status Updated','2020-12-21 14:18:21',_binary '',1,'2020-12-21 14:18:21',NULL,NULL),(5,1,'WALLET RELEASED',5,'WALLET UPDATED - RELEASED','2020-12-21 14:22:12',_binary '',1,'2020-12-21 14:21:22',1,'2020-12-21 14:22:35'),(6,1,'Status Updated',2,'Status Updated','2020-12-21 14:25:15',_binary '',1,'2020-12-21 14:25:15',NULL,NULL),(7,1,'Status Updated',1,'Status Updated','2020-12-21 14:25:37',_binary '',1,'2020-12-21 14:25:37',NULL,NULL);
/*!40000 ALTER TABLE `walletstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'walletpayment'
--

--
-- Dumping routines for database 'walletpayment'
--
/*!50003 DROP PROCEDURE IF EXISTS `SpSearchPaymentBook` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpSearchPaymentBook`(
p_Limit INT,
p_Offset INT,
p_VendorId INT,
p_PackageType INT,
p_PaymentType INT,
p_PaymentStatus INT,
p_PaymentMode INT,
p_VendorStatus INT,
p_FinanceApprovalStatus INT,
p_BHStatus INT,
p_FromDate DATETIME,
p_ToDate DATETIME
)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
BEGIN
ROLLBACK;
END;

START TRANSACTION;

     SET @Qry = " SELECT PB.Id,PB.EntryDate,PB.VendorId,PB.Package,PB.PackageType,MD1.Value AS PackageTypeValue,
                         PB.PaymentType,MD2.Value AS PaymentTypeValue,PB.PaymentAmount,PB.ReceivedAmount,PB.PaymentStatus,
                         MD3.Value AS PaymentStatusValue,PB.GST,PB.KFC,PB.TDS,PB.WalletBalance,PB.VendorStatus,
                         MD4.Value AS VendorStatusValue,PB.PaymentDate,PB.PaymentMode,MD5.Value AS PaymentModeValue,
                         PB.PaymentRefNumber,PB.PayeeName,PB.PaymentDocs,PB.BankName,PB.BankState,PB.BankCity,
                         PB.Branch,PB.BankAccountNumber,PB.IFSC,PB.BankCreditedDate,PB.FinanceApprovalStatus,
                         MD6.Value AS FinanceApprovalStatusValue,PB.FinanceApprovalStatusDate,PB.FinanceComment,
                         PB.TidNumber,PB.ChequeDate,PB.BHStatus,MD7.Value AS BHStatusValue,PB.BHStatusReason,
                         PB.BHStatusDate,PB.BHComments,PB.CreatedBy,PB.CreatedAt,PB.UpdatedBy,PB.UpdatedAt
                  FROM paymentbook PB
                  LEFT JOIN multidetail MD1 ON MD1.Id = PB.PackageType
                  LEFT JOIN multidetail MD2 ON MD2.Id = PB.PaymentType
                  LEFT JOIN multidetail MD3 ON MD3.Id = PB.PaymentStatus
                  LEFT JOIN multidetail MD4 ON MD4.Id = PB.VendorStatus
                  LEFT JOIN multidetail MD5 ON MD5.Id = PB.PaymentMode
                  LEFT JOIN multidetail MD6 ON MD6.Id = PB.FinanceApprovalStatus
                  LEFT JOIN multidetail MD7 ON MD7.Id = PB.BHStatus
                  WHERE PB.Id > 0 ";

     SET @Conditions = " ";
     SET @LimitOffset = " ";
     
     SET @p_Limit = IFNULL(p_Limit, 0);
     SET @p_Offset = IFNULL(p_Offset, 0);
     SET @p_VendorId = IFNULL(p_VendorId, 0);
     SET @p_PackageType = IFNULL(p_PackageType, 0);
     SET @p_PaymentType = IFNULL(p_PaymentType, 0);
     SET @p_PaymentStatus = IFNULL(p_PaymentStatus, 0);
     SET @p_PaymentMode = IFNULL(p_PaymentMode, 0);
     SET @p_VendorStatus = IFNULL(p_VendorStatus, 0);
     SET @p_FinanceApprovalStatus = IFNULL(p_FinanceApprovalStatus, 0);
	 SET @p_BHStatus = IFNULL(p_BHStatus, 0);
     SET @p_FromDate = p_FromDate;
	 SET @p_ToDate = p_ToDate;

     IF @p_VendorId > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND PB.VendorId = ", @p_VendorId," ");
     END IF;

     IF @p_PackageType > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND PB.PackageType = ", @p_PackageType," ");
     END IF;

     IF @p_PaymentType > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND PB.PaymentType = ", @p_PaymentType," ");
     END IF;
     
     IF @p_PaymentStatus > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND PB.PaymentStatus = ", @p_PaymentStatus," ");
     END IF;
     
     IF @p_PaymentMode > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND PB.PaymentMode = ", @p_PaymentMode," ");
     END IF;
     
     IF @p_VendorStatus > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND PB.VendorStatus = ", @p_VendorStatus," ");
     END IF;
     
     IF @p_FinanceApprovalStatus > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND PB.FinanceApprovalStatus = ", @p_FinanceApprovalStatus," ");
     END IF;
     
     IF @p_BHStatus > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND PB.BHStatus = ", @p_BHStatus," ");
     END IF;

     IF ((p_FromDate IS NOT NULL) AND (p_ToDate IS NOT NULL)) THEN 
     SET @Conditions = CONCAT(@Conditions," AND PB.PaymentDate BETWEEN '", @p_FromDate, "' AND '", @p_ToDate,"' ");
     ELSEIF ((p_FromDate IS NOT NULL) AND (p_ToDate IS NULL)) THEN 
     SET @Conditions = CONCAT(@Conditions," AND PB.PaymentDate >= '", @p_FromDate,"' ");
     ELSEIF ((p_FromDate IS NULL) AND (p_ToDate IS NOT NULL)) THEN  
     SET @Conditions = CONCAT(@Conditions," AND PB.PaymentDate <= '", @p_ToDate,"' ");
     END IF;
     
     IF (IFNULL(p_Offset, 0) > 0) THEN
     SET @LimitOffset = CONCAT(" LIMIT ",@p_Limit," , ", @p_Offset);
     END IF;
     
     SET @FullQry = CONCAT(@Qry, @Conditions, @LimitOffset);
     
     PREPARE dynamic_statement FROM @FullQry;
     EXECUTE dynamic_statement;
     DEALLOCATE PREPARE dynamic_statement; 
    
COMMIT;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpSearchWallet` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpSearchWallet`(
p_Limit INT,
p_Offset INT,
p_VendorId INT,
p_StatusId INT,
p_Balance DECIMAL(8,2),
p_IsForCutoff BIT,
p_IsForBalance BIT,
p_FromDate DATETIME,
p_ToDate DATETIME
)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
BEGIN
ROLLBACK;
END;

START TRANSACTION;

     SET @Qry = " SELECT W.Id,W.VendorId,W.Status,MD.Value AS StatusValue,W.Balance,W.Active,
                         W.CreatedBy,W.CreatedAt,W.UpdatedBy,W.UpdatedAt
                  FROM wallet W
                  LEFT JOIN multidetail MD ON MD.Id = W.Status
                  WHERE W.Active = true ";

     SET @Conditions = " ";
     
     SET @p_Limit = IFNULL(p_Limit, 0);
     SET @p_Offset = IFNULL(p_Offset, 0);
     SET @p_VendorId = IFNULL(p_VendorId, 0);
     SET @p_StatusId = IFNULL(p_StatusId, 0);
     SET @p_Balance = IFNULL(p_Balance, 0);
     SET @p_FromDate = p_FromDate;
	 SET @p_ToDate = p_ToDate;
     

     IF @p_VendorId > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND W.VendorId = ", @p_VendorId, " ");
     END IF;
     
     IF @p_StatusId > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND W.Status = ", @p_StatusId, " ");
     END IF;

     IF p_IsForCutoff = true THEN 
     SET @Conditions = CONCAT(@Conditions, " AND W.Balance < ", @p_Balance, " ");
     ELSEIF p_IsForBalance = true THEN 
     SET @Conditions = CONCAT(@Conditions, " AND W.Balance = ", @p_Balance, " ");
     END IF;

     IF ((p_FromDate IS NOT NULL) AND (p_ToDate IS NOT NULL)) THEN 
     SET @Conditions = CONCAT(@Conditions," AND W.CreatedBy BETWEEN '", @p_FromDate, "' AND '", @p_ToDate,"' ");
     ELSEIF ((p_FromDate IS NOT NULL) AND (p_ToDate IS NULL)) THEN 
     SET @Conditions = CONCAT(@Conditions," AND W.CreatedBy >= '", @p_FromDate,"' ");
     ELSEIF ((p_FromDate IS NULL) AND (p_ToDate IS NOT NULL)) THEN  
     SET @Conditions = CONCAT(@Conditions," AND W.CreatedBy <= '", @p_ToDate,"' ");
     END IF;
     
     SET @Orderby = " ORDER BY W.Status ";

     IF @p_Offset > 0 THEN 
     SET @LimitOffset = CONCAT(" LIMIT ",@p_Limit," , ", @p_Offset);
     ELSE
     SET @LimitOffset = " ";
     END IF;

     SET @FullQry = CONCAT(@Qry, @Conditions, @Orderby, @LimitOffset);

     PREPARE dynamic_statement FROM @FullQry;
     EXECUTE dynamic_statement;
     DEALLOCATE PREPARE dynamic_statement; 
    
COMMIT;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpSelectActiveMultiCode` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpSelectActiveMultiCode`(
p_Id INT,
p_Code NVARCHAR(50)
)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
BEGIN
ROLLBACK;
END;

START TRANSACTION;

     SET @Qry = " SELECT Id,Code,SystemCode,Description,IsRequired,Active,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt 
				  FROM multicode
                  WHERE Active = true ";
                  
     SET @Conditions = " ";
     SET @p_Id = IFNULL(p_Id, 0);
     SET @p_Code = TRIM(IFNULL(p_Code, ''));
     
     IF @p_Id > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND Id = ", @p_Id," "); 
     ELSEIF @p_Code !=  '' THEN
     SET @Conditions = CONCAT(@Conditions, " AND SystemCode = '", @p_Code, "' ");
     END IF;

	 SET @FullQry = CONCAT(@Qry, @Conditions);
     
     PREPARE dynamic_statement FROM @FullQry;
     EXECUTE dynamic_statement;
     DEALLOCATE PREPARE dynamic_statement; 
   
COMMIT;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpSelectActiveMultiDetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpSelectActiveMultiDetail`(
p_Id INT,
p_Code NVARCHAR(50)
)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
BEGIN
ROLLBACK;
END;

START TRANSACTION;

     SET @Qry = " SELECT MD.Id,MD.MultiCodeId,MC.Code,MD.Value,MD.Description,MD.Active,MD.CreatedBy,MD.CreatedAt,MD.UpdatedBy,MD.UpdatedAt 
				  FROM multidetail MD 
                  LEFT JOIN multicode MC ON MC.Id = MD.MultiCodeId
                  WHERE MD.Active = true ";
                  
     SET @Conditions = " ";
     SET @p_Id = IFNULL(p_Id, 0);
     SET @p_Code = TRIM(IFNULL(p_Code, ''));
  
     IF @p_Id > 0 THEN 
     SET @Conditions = CONCAT(" AND MD.Id = ", @p_Id," ");
     ELSEIF @p_Code !=  '' THEN
     SET @Conditions = CONCAT(" AND MC.SystemCode = '", @p_Code, "' ");
     END IF;
 
     SET @FullQry = CONCAT(@Qry, @Conditions);
     
     PREPARE dynamic_statement FROM @FullQry;
     EXECUTE dynamic_statement;
     DEALLOCATE PREPARE dynamic_statement; 
     
COMMIT;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpSelectActivePaymentBook` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpSelectActivePaymentBook`(
p_Value INT,
p_IsForVendorId BIT
)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
BEGIN
ROLLBACK;
END;

START TRANSACTION;

     SET @Qry = " SELECT PB.Id,PB.EntryDate,PB.VendorId,PB.Package,PB.PackageType,MD1.Value AS PackageTypeValue,
                         PB.PaymentType,MD2.Value AS PaymentTypeValue,PB.PaymentAmount,PB.ReceivedAmount,PB.PaymentStatus,
                         MD3.Value AS PaymentStatusValue,PB.GST,PB.KFC,PB.TDS,PB.WalletBalance,PB.VendorStatus,
                         MD4.Value AS VendorStatusValue,PB.PaymentDate,PB.PaymentMode,MD5.Value AS PaymentModeValue,
                         PB.PaymentRefNumber,PB.PayeeName,PB.PaymentDocs,PB.BankName,PB.BankState,PB.BankCity,
                         PB.Branch,PB.BankAccountNumber,PB.IFSC,PB.BankCreditedDate,PB.FinanceApprovalStatus,
                         MD6.Value AS FinanceApprovalStatusValue,PB.FinanceApprovalStatusDate,PB.FinanceComment,
                         PB.TidNumber,PB.ChequeDate,PB.BHStatus,MD7.Value AS BHStatusValue,PB.BHStatusReason,
                         PB.BHStatusDate,PB.BHComments,PB.CreatedBy,PB.CreatedAt,PB.UpdatedBy,PB.UpdatedAt
                  FROM paymentbook PB
                  LEFT JOIN multidetail MD1 ON MD1.Id = PB.PackageType
                  LEFT JOIN multidetail MD2 ON MD2.Id = PB.PaymentType
                  LEFT JOIN multidetail MD3 ON MD3.Id = PB.PaymentStatus
                  LEFT JOIN multidetail MD4 ON MD4.Id = PB.VendorStatus
                  LEFT JOIN multidetail MD5 ON MD5.Id = PB.PaymentMode
                  LEFT JOIN multidetail MD6 ON MD6.Id = PB.FinanceApprovalStatus
                  LEFT JOIN multidetail MD7 ON MD7.Id = PB.BHStatus ";
                  
     SET @Conditions = " ";
     SET @p_Value = IFNULL(p_Value, 0);

     IF @p_Value > 0 THEN 
           IF p_IsForVendorId = true THEN 
           SET @Conditions = CONCAT(" WHERE PB.VendorId = ", @p_Value, " ");
           ELSE
		   SET @Conditions = CONCAT(" WHERE PB.Id = ", @p_Value, " ");
           END IF;
     END IF;

     SET @Orderby = " ORDER BY PB.VendorId ";
     
     SET @FullQry = CONCAT(@Qry, @Conditions, @Orderby);
     
     PREPARE dynamic_statement FROM @FullQry;
     EXECUTE dynamic_statement;
     DEALLOCATE PREPARE dynamic_statement; 
    
COMMIT;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpSelectActiveRefund` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpSelectActiveRefund`(
p_Value INT,
p_IsforSingleRefund BIT,
p_IsforRaisedBy BIT
)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
BEGIN
ROLLBACK;
END;

START TRANSACTION;

     SET @Qry = " SELECT R.Id,R.Activity,R.RaisedDate,R.RaisedBy,R.RefundType,R.RefundAmount,R.RefundReason,R.Remarks,
                         R.BHStatus,MD.Value AS BHStatusValue,R.ApprovedDate,R.ApprovedBy,R.ApprovedAmount,
                         R.ApprovalRemarks,R.Reference,R.WalletBalance,R.CreatedBy,R.CreatedAt,R.UpdatedBy,R.UpdatedAt
                  FROM refund R
                  LEFT JOIN multidetail MD ON MD.Id = R.BHStatus
                  WHERE R.Id > 0 ";
                  
     SET @Conditions = " ";
     SET @p_Value = IFNULL(p_Value, 0);
     
     IF p_IsforSingleRefund = true THEN 
     SET @Conditions = CONCAT(" AND R.Id = ", @p_Value, " "); 
     ELSEIF p_IsforRaisedBy = true THEN 
     SET @Conditions = CONCAT(" AND R.RaisedBy = ", @p_Value, " ");
     END IF;

     SET @Orderby = " ORDER BY R.Id ";
     
     SET @FullQry = CONCAT(@Qry, @Conditions, @Orderby);
     
     PREPARE dynamic_statement FROM @FullQry;
     EXECUTE dynamic_statement;
     DEALLOCATE PREPARE dynamic_statement; 
    
COMMIT;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpSelectActiveTransactions` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpSelectActiveTransactions`(
p_Value INT,
p_IsForWallet BIT,
p_ReferenceNo NVARCHAR(250),
p_TransactionType INT,
p_TransactionDate DATETIME
)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
BEGIN
ROLLBACK;
END;

START TRANSACTION;

     SET @Qry = " SELECT T.Id,T.WalletId,T.ReferenceNo,T.Particulars,T.TransactionDate,
                         T.TransactionType,MD.Value AS TransactionTypeValue,T.Amount,T.WalletBalance,
                         T.CreatedBy,T.CreatedAt,T.UpdatedBy,T.UpdatedAt
				  FROM transactions T
                  LEFT JOIN multidetail MD ON MD.Id = T.TransactionType
                  WHERE T.Id > 0 ";
                  
     SET @Conditions = " ";
     
     SET @p_Value = IFNULL(p_Value, 0);
     SET @p_ReferenceNo = TRIM(IFNULL(p_ReferenceNo, ''));
     SET @p_TransactionType = IFNULL(p_TransactionType, 0);
     SET @p_TransactionDate = p_TransactionDate;

     IF @p_Value > 0 THEN 
           IF p_IsForWallet = true THEN 
           SET @Conditions = CONCAT(@Conditions, " AND T.WalletId = ", @p_Value, " ");
           ELSE
		   SET @Conditions = CONCAT(@Conditions, " AND T.Id = ", @p_Value, " ");
           END IF;
     END IF;
     
     IF @p_ReferenceNo !=  '' THEN 
     SET @Conditions = CONCAT(@Conditions, " AND T.ReferenceNo = '", @p_ReferenceNo, "' ");
     END IF;
     
     IF @p_TransactionType > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND T.TransactionType = ", @p_TransactionType, " ");
     END IF;
     
     IF (p_TransactionDate IS NOT NULL) THEN
     SET @Conditions = CONCAT(@Conditions," AND DATE(T.TransactionDate) = '", @p_TransactionDate,"' ");
     END IF;

     SET @Orderby = " ORDER BY T.Id DESC ";
     
     SET @FullQry = CONCAT(@Qry, @Conditions, @Orderby);
     
     PREPARE dynamic_statement FROM @FullQry;
     EXECUTE dynamic_statement;
     DEALLOCATE PREPARE dynamic_statement; 
    
COMMIT;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpSelectActiveTransactionsByVendor` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpSelectActiveTransactionsByVendor`(
p_VendorId INT
)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
BEGIN
ROLLBACK;
END;

SELECT T.Id,T.WalletId,T.ReferenceNo,T.Particulars,T.TransactionDate,T.TransactionType,MD.Value AS TransactionTypeValue,
       T.Amount,T.WalletBalance,T.CreatedBy,T.CreatedAt,T.UpdatedBy,T.UpdatedAt
FROM transactions T
LEFT JOIN multidetail MD ON MD.Id = T.TransactionType
WHERE T.WalletId = (SELECT Id AS walletId FROM wallet WHERE VendorId = p_VendorId LIMIT 1);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpSelectActiveWallet` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpSelectActiveWallet`(
p_Value INT
)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
BEGIN
ROLLBACK;
END;

START TRANSACTION;

     SET @Qry = " SELECT W.Id,W.VendorId,W.Status,MD.Value AS StatusValue,W.Balance,W.Active,
                         W.CreatedBy,W.CreatedAt,W.UpdatedBy,W.UpdatedAt
                  FROM wallet W
                  LEFT JOIN multidetail MD ON MD.Id = W.Status
                  WHERE W.Active = true ";
                  
     SET @Conditions = " ";
     SET @p_Value = IFNULL(p_Value, 0);
     
     IF @p_Value > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND W.Id = ", @p_Value, " ");
     END IF;

     SET @Orderby = " ORDER BY W.Status ";
     
     SET @FullQry = CONCAT(@Qry, @Conditions, @Orderby);
     
     PREPARE dynamic_statement FROM @FullQry;
     EXECUTE dynamic_statement;
     DEALLOCATE PREPARE dynamic_statement; 
    
COMMIT;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpSelectActiveWalletAdjustment` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpSelectActiveWalletAdjustment`(
p_Value INT,
p_AdjustmentType INT,
p_IsForVendor BIT
)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
BEGIN
ROLLBACK;
END;

START TRANSACTION;

     SET @Qry = " SELECT WA.Id,WA.VendorId,WA.AdjustmentType,MD.Value AS AdjustmentTypeValue,WA.AdjustmentAmount,
                         WA.Remarks,WA.Active,WA.CreatedBy,WA.CreatedAt,WA.UpdatedBy,WA.UpdatedAt
                  FROM walletadjustment WA
                  LEFT JOIN multidetail MD ON MD.Id = WA.AdjustmentType
                  WHERE WA.Active = true ";
                  
     SET @Conditions = " ";
     SET @p_Value = IFNULL(p_Value, 0);
     SET @p_AdjustmentType = IFNULL(p_AdjustmentType, 0);
     
     IF @p_Value > 0 THEN 
        IF p_IsForVendor = true THEN
        SET @Conditions = CONCAT(@Conditions," AND WA.VendorId = ", @p_Value, " ");
        ELSE
        SET @Conditions = CONCAT(@Conditions," AND WA.Id = ", @p_Value, " ");
        END IF;
     END IF;
     
     IF @p_AdjustmentType > 0 THEN 
     SET @Conditions = CONCAT(@Conditions," AND WA.AdjustmentType = ", @p_AdjustmentType, " ");
     END IF;

     SET @Orderby = " ORDER BY WA.VendorId ";
     
     SET @FullQry = CONCAT(@Qry, @Conditions, @Orderby);
     
     PREPARE dynamic_statement FROM @FullQry;
     EXECUTE dynamic_statement;
     DEALLOCATE PREPARE dynamic_statement; 
    
COMMIT;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpSelectActiveWalletDeduction` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpSelectActiveWalletDeduction`(
p_Value INT,
p_IsForSingleDeduction bit,
p_IsForLeadId bit,
p_IsForVendorId bit
)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
BEGIN
ROLLBACK;
END;

START TRANSACTION;

     SET @Qry = " SELECT WD.Id,WD.LeadId,WD.VendorId,WD.CustomerId,WD.CategoryId,
						 MD1.Value AS Category,WD.InvoiceNumber,WD.InvoiceDate,WD.InvoiceAmount,WD.WalletBalance,
                         WD.WalletStatus,MD2.Value AS WalletStatusValue,WD.DeductedAmount,WD.DeductedDate,WD.Active,
                         WD.CreatedBy,WD.CreatedAt,WD.UpdatedBy,WD.UpdatedAt
				  FROM walletdeduction WD
                  LEFT JOIN multidetail MD1 ON MD1.Id = WD.CategoryId
                  LEFT JOIN multidetail MD2 ON MD2.Id = WD.WalletStatus
                  WHERE WD.Active = true ";
                  
     SET @Conditions = " ";
     SET @p_Value = IFNULL(p_Value, 0);
     
     IF p_IsForSingleDeduction = true THEN 
     SET @Conditions = CONCAT(" AND WD.Id = ", @p_Value, " "); 
     ELSEIF p_IsForLeadId = true THEN 
     SET @Conditions = CONCAT(" AND WD.LeadId = ", @p_Value, " ");
     ELSEIF p_IsForVendorId = true THEN 
     SET @Conditions = CONCAT(" AND WD.VendorId = ", @p_Value, " ");
     END IF;

     SET @FullQry = CONCAT(@Qry, @Conditions);
     
     PREPARE dynamic_statement FROM @FullQry;
     EXECUTE dynamic_statement;
     DEALLOCATE PREPARE dynamic_statement; 
    
COMMIT;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpSelectActiveWalletRule` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpSelectActiveWalletRule`(
p_Value INT,
p_IsForServiceCategory BIT
)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
BEGIN
ROLLBACK;
END;

START TRANSACTION;

     SET @Qry = " SELECT WR.Id,WR.ServiceCode,WR.ServiceCategory,MD1.Value AS ServiceCategoryValue,
                         WR.Mode,MD2.Value AS ModeValue,WR.CPLAmount,WR.CommissionAmount,
                         WR.Active,WR.CreatedBy,WR.CreatedAt,WR.UpdatedBy,WR.UpdatedAt
                  FROM walletrule WR
                  LEFT JOIN multidetail MD1 ON MD1.Id = WR.ServiceCategory
                  LEFT JOIN multidetail MD2 ON MD2.Id = WR.Mode
                  WHERE WR.Active = true ";
                  
     SET @Conditions = " ";
     SET @p_Value = IFNULL(p_Value, 0);
     
     IF @p_Value > 0 THEN
        IF p_IsForServiceCategory = true THEN
        SET @Conditions = CONCAT(" AND WR.ServiceCategory = ", @p_Value, " ");
        ElSE
        SET @Conditions = CONCAT(" AND WR.Id = ", @p_Value, " ");
        END IF;
     END IF;

     SET @Orderby = " ORDER BY WR.ServiceCategory ";
     
     SET @FullQry = CONCAT(@Qry, @Conditions, @Orderby);
     
     PREPARE dynamic_statement FROM @FullQry;
     EXECUTE dynamic_statement;
     DEALLOCATE PREPARE dynamic_statement; 
    
COMMIT;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `SpSelectActiveWalletStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpSelectActiveWalletStatus`(
p_Value INT,
p_IsForWallet BIT
)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
BEGIN
ROLLBACK;
END;

START TRANSACTION;

     SET @Qry = " SELECT WS.Id,WS.WalletId,WS.Action,WS.Status,MD.Value AS StatusValue,WS.Reason,WS.StatusDate,
                         WS.Active,WS.CreatedBy,WS.CreatedAt,WS.UpdatedBy,WS.UpdatedAt
                  FROM walletstatus WS
				  LEFT JOIN multidetail MD ON MD.Id = WS.Status
                  WHERE WS.Active = true ";
                  
     SET @Conditions = " ";
     SET @p_Value = IFNULL(p_Value, 0);
     
     IF @p_Value > 0 THEN 
          IF p_IsForWallet = true THEN 
          SET @Conditions = CONCAT(" AND WS.WalletId = ", @p_Value, " ");
          ELSE
		  SET @Conditions = CONCAT(" AND WS.Id = ", @p_Value, " ");
          END IF;
     END IF;

     SET @Orderby = " ORDER BY WS.WalletId ";
     
     SET @FullQry = CONCAT(@Qry, @Conditions, @Orderby);
     
     PREPARE dynamic_statement FROM @FullQry;
     EXECUTE dynamic_statement;
     DEALLOCATE PREPARE dynamic_statement; 
    
COMMIT;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-12-22 19:22:07
