using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata;
using System.Text;

namespace Auction
{
    public abstract class Property
    {
        protected bool _AirConditioner { get; set; }
        protected bool _Protection { get; set; }
        protected bool _AccessToMainRoad { get; set; }
        protected bool _AccessForDisabled { get; set; }
        protected int _NumOfToiletCubicles { get; set; }
        protected int _NumOfDiningAreas { get; set; }
        protected string _Address { get; set; }

        public bool Airconditionder
        {
            get
            {
                return _AirConditioner;
            }
        }
        public bool Protection
        {
            get
            {
                return _Protection;
            }
        }
        public bool AccessToMainRoad
        {
            get
            {
                return _AccessToMainRoad;
            }
        }

        public bool AccessForDisabled
        {
            get
            {
                return _AccessForDisabled;
            }
        }
        public int NumOfToiletCubicles
        {
            get
            {
                return _NumOfToiletCubicles;
            }
        }
        public int NumOfDiningAreas
        {
            get
            {
                return _NumOfDiningAreas;
            }
        }
        public string Address
        {
            get
            {
                return _Address;
            }
        }



    }
}
