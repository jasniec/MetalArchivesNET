using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MetalArchivesNET.Models.Enums
{
    public enum AlbumType : byte
    {
        [Description("Full-length")]
        FullLength = 1,
        [Description("Live album")]
        LiveAlbum = 2,
        [Description("Demo")]
        Demo = 3,
        [Description("Single")]
        Single = 4,
        [Description("EP")]
        EP = 5,
        [Description("Video")]
        Video = 6,
        [Description("Boxed set")]
        BoxedSet = 7,
        [Description("Split")]
        Split = 8,
        [Description("Compilation")]
        Compilation = 10,
        [Description("Split video")]
        SplitVideo = 12,
        [Description("Collaboration")]
        Collaboration = 13
    }
}
