﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;

namespace TogglDesktop
{
static class UIExtensions
{
    public static bool TryBeginInvoke(this Control control, Action action)
    {
        if (control.Dispatcher.CheckAccess())
            return false;

        control.Dispatcher.BeginInvoke(action);

        return true;
    }
    #region overloads

    public static bool TryBeginInvoke<T0>(this Control control, Action<T0> action, T0 p0)
    {
        return control.TryBeginInvoke(() => action(p0));
    }
    public static bool TryBeginInvoke<T0, T1>(this Control control, Action<T0, T1> action, T0 p0, T1 p1)
    {
        return control.TryBeginInvoke(() => action(p0, p1));
    }
    public static bool TryBeginInvoke<T0, T1, T2>(this Control control, Action<T0, T1, T2> action, T0 p0, T1 p1, T2 p2)
    {
        return control.TryBeginInvoke(() => action(p0, p1, p2));
    }
    public static bool TryBeginInvoke<T0, T1, T2, T3>(this Control control,
            Action<T0, T1, T2, T3> action, T0 p0, T1 p1, T2 p2, T3 p3)
    {
        return control.TryBeginInvoke(() => action(p0, p1, p2, p3));
    }
    public static bool TryBeginInvoke<T0, T1, T2, T3, T4>(this Control control,
            Action<T0, T1, T2, T3, T4> action, T0 p0, T1 p1, T2 p2, T3 p3, T4 p4)
    {
        return control.TryBeginInvoke(() => action(p0, p1, p2, p3, p4));
    }

    #endregion

    public static void ShowOnlyIf(this UIElement control, bool condition)
    {
        control.Visibility = condition
                             ? Visibility.Visible
                             : Visibility.Collapsed;
    }
    public static void ShowOnlyIf(this UIElement control, bool condition, bool hideInsteadOfCollapse)
    {
        control.Visibility = condition
                             ? Visibility.Visible
                             : hideInsteadOfCollapse
                             ? Visibility.Hidden
                             : Visibility.Collapsed;
    }

    public static void RemoveFromParent(this UIElement control)
    {
        var parent = VisualTreeHelper.GetParent(control);
        if (parent == null)
            return;

        var parentAsPanel = parent as Panel;
        if (parentAsPanel != null)
        {
            parentAsPanel.Children.Remove(control);
            return;
        }

        var parentAsContentControl = parent as ContentControl;
        if (parentAsContentControl != null)
        {
            parentAsContentControl.Content = null;
            return;
        }

        var parentAsDecorator = parent as Decorator;
        if (parentAsDecorator != null)
        {
            parentAsDecorator.Child = null;
        }
    }

    public static void HideWindowOnClosing(this Window window, object sender, CancelEventArgs e)
    {
        e.Cancel = true;
        Action hideAction = window.Hide;
        window.Dispatcher.BeginInvoke(DispatcherPriority.Background, hideAction);
    }

    public static void ShowOnTop(this Window window)
    {
        window.Show();
        if (window.WindowState == WindowState.Minimized)
        {
            window.WindowState = WindowState.Normal;
        }
        window.Activate();
    }

    public static void ClearUndoHistory(this TextBoxBase textBox)
    {
        textBox.IsUndoEnabled = false;
        textBox.IsUndoEnabled = true;
    }

    public static int CountSubstrings(this string s, string searchString)
    {
        if (s == null)
            throw new ArgumentNullException("s");

        if (searchString == null)
            throw new ArgumentNullException("searchString");

        if (searchString == "")
            throw new ArgumentException("Search string must be non-empty.", "searchString");

        var stringLength = s.Length;
        var subStringLength = searchString.Length;

        var maxFirstIndex = stringLength - subStringLength;

        var count = 1;

        for (int i = 0; i <= maxFirstIndex; i++)
        {
            count++;
            for (int j = 0; j < subStringLength; j++)
            {
                if (searchString[j] != s[j + i])
                {
                    count--;
                    break;
                }
            }
        }

        return count;
    }

    public static bool IsNullOrEmpty(this string s)
    {
        return string.IsNullOrEmpty(s);
    }
}
}