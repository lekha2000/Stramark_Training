CREATE TABLE REGIONS(
    REGION_ID INT PRIMARY KEY,
    REGION_NAME VARCHAR(50) NOT NULL
);

INSERT INTO REGIONS(REGION_ID, REGION_NAME) VALUES
(1, 'Europe'),
(2, 'Americas'),
(3, 'Asia'),
(4, 'Middle East and Africa');

CREATE TABLE COUNTRIES (
    COUNTRY_ID  VARCHAR(2) PRIMARY KEY,
    COUNTRY_NAME    VARCHAR(100) NOT NULL,
    REGION_ID INT,
    FOREIGN KEY (REGION_ID) REFERENCES REGIONS(REGION_ID)
);

INSERT INTO COUNTRIES VALUES
('IT', 'Italy', 1),
('JP', 'Japan', 3),
('US', 'United States of America', 2),
('CA', 'Canada', 2),
('CN', 'China', 3),
('IN', 'India', 3),
('AU', 'Australia', 3),
('ZW', 'Zimbabwe', 4),
('SG', 'Singapore', 3),
('UK', 'United Kingdom', 1),
('FR', 'France', 1),
('DE', 'Germany', 1),
('ZM', 'Zambia', 4),
('EG', 'Egypt', 4),
('BR', 'Brazil', 2),
('CH', 'Switzerland', 1),
('NL', 'Netherlands', 1),
('MX', 'Mexico', 2),
('KW', 'Kuwait', 4),
('IL', 'Israel', 4),
('DK', 'Denmark', 1),
('HK', 'HongKong', 3),
('NG', 'Nigeria', 4),
('AR', 'Argentina', 2),
('BE', 'Belgium', 1);

CREATE TABLE LOCATIONS(
LOCATION_ID INT PRIMARY KEY,
STREET_ADDRESS VARCHAR(100),
POSTAL_CODE VARCHAR(10),
CITY VARCHAR(50),
STATE_PROVINCE VARCHAR(50),
COUNTRY_ID VARCHAR(2),
FOREIGN KEY(COUNTRY_ID) REFERENCES COUNTRIES(COUNTRY_ID)
);

INSERT INTO LOCATIONS VALUES
(1000,'1297 Via Cola di Rie', '989', 'Roma', NULL, 'IT'),
(1100,'93091 Calle della Testa', '10934', 'Venice', NULL, 'IT'),
(1200,'2017 Shinjuku-ku', '1689', 'Tokyo', 'Tokyo Prefecture', 'JP'),
(1300,'9450 Kamiya-cho', '6823', 'Hiroshima', NULL, 'JP'),
(1400,'2014 Jabberwocky Rd', '26192', 'Southlake', 'Texas', 'US'),
(1500,'2011 Interiors Blvd', '99236', 'South San Francisco', 'California', 'US'),
(1600,'2007 Zagora St', '50090', 'South Brunswick', 'New Jersey', 'US'),
(1700,'2004 Charade Rd', '98199', 'Seattle', 'Washington', 'US'),
(1800,'147 Spadina Ave', 'M5V 2L7', 'Toronto', 'Ontario', 'CA'),
(1900,'6092 Boxwood St', 'YSW 9T2', 'Whitehorse', 'Yukon', 'CA'),
(2000,'40-5-12 Laogianggen', '190518', 'Beijing', NULL, 'CN'),
(2100,'1298 Vileparle (E)', '490231', 'Bombay', 'Maharashtra', 'IN'),
(2200,'12-98 Victoria Street', '2901', 'Sydney', 'New South Wales', 'AU'),
(2300,'198 Clementi North', '540198', 'Singapore', NULL, 'SG'),
(2400,'8204 Arthur St', NULL, 'London', NULL, 'UK'),
(2500,'Magdalen Centre, The Oxford Science Park', 'OX9 9ZB', 'Oxford', 'Oxford', 'UK'),
(2600,'9702 Chester Road', '9629850293', 'Stretford', 'Manchester', 'UK'),
(2700,'Schwanthalerstr. 7031', '80925', 'Munich', 'Bavaria', 'DE'),
(2800,'Rua Frei Caneca 1360', '01307-002', 'Sao Paulo', 'Sao Paulo', 'BR'),
(2900,'20 Rue des Corps-Saints', '1730', 'Geneva', 'Geneve', 'CH'),
(3000,'Murtenstrasse 921', '3095', 'Bern', 'BE', 'CH'),
(3100,'Pieter Breughelstraat 837', '3029SK', 'Utrecht', 'Utrecht', 'NL'),
(3200,'Mariano Escobedo 9991', '11932', 'Mexico City', 'Distrito Federal', 'MX');

CREATE TABLE DEPARTMENTS(
    DEPARTMENT_ID INT PRIMARY KEY,
    DEPARTMENT_NAME VARCHAR(100) NOT NULL,
    MANAGER_ID INT,
    LOCATION_ID INT,
    FOREIGN KEY(LOCATION_ID) REFERENCES LOCATIONS(LOCATION_ID)
);

INSERT INTO DEPARTMENTS VALUES
(10, 'Administration', 200, 1700),
(20, 'Marketing', 201, 1800),
(30, 'Purchasing', 114, 1700),
(40, 'Human Resources', 203, 2400),
(50, 'Shipping', 121, 1500),
(60, 'IT', 103, 1400),
(70, 'Public Relations', 204, 2700),
(80, 'Sales', 145, 2500),
(90, 'Executive', 100, 1700),
(100, 'Finance', 108, 1700),
(110, 'Accounting', 205, 1700),
(120, 'Treasury',  NULL, 1700),
(130, 'Corporate Tax',  NULL, 1700),
(140, 'Control And Credit',  NULL, 1700),
(150, 'Shareholder Services',  NULL, 1700),
(160, 'Benefits',  NULL, 1700),
(170, 'Manufacturing',  NULL, 1700),
(180, 'Construction',  NULL, 1700),
(190, 'Contracting',  NULL, 1700),
(200, 'Operations',  NULL, 1700),
(210, 'IT Support',  NULL, 1700),
(220, 'NOC',  NULL, 1700),
(230, 'IT Helpdesk',  NULL, 1700),
(240, 'Government Sales',  NULL, 1700),
(250, 'Retail Sales',  NULL, 1700),
(260, 'Recruiting',  NULL, 1700),
(270, 'Payroll',  NULL, 1700);

CREATE TABLE JOBS(
    JOB_ID VARCHAR(25) PRIMARY KEY,
    JOB_TITLE VARCHAR(255) NOT NULL,
    MIN_SALARY money,
    MAX_SALARY money
);


INSERT INTO JOBS VALUES 
('AD_PRES', 'President', 20000, 40000),
('AD_VP', 'Administration Vice President', 15000, 30000),
('AD_ASST', 'Administration Assistant', 3000, 6000),
('FI_MGR', 'Finance Manager', 8200, 16000),
('FI_ACCOUNT', 'Accountant', 4200, 9000),
('AC_MGR', 'Accounting Manager', 8200, 16000),
('AC_ACCOUNT', 'Public Accountant', 4200, 9000),
('SA_MAN', 'Sales Manager', 10000, 20000),
('SA_REP', 'Sales Representative', 6000, 12000),
('PU_MAN', 'Purchasing Manager', 8000, 15000),
('PU_CLERK', 'Purchasing Clerk', 2500, 5500),
('ST_MAN', 'Stock Manager', 5500, 8500),
('ST_CLERK', 'Stock Clerk', 2000, 5000),
('SH_CLERK', 'Shipping Clerk', 2500, 5500),
('IT_PROG', 'Programmer', 4000, 10000),
('MK_MAN', 'Marketing Manager', 9000, 15000),
('MK_REP', 'Marketing Representative', 4000, 9000),
('HR_REP', 'Human Resources Representative', 4000, 9000),
('PR_REP', 'Public Relations Representative', 4500, 10500);

CREATE TABLE EMPLOYEES(
    EMPLOYEE_ID INT PRIMARY KEY,
    FIRSTNAME VARCHAR(50),
    LASTNAME VARCHAR(50),
    EMAIL VARCHAR(150),
    PHONE_NUMBER VARCHAR(50),
    HIRE_DATE DATE,
    JOB_ID VARCHAR(25),
    SALARY money,
    COMMISSION_PCT money,
    MANAGER_ID INT,
    DEPARTMENT_ID INT,
    FOREIGN KEY(MANAGER_ID) REFERENCES EMPLOYEES(EMPLOYEE_ID),
    FOREIGN KEY(DEPARTMENT_ID) REFERENCES DEPARTMENTS(DEPARTMENT_ID)
);
