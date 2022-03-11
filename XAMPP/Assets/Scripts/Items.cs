using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;

public class Items : MonoBehaviour
{
    Action<string> _createItemsCallback;

    // Start is called before the first frame update
    void Start()
    {
        _createItemsCallback = (jsonArrayString) => {
            StartCoroutine(CreateItemsRoutine(jsonArrayString));
        };

        CreateItems();
    }


    public void CreateItems()
    {
        string userID = Main.instance.UserInfo.UserID;
        StartCoroutine(Main.instance.web.GetItemsIDs("http://localhost/UnityBackendTutorial/GetItemsIDs.php", userID, _createItemsCallback));
    }

    public IEnumerator CreateItemsRoutine(string jsonArrayString)
    {
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;

        for (int i = 0; i < jsonArray.Count; i++)
        {
            bool isDone = false;
            string itemID = jsonArray[i].AsObject["itemID"];
            JSONObject itemInfoJSON = new JSONObject();

            Action<string> getItemInfoCallback = (itemInfo) =>
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(itemInfo) as JSONArray;
                itemInfoJSON = tempArray[0].AsObject;
            };

            StartCoroutine(Main.instance.web.GetItem("http://localhost/UnityBackendTutorial/GetItem.php", itemID, getItemInfoCallback));

            yield return new WaitUntil(() => isDone == true);

            GameObject item = Instantiate(Resources.Load("Prefabs/Item") as GameObject);
            item.transform.SetParent(this.transform);
            item.transform.localScale = Vector3.one;
            item.transform.localPosition = Vector3.zero;

            item.transform.Find("Name").GetComponent<Text>().text = itemInfoJSON["name"];
            item.transform.Find("Price").GetComponent<Text>().text = itemInfoJSON["price"];
            item.transform.Find("Description").GetComponent<Text>().text = itemInfoJSON["description"];



        }

        yield return null;
    }
    
}
