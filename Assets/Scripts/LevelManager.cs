using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button[] button_list;
    private void Start()
    {
        backButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("StartScene", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("LevelChoiceScene");
        });
        
        for(int i = 0; i < button_list.Length; i++)
        {
            button_list[i].onClick.AddListener(() =>
            {
                KeepItManager.Instance.Level = i;
                SceneManager.LoadScene("Road", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("LevelChoiceScene");
            });
        }
    }
}
