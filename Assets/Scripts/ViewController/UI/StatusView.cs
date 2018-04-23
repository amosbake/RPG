using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusView : MonoBehaviour
{

	[HideInInspector] public Status _status;

	private void Start()
	{
		_status.OnChangeValue += OnChangeValue;
		_status.OnReachMaxValue += OnReachMaxValue;
		_status.OnReachZeroValue += OnReachZeroValue;
	}

	private void OnDestroy()
	{
		_status.OnChangeValue -= OnChangeValue;
		_status.OnReachMaxValue -= OnReachMaxValue;
		_status.OnReachZeroValue -= OnReachZeroValue;
	}

	protected virtual void OnReachMaxValue(string StatusName, float maxValue)
	{
		
	}

	protected virtual void OnReachZeroValue(string StatusName)
	{
		
	}

	protected virtual void OnChangeValue(string StatusName, float deltaChange)
	{
		
	}
}
