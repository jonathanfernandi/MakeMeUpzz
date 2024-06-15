using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_PROJECT.Factories
{
    public class MakeupFactory
    {
        public static Makeup createMakeup(Makeup makeupInput)
        {
            Makeup makeup = new Makeup();
            makeup.MakeupID = makeupInput.MakeupID;
            makeup.MakeupName = makeupInput.MakeupName;
            makeup.MakeupPrice = makeupInput.MakeupPrice;
            makeup.MakeupWeight = makeupInput.MakeupWeight;
            makeup.MakeupTypeID = makeupInput.MakeupTypeID;
            makeup.MakeupBrandID = makeupInput.MakeupBrandID;

            return makeup;
        }

        public static MakeupType createMakeupType(MakeupType makeuptypeInput)
        {
            MakeupType makeuptype = new MakeupType();
            makeuptype.MakeupTypeID = makeuptypeInput.MakeupTypeID;
            makeuptype.MakeupTypeName = makeuptypeInput.MakeupTypeName;

            return makeuptype;
        }
        public static MakeupBrand createMakeupBrand(MakeupBrand makeupbrandInput)
        {
            MakeupBrand makeupbrand = new MakeupBrand();
            makeupbrand.MakeupBrandID = makeupbrandInput.MakeupBrandID;
            makeupbrand.MakeupBrandName = makeupbrandInput.MakeupBrandName;
            makeupbrand.MakeupBrandRating = makeupbrandInput.MakeupBrandRating;
            return makeupbrand;
        }
    }
}