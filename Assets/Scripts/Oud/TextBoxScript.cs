using UnityEngine;
using TMPro;

public class TextBoxScript : MonoBehaviour
{

    public string textToSay;

    private SpriteRenderer chatBg;
    private TextMeshPro textMeshPro;

    private void Awake()
    {
        textMeshPro = transform.Find("TextLine").GetComponent<TextMeshPro>();
        chatBg = transform.Find("ChatBackground").GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {
        Setup(textToSay);
    }

    private void Setup(string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(false);

        Vector2 padding = new Vector2(0.3f, 2f);
        chatBg.size = textSize+padding;

        //Vector3 offset = new Vector3(-1.5f, 0);
        //chatBg.transform.localPosition = new Vector3(chatBg.size.x / 2f, chatBg.transform.localPosition.y)+offset;
        

    }
}
