-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 22, 2024 at 06:02 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `craftingtable`
--
CREATE DATABASE IF NOT EXISTS `craftingtable` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `craftingtable`;

-- --------------------------------------------------------

--
-- Table structure for table `age_restriction`
--

CREATE TABLE `age_restriction` (
  `id` int(11) NOT NULL,
  `age_restriction` text NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `age_restriction`:
--

-- --------------------------------------------------------

--
-- Table structure for table `chat_message`
--

CREATE TABLE `chat_message` (
  `id` int(11) NOT NULL,
  `session` int(11) NOT NULL,
  `sender` int(11) NOT NULL,
  `answered` int(11) DEFAULT NULL,
  `send_date` date NOT NULL,
  `message` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `chat_message`:
--   `answered`
--       `chat_message` -> `id`
--   `session`
--       `session` -> `id`
--   `answered`
--       `chat_message` -> `id`
--   `sender`
--       `user` -> `id`
--

-- --------------------------------------------------------

--
-- Table structure for table `friend_request`
--

CREATE TABLE `friend_request` (
  `id` int(11) NOT NULL,
  `sender` int(11) NOT NULL,
  `receiver` int(11) NOT NULL,
  `send_date` date NOT NULL,
  `request_status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `friend_request`:
--   `request_status`
--       `friend_request_status` -> `id`
--   `receiver`
--       `user` -> `id`
--   `sender`
--       `user` -> `id`
--

-- --------------------------------------------------------

--
-- Table structure for table `friend_request_status`
--

CREATE TABLE `friend_request_status` (
  `id` int(11) NOT NULL,
  `status` text NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `friend_request_status`:
--

-- --------------------------------------------------------

--
-- Table structure for table `game`
--

CREATE TABLE `game` (
  `id` int(11) NOT NULL,
  `creator_user` int(11) NOT NULL,
  `game_visibility` int(11) NOT NULL,
  `age_restricted` int(11) NOT NULL,
  `age_restriction` int(11) NOT NULL,
  `game_preview` text NOT NULL,
  `game_assets_token` text NOT NULL,
  `game_script` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `game`:
--   `age_restriction`
--       `age_restriction` -> `id`
--   `creator_user`
--       `user` -> `id`
--   `game_visibility`
--       `game_visibility` -> `id`
--

-- --------------------------------------------------------

--
-- Table structure for table `game_issue`
--

CREATE TABLE `game_issue` (
  `id` int(11) NOT NULL,
  `fixed` int(11) NOT NULL,
  `detection_date` date NOT NULL,
  `issue_name` text NOT NULL,
  `issue_details` text NOT NULL,
  `game_version_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `game_issue`:
--   `game_version_id`
--       `game_version` -> `id`
--

-- --------------------------------------------------------

--
-- Table structure for table `game_public_profile`
--

CREATE TABLE `game_public_profile` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL,
  `description` text NOT NULL,
  `share_date` date DEFAULT NULL,
  `last_modified_date` date DEFAULT NULL,
  `assets_token` text NOT NULL,
  `num_of_views` int(11) NOT NULL,
  `num_of_stars` int(11) NOT NULL,
  `num_of_reviews` int(11) NOT NULL,
  `last_version` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `game_public_profile`:
--   `last_version`
--       `game_version` -> `id`
--

-- --------------------------------------------------------

--
-- Table structure for table `game_version`
--

CREATE TABLE `game_version` (
  `id` int(11) NOT NULL,
  `game_id` int(11) NOT NULL,
  `public_profile_id` int(11) NOT NULL,
  `version_name` text NOT NULL,
  `change_log` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `game_version`:
--   `game_id`
--       `game` -> `id`
--   `public_profile_id`
--       `game_public_profile` -> `id`
--

-- --------------------------------------------------------

--
-- Table structure for table `game_visibility`
--

CREATE TABLE `game_visibility` (
  `id` int(11) NOT NULL,
  `visibility` text NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `game_visibility`:
--

-- --------------------------------------------------------

--
-- Table structure for table `invoice`
--

CREATE TABLE `invoice` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `creation_date` date NOT NULL,
  `total` int(11) NOT NULL,
  `completed` int(11) NOT NULL,
  `subscription_tier` int(11) NOT NULL,
  `subscription_type` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `invoice`:
--   `user_id`
--       `user` -> `id`
--

-- --------------------------------------------------------

--
-- Table structure for table `login_status`
--

CREATE TABLE `login_status` (
  `id` int(11) NOT NULL,
  `status` text NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `login_status`:
--

-- --------------------------------------------------------

--
-- Table structure for table `session`
--

CREATE TABLE `session` (
  `id` int(11) NOT NULL,
  `host_user` int(11) NOT NULL,
  `game` int(11) NOT NULL,
  `session_join_token` text NOT NULL,
  `session_start` date NOT NULL,
  `session_ended` int(11) NOT NULL,
  `session_visibility` int(11) NOT NULL,
  `winner_user` int(11) NOT NULL,
  `session_assets_token` text NOT NULL,
  `session_end` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `session`:
--   `host_user`
--       `user` -> `id`
--   `game`
--       `game` -> `id`
--   `session_visibility`
--       `session_visibility` -> `id`
--   `winner_user`
--       `user` -> `id`
--

-- --------------------------------------------------------

--
-- Table structure for table `session_connection`
--

CREATE TABLE `session_connection` (
  `id` int(11) NOT NULL,
  `session` int(11) NOT NULL,
  `user` int(11) NOT NULL,
  `connection_date` date NOT NULL,
  `connection_status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `session_connection`:
--   `session`
--       `session` -> `id`
--   `user`
--       `user` -> `id`
--

-- --------------------------------------------------------

--
-- Table structure for table `session_visibility`
--

CREATE TABLE `session_visibility` (
  `id` int(11) NOT NULL,
  `visibility` text NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `session_visibility`:
--

-- --------------------------------------------------------

--
-- Table structure for table `two_factor_type`
--

CREATE TABLE `two_factor_type` (
  `id` int(11) NOT NULL,
  `type` text NOT NULL,
  `description` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `two_factor_type`:
--

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `Hashed_password` text NOT NULL,
  `salt` text NOT NULL,
  `use_two_factor` int(11) NOT NULL,
  `two_factor_type` int(11) DEFAULT NULL,
  `two_factor_token` text DEFAULT NULL,
  `email_address` text NOT NULL,
  `phone_number` text DEFAULT NULL,
  `birth_date` date NOT NULL,
  `subscription_tier` int(11) NOT NULL,
  `subscription_type` int(11) DEFAULT NULL,
  `subscription_token` text DEFAULT NULL,
  `first_subscription_date` date DEFAULT NULL,
  `last_subscription_date` date DEFAULT NULL,
  `first_name` text NOT NULL,
  `middle_name` text DEFAULT NULL,
  `last_name` text NOT NULL,
  `private_username` text NOT NULL,
  `public_username` text DEFAULT NULL,
  `invite_code` text DEFAULT NULL,
  `login_status` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `user`:
--   `login_status`
--       `login_status` -> `id`
--   `two_factor_type`
--       `two_factor_type` -> `id`
--

-- --------------------------------------------------------

--
-- Table structure for table `user_favourite`
--

CREATE TABLE `user_favourite` (
  `id` int(11) NOT NULL,
  `game_public_profile_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `became_favourite` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `user_favourite`:
--   `game_public_profile_id`
--       `game_public_profile` -> `id`
--

-- --------------------------------------------------------

--
-- Table structure for table `user_friend`
--

CREATE TABLE `user_friend` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `friend_id` int(11) NOT NULL,
  `friended` date NOT NULL,
  `nickname` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELATIONSHIPS FOR TABLE `user_friend`:
--   `friend_id`
--       `user` -> `id`
--   `user_id`
--       `user` -> `id`
--

--
-- Indexes for dumped tables
--

--
-- Indexes for table `age_restriction`
--
ALTER TABLE `age_restriction`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `chat_message`
--
ALTER TABLE `chat_message`
  ADD PRIMARY KEY (`id`),
  ADD KEY `message_sender` (`sender`),
  ADD KEY `chat` (`session`),
  ADD KEY `message_answered` (`answered`);

--
-- Indexes for table `friend_request`
--
ALTER TABLE `friend_request`
  ADD PRIMARY KEY (`id`),
  ADD KEY `sender_user` (`sender`),
  ADD KEY `receiver_user` (`receiver`),
  ADD KEY `freind_request_status_connection` (`request_status`);

--
-- Indexes for table `friend_request_status`
--
ALTER TABLE `friend_request_status`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `game`
--
ALTER TABLE `game`
  ADD PRIMARY KEY (`id`),
  ADD KEY `game_visiblility_type` (`game_visibility`),
  ADD KEY `age_restriction_type` (`age_restriction`),
  ADD KEY `game_creator_connection` (`creator_user`);

--
-- Indexes for table `game_issue`
--
ALTER TABLE `game_issue`
  ADD PRIMARY KEY (`id`),
  ADD KEY `game_version_connection` (`game_version_id`);

--
-- Indexes for table `game_public_profile`
--
ALTER TABLE `game_public_profile`
  ADD PRIMARY KEY (`id`),
  ADD KEY `last_verson_of_game` (`last_version`);

--
-- Indexes for table `game_version`
--
ALTER TABLE `game_version`
  ADD PRIMARY KEY (`id`),
  ADD KEY `verson_of_game` (`game_id`),
  ADD KEY `verson_of_public_profile` (`public_profile_id`);

--
-- Indexes for table `game_visibility`
--
ALTER TABLE `game_visibility`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `invoice`
--
ALTER TABLE `invoice`
  ADD PRIMARY KEY (`id`),
  ADD KEY `invoice_user` (`user_id`);

--
-- Indexes for table `login_status`
--
ALTER TABLE `login_status`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `session`
--
ALTER TABLE `session`
  ADD PRIMARY KEY (`id`),
  ADD KEY `host` (`host_user`),
  ADD KEY `session_visibility_type` (`session_visibility`),
  ADD KEY `session_game` (`game`),
  ADD KEY `session_winner` (`winner_user`);

--
-- Indexes for table `session_connection`
--
ALTER TABLE `session_connection`
  ADD PRIMARY KEY (`id`),
  ADD KEY `session_id` (`session`),
  ADD KEY `user_id` (`user`);

--
-- Indexes for table `session_visibility`
--
ALTER TABLE `session_visibility`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `two_factor_type`
--
ALTER TABLE `two_factor_type`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_two_factor` (`two_factor_type`),
  ADD KEY `user_login_status` (`login_status`);

--
-- Indexes for table `user_favourite`
--
ALTER TABLE `user_favourite`
  ADD PRIMARY KEY (`id`),
  ADD KEY `public_profile_id` (`game_public_profile_id`);

--
-- Indexes for table `user_friend`
--
ALTER TABLE `user_friend`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user_connection` (`user_id`),
  ADD KEY `friend_connection` (`friend_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `age_restriction`
--
ALTER TABLE `age_restriction`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `chat_message`
--
ALTER TABLE `chat_message`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `friend_request`
--
ALTER TABLE `friend_request`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `friend_request_status`
--
ALTER TABLE `friend_request_status`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `game`
--
ALTER TABLE `game`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `game_issue`
--
ALTER TABLE `game_issue`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `game_public_profile`
--
ALTER TABLE `game_public_profile`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `game_version`
--
ALTER TABLE `game_version`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `game_visibility`
--
ALTER TABLE `game_visibility`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `invoice`
--
ALTER TABLE `invoice`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `login_status`
--
ALTER TABLE `login_status`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `session`
--
ALTER TABLE `session`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `session_connection`
--
ALTER TABLE `session_connection`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `session_visibility`
--
ALTER TABLE `session_visibility`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `two_factor_type`
--
ALTER TABLE `two_factor_type`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user_favourite`
--
ALTER TABLE `user_favourite`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `user_friend`
--
ALTER TABLE `user_friend`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `chat_message`
--
ALTER TABLE `chat_message`
  ADD CONSTRAINT `answered_message` FOREIGN KEY (`answered`) REFERENCES `chat_message` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `chat` FOREIGN KEY (`session`) REFERENCES `session` (`id`),
  ADD CONSTRAINT `message_answered` FOREIGN KEY (`answered`) REFERENCES `chat_message` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `message_sender` FOREIGN KEY (`sender`) REFERENCES `user` (`id`);

--
-- Constraints for table `friend_request`
--
ALTER TABLE `friend_request`
  ADD CONSTRAINT `freind_request_status_connection` FOREIGN KEY (`request_status`) REFERENCES `friend_request_status` (`id`),
  ADD CONSTRAINT `receiver_user` FOREIGN KEY (`receiver`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `sender_user` FOREIGN KEY (`sender`) REFERENCES `user` (`id`);

--
-- Constraints for table `game`
--
ALTER TABLE `game`
  ADD CONSTRAINT `age_restriction_type` FOREIGN KEY (`age_restriction`) REFERENCES `age_restriction` (`id`),
  ADD CONSTRAINT `game_creator_connection` FOREIGN KEY (`creator_user`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `game_visiblility_type` FOREIGN KEY (`game_visibility`) REFERENCES `game_visibility` (`id`);

--
-- Constraints for table `game_issue`
--
ALTER TABLE `game_issue`
  ADD CONSTRAINT `game_version_connection` FOREIGN KEY (`game_version_id`) REFERENCES `game_version` (`id`);

--
-- Constraints for table `game_public_profile`
--
ALTER TABLE `game_public_profile`
  ADD CONSTRAINT `last_verson_of_game` FOREIGN KEY (`last_version`) REFERENCES `game_version` (`id`);

--
-- Constraints for table `game_version`
--
ALTER TABLE `game_version`
  ADD CONSTRAINT `verson_of_game` FOREIGN KEY (`game_id`) REFERENCES `game` (`id`),
  ADD CONSTRAINT `verson_of_public_profile` FOREIGN KEY (`public_profile_id`) REFERENCES `game_public_profile` (`id`);

--
-- Constraints for table `invoice`
--
ALTER TABLE `invoice`
  ADD CONSTRAINT `invoice_user` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);

--
-- Constraints for table `session`
--
ALTER TABLE `session`
  ADD CONSTRAINT `host` FOREIGN KEY (`host_user`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `session_game` FOREIGN KEY (`game`) REFERENCES `game` (`id`),
  ADD CONSTRAINT `session_visibility_type` FOREIGN KEY (`session_visibility`) REFERENCES `session_visibility` (`id`),
  ADD CONSTRAINT `session_winner` FOREIGN KEY (`winner_user`) REFERENCES `user` (`id`);

--
-- Constraints for table `session_connection`
--
ALTER TABLE `session_connection`
  ADD CONSTRAINT `session_id` FOREIGN KEY (`session`) REFERENCES `session` (`id`),
  ADD CONSTRAINT `user_id` FOREIGN KEY (`user`) REFERENCES `user` (`id`);

--
-- Constraints for table `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `user_login_status` FOREIGN KEY (`login_status`) REFERENCES `login_status` (`id`),
  ADD CONSTRAINT `user_two_factor` FOREIGN KEY (`two_factor_type`) REFERENCES `two_factor_type` (`id`) ON DELETE SET NULL;

--
-- Constraints for table `user_favourite`
--
ALTER TABLE `user_favourite`
  ADD CONSTRAINT `public_profile_id` FOREIGN KEY (`game_public_profile_id`) REFERENCES `game_public_profile` (`id`);

--
-- Constraints for table `user_friend`
--
ALTER TABLE `user_friend`
  ADD CONSTRAINT `friend_connection` FOREIGN KEY (`friend_id`) REFERENCES `user` (`id`),
  ADD CONSTRAINT `user_connection` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
