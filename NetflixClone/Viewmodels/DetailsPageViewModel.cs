﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using Models;
using Services;

namespace Viewmodels
{
    [QueryProperty(nameof(Media), nameof(Media))]
    public partial class DetailsPageViewModel : ObservableObject
    {
        private readonly TmdbService _tmdbService;

        public DetailsPageViewModel(TmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [ObservableProperty]
        private Media _media;

        [ObservableProperty]
        private string _mainTrailerUrl;

        [ObservableProperty]
        private bool _isBusy;
        [ObservableProperty]
        private int _runtime;
        public ObservableCollection<Video> Videos { get; set; } = new();

        public async Task InitializeAsync()
        {
            IsBusy = true;
            try
            {
                var detailsTask = _tmdbService.GetMediaDetailsAsync(Media.Id, Media.MediaType);
                var trailerTeasers = await _tmdbService.GetTrailersAsync(Media.Id, Media.MediaType);
                var details = await detailsTask;
                if (trailerTeasers?.Any() == true)
                {
                    var trailer = trailerTeasers.FirstOrDefault(t => t.type == "Trailer");
                    trailer ??= trailerTeasers.First();
                    MainTrailerUrl = GenerateYoutubeUrl(trailer.key);
                    foreach(var video in trailerTeasers)
                    {
                        Videos.Add(video);
                    }
                }
                else
                {
                    await Shell.Current.DisplayAlert("Not found", "No videos found", "Ok");
                }
                if (details is not null)
                {
                    Runtime = details.runtime;
                }

            }
            finally
            {
                IsBusy = false;
            }
        }

        private static string GenerateYoutubeUrl(string videoKey) => $"https://www.youtube.com/embed/{videoKey}?autoplay=1&mute=1&cc_load_policy=1";
    }
}
