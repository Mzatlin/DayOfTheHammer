using TMPro;

public interface ITypeCharacter
{
    float TypingSpeed { get;  }
    int TypingIndex { get; set; }
    TextMeshProUGUI TypeContent { get;  }
}