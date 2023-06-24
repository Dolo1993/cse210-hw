class Reference
{
    string book;
    int chapter, verse, endVerse;

    public Reference(string _book, int _chapter, int _verse)
    {
        book = _book;
        chapter = _chapter;
        verse = _verse;
        endVerse = 0;
    }

    public Reference(string _book, int _chapter, int _verseStart, int _verseEnd)
    {
        book = _book;
        chapter = _chapter;
        verse = _verseStart;
        endVerse = _verseEnd;
    }

    public string GetDisplayText()
    {
        if (endVerse != 0)
        {
            return $"{book} {chapter}:{verse}-{endVerse}";
        }
        else
        {
            return $"{book} {chapter}:{verse}";
        }
    }
}