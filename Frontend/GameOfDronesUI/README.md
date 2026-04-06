# Game of Drones - Technical Challenge

## How to run the project

### Backend (.NET)
1. Navigate to the `Backend` folder.
2. Open the solution in **Visual Studio**.
3. Press **F5** to run. 
   - *Note: The database and tables will be created automatically on startup (LocalDB).*
   - *Initial moves (Rock, Paper, Scissors) are seeded automatically.*

### Frontend (Angular)
1. Navigate to the `Frontend` folder.
2. Run `npm install` to download dependencies.
3. Run `ng serve` to start the web application.
4. Open `http://localhost:4200` in your browser.

## Technical Highlights
- **Runtime Rules:** Rules are fetched from the SQL database. You can add new moves (e.g., "Lizard" kills "Paper") directly in the `Moves` table without changing the code.
- **Persistence:** Game winners are tracked in the `Players` table.
- **Architecture:** Decoupled Frontend and Backend using a REST API with CORS enabled.