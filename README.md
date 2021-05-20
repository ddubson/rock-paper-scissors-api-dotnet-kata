# Rock, Paper, Scissors API Kata in .NET / C#

The goal is to create a Rock, Paper, Scissors API!

The natural progression of API endpoints to be built are:

1. Create a new game: `POST /game`
2. Play game: `POST /game/{game-id}/play`
   - [Game rules](http://agilekatas.co.uk/katas/RockPaperScissors-Kata)
3. Display score board: `GET /scoreboard`

## Operating manual:

- Fetch all dependencies: `dotnet restore`
- Start API locally: `dotnet run --project RockPaperScissorsApi`
- Run all tests: `dotnet test`