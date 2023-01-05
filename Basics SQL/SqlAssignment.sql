select * from DEPARTMENTS
select * from EMPLOYEES;
select * from Books;

select e.LASTNAME, e.DEPARTMENT_ID, d.DEPARTMENT_NAME 
from EMPLOYEES as e join DEPARTMENTS as d
on e.EMPLOYEE_ID = d.DEPARTMENT_ID ;


select distinct JOBS.* ,l.LOCATION_ID 
from JOBS, DEPARTMENTS as d , LOCATIONS as l
where d.DEPARTMENT_ID = 30;


SELECT e.lastname, d.department_name, d.location_id, l.city
	FROM employees e, departments d, locations l
	WHERE e.department_id = d.department_id
	AND
	d.location_id = l.location_id
	AND e.commission_pct IS NOT NULL;

select e.LASTNAME,d.DEPARTMENT_NAME 
from EMPLOYEES as e, DEPARTMENTS as d
where e.department_id = d.department_id and e.LASTNAME like '%a%'

SELECT 	e.lastname, e.job_id, e.department_id,d.department_name
	FROM 	employees e JOIN departments d
	ON 	(e.department_id = d.department_id)
	JOIN 	locations l
	ON 	(d.location_id = l.location_id)
	WHERE 	l.city = 'toronto';


select distinct(department_id) from employees

SELECT * 
	FROM employees 
	ORDER BY firstname DESC;

SELECT firstname, lastname, salary, salary*.15 PF 
	FROM employees;

SELECT employee_id, firstname, lastname, salary 
    FROM employees 
    ORDER BY salary;

SELECT SUM(salary) Total_Salary 
     FROM employees;

SELECT MAX(salary) max_sal, MIN(salary) min_sal
     FROM employees;

SELECT AVG(salary) av_sal, COUNT(*) no_of_emps
     FROM employees;

SELECT COUNT(*) 
    FROM employees;

SELECT COUNT(DISTINCT job_id) 
FROM employees;

SELECT UPPER(firstname) 
   FROM employees;

SELECT SUBSTRING(firstname,1,3) 
     FROM employees;

SELECT firstname, lastname, salary
FROM employees
WHERE salary NOT BETWEEN 10000 AND 15000;


SELECT SUM(salary) 
     FROM employees;

SELECT MAX(salary), MIN(salary) 
     FROM employees;

SELECT MAX(salary) 
FROM employees 
WHERE job_id = 'IT_PROG';

SELECT AVG(salary),count(*) 
FROM employees 
WHERE department_id = 90;


