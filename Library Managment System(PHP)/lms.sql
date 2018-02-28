-- phpMyAdmin SQL Dump
-- version 4.5.2
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Jul 02, 2016 at 05:59 AM
-- Server version: 5.7.9
-- PHP Version: 5.6.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `lms`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin_pass`
--

DROP TABLE IF EXISTS `admin_pass`;
CREATE TABLE IF NOT EXISTS `admin_pass` (
  `username` varchar(80) NOT NULL,
  `password` varchar(80) NOT NULL,
  PRIMARY KEY (`username`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin_pass`
--

INSERT INTO `admin_pass` (`username`, `password`) VALUES
('zain', '123'),
('admin', 'abc123');

-- --------------------------------------------------------

--
-- Table structure for table `author`
--

DROP TABLE IF EXISTS `author`;
CREATE TABLE IF NOT EXISTS `author` (
  `author_id` int(11) NOT NULL AUTO_INCREMENT,
  `author_first_name` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  `author_last_name` varchar(30) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`author_id`),
  UNIQUE KEY `author_first_name` (`author_first_name`,`author_last_name`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `author`
--

INSERT INTO `author` (`author_id`, `author_first_name`, `author_last_name`) VALUES
(24, 'abdullah', 'hussain'),
(5, 'allen ', 'turing'),
(28, 'anany', 'levitin'),
(22, 'asim', 'rasool'),
(27, 'bradley', 'miller'),
(30, 'james', 'munkers'),
(31, 'jon', 'gallaway'),
(33, 'karamat', 'dar'),
(29, 'kashif', 'murtaza'),
(35, 'kenneth', 'rosen'),
(34, 'lauren', 'darcey'),
(39, 'masood', 'sarwar'),
(26, 'morris', 'mano'),
(25, 'muhammad', 'sarwar'),
(7, 'nimra', 'ahmad'),
(23, 'qamar', 'zaidi'),
(37, 'rehman', 'shiek'),
(32, 'robert', 'lafore'),
(38, 'sadaqat', 'rana'),
(36, 'shuja', 'rehman'),
(8, 'sumera', 'hameed'),
(3, 'thomas', 'edison'),
(4, 'tonny ', 'gaddies'),
(6, 'umera ', 'ahmad');

-- --------------------------------------------------------

--
-- Table structure for table `book`
--

DROP TABLE IF EXISTS `book`;
CREATE TABLE IF NOT EXISTS `book` (
  `book_id` int(50) NOT NULL AUTO_INCREMENT,
  `status_id` tinyint(1) NOT NULL,
  `isbn` int(11) NOT NULL,
  PRIMARY KEY (`book_id`),
  KEY `status_id` (`status_id`),
  KEY `isbn` (`isbn`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `book`
--

INSERT INTO `book` (`book_id`, `status_id`, `isbn`) VALUES
(7, 2, 969),
(8, 1, 1000),
(9, 2, 1100),
(10, 2, 1500),
(11, 2, 2000),
(12, 1, 2500),
(13, 1, 2500),
(14, 1, 4000),
(15, 2, 5000),
(16, 2, 4800),
(17, 2, 4200),
(18, 2, 5001),
(19, 2, 6000),
(20, 1, 6078),
(23, 2, 2580);

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
CREATE TABLE IF NOT EXISTS `category` (
  `category_id` int(11) NOT NULL AUTO_INCREMENT,
  `category_type` varchar(80) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`category_id`),
  UNIQUE KEY `category_type` (`category_type`)
) ENGINE=InnoDB AUTO_INCREMENT=78 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`category_id`, `category_type`) VALUES
(76, 'algorithms'),
(75, 'calculus'),
(31, 'computing'),
(1, 'database'),
(4, 'designing'),
(71, 'english'),
(58, 'fiction'),
(46, 'General Knowledge'),
(74, 'language'),
(66, 'magazine'),
(77, 'my book'),
(2, 'networks'),
(5, 'novels'),
(3, 'programing');

-- --------------------------------------------------------

--
-- Table structure for table `department`
--

DROP TABLE IF EXISTS `department`;
CREATE TABLE IF NOT EXISTS `department` (
  `department_id` int(11) NOT NULL AUTO_INCREMENT,
  `department_name` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`department_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `department`
--

INSERT INTO `department` (`department_id`, `department_name`) VALUES
(1, 'computer sciences'),
(2, 'arts & architecture'),
(3, 'pharmacy');

-- --------------------------------------------------------

--
-- Table structure for table `isbn`
--

DROP TABLE IF EXISTS `isbn`;
CREATE TABLE IF NOT EXISTS `isbn` (
  `isbn` int(11) NOT NULL,
  `book_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `category_id` int(11) NOT NULL,
  `book_edition` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `author_id` int(11) NOT NULL,
  PRIMARY KEY (`isbn`),
  KEY `category_id` (`category_id`),
  KEY `author_id` (`author_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `isbn`
--

INSERT INTO `isbn` (`isbn`, `book_name`, `category_id`, `book_edition`, `author_id`) VALUES
(969, 'nasheeb', 5, '1st', 24),
(1000, 'pakistan studies', 46, '1st', 25),
(1100, 'digital logic and design', 4, '1st', 26),
(1500, 'python', 3, '1st', 27),
(2000, 'design and analysis of algortithm', 31, '1st', 28),
(2500, 'computer algorithms', 31, '1st', 29),
(2580, 'os', 3, '1st', 39),
(4000, 'topology', 75, '2nd', 30),
(4200, 'linear algebra', 75, '2nd', 33),
(4800, 'object oriented programming', 3, '3rd', 32),
(5000, 'asp.net', 3, '3rd', 31),
(5001, 'android', 3, '4rth', 34),
(6000, 'discrete mathematics', 75, '1st', 35),
(6078, 'visual c-sahrp', 3, '1st', 36),
(150000, 'statistic', 31, '1st', 38);

-- --------------------------------------------------------

--
-- Table structure for table `issue_date`
--

DROP TABLE IF EXISTS `issue_date`;
CREATE TABLE IF NOT EXISTS `issue_date` (
  `issue_date` date NOT NULL,
  `due_date` date NOT NULL,
  PRIMARY KEY (`issue_date`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `issue_date`
--

INSERT INTO `issue_date` (`issue_date`, `due_date`) VALUES
('2016-06-02', '2016-06-12'),
('2016-06-03', '2016-06-13');

-- --------------------------------------------------------

--
-- Table structure for table `issue_return`
--

DROP TABLE IF EXISTS `issue_return`;
CREATE TABLE IF NOT EXISTS `issue_return` (
  `book_id` int(50) NOT NULL AUTO_INCREMENT,
  `issue_date` date NOT NULL,
  `student_id` varchar(15) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `teacher_id` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `return_date` date DEFAULT NULL,
  `fine` int(11) DEFAULT NULL,
  PRIMARY KEY (`book_id`,`issue_date`),
  KEY `student_id` (`student_id`),
  KEY `teacher_id` (`teacher_id`),
  KEY `issue_date` (`issue_date`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `issue_return`
--

INSERT INTO `issue_return` (`book_id`, `issue_date`, `student_id`, `teacher_id`, `return_date`, `fine`) VALUES
(7, '2016-06-02', 'bcsf14a006', NULL, '2016-06-14', 20),
(8, '2016-06-02', NULL, '1', NULL, NULL),
(12, '2016-06-02', 'bcsf14a003', NULL, NULL, NULL),
(13, '2016-06-02', NULL, '3', NULL, NULL),
(14, '2016-06-02', NULL, '3', NULL, NULL),
(15, '2016-06-02', NULL, '2', '2016-06-05', 0),
(18, '2016-06-02', 'bcsf14a016', NULL, '2016-06-17', 50),
(19, '2016-06-02', 'bcsf14a032', NULL, '2016-06-06', 0),
(20, '2016-06-03', 'bcsf14a055', NULL, NULL, NULL),
(23, '2016-06-02', 'bcsf14a016', NULL, '2016-06-03', 0);

-- --------------------------------------------------------

--
-- Table structure for table `status`
--

DROP TABLE IF EXISTS `status`;
CREATE TABLE IF NOT EXISTS `status` (
  `status_id` tinyint(1) NOT NULL,
  `status_type` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`status_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `status`
--

INSERT INTO `status` (`status_id`, `status_type`) VALUES
(1, 'issued'),
(2, 'available');

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
CREATE TABLE IF NOT EXISTS `student` (
  `student_id` varchar(15) COLLATE utf8mb4_unicode_ci NOT NULL,
  `student_first_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `student_last_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `current_semester` int(11) NOT NULL,
  `department_id` int(11) NOT NULL,
  PRIMARY KEY (`student_id`),
  KEY `department_id` (`department_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`student_id`, `student_first_name`, `student_last_name`, `current_semester`, `department_id`) VALUES
('bcsf14a003', 'fahad', 'fayaz', 5, 2),
('bcsf14a006', 'ali', 'rehman', 2, 3),
('bcsf14a015', 'ameer', 'hamza', 4, 1),
('bcsf14a016', 'asma', 'maqsood', 1, 1),
('BCSF14A028', 'hassan', 'iftikhar', 4, 1),
('bcsf14a030', 'waqar', 'butt', 4, 1),
('bcsf14a032', 'mehru', 'nisa', 3, 1),
('bcsf14a040', 'zain', 'asghar', 4, 1),
('BCSF14A044', 'abdul', 'sadd', 5, 1),
('bcsf14a045', 'abdul', 'raheem', 4, 2),
('BCSF14A055', 'Hamza', 'Shafique', 8, 2),
('bcsf14a059', 'fahad', 'fiaz', 3, 1);

-- --------------------------------------------------------

--
-- Table structure for table `student_pass`
--

DROP TABLE IF EXISTS `student_pass`;
CREATE TABLE IF NOT EXISTS `student_pass` (
  `username` varchar(10) NOT NULL,
  `password` varchar(20) NOT NULL,
  PRIMARY KEY (`username`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `student_pass`
--

INSERT INTO `student_pass` (`username`, `password`) VALUES
('bcsf14a040', 'abc'),
('bcsf14a003', '123'),
('bcsf14a006', 'ali'),
('bcsf14a055', '789'),
('bcsf14a045', '4512'),
('bcsf14a015', '123'),
('bcsf14a016', '123');

-- --------------------------------------------------------

--
-- Table structure for table `teacher`
--

DROP TABLE IF EXISTS `teacher`;
CREATE TABLE IF NOT EXISTS `teacher` (
  `teacher_id` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `teacher_first_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `teacher_last_name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `gender` varchar(50) COLLATE utf8mb4_unicode_ci NOT NULL,
  `department_id` int(11) NOT NULL,
  PRIMARY KEY (`teacher_id`),
  KEY `department_id` (`department_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `teacher`
--

INSERT INTO `teacher` (`teacher_id`, `teacher_first_name`, `teacher_last_name`, `gender`, `department_id`) VALUES
('1', 'sir', 'asim', 'male', 1),
('2', 'sir', 'tariq', 'male', 2),
('3', 'mam', 'esha', 'female', 2),
('4', 'mam', 'fatima', 'female', 3),
('5', 'sir', 'sadaqat', 'male', 1),
('7', 'ejaz', 'ashraf', 'male', 1),
('b-900', 'emma', 'watson', 'female', 2),
('T-05', 'Sir', 'Gazali', 'male', 1);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `book`
--
ALTER TABLE `book`
  ADD CONSTRAINT `book_ibfk_1` FOREIGN KEY (`status_id`) REFERENCES `status` (`status_id`),
  ADD CONSTRAINT `book_ibfk_2` FOREIGN KEY (`isbn`) REFERENCES `isbn` (`isbn`);

--
-- Constraints for table `isbn`
--
ALTER TABLE `isbn`
  ADD CONSTRAINT `isbn_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `category` (`category_id`),
  ADD CONSTRAINT `isbn_ibfk_2` FOREIGN KEY (`author_id`) REFERENCES `author` (`author_id`);

--
-- Constraints for table `issue_return`
--
ALTER TABLE `issue_return`
  ADD CONSTRAINT `issue_return_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `student` (`student_id`),
  ADD CONSTRAINT `issue_return_ibfk_3` FOREIGN KEY (`issue_date`) REFERENCES `issue_date` (`issue_date`),
  ADD CONSTRAINT `issue_return_ibfk_5` FOREIGN KEY (`teacher_id`) REFERENCES `teacher` (`teacher_id`),
  ADD CONSTRAINT `issue_return_ibfk_6` FOREIGN KEY (`book_id`) REFERENCES `book` (`book_id`);

--
-- Constraints for table `student`
--
ALTER TABLE `student`
  ADD CONSTRAINT `student_ibfk_1` FOREIGN KEY (`department_id`) REFERENCES `department` (`department_id`);

--
-- Constraints for table `teacher`
--
ALTER TABLE `teacher`
  ADD CONSTRAINT `teacher_ibfk_1` FOREIGN KEY (`department_id`) REFERENCES `department` (`department_id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
