/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
 */

using System.Linq;
using Xunit;
using magic.node.extensions;

namespace magic.lambda.html.tests
{
    public class HtmlTests
    {
        [Fact]
        public void FromHtml()
        {
            var result = Common.Evaluate(@"
html2lambda:@""<html>
  <head>
    <title>Foo</title>
  </head>
  <body>
    <p class=""""howdy"""">
  </body>
</html>""");
            Assert.Equal("Foo", new Expression("**/html2lambda/*/*/*/title/*/\\#text").Evaluate(result).First().Value);
            Assert.Equal("howdy", new Expression("**/html2lambda/*/*/*/p/*/\\@class").Evaluate(result).First().Value);
        }
    }
}
