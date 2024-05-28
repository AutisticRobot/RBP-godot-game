using System;
using System.Collections;

//IEnumerator Implamentation copied from Microsoft Example
public class ItemEnum : IEnumerator
{
    public Item[] _Items;

    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int position = -1;

    public ItemEnum(Item[] list)
    {
        _Items = list;
    }

    public bool MoveNext()
    {
        position++;
        return (position < _Items.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Item Current
    {
        get
        {
            try
            {
                return _Items[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
public class ShopItemEnum : IEnumerator
{
    public ShopItem[] _Items;

    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    int position = -1;

    public ShopItemEnum(ShopItem[] list)
    {
        _Items = list;
    }

    public bool MoveNext()
    {
        position++;
        return (position < _Items.Length);
    }

    public void Reset()
    {
        position = -1;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Item Current
    {
        get
        {
            try
            {
                return _Items[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
