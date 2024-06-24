using System;
using System.Collections;
using System.Linq;
using Godot;
using Godot.Collections;

//IEnumerator Implamentation copied from Microsoft Example
public class invEnum : IEnumerator
{
    public inventory _Items;
    public invEnum(inventory list)
    {
        _Items = list;
    }

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
                return _Items.ElementAt(position);
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
