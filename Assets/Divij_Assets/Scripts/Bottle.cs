using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bottle : MonoBehaviour, IInteractable
{
    [SerializeField] private string hoverMessage = "This Work?";
    [SerializeField] private string sceneName = "Next Scene Name";


    public string nextScene => sceneName;
    public string messagePopUp => hoverMessage;

    public TextMeshProUGUI hoverText;

    public void OnMouseEnter()
    {
        hoverText.text = hoverMessage;
        hoverText.gameObject.SetActive(true);
    }

    public void OnMouseExit()
    {
        hoverText.gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        SceneManager.LoadScene(sceneName);
    }
}
