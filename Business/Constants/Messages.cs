using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        //System Messages
        public static string MaintenanceTime = "Sistem bakımda";
        
        //Car Messages
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarDetailsListed = "Araba detayları listelendi";

        //Brand Messages
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandNameInvalid = "Marka ismi geçersiz";
        public static string BrandsListed = "Markalar listelendi";
        public static string BrandListed = "Marka listelendi";

        //Color Messages
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorsListed = "Renkler listelendi";
        public static string ColorListed = "Renk listelendi";
    }
}
