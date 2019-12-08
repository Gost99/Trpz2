using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Trpz2.Helpers;
using Trpz2.Models;
using Trpz2.Services;
using Trpz2.Services.Abstractions;

namespace Trpz2.ViewModels
{
    public class ItemsPageViewModel: Base.BaseViewModel
    {
        public ProductDto ProductInfo { get; set; } = new ProductDto();
        public ProductDto SelectedProduct { get; set; }
        private IProductService _productService;

        public ObservableCollection<ProductDto> Items { get; set; }

        private PermissionClass _currentPermission;

        #region Ctors

        public ItemsPageViewModel(PermissionClass permission)
        {
            _productService = new ProductService();
            OnListChange();
            _currentPermission = permission;
        }

        public ItemsPageViewModel()
            :this(PermissionClass.User)
        { }

        #endregion

        private void OnListChange()
        {
            Items = new ObservableCollection<ProductDto>(_productService.GetAll());
        }

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
                        var itemToAdd = new ProductDto
                        {
                            Name = ProductInfo.Name,
                            Description = ProductInfo.Description,
                            Price = ProductInfo.Price
                        };
                        _productService.Create(itemToAdd);
                        Items.Add(itemToAdd);
                    }));

        public ICommand UpdateItemCommand =>
            _updateItemCommand ??
            (_updateItemCommand = new SimpleCommand(
                () =>
                {
                    var itemToUpdate = ProductInfo;
                    _productService.Update(itemToUpdate);
                    if (SelectedProduct != null)
                    {
                        SelectedProduct.Name = ProductInfo.Name;
                        SelectedProduct.Description = ProductInfo.Description;
                        SelectedProduct.Price = ProductInfo.Price;
                    }
                }));

        public ICommand DeleteItemCommand =>
            _deleteItemCommand ??
            (_deleteItemCommand = new SimpleCommand(
                () =>
                {
                    _productService.Delete((int)SelectedProduct.Id);
                    Items.Remove(SelectedProduct);
                }));

        public ICommand ItemsGridSelectionChangedCommand =>
            _itemsGridSelectionChangedCommand ??
            (_itemsGridSelectionChangedCommand =
                new SimpleCommand(
                    () =>
                    {
                        ProductInfo.Id = SelectedProduct == null ? 0 : SelectedProduct.Id;
                        ProductInfo.Name = SelectedProduct?.Name;
                        ProductInfo.Description = SelectedProduct?.Description;
                        ProductInfo.Price = SelectedProduct == null ? 0 : SelectedProduct.Price;
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
}
