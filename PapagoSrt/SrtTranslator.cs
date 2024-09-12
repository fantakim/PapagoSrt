using SubtitlesParser.Classes;
using SubtitlesParser.Classes.Parsers;
using SubtitlesParser.Classes.Writers;
using System.Text;

namespace PapagoSrt
{
    public class SrtTranslator
    {
        private const int MaxBytes = 3000;
        private static PapagoDriver _driver;

        public static void Initialize()
        {
            _driver = new PapagoDriver();
        }

        public static void Cleanup()
        {
            _driver?.Dispose();
        }

        public static void Run(string sourceFile, string targetFile)
        {
            if (_driver == null)
                throw new InvalidOperationException("Papago driver is not initialized. Call Initialize() first.");

            var parser = new SrtParser();
            var items = parser.ParseStream(File.OpenRead(sourceFile), Encoding.UTF8);

            TranslateSubtitleItems(items);

            var writer = new SrtWriter();
            writer.WriteStream(File.OpenWrite(targetFile), items);
        }

        private static string TranslateText(string text)
        {
            return _driver.Translate(text);
        }

        private static void TranslateSubtitleItems(List<SubtitleItem> items)
        {
            var groupedItems = GroupItemsByByteLimit(items);

            foreach (var group in groupedItems)
            {
                TranslateGroup(group);
            }
        }

        private static List<List<SubtitleItem>> GroupItemsByByteLimit(List<SubtitleItem> items)
        {
            var groupedItems = new List<List<SubtitleItem>>();
            var currentGroup = new List<SubtitleItem>();
            var currentByteCount = 0;

            foreach (var item in items)
            {
                var itemByteCount = GetByteCount(item);
                if (currentByteCount + itemByteCount > MaxBytes)
                {
                    groupedItems.Add(currentGroup);
                    currentGroup = new List<SubtitleItem>();
                    currentByteCount = 0;
                }
                currentGroup.Add(item);
                currentByteCount += itemByteCount;
            }

            if (currentGroup.Any())
            {
                groupedItems.Add(currentGroup);
            }

            return groupedItems;
        }

        private static int GetByteCount(SubtitleItem item)
        {
            return Encoding.UTF8.GetByteCount(string.Join(Environment.NewLine, item.Lines) + Environment.NewLine);
        }

        private static void TranslateGroup(List<SubtitleItem> group)
        {
            var textToTranslate = string.Join(Environment.NewLine, group.SelectMany(item => item.Lines));
            var translatedText = TranslateText(textToTranslate);
            var translatedLines = translatedText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            int lineIndex = 0;
            foreach (var item in group)
            {
                for (int i = 0; i < item.Lines.Count && lineIndex < translatedLines.Length; i++)
                {
                    item.Lines[i] = translatedLines[lineIndex++];
                }
            }
        }
    }
}
