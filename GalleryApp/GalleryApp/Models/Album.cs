using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GalleryApp.Models
{
    public class Album : Entity
    {
        public ObservableCollection<Entity> Entities { get; set; }

        public Album(int id, string name, string title, string thumbUrlPublic, string webUrl)
        {
            Id = id;
            Name = name;
            Title = title;
            Type = "photo";
            ThumbUrlPublic = thumbUrlPublic;
            WebUrl = WebUrl;
        }
    }
}
