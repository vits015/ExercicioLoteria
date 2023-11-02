using System.Diagnostics;
using System.Reflection.Metadata;
using ExercicioLoteria;
using ExercicioLoteria.Logica;

int LIMIT = Logic.GetQuantityOfPlayers();
string path = Logic.CreateDirectory();
for (int i = 1; i <= LIMIT; i++)
{
    string pName = Logic.GetPlayerName(i);
    var GamesAndChange = Logic.GetQuantityOfGamesAndChange();
    var numbersOfGames = Logic.RandomizeGames(GamesAndChange.QuantityOfGames);
    Player player = new Player()
    {
        Name = pName,
        Games = numbersOfGames
    };
    Logic.WriteFile(player, path);
    Process.Start("notepad.exe", Path.Combine(path, $"{player.Name}'s Games.txt"));
}
