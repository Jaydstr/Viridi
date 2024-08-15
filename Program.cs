using System;
using System.Text.RegularExpressions;

namespace MarkdownToHtmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example Markdown content
            string markdown = @"
# Hading 1

Paragraph testing **emphasis** and link test [link](https://hgo.com).

- Item 1
- Item 2
- Item 3
";

            // Convert Markdown to HTML
            string html = ConvertMarkdownToHtml(markdown);

            // Display the HTML
            Console.WriteLine(html);
        }

        static string ConvertMarkdownToHtml(string markdown)
        {
            // Convert headers
            markdown = Regex.Replace(markdown, @"^# (.*)$", "<h1>$1</h1>", RegexOptions.Multiline);
            markdown = Regex.Replace(markdown, @"^## (.*)$", "<h2>$1</h2>", RegexOptions.Multiline);
            markdown = Regex.Replace(markdown, @"^### (.*)$", "<h3>$1</h3>", RegexOptions.Multiline);

            // Convert bold text
            markdown = Regex.Replace(markdown, @"\*\*(.+?)\*\*", "<strong>$1</strong>");

            // Convert links
            markdown = Regex.Replace(markdown, @"\[(.+?)\]\((.+?)\)", "<a href=\"$2\">$1</a>");

            // Convert unordered list items
            markdown = Regex.Replace(markdown, @"^- (.+)$", "<li>$1</li>", RegexOptions.Multiline);

            // Wrap list items with <ul> tags
            markdown = Regex.Replace(markdown, @"((<li>.*<\/li>\s*)+)", "<ul>$1</ul>", RegexOptions.Singleline);

            // Convert paragraphs
            markdown = Regex.Replace(markdown, @"([^\n]+)\n", "<p>$1</p>\n");

            return markdown;
        }
    }
}
