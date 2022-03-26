using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.UI
{
    public abstract class BaseView : MonoBehaviour
    {
        public virtual void ShowView()
        {
            gameObject.SetActive(true);
        }

        public virtual void HideView()
        {
            gameObject.SetActive(false);
        }
    } 
}
