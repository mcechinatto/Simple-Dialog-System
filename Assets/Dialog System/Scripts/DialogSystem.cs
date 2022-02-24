using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace SimpleDialogSystem
{
    public class DialogSystem : MonoBehaviour
    {
        private int currentEvent = 0;
        [SerializeField]
        private IDialogView dialogView = null;
        private ISkipDialogInput skipDialogInput = null;

        public List<DialogEvents> Events = new List<DialogEvents>();
        public System.Action ExecutionEnded; 
        public IDialogView DialogView { get => dialogView; set => dialogView = value; }
        public ISkipDialogInput SkipDialogInput { get => skipDialogInput; set => skipDialogInput = value; }

        private void Start()
        {
            dialogView = FindObjectsOfType<MonoBehaviour>().OfType<IDialogView>().FirstOrDefault();
            skipDialogInput = FindObjectsOfType<MonoBehaviour>().OfType<ISkipDialogInput>().FirstOrDefault();
            skipDialogInput.SkipDialog += SkipDialog;

            Execute();
        }

        public void Execute()
        {
            if (currentEvent >= Events.Count)
            {
                skipDialogInput.SkipDialog -= SkipDialog;
                ExecutionEnded?.Invoke();
                return;
            }
            switch (Events[currentEvent].Type)  
            {
                case DialogEvents.EventType.ShowDialog:
                    Events[currentEvent].ShowDialogType.Execute(this);
                    break;
                case DialogEvents.EventType.HideDialog:
                    Events[currentEvent].HideDialogType.Execute(this);
                    break;
                case DialogEvents.EventType.TriggerEvent:
                    Events[currentEvent].TriggerEventType.Execute(this);
                    break;
                case DialogEvents.EventType.ListenEvent:
                    Events[currentEvent].ListenEventType.Execute(this);
                    break;
            }
        }

        public void ContinueExecution()
        {
            currentEvent++;
            Execute();
        }

        public void SkipDialog()
        {
            if (Events[currentEvent].Type == DialogEvents.EventType.ShowDialog) ContinueExecution();
        }
    }
}