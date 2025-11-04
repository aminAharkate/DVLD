namespace DVLD_SharedModels
{
    public   class clsPersonDTO
    {
        public clsPersonDTO(int? personID, string firstName, string lastName, string nationalID, string imagePath,
                         bool gender, DateTime dateOfBirth, int nationalityCountryID, string phone, string email, string address)
        {
            this.PersonID = personID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.NationalID = nationalID;
            this.ImagePath = imagePath;
            this.Gender = gender;
            this.DateOfBirth = dateOfBirth;
            this.NationalityCountryID = nationalityCountryID;
            this.Phone = phone;
            this.Email = email;
            this.Address = address;
        }

        public int? PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalID { get; set; }
        public string ImagePath { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NationalityCountryID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }
}
