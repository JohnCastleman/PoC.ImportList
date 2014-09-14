using System;
using Caliburn.Micro.ReactiveUI;
using ReactiveUI;

namespace PoC.ImportList
{
    public class ImportViewModel : ReactiveConductor<RecordedEventViewModel>.Collection.OneActive
    {
        public ImportViewModel()
        {
            ViewContext = ViewContext.List;
            Items.AddRange(new[]
            {
                new RecordedEventViewModel {OfficerName = "Bob Smith", Started = new DateTime(2014, 9, 14, 7, 45, 19)}, 
                new RecordedEventViewModel {OfficerName = "John Gomer", Started = new DateTime(2014, 9, 15, 3, 04, 54)}, 
            });
        }

        ViewContext _viewContext;
        public ViewContext ViewContext
        {
            get { return _viewContext; }
            set { this.RaiseAndSetIfChanged(ref _viewContext, value); }
        }
    }

    public enum ViewContext
    {
        List, Details
    }
}
