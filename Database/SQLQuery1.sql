
-- ROLE MASTER TABLE (ADMIN, PATIENT, DOCTOR)
CREATE TABLE RoleMaster (
    RoleId INT IDENTITY(1,1) PRIMARY KEY,
    RoleName NVARCHAR(50) NOT NULL UNIQUE
);
INSERT INTO RoleMaster (RoleName)
VALUES 
('Admin'),
('Patient'),
('Doctor');

select * from RoleMaster

-- GENDER MASTER TABLE (MALE, FEMALE, OTHER)
CREATE TABLE GenderMaster (
    GenderId INT IDENTITY(1,1) PRIMARY KEY,
    Gender NVARCHAR(10) NOT NULL UNIQUE
);

INSERT INTO GenderMaster (Gender)
VALUES 
('Male'),
('Female'),
('Other');

-- COUNTRY MASTER TABLE
CREATE TABLE CountryMaster (
    CountryId INT IDENTITY(1,1) PRIMARY KEY,
    CountryName NVARCHAR(150) NOT NULL UNIQUE
);

INSERT INTO CountryMaster (CountryName)
VALUES 
('India'),
('United States'),
('Germany');


-- STATE MASTER TABLE (LINKED TO COUNTRY TABLE)
CREATE TABLE StateMaster (
    StateId INT IDENTITY(1,1) PRIMARY KEY,
	StateName NVARCHAR(100) NOT NULL,
    CountryId INT NOT NULL foreign key references CountryMaster(CountryId)
);
INSERT INTO StateMaster (StateName, CountryId)
VALUES 
-- For India
('Delhi', 1),
('Maharashtra', 1),
('Tamil Nadu', 1),
('Karnataka', 1),
('Uttar Pradesh', 1),

-- For United States
('California', 2),
('Texas', 2),
('Florida', 2),
('New York', 2),
('Illinois', 2),

-- For Germany
('Bavaria', 3),
('Berlin', 3),
('Hesse', 3),
('North Rhine-Westphalia', 3),
('Saxony', 3);



--STORES LOGIN INFORMATION AND ROLE (ADMIN, PATIENT, DOCTOR)
CREATE TABLE UsersLogin (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(150) NOT NULL,
    UserEmail NVARCHAR(150) NOT NULL UNIQUE,
    UserPassword NVARCHAR(255) NOT NULL,
    RoleId INT NOT NULL foreign key references RoleMaster(RoleId),
	IsActive TINYINT DEFAULT 1,        
    IsDeleted TINYINT DEFAULT 0,    
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE()
);


-- STORES PATIENT-SPECIFIC INFO
CREATE TABLE PatientsDetails (
	PatientFirstName varchar(150),
	PatientLastName varchar(150),
    PatientId INT IDENTITY(1,1) PRIMARY KEY,
    DateofBirth Date,
    GenderId INT foreign key references GenderMaster(GenderId),
    CountryId INT foreign key references CountryMaster(CountryId),
    StateId INT foreign key references StateMaster(StateId),
    PatientAddress NVARCHAR(255),
    PatientPhoneNumber NVARCHAR(15),
	UserId INT NOT NULL foreign key references UsersLogin(UserId),
	IsActive TINYINT DEFAULT 1,        
    IsDeleted TINYINT DEFAULT 0,    
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE()
);



-- Stored procedure foor login
create procedure USP_UserLogin
@UserName varchar(150),
@UserPassword varchar(150)
as
begin
select UL.UserName, R.RoleName from UsersLogin UL join RoleMaster R on UL.RoleId=R.RoleId
where UL.UserName= @UserName
and UL.UserPassword= @UserPassword and UL.IsDeleted=0 and UL.IsActive=1
end




--STORED PROCEDURE TO ADD PATIENT DATA
create PROCEDURE USP_RegisterPatient
	@PatientFirstName NVarchar(150),
	@PatientLastName Nvarchar(150),
    @UserName NVARCHAR(150),
    @UserEmail NVARCHAR(150),
    @UserPassword NVARCHAR(255),
    @RoleId INT,
    @DateofBirth date,
    @GenderId INT,
    @CountryId INT,
    @StateId INT,
    @PatientAddress NVARCHAR(255),
    @PatientPhoneNumber NVARCHAR(15)
AS
BEGIN
    DECLARE @UserId INT;

    INSERT INTO UsersLogin (UserName, UserEmail, UserPassword, RoleId)
    VALUES (@UserName, @UserEmail, @UserPassword, @RoleId);

    SET @UserId = SCOPE_IDENTITY();

    INSERT INTO PatientsDetails(PatientFirstName, PatientLastName, DateofBirth, GenderId, CountryId, StateId, PatientAddress, PatientPhoneNumber, UserId)
    VALUES (@PatientFirstName, @PatientLastName, @DateofBirth, @GenderId, @CountryId, @StateId, @PatientAddress, @PatientPhoneNumber, @UserId);
END

exec USP_RegisterPatient 'ritikpathak109', 'ritikpathak109@gamil.com', 'Ritik@123', 2, '2001-01-14', 1, 1,1 ,'Dhaula Kuan New Delhi', 7011291675
select * from UsersLogin

select * from PatientsDetails



--VIEW TO GET DYNAMIC AGE
CREATE VIEW vw_PatientProfile AS
SELECT 
    p.PatientId,
    u.UserName,
    p.PatientPhoneNumber,
    YEAR(GETDATE()) - YEAR(p.DateOfBirth) AS Age
FROM PatientsDetails p
JOIN UsersLogin u ON p.UserId = u.UserId
WHERE p.IsDeleted = 0 AND p.IsActive = 1;




