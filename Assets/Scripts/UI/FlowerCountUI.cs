using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlowerCountUI : MonoBehaviour
{
    public TextMeshProUGUI flowerText;
    public float flower;

    void Start()
    {
    }


    void Update()
    {
        flowerText.text = flower + "";
    }
}