using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;
using UnityEngine.UI;
using TMPro;

public class StoreLoader : MonoBehaviour {

    [SerializeField] private string storeFilename;

    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private GameObject content;

    [SerializeField] private GameObject queryObject;

    private Dictionary<int, Dictionary<string, string>> details = new Dictionary<int, Dictionary<string, string>>();

    void Awake() {
        StoreEvents.loadEvent.AddListener(loadStoreObjects);
        StoreEvents.bargainEvent.AddListener(clinch);
    }

    private void loadStoreObjects() {
        TextAsset asset = Resources.Load<TextAsset>(storeFilename);

        var query = queryObject.GetComponent<IItemQuery>();

        using (var reader = new System.IO.StringReader(asset.text)) {
            using (var csv = new CsvReader(reader)) {
                csv.Read();
                csv.ReadHeader();

                while (csv.Read()) {
                    int id = int.Parse(csv.GetField("ID"));
                    int stock = int.Parse(csv.GetField("stock"));
                    int price = int.Parse(csv.GetField("price"));

                    if (stock == 0) {
                        continue;   
                    }

                    var detail = query.getItemDetail(id);
                    detail.Add("stock", stock.ToString());
                    detail.Add("price", price.ToString());
                    details.Add(id, detail);

                    var item = Instantiate(itemPrefab);
                    var image = item.GetComponentInChildren<Image>();
                    Sprite sprite = Resources.Load<Sprite>(detail["icon"]);
                    image.sprite = sprite;

                    if (stock > 1) {
                        var text = item.GetComponentInChildren<TMP_Text>();
                        text.text = stock.ToString();
                    }

                    var trans = item.GetComponent<RectTransform>();
                    trans.SetParent(content.GetComponent<RectTransform>());
                    trans.localScale = new Vector3(1, 1, 1);
                    item.name = "item" + id.ToString();

                    var rightButton = item.GetComponent<RightClick>();
                    rightButton.onRightClick.RemoveAllListeners();
                    rightButton.onRightClick.AddListener(()=>{
                        StoreEvents.instructionEvent.Invoke(detail);
                    });
                }
            }
        }
    }

    private void clinch(KeyValuePair<int, int> bargain) {
        int id = bargain.Key;
        if (!details.ContainsKey(id)) {
            Debug.LogErrorFormat("Wrong Item ID {0}", id);
            return;
        }

        var detail = details[id];
        int stock = int.Parse(detail["stock"]) - 1;
        var item = content.transform.Find("item" + id.ToString());

        if (stock > 0) {
            details[id]["stock"] = stock.ToString();
            var text = item.GetComponentInChildren<TMP_Text>();

            if (stock > 1) {
                text.text = stock.ToString();
            }
            else {
                text.text = "";
            }
        }
        else {
            DestroyImmediate(item.gameObject);
        }
    }
}
