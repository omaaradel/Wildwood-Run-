using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public Image YellowStar;

    private void Awake()
    {
        YellowStar = GetComponent<Image>();
        YellowStar.transform.localScale = Vector3.zero;
    }
}