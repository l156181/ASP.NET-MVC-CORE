using entity_frawework_core_1.Model;
using System.Collections.Generic;

namespace entity_frawework_core_1.Extensions

{
    public static class ParentalRatingExtensions
    {       

        private static Dictionary<string,ParentalRating> map = new Dictionary<string,ParentalRating>
            {
                {"G",ParentalRating.Free},
                {"PG",ParentalRating.GreaterThan10},
                {"PG-13",ParentalRating.GreaterThan13},
                {"G",ParentalRating.GreaterThan14},
                {"NC-17",ParentalRating.GreaterThan18}
            };


        public static string ForString(this ParentalRating value){            
            return map.First(c => c.Value == value);
        }

        public static ParentalRating ForValue(this string text){
            return map.First(c => c.Key == text).Value;       
        }
    }
}