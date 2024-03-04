using MauiStylesDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiStylesDemo.ViewModels
{
    public class FormValidationViewModel:ViewModelBase
    {
        #region שם
        private bool showNameError;

        public bool ShowNameError
        {
            get => showNameError;
            set
            {
                showNameError = value;
                OnPropertyChanged("ShowNameError");
            }
        }

        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                ValidateName();
                OnPropertyChanged("Name");
            }
        }

        private string nameError;

        public string NameError
        {
            get => nameError;
            set
            {
                nameError = value;
                OnPropertyChanged("NameError");
            }
        }

        private void ValidateName()
        {
            this.ShowNameError = string.IsNullOrEmpty(Name);
        }
        #endregion
        #region גיל
        private bool showAgeError;

        public bool ShowAgeError
        {
            get => showAgeError;
            set
            {
                showAgeError = value;
                OnPropertyChanged("ShowAgeError");
            }
        }

        private double? age;

        public double? Age
        {
            get => age;
            set
            {
                age = value;
                ValidateAge();
                OnPropertyChanged("Age");
            }
        }

        private string ageError;

        public string AgeError
        {
            get => ageError;
            set
            {
                ageError = value;
                OnPropertyChanged("AgeError");
            }
        }

        private void ValidateAge()
        {
            this.ShowAgeError = !Age.HasValue || Age <= 13;
        }
        #endregion

        #region  תאריך לידה
     
        private bool showYearError;
        public bool ShowYearError
        {
            get => showYearError;
            set
            {
                showYearError = value;
                OnPropertyChanged("ShowYearError");
            }
        }

        private DateTime yearOfBirth;
        public DateTime YearOfBirth
        {
            get => yearOfBirth;
            set
            {
                yearOfBirth = value;
                ValidateYearOfBirth();
                OnPropertyChanged("YearOfBirth");
            }
        }

        private string yearOfBirthError;
        public string YearOfBirthError
        {
            get => yearOfBirthError;
            set
            {
                yearOfBirthError = value;
                OnPropertyChanged("YearOfBirthError");
            }
        }

        private void ValidateYearOfBirth()
        {
            this.ShowYearError = !YearOfBirth.has || yearOfBirth < 2011;
        }
        #endregion


        public FormValidationViewModel()
        {
            this.NameError = "זהו שדה חובה";
            this.ShowNameError = false;
            this.AgeError = "הגיל חייב להיות גדול מ 13";
            this.ShowAgeError = false;
            this.YearOfBirthError = "שנת הלידה חייבת ליהיות ";
            this.YearOfBirthError = false;
            this.SaveDataCommand = new Command(() => SaveData());
        }

        //This function validate the entire form upon submit!
        private bool ValidateForm()
        {
            //Validate all fields first
            ValidateAge();
            ValidateName();

            //check if any validation failed
            if (ShowAgeError ||
                ShowNameError)
                return false;
            return true;
        }

        public Command SaveDataCommand { protected set; get; }
        private async void SaveData()
        {
            if (ValidateForm())
                await App.Current.MainPage.DisplayAlert("שמירת נתונים", "הנתונים נבדקו ונשמרו", "אישור", FlowDirection.RightToLeft);
            else
                await App.Current.MainPage.DisplayAlert("שמירת נתונים", "יש בעיה עם הנתונים", "אישור", FlowDirection.RightToLeft);
        }
    }
}
