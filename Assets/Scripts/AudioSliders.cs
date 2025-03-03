using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioSliders : MonoBehaviour
{
    private List<AudioSource> sources = new List<AudioSource>();
    private GameObject musicPlayer;
    private Canvas optionsCanvas;
    float sfxVolume = 0.5f;
    float musicVolume = 0.5f;

    private void Start()
    {
        musicPlayer = GameObject.Find("MusicPlayer"); // we need a gameobject calleld music player to be the music player
    }                                                 // ik, very innovative

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject[] gameObjects = FindObjectsOfType<GameObject>();
        sources.Clear();

        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i].GetComponent<AudioSource>() != null && gameObjects[i].name != "MusicPlayer")
            {
                sources.Add(gameObjects[i].GetComponent<AudioSource>());
            }
            if (gameObjects[i].name == "OptionsScreen")
            {
                optionsCanvas = gameObjects[i].GetComponent<Canvas>();
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < sources.Count; i++)
        {
            sources[i].volume = sfxVolume;
        }
        musicPlayer.GetComponent<AudioSource>().volume = musicVolume;
    }

    public void SetSFXVolume()
    {
        sfxVolume = optionsCanvas.transform.GetChild(0).GetComponent<Slider>().value;
    }

    public void SetMusicVolume()
    {
        musicVolume = optionsCanvas.transform.GetChild(1).GetComponent<Slider>().value;
    }

}
