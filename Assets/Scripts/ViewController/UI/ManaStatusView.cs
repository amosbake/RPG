using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaStatusView : StatusView
{
   [SerializeField] private Image ManaBar;
   [SerializeField] private Text ManaText;

   private void Update()
   {
      if (ManaBar && _status!=null)
      {
         ManaBar.fillAmount = _status.StatusPercent;
      }

      if (ManaText && _status!=null)
      {
         ManaText.text = string.Format("{0}/{1}", _status.Current.ToString("F0"), _status.Max.ToString("F0"));
      }
      
   }
}
