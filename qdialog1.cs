using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qdialog1 : MonoBehaviour
{
    public qdialog1 Qdialog;
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
