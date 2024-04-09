
Mocked example for setting up columns in a SQL-Server table to mask in this case credit card and SSN dependent on permissions.

```sql
USE ComputedSample4;


CREATE TABLE dbo.Taxpayers (Id INT IDENTITY PRIMARY KEY,
                            FullName NVARCHAR(100) NOT NULL,
                            Email NVARCHAR(100) NOT NULL,
                            Social VARCHAR(9) MASKED WITH (FUNCTION = 'partial(0,"XXXXX",4)') NOT NULL,
                            CreditCardNumber VARCHAR(16) MASKED WITH (FUNCTION = 'partial(0, "XXXX-XXXX-X-", 4)') NULL,
                            BirthDate DATE NOT NULL);

INSERT INTO dbo.Taxpayers (FullName,
                           Email,
                           Social,
						   CreditCardNumber,
                           BirthDate)
VALUES ('Jane Gallagher', 'gallagherjane@gmail.com', '123456789', '1213456789012345', '1980-01-21');

-- Create a non-privileged user
CREATE USER NonPrivilegedUser WITHOUT LOGIN;
-- Grant SELECT permission
GRANT SELECT ON Taxpayers TO NonPrivilegedUser;
-- Impersonate the user to show initial masked view
EXECUTE AS USER = 'NonPrivilegedUser';
-- Query the data
SELECT Id, FullName, Email, Social AS "SSN Masked", CreditCardNumber, BirthDate  FROM dbo.Taxpayers;
-- Revert impersonation
REVERT;
-- Grant UNMASK permission
GRANT UNMASK TO NonPrivilegedUser;
-- Impersonate again to show unmasked view
EXECUTE AS USER = 'NonPrivilegedUser';
-- Query the data
SELECT Id, FullName, Email, Social, BirthDate FROM dbo.Taxpayers;
-- Revert impersonation
REVERT;
-- Remove the user
DROP USER NonPrivilegedUser;
-- Drop the table
DROP TABLE dbo.Taxpayers;
```