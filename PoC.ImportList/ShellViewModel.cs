using Caliburn.Micro.ReactiveUI;

namespace PoC.ImportList
{
    public class ShellViewModel : ReactiveConductor<ImportViewModel>, IShell
    {
        public ShellViewModel()
        {
            DisplayName = "Import";
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            ActivateItem(new ImportViewModel());
        }
    }
}