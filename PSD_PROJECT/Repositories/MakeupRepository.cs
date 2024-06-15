using PSD_PROJECT.Factories;
using PSD_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_PROJECT.Repositories
{
    public class MakeupRepository
    {
        private static DatabaseEntities db = DatabaseSingleton.GetInstance();

        public static List<Makeup> GetMakeupList()
        {
            return (from makeup in db.Makeups select makeup).ToList();
        }
        public static List<MakeupType> GetMakeupTypeList()
        {
            return(from makeuptype in db.MakeupTypes select makeuptype).ToList();
        }
        public static List<MakeupBrand> GetMakeupBrandList()
        {
            return db.MakeupBrands.OrderByDescending(x => x.MakeupBrandRating).ToList();
        }
        public static int generateMakeupID()
        {
            int newID = 1;
            int lastID = db.Makeups.OrderByDescending(x => x.MakeupID).Select(x => x.MakeupID).FirstOrDefault();

            if (lastID == null)
            {
                return newID;
            }
            else
            {
                lastID++;
            }
            return lastID;
        }
        public static int generateMakeupTypeID()
        {
            int newID = 1;
            int lastID = db.MakeupTypes.OrderByDescending(x => x.MakeupTypeID).Select(x => x.MakeupTypeID).FirstOrDefault();

            if (lastID == null)
            {
                return newID;
            }
            else
            {
                lastID++;
            }
            return lastID;
        }
        public static int generateMakeupBrandID()
        {
            int newID = 1;
            int lastID = db.MakeupBrands.OrderByDescending(x => x.MakeupBrandID).Select(x => x.MakeupBrandID).FirstOrDefault();

            if (lastID == null)
            {
                return newID;
            }
            else
            {
                lastID++;
            }
            return lastID;
        }

        public static Makeup FindMakeupByID(int id)
        {
            return (from makeup in db.Makeups where (makeup.MakeupID == id) select makeup).FirstOrDefault();
        }

        public static Makeup FindMakeupByName(string name)
        {
            return (from makeup in db.Makeups where (makeup.MakeupName == name) select makeup).FirstOrDefault();
        }
        public static MakeupType FindTypeByID(int id)
        {
            return (from type in db.MakeupTypes where (type.MakeupTypeID == id) select type).FirstOrDefault();
        }
        
        public static MakeupBrand FindBrandByID(int id)
        {
            return (from brand in db.MakeupBrands where (brand.MakeupBrandID == id) select brand).FirstOrDefault();
        }
       
        public static void InsertMakeup(Makeup makeupInput)
        {
            int id = generateMakeupID();
            makeupInput.MakeupID = id;
            Makeup makeup = MakeupFactory.createMakeup(makeupInput);
            db.Makeups.Add(makeup);
            db.SaveChanges();
        }
        public static void InsertMakeupType(MakeupType makeupTypeInput)
        {
            int id = generateMakeupTypeID();
            makeupTypeInput.MakeupTypeID = id;
            MakeupType makeuptype = MakeupFactory.createMakeupType(makeupTypeInput);

            db.MakeupTypes.Add(makeupTypeInput);
            db.SaveChanges();
        }
        public static void InsertMakeupBrand(MakeupBrand makeupBrandInput)
        {
            int id = generateMakeupBrandID();
            makeupBrandInput.MakeupBrandID = id;
            MakeupBrand makeupbrand = MakeupFactory.createMakeupBrand(makeupBrandInput);
            db.MakeupBrands.Add(makeupBrandInput);
            db.SaveChanges();
        }
        public static void UpdateMakeup(Makeup makeupInput)
        {
            Makeup updateMakeup = MakeupRepository.FindMakeupByID(makeupInput.MakeupID);
            updateMakeup.MakeupName = makeupInput.MakeupName;
            updateMakeup.MakeupPrice = makeupInput.MakeupPrice;
            updateMakeup.MakeupWeight = makeupInput.MakeupWeight;
            updateMakeup.MakeupTypeID = makeupInput.MakeupTypeID;
            updateMakeup.MakeupBrandID = makeupInput.MakeupBrandID;

            db.SaveChanges();
        }
        public static void DeleteMakeup(int id)
        {
            Makeup makeup = MakeupRepository.FindMakeupByID(id);
            db.Makeups.Remove(makeup);
            db.SaveChanges();
        }
        public static void UpdateMakeupType(MakeupType makeuptypeInput)
        {
            MakeupType updateMakeupType = MakeupRepository.FindTypeByID(makeuptypeInput.MakeupTypeID);
            updateMakeupType.MakeupTypeName = makeuptypeInput.MakeupTypeName;

            db.SaveChanges();
        }
        public static void UpdateMakeupBrand(MakeupBrand makeupBrandInput)
        {
            MakeupBrand updateMakeupBrand = MakeupRepository.FindBrandByID(makeupBrandInput.MakeupBrandID);
            updateMakeupBrand.MakeupBrandName = makeupBrandInput.MakeupBrandName;
            updateMakeupBrand.MakeupBrandRating =makeupBrandInput.MakeupBrandRating;
            db.SaveChanges();
        }
        public static Makeup FindMakeupbyNameTypeBrand(Makeup findMakeup,MakeupType findMakeupType, MakeupBrand findMakeupBrand)
        {
            return (from makeup in db.Makeups where (makeup.MakeupName == findMakeup.MakeupName && 
                   makeup.MakeupType.MakeupTypeName == findMakeupType.MakeupTypeName &&
                   makeup.MakeupBrand.MakeupBrandName == findMakeupBrand.MakeupBrandName) select makeup).FirstOrDefault();
        }
    }
}