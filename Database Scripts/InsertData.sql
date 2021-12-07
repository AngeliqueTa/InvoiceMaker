use InvoiceMakerDB;

--Company
INSERT INTO Company 
(CompanyID, CompanyName, City, Street, Zip, PhoneNumber, Fax, Website)
VALUES 
(1, 'AkiruZ', 'George', 'Skagen 21', '0012', '0123795820', '0123795820', 'www.Akiruz.com');

INSERT INTO Company 
(CompanyID, CompanyName, City, Street, Zip, PhoneNumber, Fax, Website)
VALUES 
(2, 'LassAngelic', 'Darling', 'Skagen 23', '0012', '0123797896', '0123797896', 'www.LassAngelic.com');

--Customer
INSERT INTO Customer 
(CustomerID, LastName, FirstName, City, Street, Zip, PhoneNumber, CompanyID)
VALUES 
(1, 'Taute', 'Angelique', 'George', 'Skagen 21', '0012' , '0123478520' ,2);

INSERT INTO Customer 
(CustomerID,LastName, FirstName, City, Street, Zip, PhoneNumber,CompanyID)
VALUES 
(2,'Taute', 'Michelle', 'Darling', 'Skagen 23', '0012' , '0123698520',1);

INSERT INTO Customer 
(CustomerID,LastName, FirstName, City, Street, Zip, PhoneNumber,CompanyID)
VALUES 
(3,'Taute', 'Michael', 'Darling', 'Skagen 21', '0012' , '0124578526',2);

--Invoices 
INSERT INTO Invoices 
(InvoiceID, DueDate, TotalAmount, CustomerID)
VALUES 
(1, '2022-01-03', '852.30' ,1);

INSERT INTO Invoices 
(InvoiceID, DueDate, TotalAmount, CustomerID)
VALUES 
(2, '2022-02-04', '145.05' ,1);

INSERT INTO Invoices 
(InvoiceID, DueDate, TotalAmount, CustomerID)
VALUES 
(3, '2022-03-15', '154.32',2);

--Items
INSERT INTO Items 
(ItemID, ItemDescription, Price, Taxable)
VALUES 
(1,'Oil Change, Cleanup','230.00',0);

INSERT INTO Items 
(ItemID, ItemDescription, Price, Taxable)
VALUES 
(2, 'Labor Rates' , '375.00',0);

INSERT INTO Items 
(ItemID, ItemDescription, Price, Taxable)
VALUES 
(3, 'Oil Filter, Filter Rubber, Sealant', '345.00',1);


--InvoiceItemsLookup
INSERT INTO InvoiceItemsLookup 
(InvoiceItemID, InvoiceID, ItemID)
VALUES 
(1, 1, 1);

INSERT INTO InvoiceItemsLookup 
(InvoiceItemID, InvoiceID, ItemID)
VALUES 
(2, 1, 2);

INSERT INTO InvoiceItemsLookup 
(InvoiceItemID, InvoiceID, ItemID)
VALUES 
(3, 1, 3);

INSERT INTO InvoiceItemsLookup 
(InvoiceItemID, InvoiceID, ItemID)
VALUES 
(4, 2, 1);

INSERT INTO InvoiceItemsLookup 
(InvoiceItemID, InvoiceID, ItemID)
VALUES 
(5, 2, 2);

INSERT INTO InvoiceItemsLookup 
(InvoiceItemID, InvoiceID, ItemID)
VALUES 
(6, 3, 3);