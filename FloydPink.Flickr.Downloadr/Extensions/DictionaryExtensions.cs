﻿using System;
using System.Collections.Generic;
using System.Linq;
using FloydPink.Flickr.Downloadr.Constants;
using FloydPink.Flickr.Downloadr.Model;

namespace FloydPink.Flickr.Downloadr.Extensions
{
    public static class DictionaryExtensions
    {
        public static object GetValueFromDictionary(this Dictionary<string, object> dictionary, string key,
                                                    string subKey = AppConstants.FlickrDictionaryContentKey)
        {
            if (dictionary.ContainsKey(key))
            {
                var subDictionary = (Dictionary<string, object>) dictionary[key];
                return subDictionary.ContainsKey(subKey) ? subDictionary[subKey] : null;
            }
            return null;
        }

        public static IEnumerable<Photo> GetPhotosFromDictionary(this Dictionary<string, object> dictionary)
        {
            var photos = new List<Photo>();
            var photoDictionary =
                ((IEnumerable<object>) dictionary.GetValueFromDictionary("photos", "photo")).Cast
                    <Dictionary<string, object>>();
            photos.AddRange(photoDictionary.Select(BuildPhoto));
            return photos;
        }

        private static Photo BuildPhoto(Dictionary<string, object> dictionary)
        {
            return new Photo(dictionary["id"].ToString(),
                             dictionary["owner"].ToString(),
                             dictionary["secret"].ToString(),
                             dictionary["server"].ToString(),
                             Convert.ToInt32(dictionary["farm"]),
                             dictionary["title"].ToString(),
                             Convert.ToBoolean(dictionary["ispublic"]),
                             Convert.ToBoolean(dictionary["isfriend"]),
                             Convert.ToBoolean(dictionary["isfamily"]));
        }
    }
}