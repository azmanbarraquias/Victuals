using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameObject tilesTemplate;

    public GameObject levelUI;

    public GameObject tilesUI;


    public Transform tilesHolder;


    public List<GameObject> tiles;

    public int currentQuestionNo = 0;

    public Sprite star;

    public Color unlockColor;
    public Color defaultTilesColor;


    public Level Level;

    public TextMeshProUGUI buttonText;



    // Start is called before the first frame update
  public void SetGameLevel(Level currentLevel)
    {
        Level = currentLevel;
        levelUI.SetActive(false);
        tilesUI.SetActive(true);
        
        FindObjectOfType<QuestionManager>().SetGame(currentLevel);
        
        List<GameObject> gameobject = new List<GameObject>();
        
        for (int i = 0; i < currentLevel.question.Length; i++)
        {
            var stageObject = Instantiate(tilesTemplate);
            gameobject.Add(stageObject);
        }

        tiles = gameobject;

        for (int i = 0; i < tiles.Count; i++)
        {
            
           // tiles[i].transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Stage " + (i + 1);
            tiles[i].transform.SetParent(tilesHolder);
            tiles[i].transform.localScale = new Vector3(1, 1, 1);

            if (currentQuestionNo == i)
            {
                tiles[i].transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    public void UpdateTiles()
    {
        
        tilesUI.SetActive(true);
       
        buttonText.text = "Next Question";

        // unlock the last tiles
        Debug.Log(currentQuestionNo);


        tiles[currentQuestionNo].transform.GetChild(0).gameObject.SetActive(false);
        tiles[currentQuestionNo].transform.GetChild(2).GetComponent<Image>().color = unlockColor;

        // select the next tiles
        if (currentQuestionNo == Level.question.Length - 1)
        {
            buttonText.text = " Finis";
            return;

        }

        tiles[currentQuestionNo + 1].transform.GetChild(0).gameObject.SetActive(true);

        currentQuestionNo++;
    }

     void ResetTilesUI()
    {

        for (int i = 0; i < tiles.Count; i++)
        {
            currentQuestionNo = 0;
            tiles[i].transform.GetChild(0).gameObject.SetActive(false);
            tiles[i].transform.GetChild(2).GetComponent<Image>().color = defaultTilesColor;
        }
    }

    public void LoadFinishUI()
    {

    }


}
