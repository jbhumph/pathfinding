using System.Collections.ObjectModel;
using System.Windows.Input;
using GridTest.Models;
using ReactiveUI;

namespace GridTest.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    // this class is the primary view-model for the program
    public int Start { get; set;}
    public int End { get; set; }
    public ObservableCollection<TileViewModel> Tiles { get; } = new ObservableCollection<TileViewModel>();
    public ObservableCollection<string> Algorithms { get; } = new ObservableCollection<string>
    {
        "Dijkstra",
        "BreadthFirst",
        "DepthFirst"
    };
    
    private string _selectedAlgorithm = "Dijkstra";
    public string SelectedAlgorithm
    {
        get => _selectedAlgorithm;
        set => this.RaiseAndSetIfChanged(ref _selectedAlgorithm, value);
    }
    
    public ICommand StartCommand { get; }
    public ICommand ClearCommand { get; }
    
    private readonly Pathfinding _pathfinding = new Pathfinding();
    
    public MainWindowViewModel()
    {
        // constructor for view-model
        for (int i = 0; i < 20 * 20; i++)
        {
            Tiles.Add(new TileViewModel());
            Tiles[i].X = i % 20;
            Tiles[i].Y = i / 20;
            if (Tiles[i].X == 3 && Tiles[i].Y == 3)
            {
                Tiles[i].IsStartNode = true;
                Start = i;
                System.Console.WriteLine($"Start node at {Tiles[i].X}, {Tiles[i].IsStartNode}");
            }
            else if (Tiles[i].X == 16 && Tiles[i].Y == 16)
            {
                Tiles[i].IsEndNode = true;
                End = i;
            }
        }
        SelectedAlgorithm = Algorithms[0];
        StartCommand = ReactiveCommand.Create(OnStart);
        ClearCommand = ReactiveCommand.Create(OnClear);
    }
    
    private void OnStart()
    {
        // takes linear Tiles and creates multidimensional array to be used by algos, then runs program
        var grid = new TileViewModel[20, 20];
        foreach (var tile in Tiles)
        {
            grid[tile.X, tile.Y] = tile;
        }
        _pathfinding.Run(grid, Tiles[Start], Tiles[End], SelectedAlgorithm);
    }
    
    private void OnClear()
    {
        // resets the grid to starting point
        foreach (var tile in Tiles)
        {
            tile.IsVisited = false;
            tile.IsPath = false;
            tile.IsWall = false;
            tile.Distance = double.MaxValue;
            tile.Previous = null;
        }
    }
}