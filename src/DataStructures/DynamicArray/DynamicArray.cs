using System.Collections;

namespace DataStructures.DynamicArray;

public class DynamicArray<T> : IEnumerable<T> where T : struct
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

    /// <summary>
    /// Time  Complexity: O(1)
    ///
    /// Note:
    ///   There will be times when the array is at capacity
    ///   and a new array needs to be created in this case with
    ///   double the capacity, after that, elements will need to be
    ///   copied from the old array to the new array before the
    ///   new element is inserted. This operation will at worst be
    ///   O(n) and the
    ///   Amortized Time Complexity: O(1) 
    ///
    ///   Also were gonna need to allocate memory for the new array
    ///   hence we're gonna have
    ///     Space Complexity: O(n)
    /// </summary>
    /// <param name="element"></param>
    public void Append(T element)
    {
        InsertAtIndex(Size, element);
    }

    /// <summary>
    /// If index is not at the end of the array then
    /// Time  Complexity: O(n)
    ///
    /// If index is at the end of the array then
    /// Time  Complexity: O(1)
    ///
    /// Note:
    ///   There will be times when the array is at capacity
    ///   and a new array needs to be created in this case with
    ///   double the capacity, after that, elements will need to be
    ///   copied from the old array to the new array before the
    ///   new element is inserted. This operation will at worst be
    ///   O(n) and the
    ///   Amortized Time Complexity:
    ///     O(1) if index is at the end of the array
    ///     O(n) if index is not at the end of the array
    ///
    ///   Also were gonna need to allocate memory for the new array
    ///   hence we're gonna have
    ///     Space Complexity: O(n)
    /// </summary>
    /// <param name="index"></param>
    /// <param name="element"></param>
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

    /// <summary>
    /// Time  Complexity: O(n)
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
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


    /// <summary>
    /// Time  Complexity: O(n)
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public bool Contains(T element) => IndexOf(element) != -1;

    /// <summary>
    /// Time  Complexity: O(n)
    /// Space Complexity: O(n)
    /// </summary>
    /// <param name="indexToRemove"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public T RemoveAtIndex(int indexToRemove)
    {
        if (indexToRemove >= Size || indexToRemove < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(indexToRemove), "Index is out of bounds of the array");
        }

        var removedElement = _staticArray[indexToRemove];

        var newStaticArray = new T[Size - 1];

        for (int i = 0, j = 0; i < Size; i++, j++)
        {
            if (i == indexToRemove)
            {
                j -= 1;
            }
            else
            {
                newStaticArray[j] = _staticArray[i];
            }
        }

        _staticArray = newStaticArray;
        Size -= 1;

        return removedElement;
    }

    /// <summary>
    /// Time  Complexity: O(n)
    /// Space Complexity: O(n)
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public bool Remove(T element)
    {
        for (var i = 0; i < Size; i++)
        {
            if (_staticArray[i].Equals(element))
            {
                RemoveAtIndex(i);
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Time  Complexity: O(n)
    /// </summary>
    public void Clear()
    {
        for (var i = 0; i < Size; i++)
        {
            _staticArray[i] = default;
        }

        Size = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _staticArray.Cast<T>().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}