using System;

namespace mvcTest.Models
{

    public struct Photo
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }

        public override string ToString() =>
            $"albumId: {albumId}, id: {id}, title: {title}, url: {url}, thumbnailUrl: {thumbnailUrl}";
    }
}
