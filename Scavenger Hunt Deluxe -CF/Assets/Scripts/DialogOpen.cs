using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOpen : MonoBehaviour
{

    public string dialog;
    public GameObject interfaceManager;
    public PlayerHolding pHolding;
    public bool begin = true;
    public bool end = false;
    private string[] collectibles;
    public string[] phrases;
    private int clue;

    private AudioSource greeting;

    // Start is called before the first frame update
    void Start()
    {
        greeting = GetComponent<AudioSource>();
        collectibles = new string[] { "film", "balloons", "life saver", "bull's eye", "pipe", "key", "fish", "birdhouse", "red airhorn", "magic hat" };
        phrases = new string[] {
            "I lost my video film. Think you can help",
            "I can't find my party balloons. Could you help me out",
            "I lost my life saver. Will you look for it",
            "I can't play archery without my bull's eye. Will you help me find it",
            "I'm looking for my pipe. Have you seen it",
            "I dropped the key to my safe. Will you help me locate it",
            "I need to cook my fish for dinner. will you get it",
            "I lost my bird house. Bring it back for me",
            "I need my red airhorn for the game today. Help me find it",
            "I want to preform some magic tricks at the park but lost my hat. Will you help find it"
        };
        createClue();
    }


    public void createClue()
    {
        clue = Random.Range(0, 9);
        searchDialog();
    }

    public void searchDialog()
    {
        //dialog = "Hi can you help me find my " + collectibles[clue];
        dialog = "Hi can you help me find my" + phrases[clue];
        //dialog = phrases[clue] + "?";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!begin && pHolding.Verify())
        {
            checkClue();
        }
        greeting.Play(0);
        interfaceManager.GetComponent<InterfaceManager>().ShowBox(dialog, clue);
    }

    private void checkClue()
    {
        if (pHolding.holdValue == clue)
        {
            dialog = "You found my " + collectibles[clue] + "!  Hooray!";
            end = true;
        }
        else
        {
            dialog = phrases[clue];
        }
    }

    public void coinsScattered()
    {
        begin = false;
    }

}
