using UnityEngine;
using UnityEngine.UI;

public class HatRefresh : MonoBehaviour
{
    public Sprite hatSprite;
    public Sprite lockedSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Refresh(bool unlocked) {
        if (unlocked) {
            GetComponent<Image>().sprite = hatSprite;
        }
        else {
            GetComponent<Image>().sprite = lockedSprite;
        }
    }
}
