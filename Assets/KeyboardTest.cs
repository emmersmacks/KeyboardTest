using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardTest : MonoBehaviour
{
    public Button ShowKeyboard;
    public Button ShowPanel;
    public Button HidePanel;
    public GameObject Panel;

    public Text Text;

    public TouchScreenKeyboard overlayKeyboard;

    void Start()
    {
        ShowPanel.onClick.AddListener((() =>
        {
            Panel.SetActive(true);
            ShowPanel.gameObject.SetActive(false);
            HidePanel.gameObject.SetActive(true);
        }));
        
        HidePanel.onClick.AddListener((() =>
        {
            Panel.SetActive(false);
            ShowPanel.gameObject.SetActive(true);
            HidePanel.gameObject.SetActive(false);
        }));
        
        ShowKeyboard.onClick.AddListener(() =>
        {
            overlayKeyboard = TouchScreenKeyboard.Open(Text.text, TouchScreenKeyboardType.Default);
        });
    }

    void Update()
    {
        if (overlayKeyboard != null)
        {
            Text.text = overlayKeyboard.text;
        }

        if (overlayKeyboard != null && !overlayKeyboard.active)
        {
            overlayKeyboard = null;
        }
    }
}
