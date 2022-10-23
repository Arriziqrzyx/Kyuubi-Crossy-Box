using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using DG.Tweening;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    Player player;

    private void Start()
    {
        muterMuter();
    }

    void Update()
    {

        if (this.transform.position.z <= player.CurrentTravel - 20)
            return;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if (this.transform.position.z <= player.CurrentTravel && player.gameObject.activeInHierarchy)
        {
            // player.gameObject.SetActive(false);
            player.transform.SetParent(this.transform);

        }

    }

    public void setUpTarget(Player target)
    {
        this.player = target;
    }

    void muterMuter()
    {
        // Transform wing = transform.GetChild(1);
        // Transform wing2 = transform.GetChild(2);
        // Transform tails = transform.GetChild(3);
        // // Debug.Log(tails.name);
        // wing.DORotate(new Vector3(30, 90, 0), 0.2f).SetLoops(-1, LoopType.Yoyo);
        // wing2.DORotate(new Vector3(-30, 90, 0), 0.2f).SetLoops(-1, LoopType.Yoyo);
        // tails.DORotateQuaternion(Quaternion.Euler(20, 180, 0), 0.2f).SetLoops(-1, LoopType.Yoyo);


    }
}
