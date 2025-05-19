using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using Services;

namespace Viewmodels
{
    public partial class CategoriesViewModel : ObservableObject
    {
        private readonly TmdbService _tmdbService;

        private IEnumerable<Genre> _genreList;

        public CategoriesViewModel(TmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }
        public ObservableCollection<string> Categories { get; set; } = new();

        public async Task InitializeAsync()
        {
            _genreList ??= await _tmdbService.GetGenresAsync();

            Categories.Clear();
            Categories.Add("My List");
            Categories.Add("Downloads");

            foreach (var genre in _genreList)
            {
                Categories.Add(genre.Name);
            }
        }
    }
}
