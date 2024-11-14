class Program
{
    static void Main()
    {
        LinkedList<int> linkedList = new LinkedList<int>();
        
        linkedList.AddFirst(10);
        linkedList.AddFirst(20);
        linkedList.AddFirst(30);
        linkedList.AddFirst(40);
        linkedList.RemoveLast();

        Console.WriteLine(linkedList.Find(30).Value);


        foreach (LinkedListNode<int> node in linkedList.ToArray())
        {
            Console.WriteLine(node.Value);
        }
    }
}