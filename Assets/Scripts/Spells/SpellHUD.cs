using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpellHUD : MonoBehaviour {

    public Spell         spell;
    public RectTransform overCostRectTransform;
    public RectTransform cantCastRectTransform;
    public Text          overCostText;
    public Text          cantCastText;
    public Text          currentTimeText;
    public float         imagesHeight = 60f;


    void Update () {
        UpdateTexts();
        UpdateImages();
    }


    void UpdateTexts () {
        UpdateOverCostText();
        UpdateCantCastText();
        UpdateCurrentTimeText();
    }


    void UpdateOverCostText () {
        float value = Mathf.Max(0, spell.overCostValue - spell.currentTime);
        overCostText.text = (Mathf.Ceil(value * 10) / 10).ToString();
    }


    void UpdateCantCastText () {
        float value = Mathf.Max(0, spell.cantCastValue - spell.currentTime);
        cantCastText.text = (Mathf.Ceil(value * 10) / 10).ToString();
    }


    void UpdateCurrentTimeText () {
        currentTimeText.text = (Mathf.Ceil(spell.currentTime * 10) / 10).ToString();
    }


    void UpdateImages () {
        UpdateOverCostImage();
        UpdateCantCastImage();
    }


    void UpdateOverCostImage () {
        float ratio  = Mathf.Clamp(spell.currentTime / spell.overCostValue, 0, 1);
        overCostRectTransform.anchorMax = new Vector2(1, ratio);
    }

    
    void UpdateCantCastImage () {
        float ratio  = Mathf.Clamp((spell.currentTime - spell.overCostValue) / (spell.cantCastValue - spell.overCostValue), 0, 1);
        cantCastRectTransform.anchorMax = new Vector2(1, ratio);
    }
}