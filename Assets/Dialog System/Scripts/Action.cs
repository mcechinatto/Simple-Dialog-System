using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleDialogSystem
{
    [CreateAssetMenu(menuName = "Simple Dialog System/Action", fileName = "Action")]
    public class Action : ScriptableObject
    {
        public System.Action MyAction;
    }
}
