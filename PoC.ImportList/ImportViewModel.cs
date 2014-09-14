using System;
using System.Linq;
using Caliburn.Micro;
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
                new RecordedEventViewModel {Sequence = 1, OfficerName = "Tom Landry", Started = new DateTime(1960, 9, 14, 7, 45, 19)}, 
                new RecordedEventViewModel {Sequence = 2, OfficerName = "Jimmy Johnson", Started = new DateTime(1989, 9, 15, 3, 04, 54)}, 
                new RecordedEventViewModel {Sequence = 3, OfficerName = "Barry Switzer", Started = new DateTime(1994, 9, 15, 3, 04, 54)}, 
                new RecordedEventViewModel {Sequence = 4, OfficerName = "Chan Gailey", Started = new DateTime(1998, 9, 15, 3, 04, 54)}, 
                new RecordedEventViewModel {Sequence = 5, OfficerName = "Dave Campo", Started = new DateTime(2000, 9, 15, 3, 04, 54)}, 
                new RecordedEventViewModel {Sequence = 6, OfficerName = "Bill Parcels", Started = new DateTime(2003, 9, 15, 3, 04, 54)}, 
                new RecordedEventViewModel {Sequence = 7, OfficerName = "Wade Phillips", Started = new DateTime(2007, 9, 15, 3, 04, 54)}, 
                new RecordedEventViewModel {Sequence = 8, OfficerName = "Jason Gerrett", Started = new DateTime(2010, 9, 15, 3, 04, 54)}, 
            });

            if (Execute.InDesignMode)
            {
                ActivateItem(Items.First());
            }
        }

        public void Details(RecordedEventViewModel model)
        {
            ActivateItem(model);
            ViewContext = ViewContext.Details;
        }

        public void List()
        {
            ViewContext = ViewContext.List;
        }

        public void Previous()
        {
            int indexOfActiveItem = Items.IndexOf(ActiveItem);
            if(indexOfActiveItem > 0)
                ActivateItem(Items[indexOfActiveItem-1]);
        }

        public void Next()
        {
            int indexOfActiveItem = Items.IndexOf(ActiveItem);
            if (indexOfActiveItem < Items.Count-1)
                ActivateItem(Items[indexOfActiveItem + 1]);
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
