using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class StoreCommands : MonoBehaviour {

    [SerializeField] private Animator stateMachine;

    [SerializeField] private DialogueRunner runner;
    void Awake() {
        runner.AddCommandHandler("finish", Finish);
        runner.AddCommandHandler("clinch", Clinch);
    }

    [YarnCommand("finish")]
    private void Finish(string[] parameters) {
        stateMachine.SetBool("enableDialogue", false);
    }

    [YarnCommand("clinch")]
    private void Clinch(string[] parameters) {
        int id = int.Parse(parameters[0]);
        int price = int.Parse(parameters[1]);

        StoreEvents.bargainEvent.Invoke(new KeyValuePair<int, int>(id, price));
        StoreEvents.newItemEvent.Invoke(id);
    }
}
