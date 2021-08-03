using System;
using System.Collections.Generic;
using System.Text;

namespace CandidatesChallenge.Model
{
    public class Candidates
    {
        public string candidateId { get; set; }
        public string fullName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int gender { get; set; }
        public string profilePicture { get; set; }
        public string email { get; set; }
        public string favoriteMusicGenre { get; set; }
        public string dad { get; set; }
        public string mom { get; set; }
        public bool canSwim { get; set; }
        public string barcode { get; set; }
        public List<Experience> experience { get; set; }
        public string color { get; set; }
        public string sgender
        {
            get
            {
                string ngender = "";
                if (gender == 0)
                {
                    ngender = "Male";
                }
                else 
                {
                    ngender = "Female";
                }
                return ngender;
            }
            set
            {
            }
        }

    }
    public class Experience
    {
        public string technologyId { get; set; }
        public string technologyName { get; set; }
        public int yearsOfExperience { get; set; }
    }
}
