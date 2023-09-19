using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;

    public DialogueSettings dialogue;

    public KeyCode interactionKey = KeyCode.E;

    bool playerHit;

    private List<string> sentences = new List<string>();
    private List<string> actorName = new List<string>();
    private List<Sprite> actorSprite = new List<Sprite>();


    private void Start() {
        GetNPCInfo();
    }

    private void Update() {
        PlayerInteraciton();
    }

    void PlayerInteraciton()
    {
        if (Input.GetKeyDown(interactionKey) && playerHit)
        {
            DialogueControl.Instance.Speech(sentences.ToArray(), actorName.ToArray(), actorSprite.ToArray());

            DialogueControl.Instance.NextSentence();
        }
    }

    private void FixedUpdate() {
        ShowDialogue();
    }

    void GetNPCInfo()
    {
        for (int i = 0; i < dialogue.dialogues.Count; i++)
        {
            switch (DialogueControl.Instance.language)
            {
                case DialogueControl.idiom.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                break;

                case DialogueControl.idiom.eng:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                break;

                case DialogueControl.idiom.spa:
                    sentences.Add(dialogue.dialogues[i].sentence.spanish);
                break;
                
            }

            actorName.Add(dialogue.dialogues[i].actorName);
            actorSprite.Add(dialogue.dialogues[i].profile);
        }
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if (hit != null)
        {
            playerHit = true;
        }
        else
        {
            playerHit = false;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}