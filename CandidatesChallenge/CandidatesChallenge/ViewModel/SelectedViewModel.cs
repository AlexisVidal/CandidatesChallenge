using CandidatesChallenge.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CandidatesChallenge.ViewModel
{
    public class SelectedViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Candidates> selectedCandidatesList;
        public ObservableCollection<Candidates> SelectedCandidatesList
        {
            get { return selectedCandidatesList; }
            set
            {
                if (selectedCandidatesList != value)
                {
                    selectedCandidatesList = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
