class Program
{
    static void Main()
    {
        LinkedList<int> linkedList1 = new LinkedList<int>();

        linkedList1.AddFirst(1);
        linkedList1.AddFirst(4);
        linkedList1.AddFirst(3);
        linkedList1.AddFirst(6);

        LinkedList<int> linkedList2 = new LinkedList<int>(linkedList1);

        foreach (LinkedListNode<int> node in linkedList2.ToArray())
        {
            Console.WriteLine(node.Value);
        }
    }
}