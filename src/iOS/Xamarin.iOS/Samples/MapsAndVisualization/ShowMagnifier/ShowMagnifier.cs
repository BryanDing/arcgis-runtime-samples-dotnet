﻿// Copyright 2016 Esri.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at: http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an 
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific 
// language governing permissions and limitations under the License.

using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI.Controls;
using Foundation;
using UIKit;

namespace ArcGISRuntimeXamarin.Samples.ShowMagnifier
{
    [Register("ShowMagnifier")]
    public class ShowMagnifier : UIViewController
    {
        // Constant holding offset where the MapsAndVisualization control should start
        private const int yPageOffset = 60;

        // Create and hold reference to the used MapsAndVisualization
        private MapsAndVisualization _myMapsAndVisualization = new MapsAndVisualization();

        public ShowMagnifier()
        {
            Title = "Show magnifier";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Create the UI, setup the control references and execute initialization 
            CreateLayout();
            Initialize();
        }

        public override void ViewDidLayoutSubviews()
        {
            // Setup the visual frame for the MapsAndVisualization
            _myMapsAndVisualization.Frame = new CoreGraphics.CGRect(0, 0, View.Bounds.Width, View.Bounds.Height);

            base.ViewDidLayoutSubviews();
        }

        private void Initialize()
        {
            // Create new Map with basemap and initial location
            Map myMap = new Map(BasemapType.Topographic, 34.056295, -117.195800, 10);

            // Enable magnifier
            _myMapsAndVisualization.InteractionOptions.IsMagnifierEnabled = true;

            // Assign the map to the MapsAndVisualization
            _myMapsAndVisualization.Map = myMap;
        }

        private void CreateLayout()
        {
            // Add MapsAndVisualization to the page
            View.AddSubviews(_myMapsAndVisualization);
        }
    }
}