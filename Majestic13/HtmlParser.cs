using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

using Majestic12;

namespace Majestic13
{
    public class HtmlParser
    {
        readonly Regex dedoctype = new Regex("<!.+?>", RegexOptions.Singleline);

        public HtmlNode Parse(string html)
        {
            // Majestic12 doesn't support doctype
            html = dedoctype.Replace(html, "");
            var builder = new HtmlBuilder();

            var parser = new HTMLparser();
            parser.bDecodeEntities = false;
            parser.SetChunkHashMode(true);
            parser.SetEncoding(System.Text.Encoding.UTF8);

            parser.Init(html);
            var chunk = parser.ParseNext();
            while (chunk != null)
            {
                switch (chunk.oType)
                {
                    case HTMLchunkType.OpenTag:
                        // if something goes wrong - ignore it
                        if (chunk.sTag != "")
                        {
                            var attributes = new Dictionary<string, string>();
                            if (chunk.iParams != 0)
                            {
                                foreach (string name in chunk.oParams.Keys)
                                {
                                    attributes.Add(name, (string)chunk.oParams[name]);
                                }
                            }
                            builder.OpenTag(chunk.sTag, attributes);
                        }
                        break;
                    case HTMLchunkType.Comment:
                        builder.AddComment(chunk.oHTML);
                        break;
                    case HTMLchunkType.CloseTag:
                        if (chunk.bEndClosure)
                        {
                            var attr = new Dictionary<string, string>();
                            if (chunk.iParams != 0)
                            {
                                foreach (string name in chunk.oParams.Keys)
                                {
                                    attr.Add(name, (string)chunk.oParams[name]);
                                }
                            }
                            builder.OpenTag(chunk.sTag, attr);
                            builder.CloseTag(chunk.sTag);
                        }
                        else
                        {
                            builder.CloseTag(chunk.sTag);
                        }
                        break;
                    case HTMLchunkType.Script:
                        builder.AddScript(chunk.oHTML);
                        break;
                    case HTMLchunkType.Text:
                        builder.AddText(chunk.oHTML);
                        break;
                    default:
                        break;
                }
                chunk = parser.ParseNext();
            }
            return builder.Render();
        }
    }
}
