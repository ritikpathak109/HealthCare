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
CREATE TABLE select * from UsersLogin (
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
select * from UsersLogin

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


create PROCEDURE USP_GetPatientProfile
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

exec usp_getpatientprofile 3



--APPOINTEMENT STATUS TABLE FOR PATIENT
CREATE TABLE AppointmentStatusMaster (
    StatusId INT PRIMARY KEY IDENTITY(1,1),
    [Status] VARCHAR(50) NOT NULL
);

INSERT INTO select * from AppointmentStatusMaster (Status)
VALUES 
('Approved'),
('Cancelled'),
('Completed');
INSERT INTO AppointmentStatusMaster ([Status]) VALUES ('Deleted');



CREATE TABLE select * from Appointments (
    AppointmentId INT PRIMARY KEY IDENTITY(1,1),
    PatientId INT foreign key references PatientsDetails(PatientId),
    DoctorId INT foreign key references DoctorDetails(DoctorId) ,
    AppointmentDate DATE ,
    AppointmentTime TIME NOT NULL,
    ReasonForVisit NVARCHAR(255),
    StatusId INT foreign key references AppointmentStatusMaster(StatusId) ,
    IsDeleted BIT DEFAULT 0,
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME DEFAULT GETDATE()
);

ALTER TABLE Appointments
ADD SlotId INT;

ALTER TABLE Appointments
ADD CONSTRAINT FK_Appointments_SlotMaster
FOREIGN KEY (SlotId) REFERENCES SlotMaster(SlotId);

-- Optional: Remove column if you're fully moving to SlotId-based system
ALTER TABLE Appointments DROP COLUMN AppointmentTime;



select * from Appointments
-- TO CREATE APPOINTMENT FOR THE PATIENT
alter PROCEDURE USP_AddAppointment
   @PatientId INT,
    @DoctorId INT,
    @AppointmentDate DATE,
    @SlotId INT,
    @ReasonForVisit NVARCHAR(255),
    @StatusId INT
AS
BEGIN
  SET NOCOUNT ON;
    INSERT INTO Appointments
    (
        PatientId, DoctorId, AppointmentDate, SlotId, ReasonForVisit, StatusId
    )
    VALUES
    (
        @PatientId, @DoctorId, @AppointmentDate, @SlotId, @ReasonForVisit, @StatusId
    )
END

exec USP_AddAppointment 2,6,'2025-05-18', 2,'Regular OPD', 1

EXEC USP_AddAppointment 1, 7, '2025-05-27', 1, 'General Checkup', 1;
EXEC USP_AddAppointment 2, 8, '2025-05-27', 2, 'ENT Consultation', 1;
EXEC USP_AddAppointment 3, 9, '2025-05-27', 3, 'Fever and Cold', 1;
EXEC USP_AddAppointment 4, 10, '2025-05-27', 4, 'Blood Pressure Check', 1;
EXEC USP_AddAppointment 5, 11, '2025-05-27', 5, 'Diabetes Review', 1;
EXEC USP_AddAppointment 6, 12, '2025-05-27', 6, 'Back Pain', 1;
EXEC USP_AddAppointment 7, 13, '2025-05-27', 7, 'Skin Allergy', 1;
EXEC USP_AddAppointment 16, 14, '2025-05-27', 8, 'Stomach Pain', 1;
EXEC USP_AddAppointment 9, 15, '2025-05-27', 9, 'Follow-up Visit', 1;
EXEC USP_AddAppointment 10, 16, '2025-05-27', 10, 'Routine Checkup', 1;
EXEC USP_AddAppointment 11, 17, '2025-05-27', 11, 'Migraine Evaluation', 1;
EXEC USP_AddAppointment 12, 18, '2025-05-27', 12, 'Post Surgery Follow-up', 1;
EXEC USP_AddAppointment 13, 19, '2025-05-27', 13, 'Sore Throat', 1;
EXEC USP_AddAppointment 14, 20, '2025-05-27', 14, 'Weight Loss Consultation', 1;
EXEC USP_AddAppointment 15, 21, '2025-05-27', 15, 'Asthma Review', 1;
EXEC USP_AddAppointment 16, 22, '2025-05-27', 16, 'Diet Advice', 1;
EXEC USP_AddAppointment 17, 23, '2025-05-27', 17, 'General Weakness', 1;
EXEC USP_AddAppointment 18, 24, '2025-05-27', 18, 'Fatigue Check', 1;
EXEC USP_AddAppointment 1, 25, '2025-05-27', 19, 'Hair Fall Consultation', 1;
EXEC USP_AddAppointment 2, 26, '2025-05-27', 20, 'Ear Infection', 1;
EXEC USP_AddAppointment 3, 27, '2025-05-27', 21, 'Eye Pain', 1;
EXEC USP_AddAppointment 4, 28, '2025-05-27', 22, 'Knee Pain', 1;
EXEC USP_AddAppointment 5, 29, '2025-05-27', 23, 'Cough and Cold', 1;
EXEC USP_AddAppointment 6, 30, '2025-05-27', 24, 'Dental Cavity', 1;
EXEC USP_AddAppointment 7, 7, '2025-05-27', 25, 'Blurred Vision', 1;
EXEC USP_AddAppointment 17, 8, '2025-05-27', 26, 'Infection Checkup', 1;
EXEC USP_AddAppointment 9, 9, '2025-05-27', 27, 'Urine Infection', 1;
EXEC USP_AddAppointment 10, 10, '2025-05-27', 28, 'Headache', 1;
EXEC USP_AddAppointment 11, 11, '2025-05-27', 29, 'Swollen Ankle', 1;
EXEC USP_AddAppointment 12, 12, '2025-05-27', 30, 'Foot Pain', 1;
EXEC USP_AddAppointment 13, 13, '2025-05-27', 31, 'Chest Discomfort', 1;
EXEC USP_AddAppointment 14, 14, '2025-05-27', 32, 'Pre-natal Check', 1;
EXEC USP_AddAppointment 15, 15, '2025-05-27', 33, 'Post-natal Visit', 1;




-- TO GET WHICH TIME SLOTS ARE AVAILABLE FOR BOOKING
alter PROCEDURE USP_GetAvailableSlots
    @DoctorId INT,
    @AppointmentDate DATE
AS
BEGIN
    SELECT 
        SM.SlotId,
        SM.SlotTime AS StartTime,
        DATEADD(MINUTE, 15, SM.SlotTime) AS EndTime,
        CASE 
            WHEN A.SlotId IS NOT NULL THEN 1  -- Booked
            ELSE 0                            -- Available
        END AS IsBooked
    FROM SlotMaster SM
    LEFT JOIN Appointments A
        ON SM.SlotId = A.SlotId
        AND A.DoctorId = @DoctorId
        AND A.AppointmentDate = @AppointmentDate
        AND A.IsDeleted = 0
    WHERE SM.IsActive = 1
END

exec USP_GetAvailableSlots 9, '2025-05-27'

DELETE FROM Appointments;

--TO GET APPOINTMENT DETILS USING PATEINT ID
ALTER PROCEDURE USP_GetAppointmentsByPatientId
    @PatientId INT
AS
BEGIN
    SELECT 
        A.AppointmentId,
        A.PatientId,
        P.PatientFirstName + ' ' + P.PatientLastName AS PatientName,
        DATEDIFF(YEAR, P.DateOfBirth, GETDATE()) AS Age,
        A.DoctorId,
        D.DoctorFirstName + ' ' + D.DoctorLastName AS DoctorName,
        SMZ.SpecializationName, 
        A.AppointmentDate,

        -- Raw slot time data
        SM.SlotTime AS SlotStartTime,
        DATEADD(MINUTE, 15, SM.SlotTime) AS SlotEndTime,

        A.ReasonForVisit,
        ASM.[Status],
        A.CreatedDate
    FROM Appointments A
    INNER JOIN PatientsDetails P ON A.PatientId = P.PatientId
    INNER JOIN DoctorDetails D ON A.DoctorId = D.DoctorId
    INNER JOIN DoctorSpecializationMaster SMZ ON D.SpecializationId = SMZ.SpecializationId 
    INNER JOIN AppointmentStatusMaster ASM ON A.StatusId = ASM.StatusId
    INNER JOIN SlotMaster SM ON A.SlotId = SM.SlotId
    WHERE A.IsDeleted = 0 AND A.PatientId = @PatientId
    ORDER BY A.AppointmentDate DESC, SM.SlotTime DESC
END


exec USP_GetAppointmentsByPatientId 1


--TO DELETE APPOINTMENT 
alter PROCEDURE usp_UpdateAppointmentIsDeleted
 @AppointmentId INT
AS
BEGIN
    DECLARE @DeletedStatusId INT;

    SELECT @DeletedStatusId = StatusId 
    FROM AppointmentStatusMaster 
    WHERE [Status] = 'Deleted';

    UPDATE Appointments
    SET 
        IsDeleted = 1,
        StatusId = @DeletedStatusId,
        UpdatedDate = GETDATE() 
    WHERE AppointmentId = @AppointmentId;
END


usp_UpdateAppointmentIsDeleted 135, 1


-- TO GET DELETED APPOINTMENT BY PATIENTID
CREATE or alter PROCEDURE GetDeletedAppointmentsByPatientId
    @PatientId INT
AS
BEGIN
    SELECT 
        A.AppointmentId,
        A.PatientId,
        P.PatientFirstName + ' ' + P.PatientLastName AS PatientName,
        DATEDIFF(YEAR, P.DateOfBirth, GETDATE()) AS Age,
        A.DoctorId,
        D.DoctorFirstName + ' ' + D.DoctorLastName AS DoctorName,
        SMZ.SpecializationName, 
        A.AppointmentDate,

        -- Raw slot time data
        SM.SlotTime AS SlotStartTime,
        DATEADD(MINUTE, 15, SM.SlotTime) AS SlotEndTime,

        A.ReasonForVisit,
        ASM.[Status],
        A.CreatedDate
    FROM Appointments A
    INNER JOIN PatientsDetails P ON A.PatientId = P.PatientId
    INNER JOIN DoctorDetails D ON A.DoctorId = D.DoctorId
    INNER JOIN DoctorSpecializationMaster SMZ ON D.SpecializationId = SMZ.SpecializationId 
    INNER JOIN AppointmentStatusMaster ASM ON A.StatusId = ASM.StatusId
    INNER JOIN SlotMaster SM ON A.SlotId = SM.SlotId
    WHERE A.IsDeleted = 1 AND A.PatientId = @PatientId
    ORDER BY A.AppointmentDate DESC, SM.SlotTime DESC
END



GetDeletedAppointmentsByPatientId 1

CREATE TABLE SlotMaster (
    SlotId INT PRIMARY KEY IDENTITY(1,1),
    SlotTime TIME NOT NULL,
    IsActive BIT DEFAULT 1
);

select * from SlotMaster


--DOCTOR PORTAL TABLES

--SPECILIZATION MASTER TABLE
CREATE TABLE DoctorSpecializationMaster (
    SpecializationId INT PRIMARY KEY IDENTITY(1,1),
    SpecializationName NVARCHAR(100)
);


INSERT INTO select * from DoctorSpecializationMaster (SpecializationName)
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
    UserId INT NOT NULL foreign key references UsersLogin(UserId) on delete cascade,  
    DoctorFirstName NVARCHAR(100),
    DoctorLastName NVARCHAR(100),
	DoctorEmail nvarchar(100),
	DoctorDateofBirth date,
    DoctorPhoneNumber NVARCHAR(15),
    DoctorAddress NVARCHAR(250),
    GenderId INT foreign key references GenderMaster(GenderId),
    CountryId INT foreign key references CountryMaster(CountryId),
    StateId INT foreign key references StateMaster(StateId),
    SpecializationId INT foreign key references DoctorSpecializationMaster(SpecializationId),
    ExperienceYears INT,
 	IsActive TINYINT DEFAULT 1,        
    IsDeleted TINYINT DEFAULT 0,    
    CreatedDate DATETIME DEFAULT GETDATE(),
    UpdatedDate DATETIME Default getDate()
);

drop table DoctorDetails

--STORED PROCEDURE TO REGISTER DOCTOR

alter PROCEDURE USP_RegisterDoctor
    @UserName NVARCHAR(100),
    @UserPassword NVARCHAR(100),
    @RoleId INT,
    @DoctorFirstName NVARCHAR(100),
    @DoctorLastName NVARCHAR(100),
    @DoctorPhoneNumber NVARCHAR(15),
	@DoctorDateofBirth date,
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

 
    INSERT INTO DoctorDetails (DoctorFirstName,DoctorLastName, DoctorPhoneNumber, DoctorAddress,DoctorDateofBirth, DoctorEmail, GenderId,CountryId, StateId,SpecializationId,ExperienceYears,UserId) 
		VALUES (@DoctorFirstName, @DoctorLastName, @DoctorPhoneNumber,@DoctorAddress, @DoctorDateofBirth, @DoctorEmail, @GenderId,@CountryId,@StateId, @SpecializationId,@ExperienceYears,@UserId )
END


exec USP_RegisterDoctor 'drakashayyy', 'Akashay@123', 3, 'Akashhhay', 'Sharma', '89588555','1963-01-20', 'akashayyyy@gmail.com','lucknow', 1, 1, 1, 4, 3

delete from DoctorDetails where doctorid=1
select * from UsersLogin

select * from DoctorDetails




