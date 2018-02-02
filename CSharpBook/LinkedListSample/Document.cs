using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListSample
{
    public class Document
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public byte Priority { get; private set; }

        public Document(string title,string content,byte priorty)
        {
            this.Title = title;
            this.Content = content;
            this.Priority = priorty;
        }
    }
}
