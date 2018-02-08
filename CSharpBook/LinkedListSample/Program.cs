using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var pdm = new PriorityDocumentManager();
            pdm.AddDocument(new Document("one", "sample", 8));
            pdm.AddDocument(new Document("two", "sample", 3));
            pdm.AddDocument(new Document("three", "sample", 4));
            pdm.AddDocument(new Document("four", "sample", 8));
            pdm.AddDocument(new Document("five", "sample", 1));
            pdm.AddDocument(new Document("six", "sample",9));
            pdm.AddDocument(new Document("seven", "sample", 1));
            pdm.AddDocument(new Document("eight", "sample", 1));
            pdm.DiaplayAllNodes();
        }
    }
}
