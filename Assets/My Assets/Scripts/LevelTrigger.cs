using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    public Level level;

    public void SetLevel()
    {
        FindObjectOfType<LevelManager>().SetGameLevel(level);
    }
}
