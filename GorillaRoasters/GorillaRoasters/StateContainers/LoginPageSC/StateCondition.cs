using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GorillaRoasters.StateContainers.LoginPageSC
{
    [ContentProperty("Content")]
    public class StateCondition : View
    {
        public States State { get; set; }
        public View Content { get; set; }
    }
}
