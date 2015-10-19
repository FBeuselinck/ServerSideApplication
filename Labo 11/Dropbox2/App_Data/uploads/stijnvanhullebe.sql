-- phpMyAdmin SQL Dump
-- version 3.4.11.1deb2+deb7u1
-- http://www.phpmyadmin.net
--
-- Machine: localhost
-- Genereertijd: 09 nov 2014 om 21:30
-- Serverversie: 5.5.40
-- PHP-Versie: 5.4.34-0+deb7u1

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Databank: `stijnvanhullebe`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `tblProjecten`
--

CREATE TABLE IF NOT EXISTS `tblProjecten` (
  `ID` int(11) NOT NULL,
  `Naam` varchar(30) NOT NULL,
  `Site` varchar(100) NOT NULL,
  `Omschrijving` varchar(400) NOT NULL,
  `Image` varchar(500) NOT NULL,
  `Soort` varchar(30) NOT NULL,
  `Kleur` varchar(12) DEFAULT NULL,
  `Logo` varchar(50) DEFAULT NULL,
  `BehanceID` int(8) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `ID` (`ID`),
  KEY `ID_2` (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Gegevens worden uitgevoerd voor tabel `tblProjecten`
--

INSERT INTO `tblProjecten` (`ID`, `Naam`, `Site`, `Omschrijving`, `Image`, `Soort`, `Kleur`, `Logo`, `BehanceID`) VALUES
(2, 'Jane Interieur', 'http://www.janeinterieur.be', 'Professioneel project: Deze site heb ik gemaakt voor een interieurarchitecte', '{ "image": { "0": "../images/webdesign/jane_interieur/1.png","1": "../images/webdesign/jane_interieur/2.png","2": "../images/webdesign/jane_interieur/3.png","mobile": "../images/webdesign/jane_interieur/mobile.png" } }', 'webdesign', '#B1A58A', '../images/webdesign/jane_interieur/logo.png', 18122075),
(1, 'Multistore', '', 'Schoolproject: Multi-Store is een online winkel die ik heb gemaakt voor mijn eindwerk in de middelbare school. Op de site is het mogelijk om producten aan te kopen(fictief). Deze site heb ik gemaakt in ASP.NET.', '{ "image": { "0": "../images/webdesign/multistore/1.png" } }', 'webdesign', '#537792', '../images/webdesign/multistore/logo.png', NULL),
(0, 'Gadgetline', 'http://www.gadgetline.be', 'Eigen project: Deze site heb ik gemaakt in juni 2012 en doorheen het jaar geupdated. Deze site gaat over alle nieuwtjes in de elektronische wereld. Je kan hier nieuws vinden over Apple, Microsoft, Google,..  Momenteel heb ik dit project stop gezet doordat ik er niet genoeg tijd voor heb om hier professioneel mee bezig te zijn.', '{ "image": { "0": "../images/webdesign/gadgetline/1.png","1": "../images/webdesign/gadgetline/2.png","mobile": "../images/webdesign/gadgetline/mobile.png" } }', 'webdesign', '#e6e6e6 ', '../images/webdesign/gadgetline/logo.png', NULL),
(5, 'Spotify', '', 'Schoolproject: Maak een mockup van een site in Photoshop.', '{"image": {"0": "../images/webdesign/spotify/home.jpg","1":"../images/webdesign/spotify/app.jpg","2":"../images/webdesign/spotify/support.jpg"}}', 'webdesign', '#000000', '../images/webdesign/spotify/logo.png', 13704129),
(4, 'Pick The Color', 'http://apps.microsoft.com/windows/nl-nl/app/pick-the-color/aa33fc40-b975-4c5f-9698-13e3dd1d3a25', 'Eigen project: Pick The Color is een app die ik heb gemaakt op de Microsoft Hackaton.', '{"image": {"0": "../images/apps/pick_the_color/1.png","1":"../images/apps/pick_the_color/2.png"}}', 'apps', '#597484', '../images/apps/pick_the_color/logo.png', NULL),
(3, 'Robot', '', 'Schoolproject: Maak een creatieve robot in Illustrator', '{"image": {"0": "../images/design/robot/1.png","1": "../images/design/robot/2.png","2": "../images/design/robot/3.png"}}', 'design', '#bdccd4', '../images/design/robot/logo.png', 18122189),
(6, 'One Watch', 'http://www.onewatch.be', 'Eeen site', '{ "image": { "0": "../images/webdesign/one_watch/1.png","1": "../images/webdesign/one_watch/2.png","2": "../images/webdesign/one_watch/3.png","3": "../images/webdesign/one_watch/4.png","mobile": "../images/webdesign/one_watch/mobile.png" } }', 'webdesign', '#505661', '../images/webdesign/one_watch/logo.png', 18123181);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
