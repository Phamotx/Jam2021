using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndCondition : MonoBehaviour
{
    public string nextLevel = "Level_2";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
            SceneManager.LoadScene(nextLevel);

    }
}
