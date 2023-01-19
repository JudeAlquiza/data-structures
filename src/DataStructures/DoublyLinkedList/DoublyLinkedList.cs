namespace DataStructures.LinkedList;

public class DoublyLinkedList<T>
{
    private int _size = 0;

    private DoublyLinkedListNode<T?>? _head;

    private DoublyLinkedListNode<T?>? _tail;

    public void Clear()
    {
        var currentNode = _head;

        while(currentNode != null) 
        {
            var next = currentNode.Next;
            currentNode.Next = currentNode.Previous = null;
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
        if (IsEmpty)
        {
            _head = _tail = new DoublyLinkedListNode<T?>(data);
        }
        else
        {
            _head!.Previous = new DoublyLinkedListNode<T?>(data, next: _head);
            _head = _head.Previous;
        }

        _size += 1;
    }

    public void AddLast(T? data)
    {
        if (IsEmpty)
        {
            _head = _tail = new DoublyLinkedListNode<T?>(data);
        }
        else
        {
            _tail!.Next = new DoublyLinkedListNode<T?>(data, previous: _tail);
            _tail = _tail.Next;
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
        else
        {
            _head!.Previous = null;
        }

        return data;
    }

    public T? RemoveLast()
    {
        if (IsEmpty)
        {
            throw new IndexOutOfRangeException("The list is empty.");
        }

        T? data = _tail!.Data;
        _tail = _tail.Previous;
        _size -= 1;

        if (IsEmpty)
        {
            _head = null;
        }
        else
        {
            _tail!.Next = null;
        }

        return data;
    }

    public T? Remove(DoublyLinkedListNode<T> node)
    {
        if (node.Previous == null)
        {
            return RemoveFirst();
        }
        
        if (node.Next == null) 
        {
            return RemoveLast();
        }

        node.Next.Previous = node.Previous;
        node.Previous.Next = node.Next;

        T? data = node.Data;

        node.Data = default;
        node.Previous = node.Next = null;

        _size -= 1;

        return data;
    }

    public T? RemoveAt(int index)
    {
        if (index < 0 || index >= _size)
        {
            throw new ArgumentOutOfRangeException("Index out of range.");
        }

        DoublyLinkedListNode<T>? currentNode;

        if (index < _size / 2) 
        {
            currentNode = _head!;

            for (int i = 0; i != index; i++)
            {
                currentNode = currentNode!.Next;
            }
        }
        else 
        {
            currentNode = _tail!;

            for (int i = _size - 1; i != index; i--) 
            {
                currentNode = currentNode!.Previous;
            }
        }

        return Remove(currentNode!);
    }

    public bool Remove(T? data)
    {
        var currentNode = _head!;

        if (data == null)
        {
            for (int i = 0; i < _size; i++)
            {
                if (currentNode == null)
                {
                    Remove(currentNode!);
                    return true;
                }
            }
        }
        else
        {
            for (int i = 0; i < _size; i++)
            {
                if (currentNode.Data != null && currentNode.Data.Equals(data))
                {
                    Remove(currentNode!);
                    return true;
                }
            }
        }

        return false;
    }

    public int IndexOf(T? data)
    {
        var currentNode = _head!;

        if (data == null)
        {
            for (int i = 0; i < _size; i++)
            {
                if (currentNode == null)
                {
                    return i;
                }
            }
        }
        else
        {
            for (int i = 0; i < _size; i++)
            {
                if (currentNode.Data != null && currentNode.Data.Equals(data))
                {
                    return i;
                }
            }
        }

        return -1;
    }

    public bool Contains(T? data) => IndexOf(data) != -1;
}
