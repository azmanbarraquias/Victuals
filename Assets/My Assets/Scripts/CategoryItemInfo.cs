using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CategoryItemInfo
{

    #region Variables

    [Header("Information")]
    public string name;

    [TextArea(3, 10)] // Attribute to make a string be edited with a height-flexible and scrollable text area.
    public string descriptions;

    public Sprite categoryItemImage;





    public CategoryInfoTextAndImages[] categoryInfoTextAndImages;

    #endregion Variables

 

}

[System.Serializable]
public class CategoryInfoTextAndImages 
{
    public bool useText;
    [TextArea]
    public string categoryInfoText;
    public Sprite itemImage;

    //public CategoryType categoryType;

    //public enum CategoryType
    //{
    //    Cooking,
    //    Baking,
    //    Mixing
    //}
}



