using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppMusic.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WorkkingWithFilePage : Page
    {
        public WorkkingWithFilePage()
        {
            this.InitializeComponent();
        }

        private async void MenuFlyoutItem_Save(object sender, RoutedEventArgs e)
        {
            //tạo save file picker , mở ra cửa sổ chọn file để lưu .
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            //lựa chọn thư mục bắt đầu để mở file .
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Downloads;
            // kiểu file có thể làm việc cùng 
            savePicker.FileTypeChoices.Add("Plain Text", new List<string>() { ".txt" });
            savePicker.FileTypeChoices.Add("All file", new List<string>() { "." });
            // tên file default
            savePicker.SuggestedFileName = "New Document";
            var file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                var content = txtContent.Text;
                await FileIO.WriteTextAsync(file, content);
            }
        }
        private async void MenuFlyoutItem_Open(object sender, RoutedEventArgs e)
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            picker.FileTypeFilter.Add(".txt");
            StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                txtContent.Text = await FileIO.ReadTextAsync(file);
            }
        }
    }
}
