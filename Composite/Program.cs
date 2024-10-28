

Document document = new Document();
IDocumentComponent temp, temp_;
temp = new Paragraph();
(temp as Paragraph).Add("Текст Текст");
temp.Remove(1);
(temp as Paragraph).Add("ты");
temp_ = new Section();
temp_.Add(temp);
temp = new Section();
(temp_ as Section).Name = "2 уровень";
(temp as Section).Name = "1 уровень";
temp.Add(temp_);
temp_ = new Paragraph();
(temp_ as Paragraph).Add("Текст");
temp.Add(temp_);
document.Add(temp);
document.Name = "Название";
temp_ = new Section();
(temp_ as Section).Name = "1 уровень_";
document.Add(temp_);
document.Display();



interface IDocumentComponent
{
    public void Add(IDocumentComponent addition);
    public void Remove(int index);
    public void Display();
}


class Document : IDocumentComponent
{
    public string Name { private get; set; }
    private List<IDocumentComponent> documentComponents = new List<IDocumentComponent>();
    public void Add(IDocumentComponent addition) { if (addition.GetType() == typeof(Section)) documentComponents.Add(addition); }
    public void Remove(int index) { documentComponents.RemoveAt(index); }
    public void Display() 
    {
        Console.WriteLine("\t\t\t" + Name);
        foreach (IDocumentComponent component in documentComponents) { component.Display(); }
    }
}


class Section : IDocumentComponent
{
    public string Name { private get; set; }
    private List<IDocumentComponent> documentComponents = new List<IDocumentComponent>();
    public void Add(IDocumentComponent addition) { if (addition.GetType() != typeof(Document)) documentComponents.Add(addition); }
    public void Remove(int index) { documentComponents.RemoveAt(index); }
    public void Display()
    {
        Console.WriteLine("\t\t" + Name);
        foreach (IDocumentComponent component in documentComponents) { component.Display(); }
    }
}


class Paragraph : IDocumentComponent
{
    public string Text { private get; set; }
    public void Add(string text) { Text = Text + text; }
    public void Add(IDocumentComponent documentComponent) { }
    public void Remove(int numb) { Text = Text.Remove(Text.Length - numb, numb); }
    public void Display()
    {
        Console.WriteLine('\t' + Text);
    }
}