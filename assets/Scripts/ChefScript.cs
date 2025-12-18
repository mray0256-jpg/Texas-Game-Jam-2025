using UnityEngine;

public class ChefScript : MonoBehaviour
{
    public static bool Complete = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public bool AreAllChildrenActive(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            if (child.gameObject.GetComponent<Renderer>().enabled)// check own enabled/disabled state
            {
                return false;
            }
        }
        return true;
    }


    // Update is called once per frame
    void Update()
    {
        Complete = AreAllChildrenActive(this.gameObject);
        if (Complete)
        {
            GetComponent<AudioSource>().volume = 0.7f;
            GetComponent<AudioSource>().Play();
            this.enabled = false;
            Pause.isChef = true;
            //Debug.Log("Did it!");
        }
    }
}
