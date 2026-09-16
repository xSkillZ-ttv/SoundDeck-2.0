namespace SoundDeck.Plugin.Windows
{
    using SoundDeck.Plugin.Models.UI;
    using System;
    using System.Windows.Threading;

    public class FolderBrowserDialogWrapper : IFolderBrowserDialogProvider
    {
        private bool _isOpen = false;
        private Dispatcher Dispatcher => System.Windows.Application.Current.Dispatcher;

        private class WindowWrapper : System.Windows.Forms.IWin32Window
        {
            public IntPtr Handle { get; }
            public WindowWrapper(IntPtr handle) { Handle = handle; }
        }

        public FolderBrowserDialogResult ShowDialog(string title, string selectedPath)
        {
            if (_isOpen) return new FolderBrowserDialogResult(false, string.Empty);

            return this.Dispatcher.Invoke(() =>
            {
                if (_isOpen) return new FolderBrowserDialogResult(false, string.Empty);
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
                var win32Owner = new WindowWrapper(interop.Handle);

                try
                {
                    using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
                    {
                        dialog.Description = title;
                        if (!string.IsNullOrEmpty(selectedPath) && System.IO.Directory.Exists(selectedPath)) {
                            dialog.SelectedPath = selectedPath;
                        }

                        return dialog.ShowDialog(win32Owner) == System.Windows.Forms.DialogResult.OK
                            ? new FolderBrowserDialogResult(true, dialog.SelectedPath)
                            : new FolderBrowserDialogResult(false, string.Empty);
                    }
                }
                finally
                {
                    _isOpen = false;
                    dummy.Close();
                }
            });
        }
    }
}
