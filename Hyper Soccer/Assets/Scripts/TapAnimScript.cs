using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class TapAnimScript : MonoBehaviour
{
    [SerializeField] private GameObject _targetPoint;
    [SerializeField] private Vector3 _startPoint;
    private bool _isChanged;
    private void Start()
    {
        _startPoint = transform.position;
        StartCoroutine(StartUpdate());
    }


    private IEnumerator StartUpdate()
    {
        while (GameManager.GetInstance().currentState == StateType.ShootState)
        {
            if (!_isChanged)
            {
                transform.position = Vector3.Lerp(transform.position, _targetPoint.transform.position, 0.01f);
                yield return new WaitForSeconds(0.001f);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, _startPoint, 0.01f);
                yield return new WaitForSeconds(0.1f);
            }

            if (transform.position == _targetPoint.transform.position)
            {
                _isChanged = true;
            }
            else
            {
                _isChanged = false;
            }

        }
    }
}
