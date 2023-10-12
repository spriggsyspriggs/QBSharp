using System;

namespace QBSharp
{
    public class Dialogs
    {
        /// <summary>
        /// Saves the file dialog.
        /// </summary>
        /// <returns>The file dialog.</returns>
        /// <param name="title">Dialog box title</param>
        /// <param name="defaultPathAndFile">Default path that will be used by the dialog box if not changed by the user</param>
        /// <param name="filterPattern">File filters separated using "|" (e.g., "*.png|*.jpg|*.gif")</param>
        /// <param name="singleFilterDescription">Single filter <paramref name="singleFilterDescription"/>(e.g., "Image Files")</param>
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
                return saveDialog.Filename;
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