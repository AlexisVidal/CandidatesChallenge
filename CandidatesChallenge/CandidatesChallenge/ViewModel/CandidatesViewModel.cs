using CandidatesChallenge.Model;
using CandidatesChallenge.Services;
using MLToolkit.Forms.SwipeCardView.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CandidatesChallenge.ViewModel
{
    public class CandidatesViewModel : INotifyPropertyChanged
    {
        public static List<Candidates> AcceptedCandidates = new List<Candidates>();
        SelectedViewModel selectedviewmodel;
        public CandidatesViewModel()
        {
            SwipedCommand = new Command<SwipedCardEventArgs>(OnSwipedCommand);
            AcceptedCandidates = new List<Candidates>();
            selectedviewmodel = new SelectedViewModel();
        }
        public ICommand SwipedCommand { get; }
        private void OnSwipedCommand(SwipedCardEventArgs eventArgs)
        {
            if (eventArgs.Direction.Equals(MLToolkit.Forms.SwipeCardView.Core.SwipeCardDirection.Left))
            {
                var _candidate = (Candidates)eventArgs.Item;
                AcceptedCandidates.Add(_candidate);
                var _remove = this.CandidatesList.FirstOrDefault(x => x.candidateId.Equals(_candidate.candidateId));
                this.CandidatesList.Remove(_remove);
                Acr.UserDialogs.UserDialogs.Instance.Toast("Candidate Selected!", new TimeSpan(3));
                ObservableCollection<Candidates> newList = new ObservableCollection<Candidates>(AcceptedCandidates);
            }
        }
        
        

        public ObservableCollection<Candidates> tempCandidates = new ObservableCollection<Candidates>();
        string techselected = "";
        int years = 0;

        ObservableCollection<Candidates> candidatesList;
        public ObservableCollection<Candidates> CandidatesList
        {
            get { return candidatesList; }
            set
            {
                if (candidatesList != value)
                {
                    candidatesList = value;
                    OnPropertyChanged();
                }
            }
        }

        List<Technologies> technologiesList;
        public List<Technologies> TechnologiesList
        {
            get { return technologiesList; }
            set
            {
                if (technologiesList != value)
                {
                    technologiesList = value;
                    OnPropertyChanged();
                }
            }
        }

        private string yearsValue;
        public string YearsValue
        {
            get { return yearsValue; }
            set
            {
                yearsValue = value;
                if (yearsValue!="")
                {
                    years = Convert.ToInt32(yearsValue);
                    if (tempCandidates != null)
                    {
                        List<Candidates> xtempCandidates = new List<Candidates>();
                        techselected = selectedTechnologie.guid;
                        if (years == 0)
                        {
                            xtempCandidates = tempCandidates.Where(x => x.experience.Any(y => y.technologyId.Equals(techselected))).ToList();
                        }
                        else
                        {
                            xtempCandidates = tempCandidates.Where(x => x.experience.Any(y => y.technologyId.Equals(techselected) && y.yearsOfExperience >= years)).ToList();
                        }
                        if (tempCandidates != null)
                        {
                            ObservableCollection<Candidates> myList = new ObservableCollection<Candidates>(xtempCandidates);
                            CandidatesList = myList;
                        }
                    }
                }
                RaisePropertyChanged();
            }
        }
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handle = PropertyChanged;
            if (handle != null)
                handle(this, new PropertyChangedEventArgs(propertyName));
        }

        Technologies selectedTechnologie;
        public Technologies SelectedTechnologie
        {
            get { return selectedTechnologie; }
            set
            {
                if (selectedTechnologie != value)
                {
                    selectedTechnologie = value;
                    OnPropertyChanged();
                    if (tempCandidates != null)
                    {
                        List<Candidates> xtempCandidates = new List<Candidates>();
                        techselected = selectedTechnologie.guid;
                        if (years==0)
                        {
                            xtempCandidates = tempCandidates.Where(x => x.experience.Any(y => y.technologyId.Equals(techselected))).ToList();
                        }
                        else
                        {
                            xtempCandidates = tempCandidates.Where(x => x.experience.Any(y => y.technologyId.Equals(techselected) && y.yearsOfExperience >= years)).ToList();
                        }
                        if (tempCandidates != null)
                        {
                            ObservableCollection<Candidates> myList = new ObservableCollection<Candidates>(xtempCandidates);
                            CandidatesList = myList;
                        }
                    }
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
