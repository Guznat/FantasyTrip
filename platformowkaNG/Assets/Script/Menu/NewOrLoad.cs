using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewOrLoad : MonoBehaviour
{
    public Button newGame;
    public Button loadGame;
    public GameObject panel;

    public PlayerMovment pm;
    public Health hl;


    private void Update()
    {
        newGame.onClick.AddListener(NewGame);
        loadGame.onClick.AddListener(LoadGame);
    }



   public void NewGame()
    {
        panel.SetActive(false);
        Object.Destroy(gameObject);
    }


public void LoadGame()
    {
       
            DataHolder data = SaveSystem.LoadPlayer();
            hl.health = data.health;
            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];

            pm.gameObject.transform.position = position;

        Object.Destroy(gameObject);
    }
}


