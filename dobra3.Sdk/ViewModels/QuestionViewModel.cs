using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace dobra3.Sdk.ViewModels
{
    public sealed partial class QuestionViewModel : ObservableObject
    {
        [ObservableProperty] private string _Title;

        [ObservableProperty] private string _Description;
    }
}
