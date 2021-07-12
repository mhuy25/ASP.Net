CREATE DATABASE TodoList
GO

USE TodoList
GO

CREATE TABLE Role(
	role_id INT PRIMARY KEY,
	role_name VARCHAR(50) NOT NULL,
);

CREATE TABLE Employee(
	employee_id INT PRIMARY KEY,
	employee_name VARCHAR(50) NOT NULL,
	employee_email VARCHAR(35) NOT NULL,
	employee_password VARCHAR(35) NOT NULL,
	role_id INT NOT NULL REFERENCES Role(role_id)
);

CREATE TABLE Job(
	job_id INT PRIMARY KEY,
	job_title VARCHAR(40) NOT NULL,
	job_start VARCHAR(25) NOT NULL,
	job_end VARCHAR(25) NOT NULL,
	job_status INT NOT NULL,
	job_range INT NOT NULL
);

CREATE TABLE JobEmployee(
	employee_id INT references Employee(employee_id),
	job_id INT references Job(job_id),
	constraint pk_jobdetail primary key(employee_id, job_id)
);

CREATE TABLE Comment(
	employee_id INT references Employee(employee_id),
	job_id INT references Job(job_id),
	comment NVARCHAR(200), 
	constraint pk_comment primary key(employee_id, job_id)
);
-----Role
insert into Role(role_id, role_name)
values(1, 'Employee');
insert into Role(role_id, role_name)
values(2, 'Manager');

-------Employee
insert into Employee(employee_id, employee_name, employee_email, employee_password, role_id)
values(1	,'Lac Thi Kim'		,'kimlt180693@gmail.com'	,'@Kim123456'		,1);
insert into Employee(employee_id, employee_name, employee_email, employee_password, role_id)
values(2	,'Tu Thi Diu'		,'diutt151176@gmail.com'	,'@Diu123456'		,1);
insert into Employee(employee_id, employee_name, employee_email, employee_password, role_id)
values(3	,'Phuong Qui Quang'	,'quangpq281275@gmail.com'		,'@Quang123456'	,1);
insert into Employee(employee_id, employee_name, employee_email, employee_password, role_id)
values(4	,'Doan Quang Vuong'	,'vuongdq121285@gmail.com'		,'@Vuong123456'	,2);
insert into Employee(employee_id, employee_name, employee_email, employee_password, role_id)
values(5	,'Diep Ngoc Hao'	,'haodn280193@gmail.com'	,'@Hao123456'		,1);
insert into Employee(employee_id, employee_name, employee_email, employee_password, role_id)
values(6	,'Hoang Thi Cam'	,'camht110174@gmail.com'	,'@Cam123456'		,1);
insert into Employee(employee_id, employee_name, employee_email, employee_password, role_id)
values(7	,'Ky Thi Canh'		,'canhkt141278@gmail.com'	,'@Canh123456'		,1);
insert into Employee(employee_id, employee_name, employee_email, employee_password, role_id)
values(8	,'Khuu Van Hieu'	,'hieukv110487@gmail.com'	,'@Hieu123456'		,2);
insert into Employee(employee_id, employee_name, employee_email, employee_password, role_id)
values(9	,'Voong Manh Thao'	,'thaovm221292@gmail.com'	,'@Thao123456'		,1);
insert into Employee(employee_id, employee_name, employee_email, employee_password, role_id)
values(10	,'Lieu Van Binh	'	,'binhlv020990@gmail.com'	,'@Binh123456'		,1);

-------Job
insert into Job(job_id, job_title, job_start, job_end, job_status, job_range)
values(1	,'Job1'		,'2020-09-12 07:12:12'	,'2020-09-13 07:12:40'		,1		,1);
insert into Job(job_id, job_title, job_start, job_end, job_status, job_range)
values(2	,'Job2'		,'2020-09-13 07:50:23'	,'2020-09-14 07:12:30'		,1		,1);
insert into Job(job_id, job_title, job_start, job_end, job_status, job_range)
values(3	,'Job3'		,'2020-09-16 07:12:41'	,'2020-09-17 20:00:00'		,0		,0);
insert into Job(job_id, job_title, job_start, job_end, job_status, job_range)
values(4	,'Job4'		,'2020-09-17 08:12:20'	,'2020-09-17 21:12:24'		,1		,0);
insert into Job(job_id, job_title, job_start, job_end, job_status, job_range)
values(5	,'Job5'		,'2020-09-17 08:20:36'	,'2020-09-18 09:00:50'		,0		,0);
insert into Job(job_id, job_title, job_start, job_end, job_status, job_range)
values(6	,'Job6'		,'2020-09-19 07:20:35'	,'2020-09-20 08:12:43'		,0		,1);
insert into Job(job_id, job_title, job_start, job_end, job_status, job_range)
values(7	,'Job7'		,'2020-09-20 08:12:30'	,'2020-09-20 17:12:23'		,0		,1);
insert into Job(job_id, job_title, job_start, job_end, job_status, job_range)
values(8	,'Job8'		,'2020-09-21 07:12:42'	,'2020-09-21 18:12:50'		,0		,1);
insert into Job(job_id, job_title, job_start, job_end, job_status, job_range)
values(9	,'Job9'		,'2020-09-21 08:12:20'	,'2020-09-23 08:30:00'		,0		,0);
insert into Job(job_id, job_title, job_start, job_end, job_status, job_range)
values(10	,'Job10'		,'2020-09-23 07:12:12'	,'2020-09-23 18:12:30'		,0		,0);
insert into Job(job_id, job_title, job_start, job_end, job_status, job_range)
values(11	,'Job11'		,'2020-09-25 09:10:11'	,'2020-09-25 19:12:00'		,0		,1);
insert into Job(job_id, job_title, job_start, job_end, job_status, job_range)
values(12	,'Job12'		,'2020-09-25 10:12:18'	,'2020-09-26 07:12:00'		,0		,0);


------JobEmployee
insert into JobEmployee(employee_id, job_id)
values(1	,1);
insert into JobEmployee(employee_id, job_id)
values(3	,1);
insert into JobEmployee(employee_id, job_id)
values(2	,2);
insert into JobEmployee(employee_id, job_id)
values(3	,2);
insert into JobEmployee(employee_id, job_id)
values(7	,2);
insert into JobEmployee(employee_id, job_id)
values(1	,3);
insert into JobEmployee(employee_id, job_id)
values(5	,3);
insert into JobEmployee(employee_id, job_id)
values(8	,4);
insert into JobEmployee(employee_id, job_id)
values(1	,5);
insert into JobEmployee(employee_id, job_id)
values(5	,5);
insert into JobEmployee(employee_id, job_id)
values(9	,6);
insert into JobEmployee(employee_id, job_id)
values(10	,6);
insert into JobEmployee(employee_id, job_id)
values(7	,7);
insert into JobEmployee(employee_id, job_id)
values(4	,8);
insert into JobEmployee(employee_id, job_id)
values(2	,9);
insert into JobEmployee(employee_id, job_id)
values(3	,9);
insert into JobEmployee(employee_id, job_id)
values(2	,10);
insert into JobEmployee(employee_id, job_id)
values(6	,10);
insert into JobEmployee(employee_id, job_id)
values(9	,11);
insert into JobEmployee(employee_id, job_id)
values(4	,12);
insert into JobEmployee(employee_id, job_id)
values(9	,12);


------Comment
insert into Comment(employee_id, job_id, comment)
values(9	,12		,'1');
insert into Comment(employee_id, job_id, comment)
values(1	,1		,'1');
insert into Comment(employee_id, job_id, comment)
values(3	,1		,'2');
insert into Comment(employee_id, job_id, comment)
values(2	,2		,'1');
insert into Comment(employee_id, job_id, comment)
values(7	,2		,'2');
insert into Comment(employee_id, job_id, comment)
values(3	,2		,'3');
insert into Comment(employee_id, job_id, comment)
values(2	,10		,'1');
insert into Comment(employee_id, job_id, comment)
values(6	,10		,'2');
insert into Comment(employee_id, job_id, comment)
values(4	,12		,'2');
insert into Comment(employee_id, job_id, comment)
values(2	,10		,'3');