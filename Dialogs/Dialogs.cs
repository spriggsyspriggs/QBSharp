using System;

namespace QBSharp
{
    public class Dialogs
    {
        private string _filename;
        public string FileName
        {
            get
            {
                return _filename;
            }
        }

        public string SaveFileDialog(string title, string defaultPathAndFile = "", string filterPattern = "", string singleFilterDescription = "")
        {
            Gtk.FileChooserDialog saveDialog = new Gtk.FileChooserDialog("Save As", null, Gtk.FileChooserAction.Save, "Cancel", Gtk.ResponseType.Cancel, "Save", Gtk.ResponseType.Accept)
            {
                CanDefault = true
            };
            if (defaultPathAndFile.Trim() != string.Empty)
            {
                saveDialog.SetCurrentFolder(defaultPathAndFile);
            }
            Gtk.FileFilter filter = new Gtk.FileFilter();
            string[] filters = filterPattern.Split('|');
            if (singleFilterDescription.Trim() != string.Empty)
            {
                filter.Name = singleFilterDescription;
            }
            foreach (string filterType in filters)
            {
                filter.AddPattern(filterType.ToUpper());
                filter.AddPattern(filterType.ToLower());
            }
            saveDialog.AddFilter(filter);
            int result = saveDialog.Run();
            saveDialog.Hide();
            if (result == (int)Gtk.ResponseType.Accept)
            {
                _filename = saveDialog.Filename;
                return FileName;
            }
            return "";
        }
        string OpenFileDialog()
        {
            return "";
        }
        string SelectFolderDialog()
        {
            return "";
        }
        string ColorChooserDialog()
        {
            return "";
        }
    }
}