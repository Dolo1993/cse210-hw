 using System;
using System.Collections.Generic;
using System.Linq;

class Scripture
{
    Reference reference;
    List<Word> words;

    public Scripture(Reference _reference, string _text)
    {
        reference = _reference;
        words = _text.Split(' ').Select(wordString => new Word(wordString)).ToList();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        List<Word> visibleWords = words.Where(word => !word.GetIsHidden()).ToList();

        if (visibleWords.Count > 0)
        {
            int randomIndex = random.Next(visibleWords.Count);
            visibleWords[randomIndex].Hide();
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = "";

        foreach (Word word in words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }

        return $"{reference.GetDisplayText()} {scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        return words.All(word => word.GetIsHidden());
    }
}