using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleDialogSystem
{
    //Action to trigger during a dialog or to listen to holding the dialog execution
    [CreateAssetMenu(menuName = "Simple Dialog System/Action", fileName = "Action")]
    public class Action : ScriptableObject
    {
        public System.Action MyAction;
    }
}
