using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUIHandler : MonoBehaviour
{
    [SerializeField] private PlayerController pc = null;
    [SerializeField] private GearSpawner gs = null;
    [SerializeField] private TextMeshProUGUI bestTimeText = null;

    internal static bool startGame = false;

    // Start is called before the first frame update
    void Start()
    {
        bestTimeText.SetText("Best Time: " + (PlayerPrefs.GetInt("Minute").ToString().Length > 1 ? PlayerPrefs.GetInt("Minute").ToString() : "0" + PlayerPrefs.GetInt("Minute").ToString()) + ":" +
                (PlayerPrefs.GetInt("Seconds").ToString().Length > 1 ? PlayerPrefs.GetInt("Seconds").ToString() : "0" + PlayerPrefs.GetInt("Seconds").ToString())); 
        startGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameButton()
    {
        startGame = true;
        pc.enabled = true;
        gs.enabled = true;
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }
}
