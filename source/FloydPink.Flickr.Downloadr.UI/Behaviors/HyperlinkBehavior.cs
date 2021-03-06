﻿using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Navigation;

namespace FloydPink.Flickr.Downloadr.UI.Behaviors
{
    public static class HyperlinkBehavior
    {
        public static readonly DependencyProperty IsExternalProperty =
            DependencyProperty.RegisterAttached("IsExternal", typeof (bool), typeof (HyperlinkBehavior),
                new UIPropertyMetadata(false, OnIsExternalChanged));

        public static bool GetIsExternal(DependencyObject obj)
        {
            return (bool) obj.GetValue(IsExternalProperty);
        }

        public static void SetIsExternal(DependencyObject obj, bool value)
        {
            obj.SetValue(IsExternalProperty, value);
        }

        private static void OnIsExternalChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            var hyperlink = sender as Hyperlink;

            if ((bool) args.NewValue)
                hyperlink.RequestNavigate += HyperlinkRequestNavigate;
            else
                hyperlink.RequestNavigate -= HyperlinkRequestNavigate;
        }

        private static void HyperlinkRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}