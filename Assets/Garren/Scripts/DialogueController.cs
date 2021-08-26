using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

public class DialogueController : MonoBehaviour {

    [SerializeField] private DialogueRunner runner;

    [SerializeField] private DialogueUI dialogueUI;

    [SerializeField] private UnityEvent skipHandler;

    void Awake() {
        StoreEvents.prologueEvent.AddListener(() => {
            runner.StartDialogue("welcome");
        });

        StoreEvents.instructionEvent.AddListener((Dictionary<string, string> data) => {
            runner.variableStorage.SetValue("$id", data["ID"]);
            runner.variableStorage.SetValue("$item_name", data["name"]);
            runner.variableStorage.SetValue("$instruction", data["desc"]);
            runner.variableStorage.SetValue("$price", int.Parse(data["price"]));
            runner.StartDialogue("instruction");
        });
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        skipHandler?.Invoke();
    }
}
