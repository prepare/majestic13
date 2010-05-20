using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Majestic13
{
    public interface IHtmlNodeVisitor
    {
        void Visit(HtmlNode.Comment comment);
        void Visit(HtmlNode.Script script);
        void Visit(HtmlNode.Tag tag);
        void Visit(HtmlNode.Text text);
    }
}
