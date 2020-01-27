using System;
using Tesseract;

namespace MinimalTesseractNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args[0];
            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            using (var img = Pix.LoadFromFile(path))
            using (var page = engine.Process(img))
            {
                var text = page.GetText();
                Console.WriteLine("Mean confidence: {0}", page.GetMeanConfidence());
                Console.WriteLine($"Text: \r\n{text}");
            }
        }
    }
}
