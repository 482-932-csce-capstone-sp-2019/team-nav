
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Xamarin.Forms;
using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Location;

namespace ArcGISAppDemo
{
    public partial class ChangeBasemap : ContentPage
    {
        

        public ChangeBasemap()
        {
            InitializeComponent();

            Title = "Change basemap";

            // Create the UI, setup the control references and execute initialization
            Initialize();
        }

        

        private void Initialize()
        {
            // Create new Map with basemap
            var bmap = Basemap.CreateTopographic();
       


            var uri = new Uri("http://gis.tamu.edu/arcgis/rest/services/FCOR/ADA_120717/MapServer");
            var layer = new ArcGISMapImageLayer(uri);
            bmap.BaseLayers.Add(layer);
            Map myMap = new Map(bmap);
            myMap.OperationalLayers.Add(new ArcGISMapImageLayer(new Uri("http://gis.tamu.edu/arcgis/rest/services/Routing/20190213/MapServer")));
            //myMap.OperationalLayers.Add(layer);

            //sets initial location
            myMap.InitialViewpoint = new Viewpoint(30.6158, -96.3368, 2000);
            MyMapView.LocationDisplay.IsEnabled = true;
            MyMapView.Map = myMap;
           
        }
    }
}
