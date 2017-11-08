SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for vehicle
-- ----------------------------
DROP TABLE IF EXISTS `vehicle`;
CREATE TABLE `vehicle` (
  `numberPlate` varchar(255) NOT NULL,
  `mileage` int(11) NOT NULL default `0`,
  `rentalCharge` double default NULL,
  `under21` boolean default false,
  `offRoad` boolean default false,
  `dirtRoad` boolean default true,
  `normalRoad` boolean default true,
  `numberBeds` int(1) default `4`,
  `toilet` boolean default false,
  
  PRIMARY KEY  (`numberPlate`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for rentals
-- ----------------------------
DROP TABLE IF EXISTS `rental`;
CREATE TABLE `rental` (
  `rentalNumber` int(11) NOT NULL default `0`,
  `numberPlate` varchar(255) NOT NULL,  
  `available` boolean default true,

  PRIMARY KEY  (`numberPlate`),
  FOREIGN KEY (numberPlate) REFERENCES Vehicle(numberPlate)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
-- ----------------------------
-- Records 
-- ----------------------------

--4WD
-- numberPlate, mileage, rentalCharge, under21, offRoad, dirtRoad, normalRoad, numberBeds, toilet
INSERT INTO `vehicle` VALUES (`ab123 4WD`, `100000`, `500`, false, true, true, true, 0, false);
--2WD
INSERT INTO `vehicle` VALUES (`ab123 2WD`, `1009`, `50`, true, true, true, true, 0, false);
--Camper
INSERT INTO `vehicle` VALUES (`ab123 CAMP`, `10009`, `550`, true, false, false, true, 3, true);