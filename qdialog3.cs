using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qdialog3 : MonoBehaviour
{
    public qdialog3 Qdialog;
    public Button getBrevn;

    void Start()
    {
        Qdialog.getBrevn.onClick.AddListener(CloserDialogue);
    }
    
    void CloserDialogue()
    {
        Qdialog.gameObject.SetActive(false);
    }
}
