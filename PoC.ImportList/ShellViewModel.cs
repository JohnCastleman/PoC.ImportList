using System.Linq;
using Caliburn.Micro;
using Caliburn.Micro.ReactiveUI;

namespace PoC.ImportList
{
    public class ShellViewModel : ReactiveConductor<IScreen>, IShell
    {
        public ShellViewModel()
        {
            DisplayName = "Import";
            ImportList = new ImportViewModel();

            if (Execute.InDesignMode)
            {
                ActivateItem(ImportList);
            }
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            ActivateItem(ImportList);
        }

        public void Import()
        {
            var importProgress = new ImportProgressViewModel();
            importProgress.EventsToImport.AddRange(ImportList.Items.Where(x => x.ShouldImport));
            ActivateItem(importProgress);
        }

        public ImportViewModel ImportList { get; private set; }
    }
}