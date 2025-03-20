# Pathfinding Visualizer

## Author:
John Humphrey

## Contents:
- [Author](#author)
- [Contents](#contents)
- [Overview](#overview)
- [Instructions](#instructions)
- [About](#about)
- [Dependencies](#dependencies)
- [Screenshots](#screenshots)


## Overview:
This is a Pathfinding Visualizer application. It was made by John Humphrey for CS 240 at WCC. 
It uses C# with Avalonia and incorporates a graph data structure. It then uses any number of algorithms to traverse the graph and find the shortest path.

## Instructions:
Currently there is not an installer for the program. The user will need to install dependencies and then compile and run from their preferred .NET workspace.

## About:
## About:
The Pathfinding Visualizer is a tool designed to demonstrate various pathfinding algorithms in action. It 
uses a custom graph data structure to model nodes in a grid-like layout and therefore edges are implied but not kept track of in the traditional sense. In this implementation, the graph is comprised solely of 
vertices; relationships between nodes are computed on-the-fly based on their relative positions, rather than being represented 
with explicit edge objects. This approach simplifies the graph structure and skips redundant or unnecessary data.

The graph itself is written out in a view-model as `TileViewModel.cs`. Here is a snippet from that representing the initialization of some of it's properties:
```c#
public int X { get; set; }
    public int Y { get; set; }
    public double Distance { get; set; } = double.MaxValue;
    public TileViewModel? Previous { get; set; }
    
    private bool _isVisited;
    public bool IsVisited
    {
        get => _isVisited;
        set => this.RaiseAndSetIfChanged(ref _isVisited, value);
    }

    private bool _isPath;
    public bool IsPath
    {
        get => _isPath;
        set => this.RaiseAndSetIfChanged(ref _isPath, value);
    }
```

Avalonia is the UI framework used to build this application, offering a cross-platform, XAML-based environment that integrates 
seamlessly with C#. In the program, Avalonia handles the presentation layer by defining visual components and binding them 
to the underlying C# logic. This enables dynamic and responsive interfaces where changes in the data (such as the progress 
of a pathfinding query) are reflected immediately on-screen, providing an intuitive and interactive visualization experience.

The application supports three primary traversal techniques: **Breadth-First Search (BFS)**, **Depth-First Search (DFS)**, and **Dijkstra’s algorithm**.
- **BFS** efficiently explores the graph by visiting neighboring nodes level-by-level, ensuring that the shortest path (in terms of the number of steps) is found in unweighted graphs.
- **DFS**, on the other hand, explores as far as possible along each branch before backtracking, which can be useful for maze-like puzzles or when a complete traversal is necessary.
- **Dijkstra’s algorithm** adds the dimension of weights to the graph traversal, calculating the shortest (or least costly) path in scenarios where different nodes or movements have varying costs. Because there is no weighting to any edges, Dijkstra's algorithm doesn't have as much to work with here and the algorithm behaves similarly to BFS.

Each of these techniques provides unique insights into algorithm design and performance, making the visualizer a helpful tool for both students and enthusiasts interested in the fundamentals of graph traversal.

## Dependencies:
- **.NET 9.0 SDK/Runtime:**  
  The project targets .NET 9.0. Users will need to have the appropriate .NET SDK installed to build and run the application.

- **Avalonia UI Framework:**  
  The application uses Avalonia for its cross-platform graphical user interface. Avalonia provides a rich, XAML-based UI framework that enables a consistent look and feel across multiple operating systems.

Please consult the project file (e.g., .csproj) for a complete list of dependencies and exact package versions.


## Screenshots:

![Screenshot 2025-03-20 at 3.06.40 PM.png](GridTest/Documentation/Screenshot%202025-03-20%20at%203.06.40%20PM.png)

![Screenshot 2025-03-20 at 3.07.59 PM.png](GridTest/Documentation/Screenshot%202025-03-20%20at%203.07.59%20PM.png)

![Screenshot 2025-03-20 at 3.09.26 PM.png](GridTest/Documentation/Screenshot%202025-03-20%20at%203.09.26%20PM.png)

![Screenshot 2025-03-20 at 3.09.53 PM.png](GridTest/Documentation/Screenshot%202025-03-20%20at%203.09.53%20PM.png)
