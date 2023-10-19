using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace dobra3.Sdk.ViewModels
{
    public sealed partial class ScoreViewModel : ObservableObject
    {
        [ObservableProperty] private int _Score;
        [ObservableProperty] private int _ScoreIndex;

        public ObservableCollection<ScoreItemViewModel> Scores { get; }

        public ScoreViewModel()
        {
            Scores = new()
            {
                new() { Value = 500, IsCurrent = true },
                new() { Value = 1000 },
                new() { Value = 2000 },
                new() { Value = 5000 },
                new() { Value = 10000 },
                new() { Value = 20000 },
                new() { Value = 40000 },
                new() { Value = 75000 },
                new() { Value = 125000 },
                new() { Value = 250000 },
                new() { Value = 500000 },
                new() { Value = 1000000 },
            };
        }

        public void AddScore()
        {
            Score = Scores[ScoreIndex].Value;
            Scores[ScoreIndex++].IsCurrent = false;
            Scores[ScoreIndex].IsCurrent = true;
        }
    }

    public sealed partial class ScoreItemViewModel : ObservableObject
    {
        [ObservableProperty] private int _Value;
        [ObservableProperty] private bool _IsCurrent;
    }
}
