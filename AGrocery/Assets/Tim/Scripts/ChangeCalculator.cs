using System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCalculator : MonoBehaviour
{

 
  private List<decimal> actualChange = new List<decimal>();
  private decimal[] values = new decimal[9] { 50, 20, 10, 5, 1, .25m, .10m, .05m, .01m };


  public IReadOnlyList<decimal> MakeChange(decimal totalChange)
  {

    if (totalChange > 0)
    {
      for (var i = 0; i < values.Length; i++)
      {


        if (totalChange - values[i] > 0)
        {

          while (totalChange - values[i] > 0)
          {
            totalChange -= values[i];
            actualChange.Add(values[i]);
          }
        }
      }

    }
    return actualChange;
  }


 
}
