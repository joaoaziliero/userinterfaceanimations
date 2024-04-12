using NaughtyAttributes;
using DG.Tweening;
using R3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UI_Tweening : MonoBehaviour
{
    [SerializeField] private List<Transform> _icons;
    [SerializeField] private float _scale;
    [SerializeField] private float _animationDuration;
    [SerializeField] private float _animationDelay;

    [Button]
    private void HideIcons()
    {
        SetAnimations(_icons, 0, _animationDelay, _animationDuration).ForEach(obs => obs.Subscribe());
    }

    [Button]
    private void ShowIcons()
    {
        SetAnimations(_icons, 1, _animationDelay, _animationDuration).ForEach(obs => obs.Subscribe());
    }

    private List<Observable<Unit>> SetAnimations(List<Transform> icons, float scale, float delay, float duration)
    {
        return icons
            .Select((obj, j) => Observable.Timer(TimeSpan.FromSeconds(j * delay)).Do(_ => obj.DOScale(scale, duration)))
            .ToList();
    }
}
