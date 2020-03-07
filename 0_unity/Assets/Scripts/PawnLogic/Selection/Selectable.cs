using UnityEngine;

public class Selectable : MonoBehaviour
{
    private float highlightColorDifference = 0.5f;

    Color initialColor;
    Material material;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        initialColor = material.color;
    }

    public void OnHoverStateChange(bool isHovered)
    {
        if (isHovered)
        {
            Color.RGBToHSV(initialColor, out float H, out float S, out float V);
            material.color = Color.HSVToRGB(H, Mathf.Max(0, S - highlightColorDifference), V);
        }
        else
        {
            material.color = initialColor;
        }
    }

    public void OnStateChange(bool isSelected)
    {
        
    }
}
