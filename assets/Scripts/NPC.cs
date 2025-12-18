using UnityEngine;
using System.Collections.Generic;
public class NPC : MonoBehaviour
{
    [SerializeField] GameObject GUI;
    AudioSource music;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Sprite> portraits;
    public List<string> l = new List<string>{};
    public bool hasTalkedTo = false;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.name == "BeanieGuy")
        {
            GUI.GetComponent<Pause>().OpenShop();
        }
        else if (collision.gameObject.CompareTag("Player") && !hasTalkedTo)
        {
            // music = GetComponent<AudioSource>();
            //music.volume = 0.7f;
            //music.Play();
            DialogueManager.StartDialogue(l, portraits);
            hasTalkedTo = true;
        }
    }
}
