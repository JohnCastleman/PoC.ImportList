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
                new RecordedEventViewModel {Sequence = 1, OfficerName = "Bob Smith", Started = new DateTime(2014, 9, 14, 7, 45, 19)}, 
                new RecordedEventViewModel {Sequence = 2, OfficerName = "John Gomer", Started = new DateTime(2014, 9, 15, 3, 04, 54)}, 
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
