CREATE DATABASE ProductCatalogDB;

CREATE TABLE Category (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL
);

CREATE TABLE Attribute (
    AttributeID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryID INT NOT NULL,
    AttributeName NVARCHAR(100) NOT NULL,
    AttributeType NVARCHAR(50) NOT NULL, -- e.g., Text, Number, Boolean, Date
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID) ON DELETE CASCADE
);

CREATE TABLE Product (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryID INT NOT NULL,
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES Category(CategoryID) ON DELETE CASCADE
);

CREATE TABLE ProductAttributeValue (
    ValueID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    AttributeID INT NOT NULL,
    AttributeValue NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (ProductID) REFERENCES Product(ProductID) ON DELETE CASCADE,
    FOREIGN KEY (AttributeID) REFERENCES Attribute(AttributeID)
);

---INSERTING VALUES INTO TABLE
INSERT INTO Category (CategoryName) VALUES 
('Electronics'),
('Clothing'),
('Furniture');

-- Electronics attributes
INSERT INTO Attribute (CategoryID, AttributeName, AttributeType) VALUES
(1, 'Brand', 'Text'),
(1, 'Model', 'Text'),
(1, 'Warranty (Years)', 'Number');

-- Clothing attributes
INSERT INTO Attribute (CategoryID, AttributeName, AttributeType) VALUES
(2, 'Size', 'Text'),
(2, 'Color', 'Text'),
(2, 'Material', 'Text');

-- Furniture attributes
INSERT INTO Attribute (CategoryID, AttributeName, AttributeType) VALUES
(3, 'Dimensions', 'Text'),
(3, 'Weight Capacity', 'Number'),
(3, 'Material', 'Text');

-- Electronics
INSERT INTO Product (CategoryID, ProductName, Price) VALUES
(1, 'Smartphone', 699.99),
(1, 'Laptop', 1199.50);

-- Clothing
INSERT INTO Product (CategoryID, ProductName, Price) VALUES
(2, 'T-Shirt', 19.99),
(2, 'Jeans', 49.99);

-- Furniture
INSERT INTO Product (CategoryID, ProductName, Price) VALUES
(3, 'Office Chair', 150.00),
(3, 'Dining Table', 450.00);


-- Smartphone (ProductID = 1)
INSERT INTO ProductAttributeValue (ProductID, AttributeID, AttributeValue) VALUES
(1, 1, 'Samsung'),
(1, 2, 'Galaxy S21'),
(1, 3, '2');

-- Laptop (ProductID = 2)
INSERT INTO ProductAttributeValue (ProductID, AttributeID, AttributeValue) VALUES
(2, 1, 'Dell'),
(2, 2, 'XPS 13'),
(2, 3, '3');

-- T-Shirt (ProductID = 3)
INSERT INTO ProductAttributeValue (ProductID, AttributeID, AttributeValue) VALUES
(3, 4, 'M'),
(3, 5, 'Blue'),
(3, 6, 'Cotton');

-- Jeans (ProductID = 4)
INSERT INTO ProductAttributeValue (ProductID, AttributeID, AttributeValue) VALUES
(4, 4, '32'),
(4, 5, 'Black'),
(4, 6, 'Denim');

-- Office Chair (ProductID = 5)
INSERT INTO ProductAttributeValue (ProductID, AttributeID, AttributeValue) VALUES
(5, 7, '120x60x60 cm'),
(5, 8, '120'),
(5, 9, 'Leather');

-- Dining Table (ProductID = 6)
INSERT INTO ProductAttributeValue (ProductID, AttributeID, AttributeValue) VALUES
(6, 7, '200x100x75 cm'),
(6, 8, '300'),
(6, 9, 'Wood');


---VIEWING THE TABLE
select * from Category
select * from Attribute
select * from Product
select * from ProductAttributeValue