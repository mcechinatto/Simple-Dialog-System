using System;
using UnityEngine.Events;

namespace SimpleDialogSystem
{
    [Serializable]
    public class TriggerActionEvent : IDialogEvent
    {
        public Action Action = null;

        public void Execute(DialogSystem dialogSystem)
        {
            Action.MyAction?.Invoke();
            dialogSystem.ContinueExecution();
        }
    }
}