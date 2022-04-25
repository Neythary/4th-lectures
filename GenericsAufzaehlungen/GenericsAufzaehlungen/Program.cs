// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class Array<T>
{
    private T[]? _value;

    public T[]? Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public Array(int laenge)
    {
        this.Value = new T[laenge];
    }

    public Type GetDatentyp()
    {
        return typeof(T);
    }
}

public class Liste<T>
{
    private List<T> _value;

    public List<T> Value
    {
        get { return _value; }
        set { _value = value; }
    }

    public Liste()
    {
        this._value = new List<T>();
    }

    public Type GetDatentyp()
    {
        return typeof(T);
    }

    public void addValue(T added)
    {
        _value.Add(added);
    }

    public T getDataFromIndex(int index)
    {
        return _value.ElementAt(index);
    }
}

class Programm
{
    static void main(string[] args)
    {
        Array<string> stringarrayinhaber = new Array<string>(5);

        Type datentyp = stringarrayinhaber.GetDatentyp();

        Liste<string> stringlistinhaber = new Liste<string>();


    }
}
