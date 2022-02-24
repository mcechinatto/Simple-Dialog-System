using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDialogView 
{
    void ShowDialog(string name, string dialog);
    void HideDialog();
}
