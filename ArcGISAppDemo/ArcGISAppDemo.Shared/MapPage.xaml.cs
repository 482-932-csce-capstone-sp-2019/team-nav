
using Esri.ArcGISRuntime.Location;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI;
using System;
using System.Linq;
using Xamarin.Forms;

namespace ArcGISAppDemo
{
    public partial class ChangeBasemap : ContentPage
    {
        private string[] _navigationTypes = {
            "On",
            "Re-Center",
            "Navigation",
            "Compass"
        };
        public ChangeBasemap()
        {
            InitializeComponent();

            Title = "Change basemap";

            // Create the UI, setup the control references and execute initialization
            Initialize();
        }

        

        private  void Initialize()
        {
            // Create new Map with basemap
            var bmap = Basemap.CreateTopographic();
       


            var uri = new Uri("http://gis.tamu.edu/arcgis/rest/services/FCOR/ADA_120717/MapServer");
            var layer = new ArcGISMapImageLayer(uri);
            bmap.BaseLayers.Add(layer);
            Map myMap = new Map(bmap);
            myMap.OperationalLayers.Add(new ArcGISMapImageLayer(new Uri("http://gis.tamu.edu/arcgis/rest/services/Routing/20190213/MapServer")));


            
            myMap.InitialViewpoint = new Viewpoint(30.6158, -96.3368, 2000);
            //myMap.InitialViewpoint = new Viewpoint(lat,lon , 2000);
            

            MyMapView.Map = myMap;

        }

        private void OnStopClicked(object sender, EventArgs e)
        {
            //TODO Remove this IsStarted check https://github.com/Esri/arcgis-runtime-samples-xamarin/issues/182
            if (MyMapView.LocationDisplay.IsEnabled)
                MyMapView.LocationDisplay.IsEnabled = false;
        }

        private async void OnStartClicked(object sender, EventArgs e)
        {
            // Starts location display with auto pan mode set to Compass Navigation
            MyMapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.CompassNavigation;

            //TODO Remove this IsStarted check https://github.com/Esri/arcgis-runtime-samples-xamarin/issues/182
            if (!MyMapView.LocationDisplay.IsEnabled)
                MyMapView.LocationDisplay.IsEnabled = true;
        }


    }
}
