using System;
using System.Collections.Generic;
using System.Text;
using Client;


namespace Auction
{
    class Office : Property
    {
        
        public Office(bool AirConditioner, bool Protection, bool AccessToMainRoad, bool AccessForDisabled, int NumOfToiletCubicles, int NumOfDiningAreas, string Address)
        {
            _AirConditioner = AirConditioner;
            _Protection = Protection;
            _AccessToMainRoad = AccessToMainRoad;
            _AccessForDisabled = AccessForDisabled;
            _NumOfToiletCubicles = NumOfToiletCubicles;
            _NumOfDiningAreas = NumOfDiningAreas;
            _Address = Address;
             

        }
    }
}
