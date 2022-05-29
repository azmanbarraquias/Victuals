using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CategoryInfoTrigger : MonoBehaviour
{
	#region Variables
	public CategoryItemInfo info; // call and use variable in the Dialogue class
    #endregion

    #region Methods
    // Use this for initialization

    private void Start()
    {
        if (info.categoryItemImage != null)
        {
            transform.GetChild(1).GetComponent<Image>().sprite = info.categoryItemImage;

        }
        if (!string.IsNullOrWhiteSpace(info.name))
        {
            transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = info.name;
            gameObject.name = info.name;

        }
      

    }
    public void SetInformation()
	{
		FindObjectOfType<CategoryInfoManager>().SetInformation(info);
	}
	#endregion
}
