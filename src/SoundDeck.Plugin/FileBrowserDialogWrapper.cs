namespace SoundDeck.Plugin.Windows
{
    using Microsoft.WindowsAPICodePack.Dialogs;
    using SoundDeck.Plugin.Models.UI;
    using System;
    using System.Linq;
    using System.Windows.Threading;

    public class FileBrowserDialogWrapper : IFileDialogProvider
    {
        private bool _isOpen = false;
        private Dispatcher Dispatcher => System.Windows.Application.Current.Dispatcher;

        public string[] ShowOpenDialog(string title, string filter)
        {
            if (_isOpen) return new string[0];
            
            return this.Dispatcher.Invoke(() =>
            {
                if (_isOpen) return new string[0];
                _isOpen = true;
                var dummy = new System.Windows.Window
                {
                    Topmost = true,
                    WindowStyle = System.Windows.WindowStyle.None,
                    AllowsTransparency = true,
                    Background = System.Windows.Media.Brushes.Transparent,
                    ShowInTaskbar = false,
                    Width = 0,
                    Height = 0,
                    WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen
                };
                
                dummy.Show();
                dummy.Topmost = false;
                dummy.Activate();
                dummy.Focus();
                
                var interop = new System.Windows.Interop.WindowInteropHelper(dummy);

                try
                {
                    using (var dialog = new CommonOpenFileDialog())
                    {
                        this.AddFilters(dialog.Filters, filter);
                        dialog.EnsurePathExists = true;
                        dialog.Multiselect = true;
                        dialog.Title = title;

                        return dialog.ShowDialog(interop.Handle) == CommonFileDialogResult.Ok
                            ? dialog.FileNames.ToArray()
                            : new string[0];
                    }
                }
                finally
                {
                    _isOpen = false;
                    dummy.Close();
                }
            });
        }

        private void AddFilters(CommonFileDialogFilterCollection filters, string filter)
        {
            var segments = filter.Split('|');
            for (var i = 0; i < segments.Length; i += 2)
            {
                filters.Add(new CommonFileDialogFilter(segments[i], segments[i + 1]));
            }
        }
    }
}
