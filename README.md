
# Employee & Department Management System

This system is designed to manage employees and departments efficiently using a clean architectural approach. It adopts a layered structure, separating concerns across **Presentation**, **Business Logic**, and **Data Access Layers** while leveraging Entity Framework Core for persistence.

---

## 🛠️ Features

### 🔹 Employee Management

- **CRUD Operations**: Add, update, view, and delete employees.
- **Employee Details**: Includes name, age, gender, salary, contact info, image, and employment type.
- **Department Association**: Each employee can be linked to a department.
- **Image Upload**: Employees can have profile images stored and managed.
- **Filtering/Status**: Track active/inactive employees.

### 🔹 Department Management

- **Department CRUD**: Add, edit, and remove departments.
- **Department Details**: Includes department name and description.
- **Linked Employees**: View all employees within a department.

### 🔹 Authentication & Security

- **ASP.NET Identity Integration**: Handles user registration, login, and password recovery.
- **Role-Based Access**: Restrict access to certain features (Admin/User roles).
- **Secure Routing**: All controllers use `[Authorize]` attributes for protected endpoints.

### 🔹 File Handling & Logging

- **Image Management**: Upload and store images with validation.
- **Logging**: Tracks activity and system events using built-in logging mechanisms.

---

## 📦 Project Structure

### 1. **Data Access Layer (DAL)**

> Located in `El-sheikh.MVC.DAL`

- **Entities**:  
  - `Employee.cs`: Represents employee data (Name, Salary, Gender, etc.).
  - `Department.cs`: Defines department structure.
  - `ApplicationUser.cs`: Extends Identity for custom user data.
- **DbContext**:  
  - `ApplicationDbContext.cs`: Manages EF Core interactions.
- **Repositories**:  
  - Generic & specific repositories (EmployeeRepository, DepartmentRepository) for data access logic.
- **Migrations**:  
  - Full EF Core migration history to track schema evolution.

### 2. **Business Logic Layer (BLL)**

> Located in `El-sheikh.MVC.BLL`

- **Services**:  
  - `DepartmentService`, `EmployeeService`: Handle business operations using Unit of Work and Repository patterns.
- **DTOs**:  
  - Transfer models like `EmployeeDto`, `DepartmentDto`, `CreatedEmployeeDto`, etc., used for mapping and validation.

### 3. **Presentation Layer (PL)**

> Located in `El-sheikh.MVC.PL`

- **Controllers**:  
  - `EmployeeController`, `DepartmentController`, `AccountController`: Handle user interaction and delegate tasks to services.
- **ViewModels**:  
  - Used for passing data between views and controllers with validation attributes.
- **Utilities**:  
  - `Email.cs`: Handles system email functionality (e.g., for password reset).
- **AutoMapper**:  
  - `MappingProfile.cs` configures DTO <=> Entity mappings.

---

## 🧩 Technologies Used

- **ASP.NET Core MVC 8.0**
- **Entity Framework Core**
- **SQL Server**
- **ASP.NET Identity**
- **AutoMapper**
- **Dependency Injection**
- **Repository & Unit of Work Patterns**

---

## 🔁 Application Flow

1. **User Authentication**: Users sign up/sign in using Identity.
2. **Dashboard Access**: Authorized users manage employees and departments.
3. **Form Submission**: Forms for employee/department creation with validation.
4. **Data Processing**: Handled by BLL via repositories.
5. **Database Update**: EF Core persists changes to the database.
6. **UI Update**: User sees updated employee/department lists or detailed views.

---

## ✅ Example Use Case

1. Admin logs in.
2. Navigates to the "Employees" section and creates a new employee.
3. Selects a department, uploads an image, and submits.
4. Data is validated, saved, and displayed in the employee list.
