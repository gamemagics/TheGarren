using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class StoreController : MonoBehaviour {
    [SerializeField] private string startNode;

    [SerializeField] private DialogueRunner runner;

    [SerializeField] private YarnProgram script;

    [SerializeField] private bool enableDialogue = true;

    [SerializeField] private Animator stateMachine;

    void Awake() {
        runner.Add(script);
        runner.startNode = startNode;
        stateMachine.SetBool("enableDialogue", enableDialogue);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
