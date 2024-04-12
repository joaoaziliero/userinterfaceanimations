using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class UI_Tweening : MonoBehaviour
{
    [SerializeField] private List<Transform> _icons;
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _animationIntervalSize;

    //private List<Observable<Unit>> SetAnimations(List<Transform> icons, float interval, float duration)
    //{
    //    return icons.Select((obj, j) => Observable.Timer(TimeSpan.FromSeconds(j * interval)).Do(_ => obj.DOScale(0, duration).From()))
    //        .ToList();
    //}
}
