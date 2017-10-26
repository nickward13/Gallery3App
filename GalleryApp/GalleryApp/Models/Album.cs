using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace GalleryApp.Models
{
    public class Album : Entity
    {
        public ObservableCollection<Entity> Entities { get; set; }

        public Album()
        {
            Id = 0;
            Name = "Blank";
            Title = "Blank";
            Type = "album";
            ThumbUrlPublic = "http://";
            WebUrl = "http://";
            Entities = new ObservableCollection<Entity>();
        }

        public Album(int id, string name, string title, string thumbUrlPublic, string webUrl)
        {
            Id = id;
            Name = name;
            Title = title;
            Type = "album";
            ThumbUrlPublic = thumbUrlPublic;
            WebUrl = WebUrl;
            Entities = new ObservableCollection<Entity>();
        }


    }
}
