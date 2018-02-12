# FDWH

Real-Time Financial Data Warehouse

The Executives of ABC University wants to know the financial condition of their organization. The executives need such a repository in which most recent data is available from different departments for analysis. For this we need to develop a Real-Time DWH having most recent data for effective decision making.

A DWH collects the data from multiple operational source systems (OLTP – On-Line Transaction Processing) and stores it in a central repository, which is further used for analysis. However traditionally, the data in DWH is loaded periodically – typically in a daily, weekly or even monthly basis which means that its data is not up-to-date. The data which is saved in OLTP between those time periods (when data is loaded) is not included in reports generated for analysis from DWH.

Real-Time DWH is a solution of this problem as it provides the most recent data for analysis.  When any data is entered in OLTP, It is reflected in the repository of Real-Time DWH. We have to perform ETL process at the moment of insertion of any new record in OLTP. It is done with the special techniques. 

Pre-requisite:

Student should have the strong concepts of Databases and Data warehouse

Functional Requirements:
1.	This is a desktop application 
2.	There are two users of this application, Admin and Executive.
3.	Admin can add or remove any Executive.
4.	Different departments in the university are using their own databases (OLTPs) to store the information according to their need. 

4.1.	Accounts department stores the information of revenue such as fees submitted by  the students and money earned by the selling of the software products developed by its software house.

4.2.	Finance department stores the information about the expenses of the university such as salaries of employees, utility bills, furniture, electrical and electronic devices.  

4.3.	Registration department stores the information about the student’s bio data including the degrees in which they are enrolled. 

4.4.	HR department stores the information about the employees of the university (Faculty & Non Faculty). 

5.	All the departments (above) are using SQL server DBMS. 
6.	The star schema in this application will have the multiple fact tables.
7.	The procedure of ETL will took place at the time of insertion of any new record in OLTP. For this we will use triggers. (Student can use any other technique after getting the approval from his concerned supervisor).
8.	Executive has the interface to view different reports regarding expenses and revenue. 
8.1.	The executive will view the reports regarding expenses. For example he will be interested to see the total expenses or a particular type of expense in a particular time period etc.
8.2.	The executives will view the reports regarding revenue. 	For example he will be interested to view the total revenue or a particular type of revenue at the particular time period etc. 
9.	Reports will be generated on run time on the basis of different parameters given by the particular executive. Parameters have been discussed above in section 4.1, 4.2, 4.3 and 4.4 
10.	Interface must provide the facility to Drill Down and Roll UP Operations.   

Tools: Microsoft.Net Framework / Java, SQL Server

(UDW.Zip file contains vs2013 Complete Project source folder along with DB's.)
