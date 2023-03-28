# Events Web Application

### Implementation Description
This project is a prototype, focusing on backend and database manipulations.<br>

Framework: **ASP.NET Core** <br>
Language: **C#** and **Razor Syntax** <br>
Database: **SQLite**<br>
Database Framework: **Entity Framework**<br>
IDE: **Visual Studio Community 2022** <br>
OS: **Windows 10** <br>
Database Browser: **DB Browser for SQLite**


### Database Tables:
- *Events* - collecting information about an event (ID as a primary key)
- *Participants* - colecting information about people registered for a certain event  (ID as a primary key; EventId as foreign key).<br>

For the simplicity current prototype allows only Admin User to login (credentials are hard-coded). In the future users information should be store in the database as well after the registration process. 

### Endpoints:

```
/Index
```
Application homepage. 
```
/Registration
```
Page for registering for an event. 
```
/Account/Login
```
Authentication Page.
```
/Account/Index
```
**Authorized** page for Admin User with information about registration and functionality to create new events.
```
/Account/Create
```
**Authorized** page for Admin User to create new events.
```
/Account/Logout
```
**Authorized** page for Admin User to log out from the account.


