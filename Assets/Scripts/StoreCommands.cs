using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class StoreCommands : MonoBehaviour {

    [SerializeField] private Animator stateMachine;

    [SerializeField] private DialogueRunner runner;
    [SerializeField] private DialogueUI dialogueUI;
    void Awake() {
        runner.AddCommandHandler("finish", Finish);
    }

    [YarnCommand("finish")]
    private void Finish(string[] parameters) {
        stateMachine.SetBool("enableDialogue", false);
    }
}
