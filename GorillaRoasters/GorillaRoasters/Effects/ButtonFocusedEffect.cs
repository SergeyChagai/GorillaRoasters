using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GorillaRoasters.Effects
{
    public class ButtonFocusedEffect : RoutingEffect
    {
        public ButtonFocusedEffect() : base($"App.{nameof(ButtonFocusedEffect)}")
        {
        }
    }
}
