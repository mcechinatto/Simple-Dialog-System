using System;
using UnityEngine.Events;

namespace SimpleDialogSystem
{
    [Serializable]
    public class ListenEventType : IDialogEvent
    {
        public Action Action = null;
        private DialogSystem dialogSystem = null;

        public void Execute(DialogSystem dialogSystem)
        {
            this.dialogSystem = dialogSystem;
            Action.MyAction += ListenToEvent;
        }

        private void ListenToEvent()
        {
            dialogSystem.ContinueExecution();
        }
    }
}