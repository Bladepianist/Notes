using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Notes.Models;

namespace Notes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.FileName))
            {
                // Save
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.text");
                File.WriteAllText(filename, note.Text);
            } else
            {
                // Update
                File.WriteAllText(note.FileName, note.Text);
            }

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (File.Exists(note.FileName))
            {
                File.Delete(note.FileName);
            }

            await Navigation.PopAsync();
        }
    }
}