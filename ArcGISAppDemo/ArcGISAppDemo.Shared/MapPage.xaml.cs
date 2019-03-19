
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
        private SystemLocationDataSource slds;
        public ChangeBasemap()
        {
            InitializeComponent();

            Title = "Change basemap";

            // Create the UI, setup the control references and execute initialization
            Initialize();
        }

       
        private async void Initialize()
        {
            // Create new Map with basemap
            var bmap = Basemap.CreateTopographic();
       

            //add layers to BaseMap
            var uri = new Uri("http://gis.tamu.edu/arcgis/rest/services/FCOR/ADA_120717/MapServer");
            var layer = new ArcGISMapImageLayer(uri);
            bmap.BaseLayers.Add(layer);
            Map myMap = new Map(bmap);
            myMap.OperationalLayers.Add(new ArcGISMapImageLayer(new Uri("http://gis.tamu.edu/arcgis/rest/services/Routing/20190213/MapServer")));

            //set location
            slds = new SystemLocationDataSource();
            
            await slds.StartAsync();
            slds.LocationChanged += Slds_LocationChanged;


           // Starts location display with auto pan mode set to Compass Navigation
            MyMapView.LocationDisplay.AutoPanMode = LocationDisplayAutoPanMode.CompassNavigation;
            if (!MyMapView.LocationDisplay.IsEnabled)
                MyMapView.LocationDisplay.IsEnabled = true;

            MyMapView.Map = myMap;

        }

        private  void Slds_LocationChanged(object sender, Location e)
        {

            if (e.Position == null)
            {
                return;
            }

            // Unsubscribe from further events; only want to zoom to location once.
           // slds.LocationChanged -= Slds_LocationChanged;
            label.Text = ("Lat: "+ e.Position.X + "\tLong: " + e.Position.Y);

           
        }
    }
}
