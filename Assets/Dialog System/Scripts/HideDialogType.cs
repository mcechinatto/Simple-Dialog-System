using System;

namespace SimpleDialogSystem
{
    [Serializable]
    public class HideDialogType : IDialogEvent
    {

        public void Execute(DialogSystem dialogSystem)
        {
            dialogSystem.DialogView.HideDialog();
            dialogSystem.ContinueExecution();
        }
    }
}