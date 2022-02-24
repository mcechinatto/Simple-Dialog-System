using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipDialogInput : MonoBehaviour, ISkipDialog
{
    private Action skipDialog;
    public Action SkipDialog { get => skipDialog; set => skipDialog = value; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SkipDialog?.Invoke();
    }
}
