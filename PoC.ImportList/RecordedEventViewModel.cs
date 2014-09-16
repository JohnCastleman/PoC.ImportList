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
            ShouldImport = true;
            if (Execute.InDesignMode)
            {
                Sequence = 1;
                OfficerName = "Bob Smith";
                Started = new DateTime(2014, 9, 14, 7, 45, 19);
            }
        }

        int _sequence;
        public int Sequence
        {
            get { return _sequence; }
            set { this.RaiseAndSetIfChanged(ref _sequence, value); }
        }

        bool _shouldImport;
        public bool ShouldImport
        {
            get { return _shouldImport; }
            set { this.RaiseAndSetIfChanged(ref _shouldImport, value); }
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