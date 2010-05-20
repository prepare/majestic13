using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

using Majestic13;

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
    }
}
