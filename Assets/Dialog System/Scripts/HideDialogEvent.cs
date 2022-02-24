using System;

namespace SimpleDialogSystem
{
    [Serializable]
    public class HideDialogEvent : IDialogEvent
    {
        public void Execute(DialogSystem dialogSystem)
        {
            dialogSystem.DialogView.HideDialog();
            dialogSystem.ContinueExecution();
        }
    }
}