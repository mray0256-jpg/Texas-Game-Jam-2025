using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    AudioSource music;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static GameObject DialogueGUI;
    public static TextMeshProUGUI dialogue;
    public static Image portrait;

    private static List<string> lines;
    private static List<Sprite> sprites;
    private static bool isDialogue;
    private static int index;
    void Start()
    {
        DialogueGUI = transform.GetChild(4).gameObject;
        dialogue = transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>();
        portrait = transform.GetChild(4).GetChild(2).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogue)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (index == lines.Count)
                {
                    EndDialogue();
                }
                else
                {
                    music = GetComponent<AudioSource>();
                    music.volume = 0.7f;
                    music.Play();
                    dialogue.text = lines[index];
                    portrait.sprite = sprites[index];
                    index++;
                }
            }
        }
    }
    public static void StartDialogue(List<string> l, List<Sprite> s)
    {
        Player_Move.PausePlayerMovement();
        lines = l;
        sprites = s;
        isDialogue = true;
        index = 1;
        dialogue.text = lines[0];
        portrait.sprite = sprites[0];
        portrait.SetNativeSize();
        DialogueGUI.SetActive(true);
        CameraMovement.isDialogue(true);
    }
    public void EndDialogue()
    {
        Player_Move.PlayPlayerMovement();
        isDialogue = false;
        DialogueGUI.SetActive(false);
        CameraMovement.isDialogue(false);
    }
}
