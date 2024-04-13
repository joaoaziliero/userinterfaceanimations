using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAnimator : MonoBehaviour
{
    [SerializeField] private float _timeToEnable;

    private void Start()
    {
        Invoke(nameof(AnimatorEnabledTrue), _timeToEnable);
    }

    private void AnimatorEnabledTrue()
    {
        GetComponent<Animator>().enabled = true;
    }
}
