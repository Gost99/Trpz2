using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Trpz2.DataContainer.Repositories;
using Trpz2.Helpers;
using Trpz2.Models;

namespace Trpz2.ViewModels
{
    public class ItemsPageViewModel: Base.BaseViewModel
    {
        public Item ItemInfo { get; set; } = new Item();
        public Item SelectedItem { get; set; }
        public ItemsRepository itemsRepository;

        public ObservableCollection<Item> Items { get; set; }

        private PermissionClass _currentPermission;

        #region Ctors

        public ItemsPageViewModel(PermissionClass permission)
        {
            itemsRepository = new ItemsRepository(MockData.MockItems);
            Items = new ObservableCollection<Item>(itemsRepository.GetAll());
            _currentPermission = permission;
        }

        public ItemsPageViewModel()
            :this(PermissionClass.User)
        { }

        #endregion

        public bool IsAdminOrModeratorGranted
        {
            get
            {
                return this._currentPermission == PermissionClass.Admin || this._currentPermission == PermissionClass.Moderator;
            }
        }

        public bool IsNotAdminOrModeratorGranted => !IsAdminOrModeratorGranted;

        #region Commands

        #region Admin crud

        private ICommand _addItemCommand;
        private ICommand _updateItemCommand;
        private ICommand _deleteItemCommand;
        private ICommand _itemsGridSelectionChangedCommand;

        public ICommand AddItemCommand =>
                _addItemCommand ??
                (_addItemCommand = new SimpleCommand(
                    () =>
                    {
                        var itemToAdd = new Item
                        {
                            Name = ItemInfo.Name,
                            Description = ItemInfo.Description,
                            Price = ItemInfo.Price
                        };
        
                        App.Current.Dispatcher.BeginInvoke((Action)delegate ()
                        {
                            itemsRepository.Insert(itemToAdd);
                        });
                    }));

        public ICommand UpdateItemCommand =>
            _updateItemCommand ??
            (_updateItemCommand = new SimpleCommand(
                () =>
                {
                    itemsRepository.Update(SelectedItem.Id, ItemInfo);
                    if(SelectedItem != null)
                    {
                        SelectedItem.Name = ItemInfo.Name;
                        SelectedItem.Description = ItemInfo.Description;
                        SelectedItem.Price = ItemInfo.Price;
                    }
                }));

        public ICommand DeleteItemCommand =>
            _deleteItemCommand ??
            (_deleteItemCommand = new SimpleCommand(
                () =>
                {
                    itemsRepository.Delete(SelectedItem.Id);
                }));

        public ICommand ItemsGridSelectionChangedCommand =>
            _itemsGridSelectionChangedCommand ??
            (_itemsGridSelectionChangedCommand =
                new SimpleCommand(
                    () =>
                    {
                        ItemInfo.Name = SelectedItem?.Name;
                        ItemInfo.Description = SelectedItem?.Description;
                        ItemInfo.Price = SelectedItem?.Price;
                    }));

        #endregion

        #region Client commands

        private ICommand _addItemToShoppingCartCommand;
        
        public ICommand AddItemToShoppingCartCommand =>
                _addItemToShoppingCartCommand ??
                (_addItemToShoppingCartCommand = new RelayCommand<int>(
                    (countOfItems) =>
                    {
                        throw new Exception(countOfItems.ToString());
                    }));

        #endregion

        #endregion
    }

    internal class ItemInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
