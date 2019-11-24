using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Trpz2.Navigator.Interfaces;
using Trpz2.Views;
using Trpz2.Views.Pages;

namespace Trpz2.Navigator
{
    public class PagesResolver : IPageResolver
    {
        private readonly Dictionary<string, Func<Page>> _pagesResolvers = new Dictionary<string, Func<Page>>();

        public PagesResolver()
        {
            _pagesResolvers.Add(Navigation.Page1Alias, () => new InfoPage());
            _pagesResolvers.Add(Navigation.Page2Alias, () => new ItemsPage());
            _pagesResolvers.Add(Navigation.Page3Alias, () => new ShoppingCartPage());
        }

        public Page GetPageInstance(string alias)
        {
            if (_pagesResolvers.ContainsKey(alias))
            {
                return _pagesResolvers[alias]();
            }

            return default;
        }
    }
}
