namespace SimpleDialogSystem
{
    [System.Serializable]
    public class DialogEvents
    {
        public enum EventType
        {
            ShowDialog,
            HideDialog,
            TriggerAction,
            ListenToAction,
        }

        public EventType Type = EventType.ShowDialog;
        public ShowDialogEvent ShowDialogEvent = new ShowDialogEvent();
        public HideDialogEvent HideDialogEvent = new HideDialogEvent();
        public TriggerActionEvent TriggerActionEvent = new TriggerActionEvent();
        public ListenToActionEvent ListenToActionEvent = new ListenToActionEvent();
    }
}