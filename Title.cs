﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using VoxelBusters.NativePlugins;

public class Title : MonoBehaviour {
	bool credits = false;
	public UIPanel creditsPanel;
    public GameObject loading;

    bool _isAvailable = false;
    bool _isAuthenticated = false;
    string message = "";
    public GameObject dailyPanel;
    void Start ()
    {
        if (!GlobalVariables.finishOrderingProcess)
        {
            GlobalVariables.SetScenes();
            GlobalVariables.orderScenes();
        }

        PlayerPrefs.SetInt("lvlSelectDaily",0);
        /*_isAvailable = NPBinding.GameServices.IsAvailable();
        if (_isAvailable)
        {
            _isAuthenticated = NPBinding.GameServices.LocalUser.IsAuthenticated;
            if (!_isAuthenticated)
            {
                NPBinding.GameServices.LocalUser.Authenticate((bool _success, string _error) => {

                    if (_success)
                    {
                         
                    }
                    else
                    {

                    }
                });
            }
        }*/
        int consecutiveDays = PlayerPrefs.GetInt("consecutiveDays", -1);
        System.DateTime date = System.DateTime.Now.Date;
        System.DateTime lastPlayedDate = System.DateTime.Parse(PlayerPrefs.GetString("lastPlayedDate", date.ToString()));
        int daysSinceLastPlay = (int)(date - lastPlayedDate).TotalDays;
        if (daysSinceLastPlay == 0)
        {
            if (consecutiveDays == -1)
            {
                Debug.Log("First stage played");
            }
            else
            {
                Debug.Log(date);
                Debug.Log("Already played today");
                //dailyPanel.SetActive(false);
            }

        }
    }

    void loadNextScene(string s)
    {
        print("escene " + s);
        VariablesGlobales.nextScene = s;
        GameObject.FindWithTag("loading").GetComponent<LoadSceneWait>().enabled = true;
    }

    public void play(){

        // if (GameObject.Find("AppoDeal") != null)
        //     GameObject.Find("AppoDeal").GetComponent<AppodealDemo>().Init();

        if (PlayerPrefs.GetInt ("PlayedGame", 0) == 0) {
            loading.SetActive(true);
            PlayerPrefs.SetInt ("PlayedGame", 1);
            if(!PlayerPrefs.HasKey("scene"))
                PlayerPrefs.SetString ("scene", GlobalVariables.getIndexScene("1"));
            loadNextScene("InGame_tutorial");
            //SceneManager.LoadScene ("InGame_tutorial");
			PlayerPrefs.SetInt("lvlSelectDaily",0);
		} else
        {
            loadNextScene("LevelSelection");
            //SceneManager.LoadScene ("LevelSelection");
		}
	}

	public void daily(){

        // if (GameObject.Find("AppoDeal") != null)
        //     GameObject.Find("AppoDeal").GetComponent<AppodealDemo>().Init();

        //SceneManager.LoadScene ("LevelSelection");
        loadNextScene("LevelSelection");
        PlayerPrefs.SetInt("lvlSelectDaily",1);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			PlayerPrefs.SetInt ("PlayedGame", 0);
			Debug.Log ("not played");
		}
	}

	public void Credits(){
		if (!credits) {
			creditsPanel.GetComponent<TweenAlpha> ().PlayForward ();
			credits = true;
		} else {
			creditsPanel.GetComponent<TweenAlpha> ().PlayReverse ();
			credits = false;
		}
	}
}
