CREATE TABLE address (
	id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    region NVARCHAR(50) NOT NULL,
	city NVARCHAR(50) NOT NULL,
	district NVARCHAR(50)  NOT NULL,
	street  NVARCHAR(50)  NOT NULL
)

CREATE TABLE phone_number (
	id  INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	primary_number NVARCHAR(13) NOT NULL,
    secondary_number NVARCHAR(13) NULL
)

CREATE TABLE department (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    name NVARCHAR(50) NOT NULL
)

CREATE TABLE clinic_type (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    name NVARCHAR(50) NOT NULL
)

CREATE TABLE clinic (
    id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    name NVARCHAR(50) NOT NULL,
	description NVARCHAR(300) NULL,
	type INT NOT NULL,
	address INT NOT NULL,
	phone_number INT NOT NULL,
	location GEOGRAPHY NOT NULL,
	image VARBINARY(MAX) NULL,
	FOREIGN KEY (address) REFERENCES address (id),
	FOREIGN KEY (phone_number) REFERENCES phone_number (id),
	FOREIGN KEY (type) REFERENCES clinic_type (id)
)

CREATE TABLE clinic_department_junction (
	clinic INT NOT NULL,
	department INT NOT NULL,
	FOREIGN KEY (clinic) REFERENCES clinic (id),
	FOREIGN KEY (department) REFERENCES department (id)
	ADD CONSTRAINT pk_clinic_department PRIMARY KEY (clinic, department)
)

CREATE TABLE doctor (
	id  INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50)  NOT NULL,
	dob DATE NOT NULL,
    passport_number VARCHAR(9) NOT NULL,
	address INT NOT NULL,
	phone_number INT NOT NULL,
	email NVARCHAR(50) NOT NULL,
	clinic INT NOT NULL,
    department INT NOT NULL,
	FOREIGN KEY (address) REFERENCES Address (id),
	FOREIGN KEY (phone_number) REFERENCES phone_number (id),
	FOREIGN KEY (clinic) REFERENCES clinic (id),
    FOREIGN KEY (department) REFERENCES department (id)
)

CREATE TABLE patient (
    id  INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	first_name VARCHAR(50) NOT NULL,
	last_name VARCHAR(50)  NOT NULL,
	dob DATE NOT NULL,
    passport_number VARCHAR(9) NOT NULL,
	address INT NOT NULL,
	phone_number INT NOT NULL,
	email NVARCHAR(50) NOT NULL,
    FOREIGN KEY (address) REFERENCES Address (id),
	FOREIGN KEY (phone_number) REFERENCES phone_number (id)
)

CREATE TABLE appointment_status (
	id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	name NVARCHAR(50) NOT NULL
)

CREATE TABLE appointment (
	id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	date DATE NOT NULL,
	start_time TIME NOT NULL,
	end_time TIME NOT NULL,
	clinic INT NOT NULL,
	doctor INT NOT NULL,
	patient INT NOT NULL,
	status INT NOT NULL,
	FOREIGN KEY (clinic) REFERENCES clinic (id),
	FOREIGN KEY (doctor) REFERENCES doctor (id),
	FOREIGN KEY (patient) REFERENCES patient (id),
	FOREIGN KEY (status) REFERENCES appointment_status (id)
)