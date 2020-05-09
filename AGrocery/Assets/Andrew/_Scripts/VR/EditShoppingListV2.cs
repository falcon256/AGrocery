using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class EditShoppingListV2 : MonoBehaviour
{
    public GameObject addItemPanel;
    public GameObject[] itemTypes;
    public TextMeshProUGUI shoppingListText;

    private bool addItemMenuOpen = false;
    private GameObject activeItem;
    private int activeItemIndex = 0;
    private StringBuilder listText;

    private string[] items = new string[11] { "SNACKS", "DAIRY", "FRUITS", "VEGETABLES", "DRYGOODS", "MEAT", "FROZENGOODS", "HYGIENE", "BAKERY", "COFFEE", "OTHER" };

    private void Start()
    {
        SetActiveItem(0);

        listText = new StringBuilder();

    }

    private void LateUpdate()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four) || Input.GetKeyDown(KeyCode.Y))
        {
            if (!addItemMenuOpen)
            {
                addItemMenuOpen = true;
            }
            else
            {
                addItemMenuOpen = false;
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickDown) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            activeItemIndex++;

            if (activeItemIndex > itemTypes.Length - 1)
            {
                activeItemIndex = 0;
            }

            SetActiveItem(activeItemIndex);
        }

        else if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickUp) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            activeItemIndex--;

            if (activeItemIndex < 0)
            {
                activeItemIndex = itemTypes.Length - 1;
            }
            SetActiveItem(activeItemIndex);
        }

        if (addItemMenuOpen && OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.I))
        {
            AddItem(activeItemIndex);
        }
    }

    private void FixedUpdate()
    {
        if (addItemMenuOpen)
        {
            addItemPanel.SetActive(true);
        }
        else
        {
            addItemPanel.SetActive(false);
        }
    }

    public void AddItem(int index)
    {
        GameObject[] allProducts = GameObject.FindGameObjectsWithTag("Product");
        List<GameObject> products = new List<GameObject>();
        GameObject currentProduct;

        if (allProducts != null)
        {
            foreach (GameObject product in allProducts)
            {
                ProductData pd = product.GetComponent<ProductData>();

                if (pd.category.ToString() == items[index])
                {
                    products.Add(product);
                }
            }
        }

        int rand = Random.Range(0, products.Count);

        currentProduct = products[rand];

        currentProduct.GetComponent<Light>().enabled = true;

        listText.Clear();
        listText.Append(currentProduct.name.Replace("(Clone)", " ").ToString() + " \n");
        shoppingListText.text += listText.ToString();

        return;
    }

    public void SetActiveItem(int i)
    {
        if (activeItem != null)
        {
            activeItem.GetComponent<Text>().color = Color.black;
        }
        activeItem = itemTypes[i];
        activeItem.GetComponent<Text>().color = Color.blue;
    }
}
