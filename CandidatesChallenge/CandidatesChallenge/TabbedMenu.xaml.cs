using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CandidatesChallenge
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedMenu : TabbedPage
    {
        public TabbedMenu()
        {
            InitializeComponent();
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetIsSwipePagingEnabled(this, false);
        }
    }
}