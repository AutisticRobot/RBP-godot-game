using System;
using System.Collections;
using System.Linq;
using Godot;
using Godot.Collections;

//IEnumerator Implamentation copied from Microsoft Example
public class dicEnum : IEnumerator
{
    public Dictionary _Items;
    //public dicEnum(Dictionary list)
    //{
    //    _Items = list;
    //}

    // Enumerators are positioned before the first element
    // until the first MoveNext() call.
    public int position = -1;


    public bool MoveNext()
    {
        position++;
        return (position < _Items.Count);
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

    public Variant Current
    {
        get
        {
            try
            {
                return _Items.ElementAt(position).Value;
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
public class ItemEnum : dicEnum
{
    new public Dictionary<int, Item> _Items;

    public ItemEnum(Dictionary<int, Item> list)
    {
        _Items = list;
    }

    new public Item Current
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
public class ShopItemEnum : dicEnum
{
    new public Dictionary<int, ShopItem> _Items;

    public ShopItemEnum(Dictionary<int, ShopItem> list)
    {
        _Items = list;
    }

    new public ShopItem Current
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
