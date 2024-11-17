-- Game Project 
SET GLOBAL max_sp_recursion_depth = 10000;
DROP DATABASE IF EXISTS gameDB;

CREATE DATABASE gameDB;

USE gameDB;

DROP USER if exists 'gameClient'@'localhost';


CREATE USER 'gameClient'@'localhost' IDENTIFIED BY '54321';
GRANT ALL ON gameDB.* TO 'gameClient'@'localhost';


DELIMITER //
DROP FUNCTION IF EXISTS ErrorCode//
CREATE FUNCTION ErrorCode(name ENUM("OK", "ERROR"))
RETURNS INT DETERMINISTIC
RETURN name + 1000//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS DDL_PROCEDURE//
CREATE PROCEDURE DDL_PROCEDURE()
BEGIN
	DROP TABLE IF EXISTS Game;
    CREATE TABLE Game(
						game_id INT AUTO_INCREMENT PRIMARY KEY,
						`code` VARCHAR(4) UNIQUE NOT NULL
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
                        FOREIGN KEY (game_id) REFERENCES Game(game_id) ON DELETE CASCADE
	);
    DROP TABLE IF EXISTS Tile;
    CREATE TABLE Tile(
						tile_id INT AUTO_INCREMENT PRIMARY KEY,
						next_tile_id INT,
                        prev_tile_id INT,
                        map_id INT NOT NULL,
                        FOREIGN KEY (map_id) REFERENCES Map(map_id) ON DELETE CASCADE, 
                        FOREIGN KEY (next_tile_id) REFERENCES Tile(tile_id) ON DELETE SET NULL,
                        FOREIGN KEY (prev_tile_id) REFERENCES Tile(tile_id) ON DELETE SET NULL 
	);
    
    DROP TABLE IF EXISTS EndTile;
    CREATE TABLE EndTile(
						tile_id INT PRIMARY KEY,
                        FOREIGN KEY (tile_id) REFERENCES Tile(tile_id) ON DELETE CASCADE
	);
    
    DROP TABLE IF EXISTS HomeTile;
    CREATE TABLE HomeTile(
						tile_id INT PRIMARY KEY,
                        FOREIGN KEY (tile_id) REFERENCES Tile(tile_id) ON DELETE CASCADE
	);
    
    DROP TABLE IF EXISTS MoveTile;
    CREATE TABLE MoveTile(
						tile_id INT PRIMARY KEY,
                        distance INT NOT NULL,
                        FOREIGN KEY (tile_id) REFERENCES Tile(tile_id) ON DELETE CASCADE
	);
    
    DROP TABLE IF EXISTS Player;
    CREATE TABLE Player(
						player_id INT AUTO_INCREMENT PRIMARY KEY,
						game_id INT NOT NULL,
                        display_name VARCHAR(100)  NOT NULL,
                        tile_id INT DEFAULT 1,
                        account_id INT NOT NULL,
                        FOREIGN KEY (game_id) REFERENCES Game(game_id) ON DELETE CASCADE,
                        FOREIGN KEY (tile_id) REFERENCES Tile(tile_id) ON DELETE SET NULL,
                        FOREIGN KEY (account_id) REFERENCES `Account`(account_id) ON DELETE CASCADE
	);
    DROP TABLE IF EXISTS GameState;
    CREATE TABLE GameState(
						state_id INT AUTO_INCREMENT PRIMARY KEY,
                        game_id INT,
                        player_id INT,
                        FOREIGN KEY (player_id) REFERENCES Player(player_id) ON DELETE CASCADE,
                        FOREIGN KEY (game_id) REFERENCES Game(game_id) ON DELETE CASCADE
	);
    
    DROP TABLE IF EXISTS PlayerState;
    CREATE TABLE PlayerState(
						state_id INT AUTO_INCREMENT PRIMARY KEY,
                        player_id INT NOT NULL,
                        roll_multiplier FLOAT NOT NULL DEFAULT 1.0,
                        FOREIGN KEY (player_id) REFERENCES Player(player_id) ON DELETE CASCADE
	);
    
    DROP TABLE IF EXISTS ChatRoom;
    CREATE TABLE ChatRoom(
						chat_room_id INT AUTO_INCREMENT PRIMARY KEY,
						game_id INT NOT NULL,
                        FOREIGN KEY (game_id) REFERENCES Game(game_id) ON DELETE CASCADE
	);
    
    DROP TABLE IF EXISTS Chat;
    CREATE TABLE Chat(
						chat_id INT AUTO_INCREMENT PRIMARY KEY,
						chat_room_id INT NOT NULL,
                        `text` VARCHAR(255) NOT NULL,
                        player_id INT NOT NULL,
                        time_sent TIMESTAMP NOT NULL,
                        FOREIGN KEY (player_id) REFERENCES Player(player_id) ON DELETE CASCADE
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
                        FOREIGN KEY (player_id) REFERENCES Player(player_id) ON DELETE CASCADE
    );
    
    DROP TABLE IF EXISTS ItemType;
    CREATE TABLE ItemType(
						item_id INT AUTO_INCREMENT PRIMARY KEY,
						`name` VARCHAR(255) NOT NULL
	);
    
    DROP TABLE IF EXISTS ItemTile;
    CREATE TABLE ItemTile(
						tile_id INT PRIMARY KEY,
                        item_id INT NOT NULL,
                        FOREIGN KEY (item_id) REFERENCES ItemType(item_id) ON DELETE CASCADE,
                        FOREIGN KEY (tile_id) REFERENCES Tile(tile_id) ON DELETE CASCADE
	);
    
    DROP TABLE IF EXISTS InventoryItem;
    CREATE TABLE InventoryItem(
						item_id INT NOT NULL,
						inventory_id INT NOT NULL,
                        quantity INT NOT NULL,
                        PRIMARY KEY(item_id, inventory_id),
                        FOREIGN KEY (item_id) REFERENCES ItemType(item_id) ON DELETE CASCADE,
                        FOREIGN KEY (inventory_id) REFERENCES Inventory(inventory_id) ON DELETE CASCADE
	);
    
    DROP TABLE IF EXISTS PlayerEffect;
    CREATE TABLE PlayerEffect(
						item_id INT PRIMARY KEY,
						roll_multiplier FLOAT NOT NULL,
                        FOREIGN KEY (item_id) REFERENCES ItemType(item_id) ON DELETE CASCADE
	);
    
    DROP TABLE IF EXISTS PlayerBoost;
    CREATE TABLE PlayerBoost(
						item_id INT AUTO_INCREMENT PRIMARY KEY,
						`distance` INT NOT NULL,
                        FOREIGN KEY (item_id) REFERENCES ItemType(item_id) ON DELETE CASCADE
	);
    
    DROP TABLE IF EXISTS Dice;
    CREATE TABLE Dice(
						dice_id INT AUTO_INCREMENT PRIMARY KEY,
						last_roll VARCHAR(100) NOT NULL,
                        player_id INT NOT NULL,
                        FOREIGN KEY (player_id) REFERENCES Player(player_id) ON DELETE CASCADE
	);
    
    
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS CREATE_TEST_DATA//
CREATE PROCEDURE CREATE_TEST_DATA()
BEGIN
    INSERT INTO Game VALUES
    (1, "ABCD");
    
    INSERT INTO `Account` VALUES
    (1, "ollie-moss", "ollie@gmail.com", "BA7816BF8F01CFEA414140DE5DAE2223B00361A396177A9CB410FF61F20015AD", 1, 0, 1),
    (2, "john-ross", "john@gmail.com", "i4TYGZGJ7FItXNS6MY0tEg", 1, 0, 1),
    (3, "james-smith", "james@gmail.com", "6aWhfem9hj+L7QmBHcGKWg", 1, 0, 1),
    (4, "admin-person", "admin@gmail.com", "suv+ewq4KasfdxDRlsNJxg", 1, 0, 1);
    
    INSERT INTO Map VALUES
    (1, 1);
    
    INSERT INTO Tile VALUES
    (4, NULL, 1),
    (3, 4, 1),
    (2, 3, 1),
    (1, 2, 1);

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
    
    INSERT INTO ItemType (name) VALUES
    ("0.2x Roll Multiplier"),
    ("0.5x Roll Multiplier"),
    ("2x Roll Multiplier"),
    ("1.5x Roll Multiplier"),
    ("4 Tile Boost"),
    ("2 Tile Setback");
    
    INSERT INTO InventoryItem VALUES
    (1, 1, 3),
    (2, 2, 2),
    (3, 3, 3);
    
    INSERT INTO PlayerBoost VALUES
    (5, 4),
    (6, -2);
    
    INSERT INTO PlayerEffect VALUES
    (1, 0.2),
    (2, 0.5),
    (3, 2),
    (4, 1.5);
    
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

-- Send required data to client to render gamestate
DELIMITER //
DROP PROCEDURE IF EXISTS RENDER//
CREATE PROCEDURE RENDER(IN game_id INT)
BEGIN
	SELECT tile_id FROM Tile t
    WHERE t.map_id IN (SELECT m.map_id FROM Map m, Game g WHERE g.game_id = m.map_id);
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS GetActiveGames//
CREATE PROCEDURE GetActiveGames()
BEGIN
    SELECT g.game_id, g.code, COUNT(p.player_id) AS num_of_players FROM Game g
    JOIN Player p
    ON p.game_id = g.game_id
    GROUP BY g.game_id;
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS GetPlayerPosition//
CREATE PROCEDURE GetPlayerPosition(IN pPlayerId INT)
BEGIN
    SELECT p.tile_id FROM Player p
    WHERE p.player_id = pPlayerId;
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS GetAllTiles//
CREATE PROCEDURE GetAllTiles(IN pPlayerId INT)
BEGIN
	SELECT t.tile_id FROM Tile t
    JOIN Map m
    ON m.map_id = t.map_id
    JOIN Game g
    ON m.game_id = g.game_id
    JOIN Player p 
    ON p.game_id = g.game_id
    WHERE p.player_id = pPlayerId; 
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS GetMoveTiles//
CREATE PROCEDURE GetMoveTiles(IN pPlayerId INT)
BEGIN
	SELECT t.tile_id, mt.distance FROM Tile t
    JOIN MoveTile mt
    ON mt.tile_id = t.tile_id
    JOIN Map m
    ON m.map_id = t.map_id
    JOIN Game g
    ON m.game_id = g.game_id
    JOIN Player p 
    ON p.game_id = g.game_id
    WHERE p.player_id = pPlayerId; 
END//
DELIMITER ;
DELIMITER //
DROP PROCEDURE IF EXISTS GetItemTiles//
CREATE PROCEDURE GetItemTiles(IN pPlayerId INT)
BEGIN
	SELECT t.tile_id, it.item_id, i.name FROM Tile t
    JOIN ItemTile it
    ON it.tile_id = t.tile_id
    JOIN ItemType i
    ON i.item_id = it.item_id
    JOIN Map m
    ON m.map_id = t.map_id
    JOIN Game g
    ON m.game_id = g.game_id
    JOIN Player p 
    ON p.game_id = g.game_id
    WHERE p.player_id = pPlayerId; 
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS GetLastRoll//
CREATE PROCEDURE GetLastRoll(IN pPlayerId INT)
BEGIN
	SELECT last_roll FROM Dice 
    WHERE player_id = pPlayerId; 
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS GetAllPlayers//
CREATE PROCEDURE GetAllPlayers()
BEGIN
	SELECT g.`code`, p.player_id, p.display_name, p.tile_id FROM Player p
    JOIN Game g
    ON p.game_id = g.game_id;
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS GetPlayersInGame//
CREATE PROCEDURE GetPlayersInGame(IN pPlayerId INT)
BEGIN
	SELECT pp.player_id, pp.display_name, pp.tile_id FROM Player p
    JOIN Game g
    ON p.game_id = g.game_id
    JOIN Player pp
    ON pp.game_id = g.game_id
    WHERE p.player_id = pPlayerId; 
END//
DELIMITER ;

-- Create an account based on username, password, and email
DELIMITER //
DROP PROCEDURE IF EXISTS Register//
CREATE PROCEDURE Register(IN iUsername VARCHAR(100), IN iEmail VARCHAR(100), IN iPassword_hash VARCHAR(255))
BEGIN
	IF EXISTS (	SELECT * 
					FROM `Account` 
                    WHERE username = iUsername
				)
    THEN
		SELECT "Username is already in use" AS MESSAGE, ErrorCode("ERROR") AS STATUS;
    ELSE
		INSERT INTO `Account`  (username, email, password_hash, login_attempts, locked_out, logged_in)
		VALUES (iUsername, iEmail, iPassword_hash, 0, 0, 0);
        SELECT "Success" AS MESSAGE, LAST_INSERT_ID() AS DATA, ErrorCode("OK") AS STATUS;
	END IF;
END//
DELIMITER ;

-- Login player based on username and password
DELIMITER //
DROP PROCEDURE IF EXISTS Login//
CREATE PROCEDURE Login(IN iUsername VARCHAR(100), IN iPassword_hash VARCHAR(255))
BEGIN
	DECLARE MAX_LOGIN_ATTEMPTS INT DEFAULT 3;
    START TRANSACTION;
	IF EXISTS (	SELECT *
					FROM `Account` 
                    WHERE username = iUsername
                    AND password_hash = iPassword_hash
				)
    THEN
		IF EXISTS (	SELECT *
					FROM `Account` 
                    WHERE login_attempts < MAX_LOGIN_ATTEMPTS + 1
                    AND username = iUsername
				)
		THEN
			UPDATE `Account` SET login_attempts = 0 WHERE username = iUsername;
            SELECT "Logged In" AS MESSAGE, 
                    ErrorCode("OK") AS STATUS, 
                    account_id as DATA FROM `Account` WHERE username = iUsername;
        ELSE
			SELECT "Account is locked" AS MESSAGE, ErrorCode("ERROR") AS STATUS;
        END IF;
    ELSE
		IF EXISTS (	SELECT *
					FROM `Account` 
                    WHERE username = iUsername
				)
		THEN
			UPDATE `Account` SET login_attempts = login_attempts + 1 WHERE username = iUsername;
        END IF;
		SELECT "Incorrect username or password" AS MESSAGE, ErrorCode("ERROR") AS STATUS;
	END IF;
    COMMIT;
END//
DELIMITER ;

-- Delete Account
DELIMITER //
DROP PROCEDURE IF EXISTS DeleteAccount//
CREATE PROCEDURE DeleteAccount(IN pAccount_id INT)
BEGIN
	START TRANSACTION;
    IF EXISTS (SELECT * FROM Account WHERE account_id = pAccount_id)
    THEN
        DELETE FROM Account
        WHERE account_id = pAccount_id;
        SELECT 'Success' AS MESSAGE;
    ELSE
        SELECT 'Account with provided id does not exist!' AS MESSAGE;
    END IF;
    COMMIT;
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS EndGame//
CREATE PROCEDURE EndGame(IN pPlayer_id INT)
BEGIN
	START TRANSACTION;
	INSERT INTO GameState (game_id, player_id) VALUES ((SELECT game_id FROM Player WHERE player_id = pPlayer_id), pPlayer_id);
    COMMIT;
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS GetItems//
CREATE PROCEDURE GetItems(IN pPlayer_id INT)
BEGIN
	START TRANSACTION;
	SELECT it.item_id, it.`name`, ii.quantity FROM Inventory inv
    JOIN InventoryItem ii
    ON ii.inventory_id = inv.inventory_id
    JOIN ItemType it
    ON it.item_id = ii.item_id
    WHERE inv.player_id = pPlayer_id;
    COMMIT;
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS GetGameState//
CREATE PROCEDURE GetGameState(IN pPlayer_id INT)
BEGIN
	START TRANSACTION;
	IF EXISTS (SELECT * FROM GameState WHERE game_id IN (SELECT game_id FROM Player WHERE player_id = pPlayer_id))
    THEN
		SELECT ErrorCode("OK") AS STATUS, 1 AS completed;
	END IF;
    SELECT ErrorCode("OK") AS STATUS, 0 AS completed;
    COMMIT;
END//
DELIMITER ;

-- Move player a certain distance
DELIMITER //
DROP PROCEDURE IF EXISTS MovePlayer//
CREATE PROCEDURE MovePlayer(IN pPlayer_id INT, IN pDistance INT, IN pRecursed BOOL)
BEGIN
	START TRANSACTION;
    WITH RECURSIVE tiles AS (
    SELECT
        t.tile_id,
        t.next_tile_id,
        t.prev_tile_id,
        0 as distance
    FROM Player p
    JOIN Tile t ON t.tile_id = p.tile_id
    WHERE p.player_id = pPlayer_id
    UNION ALL
    SELECT
        t.tile_id,
        t.next_tile_id,
        t.prev_tile_id,
        ts.distance + 1
    FROM Tile t 
    JOIN tiles ts ON t.tile_id = ts.next_tile_id 
    WHERE ts.distance < pDistance AND NOT ts.next_tile_id IS NULL
    UNION ALL
    SELECT
        t.tile_id,
        t.next_tile_id,
        t.prev_tile_id,
        ts.distance - 1
    FROM Tile t 
    JOIN tiles ts ON t.tile_id = ts.prev_tile_id
    WHERE ts.distance > pDistance AND NOT ts.prev_tile_id IS NULL
    )
    SELECT tile_id FROM tiles WHERE distance =
        (CASE WHEN pDistance > 0 THEN (SELECT MAX(distance) FROM tiles)
		WHEN pDistance < 0 THEN (SELECT MIN(distance) FROM tiles)
		WHEN pDistance = 0 THEN 0
        END) INTO @tileId;


    IF EXISTS (SELECT * FROM Player WHERE tile_id = @tileId)
    AND NOT EXISTS (SELECT * FROM HomeTile WHERE tile_id = @tileId)
    THEN
		SELECT "A Player is already on that square, roll again!" AS move_error;
	ELSE
    UPDATE Player
		SET tile_id = @tileId
		WHERE player_id = pPlayer_id;
		
		IF EXISTS (SELECT * FROM EndTile WHERE tile_id = @tileId)
		THEN
			CALL EndGame(pPlayer_id);
		END IF;
		
		IF EXISTS (SELECT * FROM ItemTile WHERE tile_id = @tileId)
		THEN
			CALL PickUp(pPlayer_id);
		END IF;
		
		IF EXISTS (SELECT * FROM MoveTile WHERE tile_id = @tileId) AND pRecursed = FALSE
		THEN
			CALL MovePlayer(pPlayer_id, (SELECT distance FROM MoveTile WHERE tile_id = @tileId), TRUE);
		END IF;
        SELECT "Success" AS MESSAGE;
    END IF;
    COMMIT;
END //
DELIMITER ;

-- Generate random integer between 0 and 4 and move the player the generated distance
DELIMITER //
DROP PROCEDURE IF EXISTS Roll//
CREATE PROCEDURE Roll(IN pPlayer_id INT)
BEGIN
	START TRANSACTION;
    IF EXISTS (SELECT * FROM Player WHERE player_id = pPlayer_id)
    THEN
		-- Get Random Roll and multiply it by the current roll multiplier
        SELECT FLOOR(RAND()*4+1) INTO @RandomNumber;
        SELECT ROUND(
				@RandomNumber
				* (SELECT roll_multiplier 
                FROM PlayerState 
                WHERE player_id = pPlayer_id))
                INTO @Roll;
		-- Update last dice roll
        UPDATE Dice
        SET last_roll = CONCAT(@RandomNumber, " x ", ROUND((SELECT roll_multiplier 
                FROM PlayerState 
                WHERE player_id = pPlayer_id),1), " = ", @Roll, " (rounded)")
        WHERE player_id = pPlayer_id;
        
        -- Reset roll multiplier
        UPDATE PlayerState
        SET roll_multiplier = 1.0
        WHERE player_id = pPlayer_id;
        
        -- Move the player
        CALL MovePlayer(pPlayer_id, @Roll, FALSE);
    ELSE
        SELECT 'Not in a game!' AS MESSAGE;
    END IF;
    COMMIT;
END//
DELIMITER ;

-- Generate random map
DELIMITER //
DROP PROCEDURE IF EXISTS CreateMap//
CREATE PROCEDURE CreateMap(IN pNumberOfTiles INT, IN pGameId INT)
BEGIN
    DECLARE nullableInt INT DEFAULT NULL; 
    DECLARE mapId INT;
    DECLARE maxTileId INT;

    DECLARE ItemId INT;
    DECLARE NUM_OF_BOOST_TILES INT DEFAULT 10;
    DECLARE NUM_OF_BOOST_ITEMS INT DEFAULT 4;
    DECLARE NUM_OF_EFFECT_ITEMS INT DEFAULT 4;
    
    START TRANSACTION;

    INSERT INTO Map (game_id) VALUES (pGameId);
    SET mapId = LAST_INSERT_ID();
    SELECT MAX(tile_id) FROM Tile INTO maxTileId;
    IF (maxTileId IS NULL) THEN SET maxTileId = 0; END IF;
    
    INSERT INTO Tile (tile_id, next_tile_id, prev_tile_id, map_id)
	WITH RECURSIVE tiles AS (
        SELECT 
            maxTileId + pNumberOfTiles AS tile_id,
            nullableInt AS next_tile_id,
            nullableInt AS prev_tile_id,
            mapId AS map_id
        UNION ALL
        SELECT 
            tile_id - 1, 
            tile_id AS next_tile_id,
            nullableInt AS prev_tile_id,
            mapId AS map_id
        FROM tiles
        WHERE tile_id > 0 + maxTileId + 1
    )
    SELECT * FROM tiles;

    WITH RECURSIVE linkedTiles AS (
		SELECT 
			t.tile_id,
			nullableInt AS prev_tile_id,
			t.next_tile_id,
			t.map_id
		FROM Tile t
		WHERE t.tile_id = maxTileId + 1
		UNION ALL
		SELECT 
			lt.tile_id + 1, 
			lt.tile_id AS prev_tile_id,
			t.next_tile_id AS next_tile_id,
			lt.map_id AS map_id
		FROM linkedTiles lt
		JOIN Tile t ON t.tile_id = lt.tile_id + 1
		WHERE lt.tile_id < 0 + maxTileId + pNumberOfTiles
	)
	UPDATE Tile t 
    INNER JOIN linkedTiles lt ON t.tile_id = lt.tile_id
    SET t.prev_tile_id = lt.prev_tile_id;
    
    INSERT INTO EndTile (tile_id) VALUES (maxTileId+pNumberOfTiles);
    INSERT INTO HomeTile (tile_id) VALUES (maxTileId+1);
    
    REPEAT
	    SELECT FLOOR(RAND()*pNumberOfTiles+1)+maxTileId INTO @RandTileId;
        IF NOT EXISTS (SELECT * FROM MoveTile WHERE tile_id = @RandTileId)
        THEN
	        SELECT FLOOR(RAND()*7+1) INTO @MoveDistance;
            SELECT ROUND(RAND())*2-1 INTO @PositiveOrNegative;
            SET @MoveDistance = @MoveDistance * @PositiveOrNegative;
            INSERT INTO MoveTile (tile_id, distance) VALUES (@RandTileId, @MoveDistance);
            SET NUM_OF_BOOST_TILES = NUM_OF_BOOST_TILES - 1;
        END IF;
    UNTIL NUM_OF_BOOST_TILES < 1
    END REPEAT;

    REPEAT
	    SELECT FLOOR(RAND()*pNumberOfTiles+1)+maxTileId INTO @RandTileId;
        IF NOT EXISTS (SELECT * FROM ItemTile WHERE tile_id = @RandTileId)
        THEN
	        SELECT ROUND(RAND()*2, 1) INTO @Multiplier;

            INSERT INTO ItemType (name) VALUES (CONCAT(@Multiplier, 'x Roll Multiplier!'));
            
            SET ItemId = LAST_INSERT_ID();
            INSERT INTO ItemTile (tile_id, item_id) VALUES (@RandTileId, ItemId);
            INSERT INTO PlayerEffect (item_id, roll_multiplier) VALUES (ItemId, @Multiplier);
            SET NUM_OF_EFFECT_ITEMS = NUM_OF_EFFECT_ITEMS - 1;
        END IF;
    UNTIL NUM_OF_EFFECT_ITEMS < 1
    END REPEAT;

    REPEAT
	    SELECT FLOOR(RAND()*pNumberOfTiles+1)+maxTileId INTO @RandTileId;
        IF NOT EXISTS (SELECT * FROM ItemTile WHERE tile_id = @RandTileId)
        THEN
	        SELECT FLOOR(RAND()*7+1) INTO @MoveDistance;
            SELECT ROUND(RAND())*2-1 INTO @PositiveOrNegative;
            SET @MoveDistance = @MoveDistance * @PositiveOrNegative;
            IF (@MoveDistance > 0) 
            THEN
                INSERT INTO ItemType (name) VALUES (CONCAT(@MoveDistance, ' Tile Boost!'));
            ELSE
                INSERT INTO ItemType (name) VALUES (CONCAT(@MoveDistance, ' Tile Set Back!'));
            END IF;

            SET ItemId = LAST_INSERT_ID();
            INSERT INTO ItemTile (tile_id, item_id) VALUES (@RandTileId, ItemId);
            INSERT INTO PlayerBoost (item_id, distance) VALUES (ItemId, @MoveDistance);
            SET NUM_OF_BOOST_ITEMS = NUM_OF_BOOST_ITEMS - 1;
        END IF;
    UNTIL NUM_OF_BOOST_ITEMS < 1
    END REPEAT;
    COMMIT;
END//
DELIMITER ;


-- Create Game
DELIMITER //
DROP PROCEDURE IF EXISTS CreateGame//
CREATE PROCEDURE CreateGame(IN pCode VARCHAR(4), IN pMapSize INT)
BEGIN
    DECLARE game_id INT;
    START TRANSACTION;
    IF EXISTS (SELECT * FROM Game WHERE `code` = pCode)
    THEN
        SELECT 'Game with that code already exists!' AS MESSAGE,
                ErrorCode("ERROR") AS STATUS;
    ELSE
        INSERT INTO Game (`code`) VALUES (pCode);
        SET game_id = LAST_INSERT_ID();
        CALL CreateMap(pMapSize, game_id);
        INSERT INTO ChatRoom (game_id) VALUES (game_id);
        SELECT 'SUCCESS' AS MESSAGE,
                ErrorCode("OK") AS STATUS;
    END IF;
    COMMIT;
END//
DELIMITER ;

-- Kill Game
DELIMITER //
DROP PROCEDURE IF EXISTS KillGame//
CREATE PROCEDURE KillGame(IN pGame_id INT)
BEGIN
	START TRANSACTION;
    IF EXISTS (SELECT * FROM Game WHERE game_id = pGame_id)
    THEN
        DELETE FROM Game WHERE game_id = pGame_id;
        SELECT 'SUCCESS' AS MESSAGE;
    ELSE
        SELECT 'Game with id does not exist' AS MESSAGE;
    END IF;
    COMMIT;
END//
DELIMITER ;

-- Create Player 
DELIMITER //
DROP PROCEDURE IF EXISTS CreatePlayer//
CREATE PROCEDURE CreatePlayer(IN pCode VARCHAR(4), IN pDisplay_name VARCHAR(100), IN pAccount_id INT)
BEGIN
    DECLARE vGame_id INT;
    DECLARE vPlayer_id INT;
    START TRANSACTION;
    SELECT game_id FROM Game WHERE `code` = pCode INTO vGame_id;
    IF (vGame_id IS NULL) THEN
        SELECT 'Invalid code provided!' AS MESSAGE, ErrorCode("ERROR") AS STATUS;
    ELSE
        IF EXISTS (SELECT * FROM Account WHERE account_id = pAccount_id)
        THEN
            INSERT INTO Player (game_id, display_name, account_id) VALUES (vGame_id, pDisplay_name, pAccount_id);
            SELECT LAST_INSERT_ID() INTO vPlayer_id;
            
            INSERT INTO PlayerState (player_id) VALUES (vPlayer_id);
            INSERT INTO Inventory (max_items, player_id) VALUES (100, vPlayer_id);
            INSERT INTO Dice (last_roll, player_id) VALUES ("0", vPlayer_id);
            
            UPDATE Player
            SET tile_id = (SELECT MIN(t.tile_id) 
                                FROM Game g 
                                JOIN Map m ON g.game_id = m.game_id
                                JOIN Tile t ON t.map_id = m.map_id
                                WHERE g.game_id = vGame_id)
            WHERE player_id = vPlayer_id;
            SELECT ErrorCode("OK") AS STATUS, vPlayer_id AS player_id;
        ELSE
            SELECT 'Not Logged In!' AS MESSAGE, ErrorCode("ERROR") AS STATUS;
        END IF;
    END IF;
    COMMIT;
END//
DELIMITER ;

-- Remove Player 
DELIMITER //
DROP PROCEDURE IF EXISTS RemovePlayer//
CREATE PROCEDURE RemovePlayer(IN pPlayer_id INT)
BEGIN
	DECLARE vGame_id INT;
    START TRANSACTION;
    IF EXISTS (SELECT * FROM Player WHERE player_id = pPlayer_id)
    THEN
		SELECT game_id FROM Player WHERE player_id = pPlayer_id INTO vGame_id;
        
        DELETE FROM Player WHERE player_id = pPlayer_id; 
        IF (SELECT COUNT(*) FROM Player WHERE game_id = vGame_id) < 1
        THEN
			DELETE FROM Game WHERE game_id = vGame_id;
            SELECT 'Deleted game and player' AS MESSAGE;
		ELSE
			SELECT 'Removed player' AS MESSAGE;
        END IF;
        
    ELSE
        SELECT 'Player does not exist!' AS MESSAGE;
    END IF;
    COMMIT;
END//
DELIMITER ;

-- Send Message
DELIMITER //
DROP PROCEDURE IF EXISTS SendChat//
CREATE PROCEDURE SendChat(IN pMessage VARCHAR(255), IN pPlayer_id INT)
BEGIN
    DECLARE vChat_room_id INT;
	START TRANSACTION;
    SELECT c.chat_room_id 
    FROM Player p 
    JOIN Game g ON p.game_id = g.game_id 
    JOIN ChatRoom c ON c.game_id = g.game_id 
    WHERE player_id = pPlayer_id
    INTO vChat_room_id;
    
	IF ( vChat_room_id IS NOT NULL )
    THEN
        INSERT INTO Chat (chat_room_id, `text`, player_id, time_sent) VALUES 
        (vChat_room_id, pMessage, pPlayer_id, CURRENT_TIMESTAMP());
        SELECT 'Message Sent' AS MESSAGE;
    ELSE
        SELECT 'Not in a game!' AS MESSAGE;
    END IF;
    COMMIT;
END//
DELIMITER ;

-- Send Message
DELIMITER //
DROP PROCEDURE IF EXISTS GetChats//
CREATE PROCEDURE GetChats(IN pPlayer_id INT)
BEGIN
	START TRANSACTION;
    SELECT p.display_name, c.`text`, c.time_sent
    FROM Player p 
    JOIN Game g ON p.game_id = g.game_id 
    JOIN ChatRoom cr ON cr.game_id = g.game_id 
    JOIN Chat c ON c.chat_room_id = cr.chat_room_id
    WHERE p.player_id = pPlayer_id;
    COMMIT;
END//
DELIMITER ;

-- Pick up item
DELIMITER //
DROP PROCEDURE IF EXISTS PickUp//
CREATE PROCEDURE PickUp(IN pPlayer_id INT)
BEGIN
	START TRANSACTION;
	IF EXISTS (SELECT * FROM Player WHERE player_id = pPlayer_id)
    THEN
        IF EXISTS(
            SELECT * FROM Player p
            JOIN ItemTile t
            ON t.tile_id = p.tile_id
            WHERE p.player_id = pPlayer_id)
        THEN
            SELECT inventory_id FROM Inventory WHERE player_id = pPlayer_id INTO @Inventory_id;
            SELECT t.item_id FROM Player p
            JOIN ItemTile t
            ON t.tile_id = p.tile_id
            WHERE p.player_id = pPlayer_id INTO @item_id;

            IF EXISTS (SELECT * FROM InventoryItem WHERE item_id = @item_id AND inventory_id = @Inventory_id)
            THEN
                UPDATE InventoryItem
                SET quantity = quantity + 1
                WHERE item_id = @item_id AND inventory_id = @Inventory_id;
            ELSE
                INSERT INTO InventoryItem VALUES (@item_id, @Inventory_id, 1);
            END IF;
            SELECT 'Success' AS MESSAGE;
        ELSE
            SELECT 'There is no item on this tile!' AS MESSAGE;
        END IF;
    ELSE
        SELECT 'Not in a game!' AS MESSAGE;
    END IF;
    COMMIT;
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS EditPlayer//
CREATE PROCEDURE EditPlayer(IN pPlayer_id INT, IN pDisplay_name VARCHAR(100))
BEGIN
	START TRANSACTION;
    IF EXISTS (SELECT * FROM Player WHERE player_id = pPlayer_id)
    THEN
        UPDATE Player SET display_name = pDisplay_name
        WHERE player_id = pPlayer_id;
        SELECT 'Success' AS MESSAGE;
    ELSE
        SELECT 'Player does not exist!' AS MESSAGE;
    END IF;
    COMMIT;
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS UseItem//
CREATE PROCEDURE UseItem(IN pItem_id INT, IN pPlayer_id INT, IN pTarget_id INT)
BEGIN
	START TRANSACTION;
	IF pItem_id IN (SELECT ii.item_id 
    FROM InventoryItem ii 
	JOIN Inventory inv 
	ON inv.inventory_id = ii.inventory_id 
	WHERE inv.player_id = pPlayer_id AND 
    ii.item_id = pItem_id)
    THEN
		IF EXISTS (SELECT * FROM PlayerBoost WHERE item_id = pItem_id)
		THEN
			CALL MovePlayer(pTarget_id, (SELECT distance FROM PlayerBoost WHERE item_id = pItem_id), FALSE);
			CALL RemoveItem(pItem_id, pPlayer_id);
			SELECT 'Player has been moved' AS MESSAGE;
		ELSE 
			IF EXISTS (SELECT * FROM PlayerEffect WHERE item_id = pItem_id)
			THEN
				UPDATE PlayerState
				SET roll_multiplier = (SELECT roll_multiplier FROM PlayerEffect WHERE item_id = pItem_id)
				WHERE player_id = pTarget_id;
				CALL RemoveItem(pItem_id, pPlayer_id);
				SELECT 'Roll multiplier applied' AS MESSAGE;
			ELSE
				SELECT 'Item is not special!' AS MESSAGE;
			END IF;
		END IF;
	ELSE
		SELECT 'You does not have item!' AS MESSAGE;
    END IF;
    COMMIT;
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS RemoveItem//
CREATE PROCEDURE RemoveItem(IN pItem_id INT, IN pPlayer_id INT)
BEGIN
	START TRANSACTION;
	SELECT inventory_id FROM Inventory WHERE player_id = pPlayer_id INTO @InventoryId;
	UPDATE InventoryItem
	SET quantity = quantity-1
	WHERE inventory_id = @InventoryId
    AND item_id = pItem_id;
	IF (SELECT quantity 
		FROM InventoryItem 
		WHERE inventory_id = @InventoryId 
		AND item_id = pItem_id) < 1
    THEN
		DELETE FROM InventoryItem 
        WHERE inventory_id = @InventoryId 
        AND item_id = pItem_id;
	END IF;
    COMMIT;
END//
DELIMITER ;

DELIMITER //
DROP PROCEDURE IF EXISTS IsAdmin//
CREATE PROCEDURE IsAdmin(IN pAccountId INT)
BEGIN
	START TRANSACTION;
	IF EXISTS (SELECT * FROM AdminAccount WHERE account_id = pAccountId)
    THEN
		SELECT 1 AS admin_status;
	ELSE
    SELECT 0 AS admin_status;
    END IF;
    COMMIT;
END//
DELIMITER ;
CALL DDL_PROCEDURE();

-- USERNAME: admin PASSWORD: admin
INSERT INTO Account (username, email, password_hash, login_attempts, locked_out, logged_in) 
VALUES ('admin', 'admin@admin', '8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918', 0, 0, 0);

INSERT INTO AdminAccount VALUES (LAST_INSERT_ID());