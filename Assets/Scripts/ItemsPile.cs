using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPile : MonoBehaviour, IItemQuery {
    [SerializeField] private string itemFilename;

    private Dictionary<int, Item> items = new Dictionary<int, Item>();

    void Awake() {
        TextAsset asset = Resources.Load<TextAsset>(itemFilename);
        using (var reader = new System.IO.StringReader(asset.text)) {
            using (var csv = new CsvHelper.CsvReader(reader)) {
                csv.Read();
                csv.ReadHeader();

                while (csv.Read()) {
                    int id = int.Parse(csv.GetField("ID"));
                    Item item = new Item();
                    item.id = id;
                    item.name = csv.GetField("name");
                    item.icon = csv.GetField("icon");
                    item.desc = csv.GetField("description");

                    items.Add(id, item);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public Dictionary<string, string> getItemDetail(int id) {
        var res = new Dictionary<string, string>();
        if (items.ContainsKey(id)) {
            var item = items[id];
            res.Add("ID", id.ToString());
            res.Add("name", item.name);
            res.Add("icon", item.icon);
            res.Add("desc", item.desc);
        }
        
        return res;
    }
}
