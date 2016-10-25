using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;

namespace Postbode.MimeKit
{
    public class MimeKitContent : IContent
    {
        public MimeEntity MimeEntity { get; set; }

        public bool IsMime => true;

        public string Type => MimeEntity.ContentType.ToString();

        public string Content
        {
            get { return MimeEntity.ToString(); }
            set { }
        }


        public MimeKitContent(MimeEntity entity = null)
        {
            MimeEntity = entity;
        }
    }

    public static class MimeKitContentExtension
    {
        public static IPostbode SeMimeKitContent(this IPostbode postbode, MimeEntity content)
        {
            postbode.SetContent(new MimeKitContent(content));
            return postbode;
        }
    }
}
