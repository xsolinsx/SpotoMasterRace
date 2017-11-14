using System.ComponentModel;

internal struct StructSet
{
    private char name;
    private BindingList<string> elements;
    private bool ordered;

    public StructSet(char _name)
    {
        this.name = _name;
        this.elements = new BindingList<string>();
        this.ordered = false;
    }

    public StructSet(char _name, BindingList<string> _elements, bool _ordered = false)
    {
        this.name = _name;
        this.elements = _elements;
        this.ordered = _ordered;
    }

    public StructSet(StructSet _set)
    {
        this.name = _set.Name;
        this.elements = _set.Elements;
        this.ordered = _set.Ordered;
    }

    public char Name
    { get { return name; } }

    public BindingList<string> Elements
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
            foreach (string item in this.elements)
                strElements += item + ",";
            //remove comma and whitespace
            strElements = strElements.Remove(strElements.Length - 1);
            return this.name + " = " + (this.ordered ? "( " : "{ ") + strElements + (this.ordered ? " )" : " }");
        }
        catch
        { return this.name + " = " + (this.ordered ? "( " : "{ ") + (this.ordered ? " )" : " }"); }
    }

    public StructSet Sort()
    {
        for (int i = 0; i < this.Cardinality; i++)
            for (int j = 0; j < this.Cardinality; j++)
                if (this.elements[i].Length < this.elements[j].Length)
                {
                    string tmp = this.elements[i];
                    this.elements[i] = this.elements[j];
                    this.elements[j] = tmp;
                }
        return this;
    }
}