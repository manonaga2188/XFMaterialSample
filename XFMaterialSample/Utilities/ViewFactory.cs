using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XFMaterialSample.Utilities
{
    internal static class ViewFactory
    {
        internal static Page GetView(string viewName)
        {
            return ServiceLocator.Current.GetInstance<Page>(viewName);
        }

        internal static TView GetView<TView>() where TView : ContentPage
        {
            return ServiceLocator.Current.GetInstance<TView>();
        }
    }
}
