using System.Collections.ObjectModel;
using TimeTrakcer.Wpf.Common;

namespace TimeTrakcer.Wpf.ViewModel
{
    public class ViewModel : ObservableObject
    {
        #region private
        private string _greetings = "Hello";
        #endregion
        public ObservableCollection<string> AllTasks { get; set; }
        public string Greetings
        {
            get { return _greetings; }
            set
            {
                _greetings = value;
                RaisePropertyChanged("Greetings");
            }
        }

        public ViewModel()
        {
            AllTasks = new ObservableCollection<string>()
            {
                "dsadsa",
                "sample",

            };
        }
    }
}
