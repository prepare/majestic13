using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Majestic13;
using NUnit.Framework;

namespace MajesticTests
{
    [TestFixture]
    public class BasicTest
    {
        [Test]
        public void CaseA() 
        {
            var html = "<html><body><a href=\"#1\">foo</a></body></html>";
            var parser = new HtmlParser();
            var node = parser.Parse(html);
            Assert.That(node is HtmlNode.Tag);
        }

        [Test]
        public void CaseB()
        {
            var html = "<html><br/></html>";
            var parser = new HtmlParser();
            var node = parser.Parse(html);
            Assert.That(node is HtmlNode.Tag);
        }

        [Test]
        public void CaseC()
        {
            var html = File.ReadAllText(@"Resources\356.html");
            var parser = new HtmlParser();
            var node = parser.Parse(html);
            Assert.That(node is HtmlNode.Tag);
        }
    }
}
