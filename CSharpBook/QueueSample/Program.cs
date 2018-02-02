using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var dm = new DocumentManager();

            ProcessDocuments.Start(dm);

            for (int i = 0; i < 100; i++)
            {
                var doc = new Document("Doc" + i.ToString(), "content");
                dm.AddDocument(doc);
                Console.WriteLine("Added Document {0}", doc.Title);
                Thread.Sleep(new Random().Next(0, 1000));
            }
        }
    }
}
