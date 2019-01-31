/*
 * Author : Ekin Bulut
 * 
 * Item Provider class is for providing SelectedListItems for related Dropboxes in related Views. 
 * Each method calls its related services from ServiceProvider <see cref="ServiceProvider"/> class
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Library.Mvc.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public static class ItemProvider
    {
        /// <summary>
        /// The provider
        /// </summary>
        private static readonly ServiceProvider Provider = new ServiceProvider();

        /// <summary>
        /// Authors this instance.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> Authors()
        {
            var authors = Provider.ItemProviderServiceClient.Authors();

            return authors.AuthorDtos.Select(authorDto => new SelectListItem
            {
                Value = authorDto.Value.ToString(),
                Text = authorDto.Name

            }).OrderBy(x=>x.Text);
        }

        /// <summary>
        /// Publishers this instance.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> Publishers()
        {
            var publishers = Provider.ItemProviderServiceClient.Publishers();

            return publishers.PublisherDtos.Select(pdto => new SelectListItem
            {
                Value = pdto.Value.ToString(),
                Text = pdto.Name

            }).OrderBy(x => x.Text);
        }

        /// <summary>
        /// Genres this instance.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> Genres()
        {
            var genres = Provider.ItemProviderServiceClient.Genres();

            return genres.GenreDtos.Select(t => new SelectListItem
            {
                Value = t.Value.ToString(),
                Text = t.Name

            }).OrderBy(x => x.Text);

        }

        /// <summary>
        /// Series this instance.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> Series()
        {
            var series = Provider.ItemProviderServiceClient.Series();

            var list = series.SeriesDtos.Select(t => new SelectListItem
            {
                Value = t.Value.ToString(),
                Text = t.Name

            }).ToList();

            list.Add(new SelectListItem {Selected = true,Value = String.Empty,Text = ""});

            return list.OrderBy(x => x.Text);
        }

        /// <summary>
        /// Shelfs this instance.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> Shelfs()
        {
            var shelfs = Provider.ItemProviderServiceClient.Shelfs();

            return shelfs.ShelfDtos.Select(t => new SelectListItem
            {
                Value = t.Value.ToString(),
                Text = t.Name

            }).OrderBy(x => x.Text);
        }

        /// <summary>
        /// Racks this instance.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> Racks()
        {
            var racks = Provider.ItemProviderServiceClient.Racks();

            return racks.RackDtos.Select(t => new SelectListItem
            {
                Value = t.Value.ToString(),
                Text = t.Name

            }).OrderBy(x => x.Text);
        }

        /// <summary>
        /// Skins the types.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> SkinTypes()
        {
            return new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Ciltli",
                    Value = "0"
                },
                new SelectListItem
                {
                    Text = "Ciltsiz",
                    Value = "1"
                }
            };
        }
    }
}
