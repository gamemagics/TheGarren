using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Yarn.Unity;

public class DialogueController : MonoBehaviour {

    [SerializeField] private DialogueRunner runner;

    [SerializeField] private DialogueUI dialogueUI;

    [SerializeField] private UnityEvent skipHandler;
    private bool isOptionsDisplayed = false;

    void Awake() {
        StorePrologueEvent.prologueEvent.AddListener(() => {
            runner.StartDialogue();
        });
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        skipHandler?.Invoke();
    }

    public void EnableOptions(bool flag) {
        isOptionsDisplayed = flag;
    }
}
