using UnityEngine;
using DG.Tweening;
using System.Collections;

public class MenuMovement : MonoBehaviour {
    public void MoveMenuX(float destiny)
    {
        transform.DOKill();
        transform.DOLocalMoveX(destiny, 0.3f).SetEase(Ease.OutSine);
    }
}
