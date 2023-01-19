namespace DataStructures.LinkedList;

public class LinkedListNode<T>
{
	public LinkedListNode(T data, LinkedListNode<T>? next = null)
	{
		Data = data;
		Next = next;
	}

	public T Data { get; set; }

	public LinkedListNode<T>? Next { get;set; }
}
