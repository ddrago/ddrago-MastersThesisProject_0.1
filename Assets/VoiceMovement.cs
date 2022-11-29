using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceMovement : MonoBehaviour
{

    private KeywordRecognizer keywordRecognizer;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");

        actions.Add("forward", Forward);
        actions.Add("up", Up);
        actions.Add("down", Down);
        actions.Add("back", Back);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += recognizedPhrase;
        keywordRecognizer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void recognizedPhrase(PhraseRecognizedEventArgs phrase)
    {
        Debug.Log(phrase.text);
        actions[phrase.text].Invoke();
    }

    private void Forward()
    {
        transform.Translate(1, 0, 0);
    }

    private void Back()
    {
        transform.Translate(-1, 0, 0);
    }

    private void Up()
    {
        transform.Translate(0, 1, 0);
    }

    private void Down()
    {
        transform.Translate(0, -1, 0);
    }
}
