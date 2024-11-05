using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMousePlace : MonoBehaviour
{
    //���콺�� ��ġ�� ã���ϴ�. ���� ����ũ�� �Ѿ�� �ڵ����� �̹����� �������ݴϴ�.
    public static FindMousePlace instance;

    private Vector2 vector2;
    public Vector2 mousePosition;
    public bool inSubDesk;

    public GameObject MainObjectPosition;
    public GameObject SubObjectPotation;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        vector2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Mathf.Abs(960f) > vector2.x && Mathf.Abs(540.1f) > vector2.y)
        {
            mousePosition = vector2;
        }

        if (mousePosition.x < -504) inSubDesk = true;
        else inSubDesk = false;
    }

    public void MoveObjectToMousePosition(GameObject gameObject)
    {
        gameObject.transform.position = mousePosition;
    }

}
