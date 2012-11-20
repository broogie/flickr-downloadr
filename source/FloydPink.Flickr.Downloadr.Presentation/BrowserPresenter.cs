﻿using System.Collections.ObjectModel;
using FloydPink.Flickr.Downloadr.Logic.Interfaces;
using FloydPink.Flickr.Downloadr.Model;
using FloydPink.Flickr.Downloadr.Presentation.Views;

namespace FloydPink.Flickr.Downloadr.Presentation
{
    public class BrowserPresenter : PresenterBase
    {
        private readonly IBrowserLogic _logic;
        private readonly IBrowserView _view;

        public BrowserPresenter(IBrowserLogic logic, IBrowserView view)
        {
            _logic = logic;
            _view = view;
        }

        public void InitializeScreen()
        {
            var photosResponse = _logic.GetPublicPhotos(_view.User);
            _view.Photos = new ObservableCollection<Photo>(photosResponse.Photos);
        }
    }
}