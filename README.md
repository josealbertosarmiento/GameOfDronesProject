# 🛡️ Game of Drones - Battle Arena 🚀

![Angular](https://img.shields.io/badge/Angular-12.2.0-DD0031?style=for-the-badge&logo=angular&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-6.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-LocalDB-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

Esta es una solución **Full-Stack** desarrollada para la evaluación técnica de **Full-stack Developer** en **Alo People** El sistema implementa un simulador de combate de drones basado en reglas dinámicas, diseñado para demostrar habilidades en arquitectura, programación y análisis.

## 🌐 Demo en Vivo
👉 **[PEGA_AQUI_TU_URL_DE_GITHUB_PAGES]**

---

## 🛠️ Stack Tecnológico
* **Frontend:** Angular 12.2.0.
* **Backend:** .NET 6.0 Web API.
* **Persistencia:** SQL Server con Entity Framework Core.
* **Interfaz:** CSS3 (Glassmorphism) y Bootstrap 5.

---

## 🚀 Instrucciones de Ejecución Rápida
Para cumplir con el requisito de ejecución directa desde **Visual Studio** sin pasos adicionales[cite: 7, 105]:

### 1. Requisitos Previos
* [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0).
* [Node.js](https://nodejs.org/) (v14 o v16 recomendado para Angular 12).
* Visual Studio 2022.

### 2. Configuración del Backend (.NET)
1. Abra la solución `.sln` en **Visual Studio**.
2. Abra la **Consola del Administrador de Paquetes** (*Tools > NuGet Package Manager > Package Manager Console*).
3. Ejecute el comando para crear la base de datos automáticamente:
   ```powershell
   Update-Database
4. Presione F5 para iniciar la API.

### 3. Configuración del Frontend (Angular)

1. Navegue a la carpeta Frontend/GameOfDronesUI.
2. Instale las dependencias:
   ```powershell
   npm install
3. Inicie la aplicación:
    ```powershell
    npm start
4. Acceda a http://localhost:4200.
