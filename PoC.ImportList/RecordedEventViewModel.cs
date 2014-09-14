using System;
using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;
using ReactiveUI;

namespace PoC.ImportList
{
    public class RecordedEventViewModel : ReactiveScreen
    {
        public RecordedEventViewModel()
        {
            if (Execute.InDesignMode)
            {
                OfficerName = "Bob Smith";
                Started = new DateTime(2014, 9, 14, 7, 45, 19);
            }
        }

        string _officerName;
        public string OfficerName
        {
            get { return _officerName; }
            set { this.RaiseAndSetIfChanged(ref _officerName, value); }
        }

        DateTime _started;
        public DateTime Started
        {
            get { return _started; }
            set { this.RaiseAndSetIfChanged(ref _started, value); }
        }
    }
}