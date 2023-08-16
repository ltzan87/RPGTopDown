using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueControl : MonoBehaviour
{
    public static DialogueControl Instance { get; private set; }


    [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spa
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj;
    public Image profileSprite;
    public TMP_Text speechText;
    public TMP_Text actorNameText;

    [Header("Settings")]
    public float textSpeed;

    private bool _isShowing;
    private int _index; //sentences index
    private string[] _senteces;
    

    private void Awake() {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in _senteces[_index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    //Skip to next sentence
    public void NextSentence()
    {
        if (speechText.text == _senteces[_index])
        {
            if (_index < _senteces.Length - 1)
            {
                _index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                _index = 0;
                dialogueObj.SetActive(false);
                _senteces = null;

                _isShowing = false;
            }
        }
    }

    //Call NPC speech
    public void Speech(string[] txt)
    {
        if (!_isShowing)
        {
            dialogueObj.SetActive(true);
            _senteces = txt;
            StartCoroutine(TypeSentence());
            _isShowing = true;
        }
    }
}