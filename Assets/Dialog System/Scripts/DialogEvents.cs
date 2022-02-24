using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleDialogSystem
{
    [System.Serializable]
    public class DialogEvents
    {
        public enum EventType
        {
            ShowDialog,
            HideDialog,
            TriggerEvent,
            ListenEvent,
        }

        public EventType Type = EventType.ShowDialog;
        public ShowDialogType ShowDialogType = new ShowDialogType();
        public HideDialogType HideDialogType = new HideDialogType();
        public TriggerEventType TriggerEventType = new TriggerEventType();
        public ListenEventType ListenEventType = new ListenEventType();
    }
}