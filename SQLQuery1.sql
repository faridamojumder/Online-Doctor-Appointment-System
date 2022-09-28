Create database DoctorCrud
Use DoctorCrud

create table Specialist
(
	SpecialistID int identity(1,1) primary key,
	SpecialistName Varchar(50) NULL
);

create table Doctor
(
	DoctorID int identity(1,1) primary key,
	DoctorName Varchar(50) NULL,
	ScheduleDate datetime NULL,
	Gender varchar(50) NULL,
	Prescription nvarchar(500) NULL,
	TotalPatient int NULL,
	SpecialistID int references Specialist(SpecialistID)
);
create table Patient
(
	PatientID int identity(1,1) primary key,
	PatientName Varchar(50) NULL,
	ScheduleDate datetime NULL,
	Gender varchar(50) NULL,
	Report nvarchar(500) NULL,
	SerialNo int NULL,
	DoctorID int references Doctor(DoctorID)
);
create table [User]
(
	Id int identity(1,1) primary key,
	UserName Varchar(50),
	Password Varchar(50)
);