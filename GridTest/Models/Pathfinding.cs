using GridTest.ViewModels;

namespace GridTest.Models;

public class Pathfinding
{
    Algos algo = new Algos();
    public void Run(TileViewModel[,] grid, TileViewModel start, TileViewModel end, string algorithm)
    {
        // this method takes the graph data structure and calls the appropriate algorithm based on user input
        if (algorithm == "BreadthFirst")
        {
            algo.BFS(grid, start, end);
        } else if (algorithm == "DepthFirst")
        {
            algo.DFS(grid, start, end);
        } else if (algorithm == "Dijkstra")
        {
            algo.Dijkstra(grid, start, end);
        }
    }
}