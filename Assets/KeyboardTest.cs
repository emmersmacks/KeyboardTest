using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardTest : MonoBehaviour
{
    public Button ShowKeyboard;
    public Button SaveFile;
    public Button ShowPanel;
    public Button HidePanel;
    public GameObject Panel;

    public Text Text;

    void Start()
    {
        Debug.Log("START!!!!!!!");
        ShowPanel.onClick.RemoveAllListeners();
        ShowPanel.onClick.AddListener((() =>
        {
            Panel.SetActive(true);
            ShowPanel.gameObject.SetActive(false);
            HidePanel.gameObject.SetActive(true);
        }));
        
        HidePanel.onClick.RemoveAllListeners();
        HidePanel.onClick.AddListener((() =>
        {
            Panel.SetActive(false);
            ShowPanel.gameObject.SetActive(true);
            HidePanel.gameObject.SetActive(false);
        }));
        
        ShowKeyboard.onClick.RemoveAllListeners();
        ShowKeyboard.onClick.AddListener(() =>
        {
            Keyboard.overlayKeyboard = null;
            GC.Collect();
            
            Keyboard.overlayKeyboard = TouchScreenKeyboard.Open(Text.text, TouchScreenKeyboardType.Default);
        });
        
        SaveFile.onClick.AddListener((() =>
        {
            Debug.Log("SAVE FILE!!!");
            var reportsFolder = Application.persistentDataPath + "/Reports/";
            Debug.Log(reportsFolder);
            PDFSave.Save(reportsFolder, "Report");
        }));
    }

    void Update()
    {
        if (Keyboard.overlayKeyboard != null)
        {
            Text.text = Keyboard.overlayKeyboard.text;
        }
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        Debug.Log("OnApplicationFocus!!!!!!!");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable!!!!!!!");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy!!!!!!!");
    }
}
