using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Prism.Navigation;

namespace NestedLayoutDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            OrderItemsList = new ObservableCollection<Element>();
            CreateLists();
        }

        ObservableCollection<Element> _OrderItemsList;
        public ObservableCollection<Element> OrderItemsList
        {
            get { return _OrderItemsList; }
            set { SetProperty(ref _OrderItemsList, value); }
        }

        private void CreateLists()
        {
            for (int i = 0; i < 5; i++)
            {

                OrderItemsList.Add(new Element
                {
                    Name = $"item{i}",
                    Price = 0,
                    ItemCost = "0.0",
                    HasExtras = true,
                });
                
                ObservableCollection<ModificationsElement> mods = new ObservableCollection<ModificationsElement>();
                for (int j = 0; j < 3; j++)
                {
                    mods.Add
                    (
                        new ModificationsElement
                        {
                            Id = $"id{j}",
                            Name = $"item{j}",
                            Price = j.ToString(),
                            Amount = 0
                        }
                    );
                }
                OrderItemsList[i].Mods = mods;
            }
        }
    }

    public class Element
    {
        public string Name { get; set; }

        public long? Price { get; set; }

        public Modifications Modifications { get; set; }

        public string ItemCost { get; set; }

        public bool HasExtras { get; set; }

        public ObservableCollection<ModificationsElement> Mods { get; set; }
    }

    public partial class Modifications
    {
        public ObservableCollection<ModificationsElement> Elements { get; set; }
    }

    public partial class ModificationsElement
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public long? Amount { get; set; }

        public string Price { get; set; }
    }
}
