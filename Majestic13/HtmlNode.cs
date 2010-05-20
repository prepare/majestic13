using System;
using System.Text;
using System.Collections.Generic;

namespace Majestic13
{
    public abstract class HtmlNode
    {
        public class Tag : HtmlNode
        {
            public Tag() : this("", new Dictionary<string,string>(), new List<HtmlNode>()) { }

            public Tag(string name, Dictionary<string, string> attributes, List<HtmlNode> children)
            {
                Name = name;
                Attributes = attributes;
                Children = children;
            }
            
            public string Name { get; set; }
            public Dictionary<string,string> Attributes { get; set; }
            public List<HtmlNode> Children { get; set; }
            public override void AcceptVisitor(IHtmlNodeVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public class Comment : HtmlNode
        {
            public Comment(string value) { Value = value; }
            public string Value { get; set; }
            public override void AcceptVisitor(IHtmlNodeVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public class Script : HtmlNode
        {
            public Script(string value) { Value = value; }
            public string Value { get; set; }
            public override void AcceptVisitor(IHtmlNodeVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public class Text : HtmlNode
        {
            public Text(string value) { Value = value; }
            public string Value { get; set; }
            public override void AcceptVisitor(IHtmlNodeVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public abstract void AcceptVisitor(IHtmlNodeVisitor visitor);
    }
}
