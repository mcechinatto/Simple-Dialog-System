using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDialogAnimation
{
    void Animate();
    void CompleteDialogAnimation();
    System.Action AnimationCompleted { get; set; }
}
