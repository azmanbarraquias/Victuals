using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CategoryInfoManager : MonoBehaviour
{
    public GameObject categoryContainer;


    public GameObject categoryInfoUI;

    public Transform categoryInfoContainer;

    public GameObject categoryTextTemplate;
    public GameObject categoryImageTemplate;

    public TextMeshProUGUI categoryHeaderTitle;

    public TextMeshProUGUI categoryTitle;

    public Image categoryImage;


    public void SetInformation(CategoryItemInfo _info) // Receive a Dialogue object or class
    {
        categoryTitle.text = _info.name;
        categoryImage.sprite = _info.categoryItemImage;
        GenerateInfo(_info);
        categoryInfoUI.SetActive(true);

    }

    public void GenerateInfo(CategoryItemInfo _info)
    {
        categoryTitle.text = _info.name;

        for (int i = 0; i < _info.categoryInfoTextAndImages.Length; i++)
        {
            if (_info.categoryInfoTextAndImages[i].useText == true)
            {
                var categoryItem = Instantiate(categoryTextTemplate);

                categoryItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _info.categoryInfoTextAndImages[i].categoryInfoText;

                categoryItem.transform.SetParent(categoryInfoContainer);

                categoryItem.transform.localScale = new Vector3(1, 1, 1);


            }
            else
            {
                var categoryItem = Instantiate(categoryImageTemplate);

                categoryItem.transform.GetChild(1).GetComponent<Image>().sprite = _info.categoryInfoTextAndImages[i].itemImage;

                categoryItem.transform.SetParent(categoryInfoContainer);

                categoryItem.transform.localScale = new Vector3(1, 1, 1);

            }
        }
    }

    public void SetCategoryName(string name)
    {
        categoryHeaderTitle.text = name;
    }
}
