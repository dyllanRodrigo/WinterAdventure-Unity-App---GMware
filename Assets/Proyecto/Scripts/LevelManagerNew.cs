using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class LevelManagerNew : MonoBehaviour {

    [System.Serializable]

    public class Level {
        public string LevelText;
        public int Unlocked;
        public bool IsInteractable;
    }

    public List<Level> LevelList;
    public GameObject LevelButton;
    public Transform Spacer;
   
    // Use this for initialization
    void Start() {
      // DeleteAll();
        FillList();
    }

    void FillList() {
        foreach (var Level in LevelList) {
            GameObject newButton = Instantiate(LevelButton) as GameObject;

            LevelButton button = newButton.GetComponent<LevelButton>();

            button.LevelText.text = Level.LevelText;

            //colocar solo el numero de nivel 1,2,3

            if (PlayerPrefs.GetInt("Level" + button.LevelText.text) == 1) {
                Level.Unlocked = 1;
                Level.IsInteractable = true;
            }

            button.Unlocked = Level.Unlocked;
            button.GetComponent<Button>().interactable = Level.IsInteractable;
            button.GetComponent<Button>().onClick.AddListener(() => LoadLevels(button.LevelText.text));




            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") > 0){
                button.Star1.SetActive(true);
            }

            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") >= 40)
            {
                button.Star2.SetActive(true);
            }
            if (PlayerPrefs.GetInt("Level" + button.LevelText.text + "_score") >= 80)
            {
                button.Star3.SetActive(true);
            }



            newButton.transform.SetParent(Spacer, false);
        
        }
        SaveAll();
    }


    void SaveAll() {

        //   if (PlayerPrefs.HasKey("Level1"))
        // {
        //    return;
        //}
        //else
        {

            GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");
            foreach (GameObject buttons in allButtons)
            {

                LevelButton button = buttons.GetComponent<LevelButton>();
                PlayerPrefs.SetInt("Level" + button.LevelText.text, button.Unlocked);
            }
        }
    }

    void DeleteAll(){
        PlayerPrefs.DeleteAll();
    }


    void LoadLevels(string value)
    {

        int num = int.Parse(value);
        LoadingScreenManager.LoadScene(num);

    }

}

