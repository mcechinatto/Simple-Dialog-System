using System;

namespace SimpleDialogSystem
{
    [System.Serializable]
    public class ShowDialogType : IDialogEvent
    {
        public string CharacterName;
        public string Dialog;

        public void Execute(DialogSystem dialogSystem)
        {
            dialogSystem.DialogView.ShowDialog(CharacterName, Dialog);
        }
    }
}