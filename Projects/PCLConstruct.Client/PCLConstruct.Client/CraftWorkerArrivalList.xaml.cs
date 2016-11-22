using Xamarin.Forms;

namespace PCLConstruct.Client
{
    public partial class CraftWorkerArrivalList : ContentPage
    {
        public CraftWorkerArrivalList()
        {
            InitializeComponent();

            this.BindingContext = new[] { "a", "b", "c" };
        }

        public void OnJobItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e == null) return; // has been set to null, do not 'process' tapped event
            ((ListView)sender).SelectedItem = null; // de-select the row
        }
    }
}
