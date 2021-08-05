using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;

public class StoreLoader : MonoBehaviour {

    [SerializeField] private string storeFilename;

    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private GameObject content;

    void Awake() {
        StoreLoadEvent.loadEvent.AddListener(loadStoreObjects);
    }

    private void loadStoreObjects() {
        TextAsset asset = Resources.Load<TextAsset>(storeFilename);
        
    }
}
