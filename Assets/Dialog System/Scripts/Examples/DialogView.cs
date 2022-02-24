using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SimpleDialogSystem
{
    public class DialogView : MonoBehaviour, IDialogView
    {
        [SerializeField]
        private GameObject dialogCanvas = null;
        [SerializeField]
        private Text dialogText = null;

        private void Start()
        {
            dialogCanvas.SetActive(false);
        }

        public void ShowDialog(string name, string dialog)
        {
            dialogText.text = name + ": " + dialog;
            if (!dialogCanvas.activeInHierarchy) dialogCanvas.SetActive(true);
        }

        public void HideDialog()
        {
            dialogCanvas.SetActive(false);
        }
    }
}