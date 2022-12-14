# Downstream - ASP.NET Core IT Ticketing System

This is a work in progress project for CodeLouisville's Software Development II course. While I will continue to work on this as a personal project, as of 11/17/22 this meets the requirements for the course. This program lets the user create a IT support ticket and then modify it as needed. 

Currently needs to run on Windows based system. On startup when no Tickets are found in the database, AppDbInitializer will seed the database with 2 sample tickets for the user to view and modify. There is currently a basic logging system to determine if the Create action in the TicketsController was successful or not.  The information will be saved at "C:\Downstream Logs\CreateLog.txt".

## Requirements
 -  You must create at least one class, then create at least one object of that class and populate it with data from a database. You must use or display the data in your application. You are only required to have 1 table (one entity).
 - Create and call at least 3 functions or methods, at least one of which must return a value that is used in your application.
 - Choose at least 3 items on the Features List below and implement them in your project
## Chosen Features from Project Requirements Document
 - Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program
 - Make your application asynchronous
 - Add comments to your code explaining how you are using at least 2 of the solid principles
 - Implement a log that records errors, invalid inputs, or other important events and writes them to a text file

