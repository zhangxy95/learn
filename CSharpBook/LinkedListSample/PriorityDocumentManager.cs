using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListSample
{
    public class PriorityDocumentManager
    {
        private readonly LinkedList<Document> documentList;

        private readonly List<LinkedListNode<Document>> priorityNodes;

        public PriorityDocumentManager()
        {
            documentList = new LinkedList<Document>();

            priorityNodes = new List<LinkedListNode<Document>>(10);
            for (int i = 0; i < 10; i++)
            {
                priorityNodes.Add(new LinkedListNode<Document>(null));
            }
        }

        public void AddDocument(Document d)
        {
            if (d == null)
            {
                throw new ArgumentException("d");
            }

            AddDocumentToPriorityNode(d, d.Priority);
        }

        private void AddDocumentToPriorityNode(Document doc, byte priority)
        {
            //检查优先级范围
            if (priority > 9 || priority < 0)
            {
                throw new ArgumentException("Priority must between 0 and 9");
            }

            //检查是否存在一个相同的优先级
            if (priorityNodes[priority].Value == null)
            {
                --priority;
                if (priority >= 0)
                {
                    AddDocumentToPriorityNode(doc, priority);
                }
                else 
                {
                    documentList.AddLast(doc);
                    priorityNodes[doc.Priority] = documentList.Last;
                }
                return;
            }
            else
            {
                LinkedListNode<Document> prioNode = priorityNodes[priority];
                if (priority == doc.Priority)
                {
                    documentList.AddAfter(prioNode, doc);
                    priorityNodes[doc.Priority] = prioNode.Next;
                }
                else
                {
                    LinkedListNode<Document> firstPrioNode = prioNode;
                    while (firstPrioNode.Previous != null && firstPrioNode.Previous.Value.Priority == prioNode.Value.Priority)
                    {
                        firstPrioNode = prioNode.Previous;
                        prioNode = firstPrioNode;
                    }

                    documentList.AddBefore(firstPrioNode, doc);
                    priorityNodes[doc.Priority] = firstPrioNode.Previous;
                }
            }
        }

        public void DiaplayAllNodes()
        {
            foreach (Document doc in documentList)
            {
                Console.WriteLine("priority:{0},title {1}", doc.Priority, doc.Title);
            }
        }

        public Document GetDocument()
        {
            Document doc = documentList.First.Value;
            documentList.RemoveFirst();
            return doc;
        }
    }
}
