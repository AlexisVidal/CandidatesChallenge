using CandidatesChallenge.Model;
using CandidatesChallenge.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CandidatesChallenge
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedPage : ContentPage
    {
        SelectedViewModel viewmodel;
        public ObservableCollection<Candidates> selectedCandidates;
        public SelectedPage()
        {
            InitializeComponent();
            viewmodel = new SelectedViewModel();
            this.BindingContext = viewmodel;
        }
        protected override async void OnAppearing()
        {
            var _xlist = CandidatesViewModel.AcceptedCandidates;
            if (_xlist != null)
            {
                if (_xlist.Any())
                {
                    //var _list = viewmodel.SelectedCandidatesList;
                    viewmodel.SelectedCandidatesList = new ObservableCollection<Candidates>(_xlist);
                }
                else
                {
                    viewmodel.SelectedCandidatesList = new ObservableCollection<Candidates>();
                }
            }
            else
            {
                viewmodel.SelectedCandidatesList = new ObservableCollection<Candidates>();
            }       
            base.OnAppearing();
        }
    }
}