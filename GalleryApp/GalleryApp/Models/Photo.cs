using System;
using System.Collections.Generic;
using System.Text;

namespace GalleryApp.Models
{
    public class Photo : Entity
    {
        public string MimeType { get; set; }
        public string FileUrl { get; set; }

        public Photo(int id, string name, string title, string thumbUrlPublic, string webUrl, string mimeType, string fileUrl)
        {
            Id = id;
            Name = name;
            Title = title;
            Type = "photo";
            ThumbUrlPublic = thumbUrlPublic;
            WebUrl = WebUrl;
            MimeType = mimeType;
            FileUrl = fileUrl;
        }
    }
}
