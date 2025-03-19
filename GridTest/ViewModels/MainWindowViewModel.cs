using System.Collections.ObjectModel;
using System.Windows.Input;
using GridTest.Models;
using ReactiveUI;

namespace GridTest.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public int Start { get; set;}
    public int End { get; set; }
    public ObservableCollection<TileViewModel> Tiles { get; } = new ObservableCollection<TileViewModel>();
    
    // Property that holds the available algorithms for the ComboBox.
    public ObservableCollection<string> Algorithms { get; } = new ObservableCollection<string>
    {
        "Dijkstra",
        "AStar",
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
    
    private readonly Pathfinding _pathfinding = new Pathfinding();
    
    
    
    public MainWindowViewModel()
    {
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

        
    }
    
    private void OnStart()
    {
        System.Console.WriteLine($"Selected algorithm: {SelectedAlgorithm}");
        
        var grid = new TileViewModel[20, 20];
        foreach (var tile in Tiles)
        {
            grid[tile.X, tile.Y] = tile;
        }
        
        var result = _pathfinding.Run(grid, Tiles[Start], Tiles[End], SelectedAlgorithm);


    }

    
    
}