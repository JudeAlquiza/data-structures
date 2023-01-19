namespace DataStructures.LinkedList;

public class DoublyLinkedListNode<T>
{
	public DoublyLinkedListNode(T data, DoublyLinkedListNode<T>? previous = null, DoublyLinkedListNode<T>? next = null)
	{
		Data = data;
		Previous = previous;
		Next = next;
	}

	public T? Data { get; set; }

	public DoublyLinkedListNode<T>? Previous { get; set; }

	public DoublyLinkedListNode<T>? Next { get; set; }
}
