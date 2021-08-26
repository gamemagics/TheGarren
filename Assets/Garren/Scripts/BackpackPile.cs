using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackPile : MonoBehaviour {
    [SerializeField] private Backpack backpack;

    void Awake() {
        backpack.AddItem(1); backpack.AddItem(2); backpack.AddItem(3);
        backpack.LoadBackpackObjects();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
