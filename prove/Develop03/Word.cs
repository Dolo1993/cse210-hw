class Word
{
    string text;
    bool isHidden;

    public Word(string _text)
    {
        text = _text;
        isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }

    public bool GetIsHidden()
    {
        return isHidden;
    }

    public string GetDisplayText()
    {
        if (isHidden)
        {
            return new string('_', text.Length);
        }
        else
        {
            return text;
        }
    }
}