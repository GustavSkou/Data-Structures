class LinkedListNode<T>
{
    private LinkedListNode<T>? nextNode, prevNode;
    private T value;

    public LinkedListNode<T>? NextNode
    {
        get { return nextNode; }
        set { nextNode = value; }
    }

    public LinkedListNode<T>? PrevNode
    {
        get { return prevNode; }
        set { prevNode = value; }
    }

    public T? Value
    {
        get { return value; }
        set { this.value = value!; }
    }

    public LinkedListNode()
    {
        nextNode = null;
        prevNode = null;
        value = default!;
    }
}

class LinkedList<T> : LinkedListNode<T>
{
    private LinkedListNode<T>? head, tail;

    private int count;

    public LinkedListNode<T>? Head
    {
        get { return head; }
    }

    public LinkedListNode<T>? Tail
    {
        get { return tail; }
    }

    public int Count
    {
        get { return count; }
    }

    public LinkedList()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public void AddFirst(T value)
    {
        LinkedListNode<T> node = new()
        {
            Value = value
        };

        if (head == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            node.NextNode = head;
            head.PrevNode = node;
            head = node;
        }
        count++;
    }

    public void AddLast(T value)
    {
        LinkedListNode<T> node = new();
        node.Value = value;
        if (tail == null)
        {
            head = node;
            tail = node;
        }
        else
        {
            tail.NextNode = node;
            node.PrevNode = tail;
            tail = node;
        }
        count++;
    }

    public void Remove(T value)
    {
        LinkedListNode<T>? node = head;

        while (node != null)
        {
            if (node.Value != null && node.Value.Equals(value))
            {
                count--;
                if (node == head)
                {
                    head = node.NextNode;
                    if (head != null) head.PrevNode = null;
                    return;
                }
                if (node == tail)
                {
                    tail = node.PrevNode;
                    if (tail != null) tail.NextNode = null;
                    return;
                }
                node.PrevNode!.NextNode = node.NextNode;
                node.NextNode!.PrevNode = node.PrevNode;
                return;
            }
            node = node.NextNode;
        }
        throw new InvalidOperationException($"Value {value} could not be found");
    }

    public void Remove(LinkedListNode<T> nodeObj)
    {
        LinkedListNode<T>? node = head;

        while (node != null)
        {
            if (node.Equals(nodeObj))
            {
                count--;
                if (node == head)
                {
                    head = node.NextNode;
                    return;
                }
                if (node == tail)
                {
                    tail = node.PrevNode;
                    return;
                }
                node.PrevNode = node.NextNode;
                return;
            }
            node = node.NextNode;
        }
        throw new InvalidOperationException($"Value {nodeObj} could not be found");
    }

    public void RemoveFirst()
    {
        if (head != null)
        {
            count--;
            head = head.NextNode;
            if (head != null) head.PrevNode = null;
        }
        else throw new NullReferenceException();
    }

    public void RemoveLast()
    {
        if (tail != null)
        {
            count--;
            tail = tail.PrevNode;
            if (tail != null) tail.NextNode = null;
        }
        else throw new NullReferenceException();
    }

    public LinkedListNode<T> Find(T value)
    {
        LinkedListNode<T>? node = head;

        while (node != null)
        {
            if (node.Value != null && node.Value.Equals(value)) return node;
            node = node.NextNode;
        }
        throw new InvalidOperationException($"Value {value} could not be found");
    }

    public LinkedListNode<T>[] ToArray()
    {
        LinkedListNode<T>[] array = new LinkedListNode<T>[count];
        LinkedListNode<T>? node = head;
        int index = 0;
        while (node != null)
        {
            array[index] = node;
            node = node.NextNode;
            index++;
        }
        return array;
    }
}