using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivity : MonoBehaviour
{
    float mouseSens;
    public Slider mouseVal;
    public Text ValAmount;

    public void Awake()
    {
        mouseSens = PlayerPrefs.GetFloat("LookSensitivity");
        mouseVal.maxValue = 10f;
        mouseVal.value = mouseSens;
        ValAmount.text = mouseSens.ToString();
    }

    public void Update()
    {
        mouseSens = mouseVal.value;
        PlayerPrefs.SetFloat("LookSensitivity", mouseSens);
        ValAmount.text = mouseSens.ToString();
    }
}
