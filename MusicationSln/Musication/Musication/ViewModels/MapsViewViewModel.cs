using Musication.Model.Security;
using Musication.Services.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms.Maps;

namespace Musication.ViewModels
{
    public class MapsViewViewModel : ViewModelBase
    {
        private IMapping _mappingService;

        readonly ObservableCollection<Location> _locations;

        public IEnumerable Locations => _locations;


        private DelegateCommand _addLocationCommand;
        public DelegateCommand AddLocationCommand =>
            _addLocationCommand ?? (_addLocationCommand = new DelegateCommand(ExecuteAddLocation));
        private DelegateCommand _removeLocationCommand;

        public DelegateCommand RemoveLocationCommand =>
            _removeLocationCommand ?? (_removeLocationCommand = new DelegateCommand(ExecuteRemoveLocation));

        private DelegateCommand _clearLocationCommand;
        public DelegateCommand ClearLocationsCommand =>
    _clearLocationCommand ?? (_clearLocationCommand = new DelegateCommand(ExecuteClearLocation));


        private DelegateCommand _updateLocationCommand;
        public DelegateCommand UpdateLocationCommand =>
    _updateLocationCommand ?? (_updateLocationCommand = new DelegateCommand(ExecuteUpdateLocations));

        private DelegateCommand _replaceLocationCommand;
        public DelegateCommand ReplaceLocationCommand =>
        _replaceLocationCommand ?? (_replaceLocationCommand = new DelegateCommand(ExecuteReplaceLocation));


        public MapsViewViewModel(INavigationService navigationService) : base(navigationService)
        {
            _locations = new ObservableCollection<Location>()
            {
                new Location("Delft", "Sekunjalo Music Academy", new Position(-33.960231, 18648785)),
                new Location("Cnr of Juno Street & Mitchell Avenue", "Mitchells Plain Music Academy", new Position(-34.035998, 18.599231)),
                new Location("Cape Town", "Cape Town Music Academy", new Position(-33.914773,  18.402393)),
                new Location("Cape Town City Centre","The Rainbow Academy", new Position(-33.922538,18.422539)),
                new Location("Langa","Bridges for Music Academy",new Position(-33.943858,18.528139)),
                new Location("Athlone", "The Athlone Academy of Music",new Position(-33.968046,18.502721))
            };

            //_mappingService = mapping;

            Title = "Maps for Musication";

        }

        private void ExecuteAddLocation()
        {
            _locations.Add(_mappingService.GetNewLocation());
        }

        private void ExecuteUpdateLocations()
        {
            if (!_locations.Any())
            {
                return;
            }

            double lastLatitude = _locations.Last().Position.Latitude;
            foreach (Location location in Locations)
            {
                location.Position = new Position(lastLatitude, location.Position.Longitude);
            }

        }

        private void ExecuteReplaceLocation()
        {
            if (!_locations.Any())
            {
                return;
            }

            _locations[_locations.Count - 1] = _mappingService.GetNewLocation();

        }

        private void ExecuteClearLocation()
        {
            _locations.Clear();
        }

        private void ExecuteRemoveLocation()
        {
            if (_locations.Any())
            {
                _locations.Remove(_locations.First());
            }
        }
    }
}

