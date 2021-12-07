use InvoiceMakerDB;


CREATE TABLE Company (
    CompanyID int NOT NULL PRIMARY KEY,
    CompanyName varchar(255) NOT NULL,
    Address varchar(255),
    City varchar(255),
	Street varchar(255),
    Zip varchar(255),
	PhoneNumber char(10),
	Fax char(10),
	Website varchar(255),
    CONSTRAINT chk_phone CHECK (PhoneNumber not like '%[^0-9]%'),
	CONSTRAINT chk_fax CHECK (Fax not like '%[^0-9]%')
);

CREATE TABLE Customer (
    CustomerID int NOT NULL PRIMARY KEY,
    LastName varchar(255),
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255),
	Street varchar(255),
    Zip varchar(255),
	PhoneNumber char(10)
);

CREATE TABLE Invoices (
    InvoiceID int NOT NULL PRIMARY KEY,
    DateOfInvoice DATE DEFAULT GETDATE(),
    DueDate DATE,
    TotalAmount decimal(10,2) 
);

CREATE TABLE Items (
    ItemID int NOT NULL PRIMARY KEY,
    ItemDescription varchar(255),
    Price varchar(255),
	Taxable bit
);

CREATE TABLE InvoiceItemsLookup (
    InvoiceItemID int NOT NULL PRIMARY KEY,
	InvoiceID int,
	ItemID int
);

--FOREIGN KEYS

ALTER TABLE Customer
ADD CompanyID INT
CONSTRAINT FK_Company
FOREIGN KEY (CompanyID) REFERENCES Company(CompanyID);

ALTER TABLE Invoices
ADD CustomerID INT
CONSTRAINT FK_Customer
FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID);

ALTER TABLE InvoiceItemsLookup
ADD CONSTRAINT FK_InvoiceLookup
FOREIGN KEY (InvoiceID) REFERENCES Invoices(InvoiceID);

ALTER TABLE InvoiceItemsLookup
ADD CONSTRAINT FK_ItemLookup
FOREIGN KEY (ItemID) REFERENCES Items(ItemID);

--Updates 
UPDATE Company
SET PhoneNumber = SUBSTRING(PhoneNumber, 1, 3) + '-' + 
                  SUBSTRING(PhoneNumber, 4, 3) + '-' + 
                  SUBSTRING(PhoneNumber, 7, 4)

UPDATE Company
SET Fax = SUBSTRING(Fax, 1, 3) + '-' + 
          SUBSTRING(Fax, 4, 3) + '-' + 
          SUBSTRING(Fax, 7, 4)

--ALTER Mistakes 
ALTER TABLE Company
DROP COLUMN Address;

ALTER TABLE Customer
DROP COLUMN Address;  