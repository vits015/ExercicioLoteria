using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioLoteria.Logica
{
    public static class Logic
    {
        public static int GetQuantityOfPlayers()
        {
            Console.WriteLine("Quantos jogadores irão usar o sistema?");
            return Int32.Parse(Console.ReadLine()!);
        }
        public static string GetPlayerName(int i)
        {
            Console.WriteLine($"Digite o nome do jogador {i}");
            //adicionar validações
            return Console.ReadLine()!;
        }
        public static (int QuantityOfGames, int Change) GetQuantityOfGamesAndChange()
        {
            Console.WriteLine("Digite o valor que deseja jogar!");
            string value = Console.ReadLine()!;
            //colocar para só exibir o troco se for maior que zero
            var result = (Int32.Parse(value) / 5, Int32.Parse(value) % 5);
            if (result.Item2 > 0)
            {
                Console.WriteLine($"Com esse valor vai dar para realizar {result.Item1} jogos e ainda vai sobrar {result.Item2} reais");
            }
            else
            {
                Console.WriteLine($"Com esse valor da pra realizar {result.Item1} jogos!");
            }
            return result;
        }
        public static List<Game> RandomizeGames(int QuantityOfGames)
        {
            int[] possibleNumbers = new int[60];
            for (int i = 1; i <= 60; i++)
            {
                possibleNumbers[i - 1] = i;
            }
            List<Game> GameList = new List<Game>();
            for (int i = 0; i < QuantityOfGames; i++)
            {
                Random randomization = new Random();
                Game game = new Game();
                game.Id = i;
                game.SortedNumbers = new int[6];
                for (int j = 0; j < 6; j++)
                {
                    bool temNaLista = true;
                    int randomNumber = 0;
                    while (temNaLista == true)
                    {
                        temNaLista = false;
                        randomNumber = possibleNumbers[randomization.Next(59)];
                        foreach (var number in game.SortedNumbers)
                        {
                            if (randomNumber == number)
                            {
                                temNaLista = true;
                                break;
                            }
                        }
                    }
                    game.SortedNumbers[j] = randomNumber;
                }
                GameList.Add(game);
            }
            return GameList;
        }
        public static void WriteFile(Player player, string path)
        {
            using (StreamWriter writer = new StreamWriter(
                                                Path.Combine(path, $"{player.Name}'s Games.txt")
                                                , append: true))
            {
                writer.WriteLine($"Player: {player.Name}");
                foreach (var game in player.Games)
                {
                    writer.WriteLine($"Game {game.Id + 1}:");
                    for (int n = 0; n < game.SortedNumbers.Length; n++)
                    {
                        writer.Write($"{game.SortedNumbers[n]} | ");
                    }
                    writer.WriteLine(" ");
                }
            }
        }
        public static string CreateDirectory()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Games");
            DirectoryInfo directory = new DirectoryInfo(path);
            if (directory.Exists)
            {
                directory.Delete(true);
            }
            Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Games"));
            return path;
        }

    }
}