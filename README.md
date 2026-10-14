![.Net](http://img.shields.io/badge/-Core%20v4.6-008999?style=flat-square&logo=.net&logoColor=ffffff) ![license](https://img.shields.io/github/license/anthueeccel/hackatonhf) ![date](http://img.shields.io/badge/August-25th%20and%2026th-333302?style=flat-square&logo=none&logoColor=442342)


# hackatonhf
_BeAlive_ is a project for an "panic button" App. Here you can find de ASP.NET MVC Web project. The Android App (Xamarin) wa
The idea of this project was concepted during a **Hackathon Health Shift on August 25th and 26th of 2018 @ SOCIESC University on Joinville/Brazil**.

This repository, **hackatonhf (BeAlive)**, is a web project created for a hackathon in August 2018. It serves as the backend and management dashboard for a "panic button" application (intended to work with a Xamarin Android app).

This is a **legacy ASP.NET Monolith** designed for quick prototyping.

---

### 1. Core Purpose
The system manages a "BeAlive" dashboard where alerts (labeled in the code as `Produtos` but functioning as emergency status reports) are tracked. It allows operators to see incoming requests, mark them as "Pendente" (Pending), "Em atendimento" (In service), or "Finalizado" (Finished).

### 2. Technology Stack
*   **Framework:** .NET Framework 4.6.1 (Legacy ASP.NET).
*   **Architectural Pattern:** 
    *   **Model-View-Controller (MVC 5):** Handles the web-based management dashboard.
    *   **Web API 2:** Provides a RESTful interface for the mobile app to communicate with.
*   **ORM:** Entity Framework 6 (EF6) using the **Code First** approach with Migrations.
*   **Database:** SQL Server (configured for both LocalDB and a remote Gear.Host instance).
*   **Frontend / UI:** 
    *   **Razor Views:** For server-side HTML rendering.
    *   **Bootstrap 4:** For responsive styling.
    *   **jQuery & AJAX:** Used to perform background checks (polling) for new alerts without refreshing the page (seen in `Index.cshtml`).
*   **Monitoring:** **Application Insights** is integrated for telemetry and error tracking.
*   **API Documentation:** Uses the built-in **HelpPage** area to automatically generate documentation for the endpoints.

---

### 3. Project Structure
This is a standard "all-in-one" ASP.NET project:

*   **`App_Start/`:** Contains the configuration for routing (`RouteConfig`), bundling CSS/JS (`BundleConfig`), and the API configuration (`WebApiConfig`).
*   **`Controllers/`:** 
    *   `ProdutosController.cs`: An **MVC Controller** that serves the HTML pages for the dashboard.
    *   `ProductsController.cs`: An **API Controller** (REST) that the mobile app likely uses to send panic signals.
*   **`Models/`:** Contains the `Produtos` class, which despite the name, stores `Nome`, `Idade`, `Status`, and `Mensagem` (emergency data).
*   **`Views/`:** HTML templates for Creating, Editing, and Viewing the status of the "products" (alerts).
*   **`Migrations/`:** Files that define the database schema and versioning.
*   **`Areas/HelpPage/`:** Auto-generated code that provides a website at `/help` describing how to use the API.

---

### 4. Key Functional Features
*   **Emergency Dashboard:** The main index page (`Produtos/Index.cshtml`) includes a JavaScript timer that uses AJAX to poll the server every few seconds to count how many "Pending" alerts exist.
*   **Panic Button Integration:** The `ProductsController` (API) allows external apps to POST new emergency alerts into the database.
*   **CORS Enabled:** The project is configured with Cross-Origin Resource Sharing (CORS), allowing the backend to accept requests from different domains (important for mobile/web integration).

### 5. Comparison to the Previous Project
| Feature | First Project (anthueeccel-firstone) | Second Project (hackatonhf) |
| :--- | :--- | :--- |
| **Platform** | .NET Core 3.1 (Modern) | .NET Framework 4.6.1 (Legacy) |
| **Architecture** | CQRS, DDD, Mediator (Decoupled) | MVC 5 / Web API 2 (Monolithic) |
| **ORM** | EF Core | EF 6 |
| **Mapping** | AutoMapper | Direct Model usage |
| **Project Goal** | Scalable Architecture Reference | Hackathon Prototype / MVP |

### Summary
This project is a classic **Full-Stack ASP.NET Monolith**. It is a simpler repository and is designed to get a functional UI and API up and running very quickly. It captures the typical "Hackathon" style: using familiar, robust tools to build a specialized management system (in this case, for health/security emergencies).
