using UnityEngine;
using TMPro;

public class TextBoxManager : MonoBehaviour
{
    //Doel script
    //Aangegeven tekst in de chatbubbel zetten en de achtergrond mee laten schalen

    public string textToSay;

    private SpriteRenderer chatBg;
    private TextMeshPro textMeshPro;

    private void Awake()
    {
        //Component opzoeken in onze children
        textMeshPro = transform.Find("TextLine").GetComponent<TextMeshPro>();
        chatBg = transform.Find("ChatBackground").GetComponent<SpriteRenderer>();

        //Als dit op het object zelf zat
        //textMeshPro = GetComponent<TextMeshPro>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Setup(textToSay);
    }

    /// <summary>
    /// Setup the text and size of the background
    /// </summary>
    /// <param name="text">Text to use</param>
    private void Setup(string text)
    {
        //Hier gaan we de text toepassen, scale/resize en dan is het klaar
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        //Ophalen hoe breedt/hoog de tekst is
        Vector2 textSize = textMeshPro.GetRenderedValues(false);

        //Padding toevoegen om de randjes wwat mooier te maken
        Vector2 padding = new Vector2(0.5f, 0.2f);

        //Achtergrond meescale in de breedte zodat die achter de tekst blijft
        chatBg.size = textSize+padding;
    }
}
