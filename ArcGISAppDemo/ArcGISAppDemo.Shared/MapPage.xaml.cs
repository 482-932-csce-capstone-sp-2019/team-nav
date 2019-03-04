
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
       

            //add layers to BaseMap
            var uri = new Uri("http://gis.tamu.edu/arcgis/rest/services/FCOR/ADA_120717/MapServer");
            var layer = new ArcGISMapImageLayer(uri);
            bmap.BaseLayers.Add(layer);
            Map myMap = new Map(bmap);
            myMap.OperationalLayers.Add(new ArcGISMapImageLayer(new Uri("http://gis.tamu.edu/arcgis/rest/services/Routing/20190213/MapServer")));




           // Starts location display with auto pan mode set to Compass Navigation
            MyMapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.CompassNavigation;
            if (!MyMapView.LocationDisplay.IsEnabled)
                MyMapView.LocationDisplay.IsEnabled = true;

            MyMapView.Map = myMap;

        }

      


    }
}
