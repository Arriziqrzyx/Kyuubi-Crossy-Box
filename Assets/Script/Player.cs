using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    [SerializeField] TMP_Text stepText;
    [SerializeField] ParticleSystem dieParticles;
    [SerializeField, Range(0.01f, 1f)] float moveDuration = 0.8f;
    [SerializeField, Range(0.01f, 1f)] float jumpHigh = 0.5f;
    private float rightBoundary;
    private float leftBoundary;
    private float backBoundary;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] AudioSource dieSound;

    [SerializeField] private int maxTravel;
    public int MaxTravel { get => maxTravel; }
    
    [SerializeField] private int currentTravel;
    public int CurrentTravel { get => currentTravel; }

    public bool IsDie { get => this.enabled == false; }


    public void SetUp(int minZPos, int extent)
    {
        backBoundary = minZPos - 1;
        leftBoundary = -(extent + 1);
        rightBoundary = extent + 1;
    }



    private void Update()
    {
        var MoveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
            MoveDir += new Vector3(0, 0, 1);

        if (Input.GetKey(KeyCode.DownArrow))
            MoveDir += new Vector3(0, 0, -1);

        if (Input.GetKey(KeyCode.RightArrow))
            MoveDir += new Vector3(1, 0, 0);

        if (Input.GetKey(KeyCode.LeftArrow))
            MoveDir += new Vector3(-1, 0, 0);

        if (MoveDir != Vector3.zero && IsJumping() == false)
            Jump(MoveDir);
    }
    private void Jump(Vector3 TargetDirection)
    {
        // rotaten menghadap
        var targetPosition = transform.position + TargetDirection;
        transform.LookAt(targetPosition);

        // loncat
        var moveSeq = DOTween.Sequence(transform);
        moveSeq.Append(transform.DOMoveY(jumpHigh, moveDuration / 2));
        moveSeq.Append(transform.DOMoveY(0f, moveDuration / 2));

        if (targetPosition.z <= backBoundary || targetPosition.x <= leftBoundary || targetPosition.x >= rightBoundary)
            return;

        if (Tree.AllPositions.Contains(targetPosition))
            return;

        // gerak 
        transform.DOMoveX(targetPosition.x, moveDuration);
        transform.DOMoveZ(targetPosition.z, moveDuration).OnComplete(UpdateTravel);
        jumpSound.Play();
    }

    private void UpdateTravel()
    {
        currentTravel = (int)this.transform.position.z;
        if (currentTravel > maxTravel)
            maxTravel = currentTravel;

        stepText.text = "STEP: " + maxTravel.ToString();
    }

    

    public bool IsJumping()
    {
        return DOTween.IsTweening(transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.enabled == false)
            return;

        var car = other.GetComponent<Car>();
        if (car != null)
        {
            AnimateCrash(car);
        }
    }

    private void AnimateCrash(Car car)
    {
        // Gepeng
        transform.DOScaleY(0.1f, 0.2f);
        transform.DOScaleX(3, 0.2f);
        transform.DOScaleZ(2, 0.2f);
        this.enabled = false;
        dieParticles.Play();
        dieSound.Play();
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {

    }

}
