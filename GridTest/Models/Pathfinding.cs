using GridTest.ViewModels;

namespace GridTest.Models;

public class Pathfinding
{
    Algos algo = new Algos();
    public int Run(TileViewModel[,] grid, TileViewModel start, TileViewModel end, string algorithm)
    {
        if (algorithm == "BreadthFirst")
        {
            System.Console.WriteLine($"Breadth First: Start {start.X}, {start.Y} End {end.X}, {end.Y}");
            algo.BFS(grid, start, end);
        } else if (algorithm == "DepthFirst")
        {
            System.Console.WriteLine($"Depth First: Start {start.X}, {start.Y} End {end.X}, {end.Y}");
        } else if (algorithm == "Dijkstra")
        {
            System.Console.WriteLine($"Dijkstra: Start {start.X}, {start.Y} End {end.X}, {end.Y}");
        }

        return 0;
    }
}