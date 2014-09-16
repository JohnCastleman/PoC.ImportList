using System;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;
using ReactiveUI;

namespace PoC.ImportList
{
    public class ImportProgressViewModel : ReactiveScreen
    {
        public ImportProgressViewModel()
        {
            EventsToImport = new ReactiveList<RecordedEventViewModel>();

            if (Execute.InDesignMode)
            {
                CurrentIndex = 2;
                EventsToImport.AddRange(new[]
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
            }
        }

        protected override async void OnActivate()
        {
            base.OnActivate();
            foreach (var eventToImport in EventsToImport)
            {
                CurrentIndex = EventsToImport.IndexOf(eventToImport) + 1;
                await ImportEvent(eventToImport);
            }
        }

        public Task ImportEvent(RecordedEventViewModel recordedEvent)
        {
            // Do some work
            return Task.Delay(2000);
        }

        public void Complete()
        {
            var shell = ((ShellViewModel)Parent);
            shell.ActivateItem(shell.ImportList);
        }

        public ReactiveList<RecordedEventViewModel> EventsToImport { get; private set; }

        int _currentIndex;
        public int CurrentIndex
        {
            get { return _currentIndex; }
            set { this.RaiseAndSetIfChanged(ref _currentIndex, value); }
        }
    }
}
