using System.Windows.Input;
using ReactiveUI;

namespace GridTest.ViewModels;

public class TileViewModel : ViewModelBase
{
    // the TileViewModel represents a node or vertex in the graph
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
    
    private bool _isWall;
    public bool IsWall
    {
        get => _isWall;
        set => this.RaiseAndSetIfChanged(ref _isWall, value);
    }

    private bool _isStartNode;
    public bool IsStartNode
    {
        get => _isStartNode;
        set => this.RaiseAndSetIfChanged(ref _isStartNode, value);
    }
    
    private bool _isEndNode;
    public bool IsEndNode
    {
        get => _isEndNode;
        set => this.RaiseAndSetIfChanged(ref _isEndNode, value);
    }
    
    public ICommand ToggleWallCommand { get; }
    
    public TileViewModel()
    {
        ToggleWallCommand = ReactiveCommand.Create<object>(_ =>
        {
            IsWall = !IsWall;
            System.Console.WriteLine($"Toggled wall at {X}, {Y}");
        });
    }
}