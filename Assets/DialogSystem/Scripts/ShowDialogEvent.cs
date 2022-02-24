namespace SimpleDialogSystem
{
    [System.Serializable]
    public class ShowDialogEvent : IDialogEvent
    {
        public string CharacterName;
        public string Dialog;

        public void Execute(DialogSystem dialogSystem)
        {
            dialogSystem.DialogView.ShowDialog(CharacterName, Dialog);
        }
    }
}