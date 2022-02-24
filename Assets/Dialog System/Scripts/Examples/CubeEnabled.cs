using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SimpleDialogSystem
{
    public class CubeEnabled : MonoBehaviour
    {
        public Action ShowCube = null;
        public Action ShowedCube = null;

        private void Start()
        {
            ShowCube.MyAction += Show;
        }

        public void Show()
        {
            GetComponent<MeshRenderer>().enabled = true;
            StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(1f);
            ShowedCube.MyAction?.Invoke();
        }
    }
}
