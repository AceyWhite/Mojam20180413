using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabyrinthTimer : MonoBehaviour
{
	public bool isFinished;
	public bool restartTimer;
	public float Duration;
	float Duration_TIMER;
	float TIMER;

	[System.Serializable]
	public class _Display
    {
		public Text timer_text;
		public Image timer_image;
	}
	public _Display Display;

	int state;
    
	void Update ()
    {
		if(restartTimer == true)
        {
			state = 0;
			restartTimer = false;
		}
		switch(state)
        {
		    case 0:
			    Duration_TIMER = Time.time + Duration;
			    TIMER = Time.time;
			    isFinished = false;
			    state++;
			    break;
		    case 1:
			    if(Time.time >= Duration_TIMER)
                {
				    Display.timer_text.text = ""+0;
				    Display.timer_image.fillAmount = 0;
				    state++;
			    }
			    else
                {
				    string _timer_s = ""+Mathf.CeilToInt(stocktime());
				    if(Display.timer_text.text != _timer_s)
                    {
					    Display.timer_text.text = _timer_s;
				    }
				    Display.timer_image.fillAmount = bar(stocktime(), Duration_TIMER - TIMER, 1);
			    }
			    break;
		    case 2:
			    isFinished = true;
                LabyrinthLogic.m_Manager.SetTimeout();
                state++;
			    break;
		}
	}
		
	float stocktime()
    {
		return (Duration_TIMER - TIMER) - (Time.time - TIMER);
	}

	float bar(float current, float amount, float length)
    {
		float result = 0;
		if(current < amount)
        {
			if(amount != 1)
            {
				result =  length * (current / ((float)amount));
			}
			else if(amount == 1)
            {
				result =  length * (current);
			}
		}
		else if(current >= amount)
        {
			result = length;
		}
		return result;
	}
}
