
using demo_json_serialization.Commands;
using demo_json_serialization.Services;
using System;
using System.Collections.Generic;

namespace demo_json_serialization.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private bool firstLoad = true;

        public List<BaseViewModel> ContentViewModels { get; set; }

        private BaseViewModel currentViewModel;

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set { 
                currentViewModel = value;
                OnPropertyChanged();
            }
        }


        public DelegateCommand<BaseViewModel> ChangePageCommand { get; set; }

        public MainViewModel()
        {
            buildViewModels();
            buildCommands();
        }

        private void buildViewModels()
        {
            ContentViewModels = new List<BaseViewModel> {
                new PersonViewModel { Name = "People", DataService = PeopleDataService.Instance }, 
            };
        }

        private void buildCommands()
        {
            ChangePageCommand = new DelegateCommand<BaseViewModel>(ChangePage);
        }

        private void ChangePage(BaseViewModel vm)
        {
            if (firstLoad)
            {
                CurrentViewModel = vm;
            }
        }
    }
}