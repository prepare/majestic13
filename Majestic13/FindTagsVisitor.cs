using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Majestic13
{
    public class FindTagsVisitor : IHtmlNodeVisitor
    {
        public FindTagsVisitor(Predicate<HtmlNode.Tag> predicate) 
        {
            Result = new List<HtmlNode.Tag>();
            this.predicate = predicate;
        }

        public List<HtmlNode.Tag> Result { get; private set; }
        Predicate<HtmlNode.Tag> predicate;
        
        public void Visit(HtmlNode.Tag tag) 
        {
            if (predicate(tag)) Result.Add(tag);

            tag.Children.ForEach(x => x.AcceptVisitor(this));
        }

        
        public void Visit(HtmlNode.Comment comment) { }

        public void Visit(HtmlNode.Script script) { }

        public void Visit(HtmlNode.Text text) { }
    }
}
