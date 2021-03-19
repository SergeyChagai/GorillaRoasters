using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GorillaRoasters.Models
{
    public class CoffeeInfoModel
    {
        public string Name { get; set; }
        public string From { get; set; }
        public string Price { get; set; }
        public string ImageSrc { get; set; }
        public List<PreparationParamModel> PreparationParams { get; set; }
    }
}
