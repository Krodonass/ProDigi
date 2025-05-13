using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OvenResultView : MonoBehaviour
{

    public TextMeshProUGUI Header;
    public TextMeshProUGUI Description;
    public Image BackgroundImage;
    
    public void LoadResult(OvenPreset preset)
    {
        Header.text = preset.header;
        Description.text = preset.description;
        BackgroundImage.color = preset.color;
    }
}
