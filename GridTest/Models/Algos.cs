using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using GridTest.ViewModels;

namespace GridTest.Models;

public class Algos
{

    public async Task BFS(TileViewModel[,] grid, TileViewModel start, TileViewModel end)
    // Breadth-First search for grid
    {
        var queue = new Queue<TileViewModel>();
        queue.Enqueue(start);
        start.IsVisited = true;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current == end)
            {
                MarkRoute(current);
                return;
            }

            foreach (var neighbor in GetNeighbors(current, grid))
            {
                if (!neighbor.IsVisited && !neighbor.IsWall)
                {
                    await Task.Delay(10);
                    neighbor.IsVisited = true;
                    neighbor.Previous = current;
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
    
    public async Task DFS(TileViewModel[,] grid, TileViewModel start, TileViewModel end)
    // Depth-First search for grid
    {
        var stack = new Stack<TileViewModel>();
        stack.Push(start);
        start.IsVisited = true;

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            if (current == end)
            {
                MarkRoute(current);
                return;
            }
            
            foreach (var neighbor in GetNeighbors(current, grid))
            {
                if (!neighbor.IsVisited && !neighbor.IsWall)
                {
                    await Task.Delay(10);
                    neighbor.IsVisited = true;
                    neighbor.Previous = current;
                    stack.Push(neighbor);
                }
            }
        }
    }
    
    public async Task Dijkstra(TileViewModel[,] grid, TileViewModel start, TileViewModel end)
    // Dijkstra search for grid
    {
        var unvisited = new List<TileViewModel>();
        foreach (var node in grid)
        {
            node.IsVisited = false;
            node.Distance = double.MaxValue;
            node.Previous = null;
            unvisited.Add(node);
        }
        System.Console.WriteLine("Test");
        start.Distance = 0;
        while (unvisited.Count > 0)
        {
            // get node with smallest distance
            var current = unvisited.OrderBy(x => x.Distance).First();
            var temp = unvisited.Remove(current);
            await Task.Delay(10);
            current.IsVisited = true;
            
            if (current.IsWall) continue;
            if (current.Distance == double.MaxValue) break;
            if (current == end)
            {
                
                MarkRoute(current);
                return;
            }

            
            // update distances of neighbors
            foreach (var neighbor in GetNeighbors(current, grid))
            {
                if (neighbor.IsWall) continue;
                
                double alt = current.Distance + 1;
                if (alt < neighbor.Distance)
                {
                    neighbor.Distance = alt;
                    neighbor.Previous = current;
                }
            }
        }
    }
    
    static List<TileViewModel> GetNeighbors(TileViewModel node, TileViewModel[,] grid)
        // returns all neighbors of node in a list
    {
        var neighbors = new List<TileViewModel>();
        var directions = new (int dx, int dy)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };

        foreach (var (dx, dy) in directions)
        {
            int nx = node.X + dx;
            int ny = node.Y + dy;
            
            if (nx >= 0 && ny >= 0 && nx < 20 && ny < 20) neighbors.Add(grid[nx, ny]);
        }
        
        return neighbors;
    }

    static async Task MarkRoute(TileViewModel end)
    {
        var current = end;
        while (current != null)
        {
            await Task.Delay(30);
            current.IsPath = true;
            current = current.Previous;
        }
    }
}