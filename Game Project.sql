-- Game Project

DROP DATABASE IF EXISTS gameDB;

CREATE DATABASE gameDB;

USE gameDB;

DROP USER if exists 'gameClient'@'localhost';

CREATE USER 'gameClient'@'localhost' IDENTIFIED BY '54321';
GRANT ALL ON gameDB.* TO 'gameClient'@'localhost';

DELIMITER //
DROP PROCEDURE IF EXISTS DDL_PROCEDURE//
CREATE PROCEDURE DDL_PROCEDURE()
BEGIN
	DROP TABLE IF EXISTS Game;
    CREATE TABLE Game(
						game_id INT AUTO_INCREMENT PRIMARY KEY,
						`code` VARCHAR(4) NOT NULL
	);
    
    DROP TABLE IF EXISTS `Account`;
    CREATE TABLE `Account`(
						account_id INT AUTO_INCREMENT PRIMARY KEY,
						username VARCHAR(100) NOT NULL,
                        email VARCHAR(100) NOT NULL,
                        password_hash VARCHAR(255) NOT NULL,
                        login_attempts INT NOT NULL,
                        locked_out BIT NOT NULL,
                        logged_in BIT NOT NULL
	);
    
    DROP TABLE IF EXISTS Map;
    CREATE TABLE Map(
						map_id INT AUTO_INCREMENT PRIMARY KEY,
                        game_id INT NOT NULL,
                        FOREIGN KEY (game_id) REFERENCES Game(game_id)
	);
    DROP TABLE IF EXISTS Tile;
    CREATE TABLE Tile(
						tile_id INT AUTO_INCREMENT PRIMARY KEY,
                        col INT NOT NULL,
                        `row` INT NOT NULL,
                        map_id INT NOT NULL,
                        FOREIGN KEY (map_id) REFERENCES Map(map_id)
	);
    
    DROP TABLE IF EXISTS EndTile;
    CREATE TABLE EndTile(
						tile_id INT PRIMARY KEY,
                        FOREIGN KEY (tile_id) REFERENCES Tile(tile_id)
	);
    
    DROP TABLE IF EXISTS HomeTile;
    CREATE TABLE HomeTile(
						tile_id INT PRIMARY KEY,
                        FOREIGN KEY (tile_id) REFERENCES Tile(tile_id)
	);
    
    DROP TABLE IF EXISTS MoveTile;
    CREATE TABLE MoveTile(
						tile_id INT PRIMARY KEY,
                        next_tile_id INT NOT NULL,
                        FOREIGN KEY (tile_id) REFERENCES Tile(tile_id),
                        FOREIGN KEY (next_tile_id) REFERENCES Tile(tile_id)
	);
    
    DROP TABLE IF EXISTS Player;
    CREATE TABLE Player(
						player_id INT AUTO_INCREMENT PRIMARY KEY,
						game_id INT NOT NULL,
                        display_name VARCHAR(100)  NOT NULL,
                        tile_id INT NOT NULL,
                        account_id INT NOT NULL,
                        FOREIGN KEY (game_id) REFERENCES Game(game_id),
                        FOREIGN KEY (tile_id) REFERENCES Tile(tile_id),
                        FOREIGN KEY (account_id) REFERENCES `Account`(account_id)
	);
    
    DROP TABLE IF EXISTS PlayerState;
    CREATE TABLE PlayerState(
						state_id INT AUTO_INCREMENT PRIMARY KEY,
                        player_id INT NOT NULL,
                        playing BIT NOT NULL,
                        FOREIGN KEY (player_id) REFERENCES Player(player_id)
	);
    
    DROP TABLE IF EXISTS ChatRoom;
    CREATE TABLE ChatRoom(
						chat_room_id INT AUTO_INCREMENT PRIMARY KEY,
						game_id INT NOT NULL,
                        FOREIGN KEY (game_id) REFERENCES Game(game_id)
	);
    
    DROP TABLE IF EXISTS Chat;
    CREATE TABLE Chat(
						chat_id INT AUTO_INCREMENT PRIMARY KEY,
						chat_room_id INT NOT NULL,
                        `text` VARCHAR(255) NOT NULL,
                        player_id INT NOT NULL,
                        time_sent TIMESTAMP NOT NULL,
                        FOREIGN KEY (player_id) REFERENCES Player(player_id)
	);
    
    DROP TABLE IF EXISTS AdminAccount;
    CREATE TABLE AdminAccount(
						account_id INT PRIMARY KEY,
                        FOREIGN KEY (account_id) REFERENCES `Account`(account_id)
	);
    
    DROP TABLE IF EXISTS Inventory;
    CREATE TABLE Inventory(
						inventory_id INT AUTO_INCREMENT PRIMARY KEY,
                        max_items INT NOT NULL,
                        player_id INT NOT NULL,
                        FOREIGN KEY (player_id) REFERENCES Player(player_id)
    );
    
    DROP TABLE IF EXISTS ItemType;
    CREATE TABLE ItemType(
						item_id INT AUTO_INCREMENT PRIMARY KEY,
						`name` VARCHAR(255) NOT NULL
	);
    
    DROP TABLE IF EXISTS ItemTile;
    CREATE TABLE ItemTile(
						tile_id INT AUTO_INCREMENT PRIMARY KEY,
                        item_id INT NOT NULL,
                        FOREIGN KEY (item_id) REFERENCES ItemType(item_id)
	);
    
    DROP TABLE IF EXISTS InventoryItem;
    CREATE TABLE InventoryItem(
						item_id INT NOT NULL,
						inventory_id INT NOT NULL,
                        quantity INT NOT NULL,
                        PRIMARY KEY(item_id, inventory_id),
                        FOREIGN KEY (item_id) REFERENCES ItemType(item_id),
                        FOREIGN KEY (inventory_id) REFERENCES Inventory(inventory_id)
	);
    
    DROP TABLE IF EXISTS PlayerEffect;
    CREATE TABLE PlayerEffect(
						item_id INT PRIMARY KEY,
						roll_multiplier INT NOT NULL,
                        FOREIGN KEY (item_id) REFERENCES ItemType(item_id)
	);
    
    DROP TABLE IF EXISTS PlayerBoost;
    CREATE TABLE PlayerBoost(
						item_id INT AUTO_INCREMENT PRIMARY KEY,
						tile_id INT NOT NULL,
                        FOREIGN KEY (item_id) REFERENCES ItemType(item_id),
                        FOREIGN KEY (tile_id) REFERENCES Tile(tile_id)
	);
    
    DROP TABLE IF EXISTS Dice;
    CREATE TABLE Dice(
						dice_id INT AUTO_INCREMENT PRIMARY KEY,
						last_roll INT NOT NULL,
                        player_id INT NOT NULL,
                        FOREIGN KEY (player_id) REFERENCES Player(player_id)
	);
    
    INSERT INTO Game VALUES
    (1, "ABCD");
    
    INSERT INTO `Account` VALUES
    (1, "ollie-moss", "ollie@gmail.com", "BTut0sw3Gk7sztkXROYlJw", 1, 0, 1),
    (2, "john-ross", "john@gmail.com", "i4TYGZGJ7FItXNS6MY0tEg", 1, 0, 1),
    (3, "james-smith", "james@gmail.com", "6aWhfem9hj+L7QmBHcGKWg", 1, 0, 1),
    (4, "admin-person", "admin@gmail.com", "suv+ewq4KasfdxDRlsNJxg", 1, 0, 1);
    
    INSERT INTO Map VALUES
    (1, 1);
    
    INSERT INTO Tile VALUES
    (1, 0, 0, 1),
    (2, 1, 0, 1),
    (3, 1, 1, 1),
    (4, 0, 1, 1);
    
    INSERT INTO EndTile VALUES
    (4);
    
    INSERT INTO HomeTile VALUES
    (1);
    
    INSERT INTO MoveTile VALUES
    (2, 3);
    
    INSERT INTO Player VALUES
    (1, 1, "Ollie", 1, 1),
    (2, 1, "John", 1, 2),
    (3, 1, "James", 1, 3);
    
    INSERT INTO PlayerState VALUES
    (1, 1, 1),
    (2, 2, 1),
    (3, 3, 1);
    
    INSERT INTO ChatRoom VALUES
    (1, 1);
    
    INSERT INTO Chat VALUES
    (1, 1, "Hello from Ollie", 1, CURRENT_TIMESTAMP()),
    (2, 1, "Hello from John", 2, CURRENT_TIMESTAMP()),
    (3, 1, "Hello from James", 3, CURRENT_TIMESTAMP());
    
    INSERT INTO AdminAccount VALUES
    (4);
    
    INSERT INTO Inventory VALUES
    (1, 10, 1),
    (2, 10, 2),
    (3, 10, 3);
    
    INSERT INTO ItemType VALUES
    (1, "0.2x Roll Multiplier"),
    (2, "2x Roll Multiplier"),
    (3, "Boost to End Tile");
    
    INSERT INTO InventoryItem VALUES
    (1, 1, 3),
    (2, 2, 2),
    (3, 3, 3);
    
    INSERT INTO PlayerBoost VALUES
    (3, 4);
    
    INSERT INTO PlayerEffect VALUES
    (1, 0.2),
    (2, 2);
    
    INSERT INTO ItemTile VALUES
    (3, 2);
    
    INSERT INTO Dice VALUES
    (1, 1, 1),
    (2, 1, 2),
    (3, 1, 3);
    
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS LOGIN_TEST//
CREATE PROCEDURE LOGIN_TEST()
BEGIN
	SELECT 'LOGIN TEST' AS MESSAGE;
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS GAMEPLAY_TEST//
CREATE PROCEDURE GAMEPLAY_TEST()
BEGIN
	SELECT 'GAMEPLAY TEST' AS MESSAGE;
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS ADMIN_TEST//
CREATE PROCEDURE ADMIN_TEST()
BEGIN
	SELECT 'ADMIN TEST' AS MESSAGE;
END//
DELIMITER ;

CALL DDL_PROCEDURE()
