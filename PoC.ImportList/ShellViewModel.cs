using System;
using Caliburn.Micro.ReactiveUI;

namespace PoC.ImportList
{
    public class ShellViewModel : ReactiveConductor<RecordedEventViewModel>.Collection.OneActive, IShell
    {
        public ShellViewModel()
        {
            Items.AddRange(new []
            {
                new RecordedEventViewModel {OfficerName = "Bob Smith", Started = new DateTime(2014, 9, 14, 7, 45, 19)}, 
                new RecordedEventViewModel {OfficerName = "John Gomer", Started = new DateTime(2014, 9, 15, 3, 04, 54)}, 
            });
        }

    }
}