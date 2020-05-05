using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using WpfMailSender.Services;

namespace WpfMailSender.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
		private readonly IDataAccessService _dataService;
        private ObservableCollection<Email> _emails = new ObservableCollection<Email>();

        public ObservableCollection<Email> Emails
        {
            get => _emails;
            set
            {
                Set(ref _emails, value);
            }
        }
        private Email _currentEmail = new Email();
        private string _name;

        public Email CurrentEmail
        {
            get => _currentEmail;
            set => Set(ref _currentEmail, value);
        }

        public string Name
        {
            get => _name;
            set
            {
                GetEmails();
                var result  = new ObservableCollection<Email>(Emails.Where(e => e.Name.Contains(value)));
                Emails = result;
                _name = value;
            }
        }

        public RelayCommand<Email> SaveEmailCommand { get; }
        public RelayCommand ReadAllMailsCommand { get; }

        public MainViewModel(IDataAccessService dataService)
        {
            _dataService = dataService;
            ReadAllMailsCommand = new RelayCommand(GetEmails);
            SaveEmailCommand = new RelayCommand<Email>(SaveEmail);
        }

        private void SaveEmail(Email email)
        {
            email.Id = _dataService.CreateEmail(email);
            if (email.Id == 0) return;
            Emails.Add(email);
        }

        private void GetEmails() => Emails = _dataService.GetEmails();
	}
}