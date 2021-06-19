using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPSoundboard1.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPSoundboard1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Sound> sounds;
        private List<MenuItem> menuItem;
        public MainPage()
        {
            this.InitializeComponent();
            sounds = new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(sounds);
            menuItem = new List<MenuItem> {
                new MenuItem{category=SoundCategory.Animals,IconFile="Assets/Icons/animals.png"},
                new MenuItem{category=SoundCategory.Cartoons,IconFile="Assets/Icons/cartoon.png"},
                new MenuItem{category=SoundCategory.Taunts,IconFile="Assets/Icons/taunt.png"},
                new MenuItem{category=SoundCategory.Warnings,IconFile="Assets/Icons/warning.png"}
            };
        }

        private void Hamburger_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;


        }

        private void MenuItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            SoundManager.GetSoundsByCategory(sounds, menuItem.category);
            BackButton.Visibility = Visibility.Visible;
            CategoryTextBlock.Text = menuItem.category.ToString();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SoundManager.GetAllSounds(sounds);
            BackButton.Visibility = Visibility.Collapsed;
            CategoryTextBlock.Text = "AllSounds";


        }

        private void ItemGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound =(Sound)e.ClickedItem;
            SoundElement.Source = new Uri(this.BaseUri, sound.SoundLink);
               
        }
    }
   
}
