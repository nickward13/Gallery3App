using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryApp.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string ThumbUrlPublic { get; set; }
        public string WebUrl { get; set; }

        public override string ToString()
        {
            return Title;
        }

    }
}
