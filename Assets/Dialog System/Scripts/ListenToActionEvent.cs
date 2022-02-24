using System;

namespace SimpleDialogSystem
{
    //This event outs the dialog execution on hold untill the action is invoked
    [Serializable]
    public class ListenToActionEvent : IDialogEvent
    {
        public Action Action = null;
        private DialogSystem dialogSystem = null;

        public void Execute(DialogSystem dialogSystem)
        {
            this.dialogSystem = dialogSystem;
            Action.MyAction += ListenToAction;
        }

        private void ListenToAction()
        {
            dialogSystem.ContinueExecution();
        }
    }
}