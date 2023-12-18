using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions.ValueExceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.CustomStructures;

public class CustomDictionaryRealization<T>
{
    private int[] _keys;
    private T?[] _values;
    private int _size;

    public CustomDictionaryRealization(int capacity)
    {
        if (capacity < 0) throw new ValueOutOfRangeException();
        _keys = new int[capacity];
        _values = new T?[capacity];
        _size = 0;
    }

    public void Add(int key, T? value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        _keys[_size] = key;
        _values[_size] = value;
        _size++;
    }

    public T? Get(int key)
    {
        if (key < 0) throw new ValueOutOfRangeException();
        for (int i = 0; i < _size; i++)
        {
            if (_keys[i] == key)
            {
                return _values[i];
            }
        }

        return default;
    }

    public void Set(int key, T? newValue)
    {
        if (newValue == null) throw new ArgumentNullException(nameof(newValue));
        _keys[_size] = key;
        _values[_size] = newValue;
    }
}