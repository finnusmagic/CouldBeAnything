using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Inventory : MonoBehaviour {

    public Transform inventoryPlayerParent;
    public Transform inventoryUIParent;
    public GameObject uiButton;

    Player_Master playerMaster;
    GameManager_ToggleInventoryUI inventoryUIScript;
    float timeToPlaceInHands = 0.1f;
    Transform currentlyHeldItem;
    int counter;
    string buttonText;

    List<Transform> listInventory = new List<Transform>();

    void OnEnable()
    {
        SetInitialReferences();
        DeactivateAllInventoryItems();
        UpdateInventoryListAndUI();
        CheckIfHandIsEmpty();

        playerMaster.EventInventoryChanged += UpdateInventoryListAndUI;
        playerMaster.EventInventoryChanged += CheckIfHandIsEmpty;
        playerMaster.EventHandsEmpty += ClearHands;
    }

    void OnDisable()
    {
        playerMaster.EventInventoryChanged -= UpdateInventoryListAndUI;
        playerMaster.EventInventoryChanged -= CheckIfHandIsEmpty;
        playerMaster.EventHandsEmpty -= ClearHands;
    }

    void SetInitialReferences()
    {
        playerMaster = GetComponent<Player_Master>();
        inventoryUIScript = GameObject.Find("GameManager").GetComponent<GameManager_ToggleInventoryUI>();
    }

    void UpdateInventoryListAndUI()
    {
        counter = 0;
        listInventory.Clear();
        listInventory.TrimExcess();

        ClearInventoryUI();

        foreach (Transform child in inventoryPlayerParent)
        {
            if (child.CompareTag("Item"))
            {
                listInventory.Add(child);
                GameObject go = Instantiate(uiButton) as GameObject;
                buttonText = child.name;
                go.GetComponentInChildren<Text>().text = buttonText;
                int index = counter;
                go.GetComponent<Button>().onClick.AddListener(delegate { ActivateInventoryItem(index); });
                go.GetComponent<Button>().onClick.AddListener(inventoryUIScript.ToggleInventoryUI);
                go.transform.SetParent(inventoryUIParent, false);
                counter++;
            }
        }
    }

    void CheckIfHandIsEmpty()
    {
        if (currentlyHeldItem == null && listInventory.Count > 0)
        {
            StartCoroutine(PlaceItemInHands(listInventory[listInventory.Count - 1]));
        }
    }

    void ClearHands()
    {
        currentlyHeldItem = null;
    }

    void ClearInventoryUI()
    {
        foreach (Transform child in inventoryUIParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void ActivateInventoryItem(int inventoryIndex)
    {
        DeactivateAllInventoryItems();
        StartCoroutine(PlaceItemInHands(listInventory[inventoryIndex]));
    }

    void DeactivateAllInventoryItems()
    {
        foreach (Transform child in inventoryPlayerParent)
        {
            if (child.CompareTag("Item"))
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator PlaceItemInHands(Transform itemTransform)
    {
        yield return new WaitForSeconds(timeToPlaceInHands);

        currentlyHeldItem = itemTransform;
        currentlyHeldItem.gameObject.SetActive(true);
    }
}
