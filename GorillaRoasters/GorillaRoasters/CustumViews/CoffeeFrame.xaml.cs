using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GorillaRoasters.CustumViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoffeeFrame : ContentView
    {
        public static readonly BindableProperty ImageSrcProperty =
            BindableProperty.Create
            (
                propertyName: nameof(ImageSrc),
                returnType: typeof(string),
                declaringType: typeof(CoffeeFrame),
                propertyChanged: ImageSrcPropertyChanged
            );

        public static readonly BindableProperty CoffeeNameProperty =
            BindableProperty.Create
            (
                propertyName: nameof(CoffeeName),
                returnType: typeof(string),
                declaringType: typeof(CoffeeFrame),
                propertyChanged: CoffeeNamePropertyChanged
            );
        
        public static readonly BindableProperty ProducerProperty =
            BindableProperty.Create
            (
                propertyName: nameof(Producer),
                returnType: typeof(string),
                declaringType: typeof(CoffeeFrame),
                propertyChanged: ProducerPropertyChanged
            );
        
        public static readonly BindableProperty PriceProperty =
            BindableProperty.Create
            (
                propertyName: nameof(Price),
                returnType: typeof(string),
                declaringType: typeof(CoffeeFrame),
                propertyChanged: PricePropertyChanged
            );
       
        public string ImageSrc
        {
            get => (string)GetValue(ImageSrcProperty);
            set
            {
                SetValue(ImageSrcProperty, value);
            }
        }  
        public string CoffeeName
        {
            get => (string)GetValue(CoffeeNameProperty);
            set
            {
                SetValue(CoffeeNameProperty, value);
            }
        }  
        public string Producer
        {
            get => (string)GetValue(ProducerProperty);
            set
            {
                SetValue(ProducerProperty, value);
            }
        } 
        public string Price
        {
            get => (string)GetValue(PriceProperty);
            set
            {
                SetValue(PriceProperty, value);
            }
        } 

        public CoffeeFrame()
        {
            InitializeComponent();
        }
        private static void ImageSrcPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is CoffeeFrame frame)
            {
                frame.Image.Source = (string)newValue;
            }
        }
        private static void CoffeeNamePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is CoffeeFrame frame)
            {
                frame.CoffeeNameLabel.Text = (string)newValue;
            }
        }
        private static void ProducerPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is CoffeeFrame frame)
            {
                frame.CoffeeProducerLabel.Text = (string)newValue;
            }
        }
        private static void PricePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is CoffeeFrame frame)
            {
                frame.PriceLabel.Text = (string)newValue;
            }
        }

    }
}