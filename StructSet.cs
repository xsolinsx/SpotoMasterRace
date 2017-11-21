using System.ComponentModel;

internal struct StructSet<T>
{
    private char name;
    private BindingList<T> elements;
    private bool ordered;

    public StructSet(char _name)
    {
        this.name = _name;
        this.elements = new BindingList<T>();
        this.ordered = false;
    }

    public StructSet(char _name, BindingList<T> _elements, bool _ordered = false)
    {
        this.name = _name;
        this.elements = _elements;
        this.ordered = _ordered;
    }

    public StructSet(StructSet<T> _set)
    {
        this.name = _set.Name;
        this.elements = _set.Elements;
        this.ordered = _set.Ordered;
    }

    public char Name
    { get { return name; } }

    public BindingList<T> Elements
    {
        get { return elements; }
        set { elements = value; }
    }

    public bool Ordered
    {
        get { return ordered; }
        set { ordered = value; }
    }

    public int Cardinality
    { get { return elements.Count; } }

    public override string ToString()
    {
        try
        {
            string strElements = "";
            foreach (T item in this.elements)
                strElements += item.ToString() + ",";
            //remove comma and whitespace
            strElements = strElements.Remove(strElements.Length - 1);
            return this.name + " = " + (this.ordered ? "( " : "{ ") + strElements + (this.ordered ? " )" : " }");
        }
        catch
        { return this.name + " = " + (this.ordered ? "( " : "{ ") + (this.ordered ? " )" : " }"); }
    }

    public StructSet<T> Sort()
    {
        for (int i = 0; i < elements.Count - 1; i++)
            for (int j = 0; j < elements.Count - 1; j++)
                if (elements[j].ToString().Split(',').Length <= elements[j + 1].ToString().Split(',').Length)
                {
                    if (elements[j].ToString().Split(',').Length == elements[j + 1].ToString().Split(',').Length && elements[j].ToString().Length > elements[j + 1].ToString().Length)
                    {
                        T tmp = elements[j];
                        elements[j] = elements[j + 1];
                        elements[j + 1] = tmp;
                    }
                }
                else
                {
                    T tmp = elements[j];
                    elements[j] = elements[j + 1];
                    elements[j + 1] = tmp;
                }
        return this;
    }
}