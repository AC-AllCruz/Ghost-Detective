using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    private Light flashlight;

    public bool IsUVMode => Input.GetMouseButton(1);

    public Color NormalColor;
    public Color UVColor; //7401FF


    private void Awake()
    {
        flashlight = GetComponent<Light>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }

        // Update the flashlight color based on the mode
        flashlight.color = IsUVMode 
            ? UVColor 
            : NormalColor;
    }

}

