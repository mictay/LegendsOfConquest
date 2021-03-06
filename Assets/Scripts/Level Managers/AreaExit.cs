using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{

    [SerializeField] 
    public string enterAreaName;

    [SerializeField]
    public string targetAreaName;

    [SerializeField]
    private string sceneToLoad;

    [SerializeField]
    AreaEnter areaEnter;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Area Exit start() called for " + enterAreaName);
        areaEnter.areaName = enterAreaName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            //Debug.Log("Player entrance area name is: " + targetEnterAreaName);
            Player.instance.entranceAreaName = targetAreaName;

            MenuManager.instance.FadeImage();

            StartCoroutine(LoadSceneCoroutine());
        }

    }

    IEnumerator LoadSceneCoroutine()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneToLoad);
    }

}
