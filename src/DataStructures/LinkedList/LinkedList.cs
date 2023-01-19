namespace DataStructures.LinkedList;

public class LinkedList<T>
{
    private int _size = 0;

    private LinkedListNode<T?>? _head;

    private LinkedListNode<T?>? _tail;

    public void Clear()
    {
        var currentNode = _head;

        while(currentNode != null) 
        {
            var next = currentNode.Next;
            currentNode.Next = null;
            currentNode.Data = default;
            currentNode = next;
        }

        _head = _tail = null;
        _size = 0;
    }

    public int Size => _size;

    public bool IsEmpty => _size == 0;

    public void AddFirst(T? data)
    {
        var newNode = new LinkedListNode<T?>(data);

        if (IsEmpty)
        {
            _head = _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head = newNode;
        }

        _size += 1;
    }

    public void AddLast(T? data)
    {
        var newNode = new LinkedListNode<T?>(data);

        if (IsEmpty)
        {
            _head = _tail = newNode;
        }
        else
        {
            _tail!.Next = newNode;
            _tail = newNode;
        }

        _size += 1;
    }

    public T? PeekFirst()
    {
        if (IsEmpty)
        {
            throw new IndexOutOfRangeException("The list is empty.");
        }

        return _head!.Data;
    }

    public T? PeekLast()
    {
        if (IsEmpty)
        {
            throw new IndexOutOfRangeException("The list is empty.");
        }

        return _tail!.Data;
    }

    public T? RemoveFirst()
    {
        if (IsEmpty)
        {
            throw new IndexOutOfRangeException("The list is empty.");
        }

        T? data = _head!.Data;
        _head = _head.Next;
        _size -= 1;

        if (IsEmpty)
        {
            _tail = null;
        }

        return data;
    }

    public T? RemoveLast()
    {
        if (IsEmpty)
        {
            throw new IndexOutOfRangeException("The list is empty.");
        }

        LinkedListNode<T> currentNode = _head!;

        if (_head == _tail)
        {
            return RemoveFirst();
        }

        while (currentNode!.Next != _tail) 
        {
            currentNode = currentNode.Next!;
        }

        T? data = _tail!.Data;
        currentNode.Next = null;
        _tail = currentNode!;
        return data;
    }
}
