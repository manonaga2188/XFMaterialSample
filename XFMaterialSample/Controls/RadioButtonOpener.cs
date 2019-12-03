using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XF.Material.Forms.UI;

namespace XFMaterialSample.Controls
{
   public class RadioButtonOpener:MaterialButton
    {
        private static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(propertyName: "SelectedIndex",
            returnType: typeof(int),
            declaringType: typeof(MaterialButton),
            defaultValue: -1,
            defaultBindingMode: BindingMode.TwoWay);
        private static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(propertyName: "SelectedItem",
            returnType: typeof(string),
            declaringType: typeof(MaterialButton),
            defaultValue: "",
            defaultBindingMode: BindingMode.TwoWay);
        public int SelectedIndex {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }
        public string SelectedItem
        {
            get { return (string)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
    }
}
