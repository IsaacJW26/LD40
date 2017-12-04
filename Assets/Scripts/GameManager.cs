using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE = null;

    [Tooltip("Restart")]
    public float restartTime = 1f;

	// Use this for initialization
	void Awake ()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void RestartLevel()
    {
        StartCoroutine(RestartLevelCoroutine());
    }

    //Coroutine 
    IEnumerator RestartLevelCoroutine()
    {
        yield return new WaitForSeconds(restartTime);
        Debug.Log("restart");
        Player.INSTANCE.gameObject.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
