using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class StoreEvents {
    public static UnityEvent loadEvent = new UnityEvent();
    public static UnityEvent prologueEvent = new UnityEvent();

    public static StoreEvnet instructionEvent = new StoreEvnet();

    public static BargainEvent bargainEvent = new BargainEvent();

    public static UnityEvent endEvent = new UnityEvent();

    public static NewItemEvent newItemEvent = new NewItemEvent();
}

public class StoreEvnet : UnityEvent<Dictionary<string, string>> {}

public class BargainEvent : UnityEvent<KeyValuePair<int, int>> {}

public class NewItemEvent : UnityEvent<int> {}