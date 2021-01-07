-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: localhost    Database: happy-wed-lead
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
-- Table structure for table `leadassign`
--

DROP TABLE IF EXISTS `leadassign`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `leadassign` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `LeadId` int NOT NULL,
  `LeadSentDate` datetime DEFAULT NULL,
  `VendorId` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `VendorName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Category` int DEFAULT NULL,
  `ProposedBudget` decimal(8,2) DEFAULT NULL,
  `Packs` int DEFAULT NULL,
  `Remarks` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_leadassign_LeadId_idx` (`LeadId`),
  KEY `FK_leadassign_Category_idx` (`Category`),
  CONSTRAINT `FK_leadassign_Category` FOREIGN KEY (`Category`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_leadassign_LeadId` FOREIGN KEY (`LeadId`) REFERENCES `leads` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `leadassign`
--

LOCK TABLES `leadassign` WRITE;
/*!40000 ALTER TABLE `leadassign` DISABLE KEYS */;
INSERT INTO `leadassign` VALUES (6,15,'2020-12-23 18:35:01','HW_VENDOR1','XYZ',17,0.00,0,'string',_binary '',1,'2020-12-23 18:35:01',NULL,NULL);
/*!40000 ALTER TABLE `leadassign` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `leaddatacollection`
--

DROP TABLE IF EXISTS `leaddatacollection`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `leaddatacollection` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `CustomerId` varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `CustomerName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CustomerEmail` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CustomerPhone1` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CustomerPhone2` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `CustomerLocation` varchar(45) NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `leaddatacollection`
--

LOCK TABLES `leaddatacollection` WRITE;
/*!40000 ALTER TABLE `leaddatacollection` DISABLE KEYS */;
INSERT INTO `leaddatacollection` VALUES (12,'HW_USER1','Max','max@mac.in','8120201010','string','string',_binary '',1,'2020-12-23 18:33:12',NULL,NULL);
/*!40000 ALTER TABLE `leaddatacollection` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `leadquote`
--

DROP TABLE IF EXISTS `leadquote`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `leadquote` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `VendorId` int NOT NULL,
  `LeadId` int NOT NULL,
  `EventDate` datetime NOT NULL,
  `Location` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `LeadType` int NOT NULL,
  `SubLeadType` int NOT NULL,
  `QuotedRate` decimal(8,2) DEFAULT NULL,
  `IsSelected` bit(1) NOT NULL DEFAULT b'0',
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `Remarks` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `ldid_idx` (`LeadId`),
  KEY `ldtype_idx` (`LeadType`),
  KEY `subldtype_idx` (`SubLeadType`),
  CONSTRAINT `ldid` FOREIGN KEY (`LeadId`) REFERENCES `leads` (`Id`),
  CONSTRAINT `ldtype` FOREIGN KEY (`LeadType`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `subldtype` FOREIGN KEY (`SubLeadType`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `leadquote`
--

LOCK TABLES `leadquote` WRITE;
/*!40000 ALTER TABLE `leadquote` DISABLE KEYS */;
/*!40000 ALTER TABLE `leadquote` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `leads`
--

DROP TABLE IF EXISTS `leads`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `leads` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DataCollectionId` int NOT NULL,
  `EventDate` datetime DEFAULT NULL,
  `EventLocation` int NOT NULL,
  `LeadId` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Owner` int NOT NULL,
  `OwnerName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Description` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `LeadType` int NOT NULL,
  `EventType` int NOT NULL,
  `LeadMode` int NOT NULL,
  `Category` int NOT NULL,
  `LeadStatusId` int NOT NULL,
  `LeadQuality` int DEFAULT NULL,
  `Budget` decimal(8,2) DEFAULT NULL,
  `Revenue` decimal(8,2) DEFAULT NULL,
  `CPLValue` decimal(10,0) DEFAULT NULL,
  `CommisionValue` decimal(10,0) DEFAULT NULL,
  `WalletStatus` int DEFAULT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_leads_DataCollectionId_idx` (`DataCollectionId`),
  KEY `FK_leads_LeadType_idx` (`LeadType`),
  KEY `FK_leads_LeadMode_idx` (`LeadMode`),
  KEY `FK_leads_LeadStatus_idx` (`LeadStatusId`),
  KEY `FK_leads_LeadQuality_idx` (`LeadQuality`),
  KEY `FK_leads_WalletStatus_idx` (`WalletStatus`),
  KEY `FK_leads_EventType_idx` (`EventType`),
  KEY `FK_leads_Category_idx` (`Category`),
  KEY `eventlocation_idx` (`EventLocation`),
  CONSTRAINT `eventlocation` FOREIGN KEY (`EventLocation`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_leads_Category` FOREIGN KEY (`Category`) REFERENCES `multidetail` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_leads_DataCollectionId` FOREIGN KEY (`DataCollectionId`) REFERENCES `leaddatacollection` (`Id`),
  CONSTRAINT `Fk_leads_EventType` FOREIGN KEY (`EventType`) REFERENCES `multidetail` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `FK_leads_LeadMode` FOREIGN KEY (`LeadMode`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_leads_LeadQuality` FOREIGN KEY (`LeadQuality`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_leads_LeadType` FOREIGN KEY (`LeadType`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_leads_Status` FOREIGN KEY (`LeadStatusId`) REFERENCES `multidetail` (`Id`),
  CONSTRAINT `FK_leads_WalletStatus` FOREIGN KEY (`WalletStatus`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `leads`
--

LOCK TABLES `leads` WRITE;
/*!40000 ALTER TABLE `leads` DISABLE KEYS */;
INSERT INTO `leads` VALUES (15,12,'2020-12-23 18:31:14',17,'HW_LEAD1',1,'Admin','string',17,17,17,17,17,17,0.00,0.00,0,0,17,_binary '',1,'2020-12-23 18:33:12',NULL,NULL);
/*!40000 ALTER TABLE `leads` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `leadstatus`
--

DROP TABLE IF EXISTS `leadstatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `leadstatus` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `LeadId` int NOT NULL,
  `LeadStatusId` int NOT NULL,
  `Date` datetime NOT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_leadstatus_leadstatus_idx` (`LeadId`),
  KEY `FK_leadstatus_LeadStatusId_idx` (`LeadStatusId`),
  CONSTRAINT `FK_leadstatus_leadstatus` FOREIGN KEY (`LeadId`) REFERENCES `leads` (`Id`),
  CONSTRAINT `FK_leadstatus_LeadStatusId` FOREIGN KEY (`LeadStatusId`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `leadstatus`
--

LOCK TABLES `leadstatus` WRITE;
/*!40000 ALTER TABLE `leadstatus` DISABLE KEYS */;
INSERT INTO `leadstatus` VALUES (11,15,17,'2020-12-23 18:31:14',_binary '',1,'2020-12-23 18:33:12',NULL,NULL);
/*!40000 ALTER TABLE `leadstatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `leadvalidation`
--

DROP TABLE IF EXISTS `leadvalidation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `leadvalidation` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `LeadId` int NOT NULL,
  `CalledBy` int NOT NULL,
  `CalledOn` datetime NOT NULL,
  `Status` int NOT NULL,
  `Remark` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `FollowUpDate` datetime DEFAULT NULL,
  `CallRecordings` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Active` bit(1) NOT NULL DEFAULT b'1',
  `CreatedBy` int NOT NULL,
  `CreatedAt` datetime NOT NULL,
  `UpdatedBy` int DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_leadvalidation_LeadId_idx` (`LeadId`),
  KEY `FK_leadvalidation_Status_idx` (`Status`),
  CONSTRAINT `FK_leadvalidation_LeadId` FOREIGN KEY (`LeadId`) REFERENCES `leads` (`Id`),
  CONSTRAINT `FK_leadvalidation_Status` FOREIGN KEY (`Status`) REFERENCES `multidetail` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `leadvalidation`
--

LOCK TABLES `leadvalidation` WRITE;
/*!40000 ALTER TABLE `leadvalidation` DISABLE KEYS */;
/*!40000 ALTER TABLE `leadvalidation` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `multicode`
--

LOCK TABLES `multicode` WRITE;
/*!40000 ALTER TABLE `multicode` DISABLE KEYS */;
INSERT INTO `multicode` VALUES (20,'Test','Test','Test',_binary '',_binary '',1,'2020-12-10 00:00:00',NULL,NULL),(21,'Test1','Test1','Test1',_binary '',_binary '',1,'2020-12-10 00:00:00',NULL,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `multidetail`
--

LOCK TABLES `multidetail` WRITE;
/*!40000 ALTER TABLE `multidetail` DISABLE KEYS */;
INSERT INTO `multidetail` VALUES (17,20,'test','test',_binary '',1,'2020-12-10 00:00:00',NULL,NULL),(18,21,'test1','test1',_binary '',1,'2020-12-10 00:00:00',NULL,NULL);
/*!40000 ALTER TABLE `multidetail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'happy-wed-lead'
--
/*!50003 DROP PROCEDURE IF EXISTS `SpSearchLead` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpSearchLead`(
p_Limit INT,
p_Offset INT,
p_LeadType INT,
p_SubLeadType INT,
p_LeadMode INT,
p_LeadStatus INT,
p_LeadQuality INT,
p_WalletStatus INT,
p_IsForAssignLead BIT,
p_IsForUnAssignLead BIT,
p_FromDate DATETIME,
p_ToDate DATETIME
)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
BEGIN
ROLLBACK;
END;

START TRANSACTION;

     SET @p_Limit = IFNULL(p_Limit, 0);
     SET @p_Offset = IFNULL(p_Offset, 0);
     SET @p_LeadType = IFNULL(p_LeadType, 0);
     SET @p_SubLeadType = IFNULL(p_SubLeadType, 0);
     SET @p_LeadMode = IFNULL(p_LeadMode, 0);
     SET @p_LeadStatus = IFNULL(p_LeadStatus, 0);
	 SET @p_LeadQuality = IFNULL(p_LeadQuality, 0);
     SET @p_WalletStatus = IFNULL(p_WalletStatus, 0);
     SET @p_FromDate = p_FromDate;
	 SET @p_ToDate = p_ToDate;

     SET @Qry = " SELECT L.Id,L.DataCollectionId,LDC.CustomerName,L.EventDate,L.EventLocation,MD7.Value AS EventLocationValue,
                         L.LeadId,L.Owner,L.Description,L.LeadType,MD1.Value AS LeadTypeValue,L.SubLeadType,MD2.Value AS SubLeadTypeValue,
                         L.LeadMode,MD3.Value AS LeadModeValue,L.LeadStatus,MD4.Value AS LeadStatusValue,L.LeadQuality,
                         MD5.Value AS LeadQualityValue,L.Budget,L.ValueInPercentage,L.Revenue,L.WalletStatus,MD6.Value AS WalletStatusValue,
                         L.Active,L.CreatedBy,L.CreatedAt,L.UpdatedBy,L.UpdatedAt
                  FROM leads L
                  LEFT JOIN leaddatacollection LDC ON LDC.Id = L.DataCollectionId
                  LEFT JOIN multidetail MD1 ON MD1.Id = L.LeadType
                  LEFT JOIN multidetail MD2 ON MD2.Id = L.SubLeadType
                  LEFT JOIN multidetail MD3 ON MD3.Id = L.LeadMode
                  LEFT JOIN multidetail MD4 ON MD4.Id = L.LeadStatus
                  LEFT JOIN multidetail MD5 ON MD5.Id = L.LeadQuality
                  LEFT JOIN multidetail MD6 ON MD6.Id = L.WalletStatus
                  LEFT JOIN multidetail MD7 ON MD6.Id = L.EventLocation
                  WHERE L.Active = true ";

     SET @Conditions = " ";
     SET @LimitOffset = " ";

     IF @p_LeadType > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND L.LeadType = ", @p_LeadType," ");
     END IF;
     
     IF @p_SubLeadType > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND L.SubLeadType = ", @p_SubLeadType," ");
     END IF;
     
     IF @p_LeadMode > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND L.LeadMode = ", @p_LeadMode," ");
     END IF;
     
     IF @p_LeadStatus > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND L.LeadStatus = ", @p_LeadStatus," ");
     END IF;
     
     IF @p_LeadQuality > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND L.LeadQuality = ", @p_LeadQuality," ");
     END IF;
     
     IF @p_WalletStatus > 0 THEN 
     SET @Conditions = CONCAT(@Conditions, " AND L.WalletStatus = ", @p_WalletStatus," ");
     END IF;

     IF ((p_FromDate IS NOT NULL) AND (p_ToDate IS NOT NULL)) THEN 
     SET @Conditions = CONCAT(@Conditions," AND L.EventDate BETWEEN '", @p_FromDate, "' AND '", @p_ToDate,"' ");
     ELSEIF ((p_FromDate IS NOT NULL) AND (p_ToDate IS NULL)) THEN 
     SET @Conditions = CONCAT(@Conditions," AND L.EventDate >= '", @p_FromDate,"' ");
     ELSEIF ((p_FromDate IS NULL) AND (p_ToDate IS NOT NULL)) THEN  
     SET @Conditions = CONCAT(@Conditions," AND L.EventDate <= '", @p_ToDate,"' ");
     END IF;
     
     IF p_IsForAssignLead = true THEN 
     SET @Conditions = CONCAT(@Conditions, " AND L.Id IN (SELECT LeadId FROM leadassign) ");
     ELSEIF p_IsForUnAssignLead = true THEN 
     SET @Conditions = CONCAT(@Conditions, " AND L.Id NOT IN (SELECT LeadId FROM leadassign) ");
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
/*!50003 DROP PROCEDURE IF EXISTS `SpSelectActiveLeadsByVendor` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `SpSelectActiveLeadsByVendor`(
p_VendorId INT,
p_IsForAssignedLead bit,
p_IsForQuotedLead bit
)
BEGIN

DECLARE EXIT HANDLER FOR SQLEXCEPTION 
BEGIN
ROLLBACK;
END;

START TRANSACTION;

     SET @Qry = " SELECT L.Id,L.DataCollectionId,L.EventDate,L.EventLocation,L.LeadId,L.Owner,L.Description,L.LeadType,
                         MD1.Value AS LeadTypeValue,L.SubLeadType,MD2.Value AS SubLeadTypeValue,L.LeadMode,MD3.Value AS LeadModeValue,
                         L.LeadStatusId,MD4.Value AS LeadStatusValue,L.LeadQuality,MD5.Value AS LeadQualityValue,
                         L.Budget,L.Revenue,L.CPLValue,L.CommisionValue,L.WalletStatus,MD6.Value AS WalletStatusValue,
                         L.Active,L.CreatedBy,L.CreatedAt,L.UpdatedBy,L.UpdatedAt
                  FROM leads L ";

     SET @CommonJoins = " LEFT JOIN multidetail MD1 ON MD1.Id = L.LeadType
                          LEFT JOIN multidetail MD2 ON MD2.Id = L.SubLeadType
                          LEFT JOIN multidetail MD3 ON MD3.Id = L.LeadMode
                          LEFT JOIN multidetail MD4 ON MD4.Id = L.LeadStatusId
                          LEFT JOIN multidetail MD5 ON MD5.Id = L.LeadQuality
                          LEFT JOIN multidetail MD6 ON MD6.Id = L.WalletStatus ";

     SET @Joins = " ";
     SET @Conditions = " ";
     
     SET @p_VendorId = IFNULL(p_VendorId, 0);
   
     IF p_IsForAssignedLead = true THEN 
     SET @Joins = " INNER JOIN leadassign LA ON LA.LeadId = L.Id AND LA.Active = true "; 
     SET @Conditions = CONCAT(@Conditions," WHERE L.Active = true AND LA.VendorId = ", @p_VendorId, " "); 
     ELSEIF p_IsForQuotedLead = true THEN 
     SET @Joins = " INNER JOIN leadquote LQ ON LQ.LeadId = L.Id AND LQ.Active = true ";
     SET @Conditions = CONCAT(@Conditions," WHERE L.Active = true AND LQ.VendorId = ", @p_VendorId, " "); 
     END IF;

     SET @FullQry = CONCAT(@Qry, @Joins, @CommonJoins, @Conditions);
     
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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-01-04 12:38:10
