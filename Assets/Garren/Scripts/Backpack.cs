using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backpack : MonoBehaviour {
    private List<KeyValuePair<int, int>> items;

    [SerializeField] private GameObject content;

    [SerializeField] private GameObject prefab;

    [SerializeField] private GameObject queryObject;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void AddItem(int id, int count = 1) {
        items.Add(new KeyValuePair<int, int>(id, count));
    }

    public void LoadBackpackObjects() {
        var query = queryObject.GetComponent<IItemQuery>();

        foreach (var pair in items) {
            var id = pair.Key;
            var detail = query.getItemDetail(id);
            
            var item = Instantiate(prefab);
            var image = item.GetComponentInChildren<Image>();
            Sprite sprite = Resources.Load<Sprite>(detail["icon"]);
            image.sprite = sprite;

            var trans = item.GetComponent<RectTransform>();
            trans.SetParent(content.GetComponent<RectTransform>());
            trans.localScale = new Vector3(1, 1, 1);
            item.name = "item" + id.ToString();
        }
    }
}
