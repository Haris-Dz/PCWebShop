
# PC Web Shop

This project is a full-stack PC Web Shop application built with **.NET**, **Angular**, and **MySQL**. It allows users to browse and purchase PC components and offers a secure authentication system, product management, and order tracking.

## Table of Contents
1. [Project Setup](#2-project-setup)
2. [Features](#3-features)
3. [Technologies Used](#4-technologies-used)

## 2. Project Setup

Follow the steps below to set up the project on your local machine:

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Haris-Dz/PCWebShop.git
   ```

2. **Backend Setup (.NET Core API):**
   - Open the solution file (`PCWebShop.sln`) in Visual Studio.
   - Ensure you have the latest version of .NET Core SDK installed.
   - Restore NuGet packages:
     ```bash
     dotnet restore
     ```
   - Build the project:
     ```bash
     dotnet build
     ```
   - Run the backend server:
     ```bash
     dotnet run
     ```

3. **Frontend Setup (Angular App):**
   - Navigate to the frontend directory:
     ```bash
     cd PCWebShop/Frontend
     ```
   - Install the required dependencies:
     ```bash
     npm install
     ```
   - Run the Angular development server:
     ```bash
     ng serve
     ```
   - Open your browser and go to `http://localhost:4200` to view the app.

## 3. Features

The PC Web Shop App includes the following features:

- **Product Listings:** Display a wide range of PC components available for purchase.
- **User Authentication:** Secure login and registration for customers.
- **Shopping Cart:** Add products to the cart and proceed to checkout.
- **Order Management:** Manage customer orders and track status.
- **Admin Dashboard:** Admin functionality to manage products, users, and orders.
- **Search Functionality:** Search for products by category or name.
- **Responsive Design:** The app is optimized for both desktop and mobile devices.

## 4. Technologies Used

This project utilizes the following technologies:

- **Frontend:**  
  - Angular for building the user interface.
  - Bootstrap for responsive layout and styling.
  
- **Backend:**  
  - .NET Core for building the API and handling business logic.
  - Entity Framework for database interaction.

- **Database:**  
  - MySQL for storing and managing data such as products, users, and orders.

