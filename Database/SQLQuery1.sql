--PATEINT PORTAL TABLES

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
select * from PatientsDetails

ALTER TABLE PatientsDetails
ADD ProfilePicture NVARCHAR(MAX) NULL;




-- Stored procedure foor login
alter procedure USP_UserLogin
@UserName varchar(150),
@UserPassword varchar(150)
as
begin
select UL.UserName,Ul.UserId, R.RoleName, R.RoleId from UsersLogin UL join RoleMaster R on UL.RoleId=R.RoleId
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


alter PROCEDURE USP_GetPatientProfile
    @UserId INT
AS
BEGIN
    SELECT 
        p.PatientId,
        p.UserId,
        u.UserEmail,
        p.PatientFirstName,
        p.PatientLastName,
		p.ProfilePicture,
        p.PatientPhoneNumber,
        p.PatientAddress,
        g.Gender,
        c.CountryName,
        s.StateName,
        DATEDIFF(YEAR, p.DateOfBirth, GETDATE()) AS Age
    FROM 
        PatientsDetails p
    JOIN 
        GenderMaster g ON p.GenderId = g.GenderId
    JOIN 
        CountryMaster c ON p.CountryId = c.CountryId
    JOIN 
        StateMaster s ON p.StateId = s.StateId
    JOIN 
        UsersLogin u ON p.UserId = u.UserId
    WHERE 
        p.UserId = @UserId AND p.IsDeleted = 0;
END;

exec usp_getpatientprofile 1



--DOCTOR PORTAL TABLES

--SPECILIZATION MASTER TABLE
CREATE TABLE DoctorSpecializationMaster (
    SpecializationId INT PRIMARY KEY IDENTITY(1,1),
    SpecializationName NVARCHAR(100)
);


INSERT INTO DoctorSpecializationMaster (SpecializationName)
VALUES 
('General Physician'),
('ENT Specialist'),
('Gynecologist'),
('Psychiatrist'),
('Ophthalmologist'),
('Oncologist'),
('Dentist'),
('Radiologist'),
('Urologist'),
('Nephrologist'),
('Gastroenterologist'),
('Pulmonologist'),
('Endocrinologist'),
('Rheumatologist'),
('Surgeon'),
('Plastic Surgeon'),
('Anesthesiologist'),
('Dermatologist'),
('Cardiologist'),
('Pediatrician'),
('Orthopedic'),
('Neurologist'),
('Hematologist'),
('Hepatologist'),
('Pathologist'),
('Immunologist'),
('Sports Medicine Specialist'),
('Emergency Medicine Specialist'),
('Clinical Geneticist'),
('Medical Oncologist'),
('Surgical Oncologist'),
('Physiotherapist');



--DOCOTOR DETAILS TABLE FOR REGISTRATION
CREATE TABLE DoctorDetails (
    DoctorId INT PRIMARY KEY IDENTITY(1,1),
    UserId INT NOT NULL foreign key references UsersLogin(UserId),  
    DoctorFirstName NVARCHAR(100),
    DoctorLastName NVARCHAR(100),
	DoctorEmail nvarchar(100),
    DoctorPhoneNumber NVARCHAR(15),
    DoctorAddress NVARCHAR(250),
    GenderId INT,
    CountryId INT,
    StateId INT,
    SpecializationId INT foreign key references DoctorSpecializationMaster(SpecializationId),
    ExperienceYears INT,
 	IsActive TINYINT DEFAULT 1,        
    IsDeleted TINYINT DEFAULT 0,    
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME Default getDate()
);

drop table DoctorDetails

--STORED PROCEDURE TO REGISTER DOCTOR

drop procedure USP_RegisterDoctor
create PROCEDURE USP_RegisterDoctor
    @UserName NVARCHAR(100),
    @UserPassword NVARCHAR(100),
    @RoleId INT,
    @DoctorFirstName NVARCHAR(100),
    @DoctorLastName NVARCHAR(100),
    @DoctorPhoneNumber NVARCHAR(15),
	@DoctorEmail nvarchar(100),
    @DoctorAddress NVARCHAR(250),
    @GenderId INT,
    @CountryId INT,
    @StateId INT,
    @SpecializationId INT,
    @ExperienceYears INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO UsersLogin (UserName, UserPassword,UserEmail, RoleId)
    VALUES (@UserName, @UserPassword, @DoctorEmail, @RoleId)

    DECLARE @UserId INT = SCOPE_IDENTITY()

 
    INSERT INTO DoctorDetails (DoctorFirstName,DoctorLastName, DoctorPhoneNumber, DoctorAddress, DoctorEmail, GenderId,CountryId, StateId,SpecializationId,ExperienceYears,UserId) 
		VALUES (@DoctorFirstName, @DoctorLastName, @DoctorPhoneNumber,@DoctorAddress,@DoctorEmail, @GenderId,@CountryId,@StateId, @SpecializationId,@ExperienceYears,@UserId )
END


exec USP_RegisterDoctor 'dradityasingh', 'Aditya@123', 3, 'Aditya', 'Singh', '8956412470', 'adityasingh@gmail.com', 'lucknow', 1, 1, 1, 1, 5

select * from UsersLogin

select * from DoctorDetails

delete from UsersLogin where UserId= 18