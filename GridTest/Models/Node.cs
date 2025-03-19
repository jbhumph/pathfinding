namespace GridTest.Models;

public class Node(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    public bool IsWall { get; set; }
    public bool IsVisited { get; set; }
    public double Distance { get; set; } = double.MaxValue;
    public Node? Previous { get; set; }
}