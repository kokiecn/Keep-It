using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClearController : MonoBehaviour
{
    [SerializeField] private Material myskybox;
    private void Awake()
    {
        RenderSettings.skybox = myskybox;
    }
    private void Start()
    {
        StartCoroutine(Clear());
    }

    private IEnumerator Clear()
    {
        yield return new WaitForSeconds(10f);
        KeepItManager.Instance.Save(KeepItManager.Instance.Level);
        KeepItManager.Instance.Load();
        SceneManager.LoadScene("ClearScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Road");

    }
}
