# Secure Task Manager - ASP.NET Core MVC

## Project Description

Secure Task Manager is an ASP.NET Core MVC web application developed as part of a coding challenge.  
The main goal of this project is to implement secure authentication, authorization, session management, and protection against common web vulnerabilities such as CSRF and XSS.

The application allows users to register, log in, access a dashboard, and view different pages based on their role. Admin users can access the task management page, while normal users can access their own task list.

---

## Technologies Used

- ASP.NET Core MVC
- C#
- Entity Framework Core
- ASP.NET Core Identity
- SQL Server / LocalDB
- Razor Views
- Bootstrap
- Visual Studio

---

## Features Implemented

### Authentication

- User registration
- User login
- User logout
- Password hashing using ASP.NET Core Identity
- Secure forms-based authentication

### Authorization

- Role-based authorization
- Admin role
- User role
- Claims-based authorization using `CanEditTask` claim
- Restricted access for unauthorized users

### Security Features

- Anti-forgery token protection for forms
- CSRF protection
- XSS protection using Razor output encoding
- Secure authentication cookies
- HttpOnly cookie setting
- Secure cookie policy
- SameSite cookie protection
- 15-minute session timeout
- Secure logout by clearing authentication cookies

---

## User Roles

### Admin

Admin can access:

```text
/Admin/ManageTasks
