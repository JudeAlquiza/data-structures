namespace DataStructures;

public class DynamicArray<T> where T : struct
{
    private T[] _staticArray;
    private readonly int _capacity;

    public DynamicArray() : this(capacity: 16) { }

    public DynamicArray(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity cannot be less than zero (0).");
        }

        _capacity = capacity;
        _staticArray = new T[_capacity];
    }

    public int Size { get; private set; }

    public bool IsEmpty => Size == 0;

    public T GetAtIndex(int index) => _staticArray[index];

    public void SetAtIndex(int index, T element) => _staticArray[index] = element;

    public void Append(T element)
    {
        InsertAtIndex(Size, element);
    }

    public void InsertAtIndex(int index, T element)
    {
        if (Size == _capacity)
        {
            var newStaticArray = new T[_capacity == 0 ? 1 : 2 * _capacity];

            for (var i = 0; i < Size; i++)
            {
                newStaticArray[i] = _staticArray[i];
            }

            _staticArray = newStaticArray;
        }

        for (var i = Size - 1; i >= index; i--)
        {
            _staticArray[i + 1] = _staticArray[i];
        }

        _staticArray[index] = element;
        Size += 1;
    }

    public int IndexOf(T element)
    {
        for (var i = 0; i < Size; i++)
        {
            if (_staticArray[i].Equals(element))
            {
                return i;
            }
        }

        return -1;
    }

    public void RemoveAtIndex(int index)
    {
        if (index >= Size || index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Index is out of bounds of the array");
        }

        for (var i = index; i < Size - 1; i++)
        {
            _staticArray[i] = _staticArray[i + 1];
        }

        _staticArray[Size - 1] = default;

        Size -= 1;
    }

    public void Remove(T element)
    {
        var indexToRemove = 0;

        for (var i = 0; i < Size; i++)
        {
            if (_staticArray[i].Equals(element))
            {
                indexToRemove =  i;
            }
        }

        RemoveAtIndex(indexToRemove);
    }

    public void Clear()
    {
        for (var i = 0; i < Size; i++)
        {
            _staticArray[i] = default;
        }

        Size = 0;
    }
}