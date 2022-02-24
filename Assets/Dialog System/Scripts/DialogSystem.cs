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
        private ISkipDialog skipDialog = null;

        public List<DialogEvents> Events = new List<DialogEvents>();
        public System.Action ExecutionEnded; 
        public IDialogView DialogView { get => dialogView; set => dialogView = value; }

        private void Start()
        {
            dialogView = FindObjectsOfType<MonoBehaviour>().OfType<IDialogView>().FirstOrDefault();
            skipDialog = FindObjectsOfType<MonoBehaviour>().OfType<ISkipDialog>().FirstOrDefault();
            skipDialog.SkipDialog += SkipDialog;

            Execute();
        }

        public void Execute()
        {
            if (currentEvent >= Events.Count)
            {
                skipDialog.SkipDialog -= SkipDialog;
                ExecutionEnded?.Invoke();
                Debug.Log("Dialog execution ended!");
                return;
            }
            switch (Events[currentEvent].Type)  
            {
                case DialogEvents.EventType.ShowDialog:
                    Events[currentEvent].ShowDialogEvent.Execute(this);
                    break;
                case DialogEvents.EventType.HideDialog:
                    Events[currentEvent].HideDialogEvent.Execute(this);
                    break;
                case DialogEvents.EventType.TriggerAction:
                    Events[currentEvent].TriggerActionEvent.Execute(this);
                    break;
                case DialogEvents.EventType.ListenToAction:
                    Events[currentEvent].ListenToActionEvent.Execute(this);
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