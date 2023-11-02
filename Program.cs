using System.Diagnostics;
using System.Reflection.Metadata;
using ExercicioLoteria;
using ExercicioLoteria.Logica;

Console.WriteLine("Quantos jogadores irão usar o sistema?");
int LIMIT = Int32.Parse(Console.ReadLine()!);
string path = Logic.CreateDirectory();
for (int i = 1; i <= LIMIT; i++)
{
    Console.WriteLine($"Jogador nº {i}");
    string pName = Logic.GetPlayerName();
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
