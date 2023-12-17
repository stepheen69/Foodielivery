Create Database Final

Use Final

Create table UserAccount(

     Fullname varchar (50) NOT NULL,
	 Pass varchar (50) NOT NULL,
	 Usertype varchar (50) NOT NULL
	 );

CREATE TABLE AdminView(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(255) NOT NULL,
    UserType NVARCHAR(50) NOT NULL,
    LoginTime DATETIME NOT NULL
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
	UserName NVARCHAR(100),
    FoodName NVARCHAR(255),
    Quantity INT,
    Price DECIMAL(10,2)   
);

CREATE TABLE FoodItems
(
    FoodID INT PRIMARY KEY,
    FoodName NVARCHAR(100),
    Price INT,
    QuantityAvailable INT
);

INSERT INTO FoodItems (FoodID, FoodName, Price, QuantityAvailable)
VALUES
    (1, 'Egg with Tocino and Rice', 120, 10),
    (2, '5pcs Lumpia With Rice', 60, 15),
    (3, 'Beef Tapa With Egg and Rice', 80, 20),
    (4, '4 pcs Siomai with Rice', 60, 12),
    (5, '2pcs Lumpia w/ Pansit Rice', 130, 8),
    (6, '1pc w/ Chicken and Rice', 50, 5);

UPDATE FoodItems
SET QuantityAvailable = 10
WHERE FoodID = 3;

CREATE TABLE MergedOrders
(
    MergedOrderID INT PRIMARY KEY,
    UserName NVARCHAR(100),
    MergedOrderStatus NVARCHAR(50),
    -- Add other columns as needed
);

	--Admin :PoV
	 SELECT *FROM AdminView

	 --Customer PoV
	 SELECT *FROM UserAccount
	

	 --Seller :PoV
	 SELECT *FROM Orders
	 SELECT *FROM FoodItems
	 SELECT *FROM Delivered


CREATE TABLE Delivered
(
    MergedOrderID INT PRIMARY KEY IDENTITY(1,1),
    UserName NVARCHAR(100),
    OrderStatus NVARCHAR(50) DEFAULT 'Pending'
);

ALTER TABLE Orders
ADD MergedOrderID INT REFERENCES Delivered(MergedOrderID);


