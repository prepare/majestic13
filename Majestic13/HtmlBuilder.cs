using System;
using System.Collections.Generic;

namespace Majestic13
{
    public class HtmlBuilder
    {
        public HtmlBuilder()
        {
            current = new HtmlNode.Tag();
            stack = new Stack<HtmlNode.Tag>();
        }

        HtmlNode.Tag current;

        Stack<HtmlNode.Tag> stack;

        public void OpenTag(string name, Dictionary<string, string> attributes)
        {
            stack.Push(current);
            current = new HtmlNode.Tag(name, attributes, new List<HtmlNode>());
        }

        void CloseLastTag()
        {
            var node = current;
            current = stack.Pop();
            current.Children.Add(node);
        }

        public void CloseTag(string name)
        {
            if (current.Name == "")
            {
                // unreal situation  stack.Count!=0 && current.Name==""
                if (stack.Count != 0) throw new Exception();

                var node = new HtmlNode.Tag(name, current.Attributes, current.Children);
                current.Attributes = new Dictionary<string, string>();
                current.Children = new List<HtmlNode>();
                current.Children.Add(node);
            }
            else
            {
                if (current.Name == name)
                {
                    CloseLastTag();
                }
                else
                {
                    CloseLastTag();
                    CloseTag(name);
                }
            }
        }

        public void AddText(string text)
        {
            current.Children.Add(new HtmlNode.Text(text));
        }
        public void AddComment(string text)
        {
            current.Children.Add(new HtmlNode.Comment(text));
        }
        public void AddScript(string text)
        {
            current.Children.Add(new HtmlNode.Script(text));
        }

        public HtmlNode Render()
        {
            if (current.Name == "")
            {
                // unreal situation  stack.Count!=0 && current.Name==""
                if (stack.Count != 0) throw new Exception();

                return current;
            }
            else
            {
                CloseLastTag();
                return Render();
            }
        }
    }
}
