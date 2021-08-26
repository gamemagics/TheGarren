using UnityEngine;
using TMPro;
using Yarn.Unity;
using System.Collections.Generic;

public class StoreDeposit : MonoBehaviour {
    public int deposit;

    [SerializeField] private TMP_Text textComponent;

    [SerializeField] private DialogueRunner runner;

    // Start is called before the first frame update
    void Awake() {
        setDeposit();
        
        StoreEvents.bargainEvent.AddListener((KeyValuePair<int, int> bargain)=>{
            deposit -= bargain.Value;
            runner.variableStorage.SetValue("$deposit", deposit);
        });
    }

    // Update is called once per frame
    void Update() {
        textComponent.text = deposit.ToString();
    }

    private void setDeposit() {
        var storage = (InMemoryVariableStorage)runner.variableStorage;
        for (int i = 0; i < storage.defaultVariables.Length; ++i) {
            if (storage.defaultVariables[i].name == "deposit") {
                storage.defaultVariables[i].value = deposit.ToString();
                Debug.Log(storage.defaultVariables[i].value);
                break;
            }
        }
    }
}
