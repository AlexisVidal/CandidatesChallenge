using CandidatesChallenge.Model;
using CandidatesChallenge.Services;
using CandidatesChallenge.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CandidatesChallenge
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CandidatesPage : ContentPage
    {
        CandidatesViewModel viewmodel;
        //public ObservableCollection<Candidates> candidates;       
        public CandidatesPage()
        {
            InitializeComponent();
            viewmodel = new CandidatesViewModel();
            this.BindingContext = viewmodel;
        }
        protected override async void OnAppearing()
        {
            viewmodel.TechnologiesList = await GetTechsAsync();
            viewmodel.CandidatesList = await GetCandidatesAsync();
            viewmodel.tempCandidates = viewmodel.CandidatesList;
            base.OnAppearing();
        }
        
        private async Task<List<Technologies>> GetTechsAsync()
        {
            try
            {
                List<Technologies> techList = new List<Technologies>();
                HttpClient client = new HttpClient();
                Uri uri = new Uri(string.Format("https://app.ifs.aero/EternalBlue/api/technologies", string.Empty));
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    techList = JsonConvert.DeserializeObject<List<Technologies>>(content);
                }

                return techList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        private async Task<ObservableCollection<Candidates>> GetCandidatesAsync()
        {
            try
            {
                List<Candidates> candiList = new List<Candidates>();
                HttpClient client = new HttpClient();
                Uri uri = new Uri(string.Format("https://app.ifs.aero/EternalBlue/api/candidates", string.Empty));
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var _candiList = JsonConvert.DeserializeObject<List<Candidates>>(content);
                    if (_candiList.Any())
                    {
                        foreach (var item in _candiList)
                        {
                            if (item.experience.Any() && viewmodel.TechnologiesList.Any())
                            {
                                foreach (var itemx in item.experience)
                                {
                                    string _guid = itemx.technologyId;
                                    string _nametech = viewmodel.TechnologiesList.Where(x => x.guid.Equals(_guid)).Select(y => y.name).FirstOrDefault();
                                    if (_nametech != null)
                                    {
                                        itemx.technologyName = _nametech;
                                    }
                                    else
                                    {
                                        itemx.technologyName = "";
                                    }
                                }
                            }
                            candiList.Add(item);
                        }
                    }
                }
                ObservableCollection<Candidates> myList = new ObservableCollection<Candidates>(candiList);
                return myList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}