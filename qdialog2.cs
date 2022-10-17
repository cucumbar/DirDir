using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qdialog2 : MonoBehaviour
{
    public qdialog2 Qdialog;
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
