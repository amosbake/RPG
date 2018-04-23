using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthStatusView : StatusView
{
   [SerializeField] private Image HealthBar;
   [SerializeField] private Text HealthText;

   private void Update()
   {
      if (HealthBar && _status!=null)
      {
         HealthBar.fillAmount = _status.StatusPercent;
      }

      if (HealthText && _status!=null)
      {
         HealthText.text = string.Format("{0}/{1}", _status.Current.ToString("F0"), _status.Max.ToString("F0"));
      }
      
   }
}
