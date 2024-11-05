using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//���� ��ο� ���� ������Ʈ on/off ��ũ�� ���ߴ� �Լ��Դϴ�.

public class SynkInvoice : MonoBehaviour
{
    public GameObject InvoiceTop;

    private Shadow TopShadow;
    private Shadow shadow;

    private Image image;

    [Header ("���� �и� ����")]
    public bool IsCut;

    private void Awake()
    {
        shadow = GetComponent<Shadow>();
        TopShadow = InvoiceTop.GetComponent<Shadow>();
        image = GetComponent<Image>();
    }


    // Update is called once per frame
    void Update()
    {
        if (IsCut == false)
        {
            shadow.enabled = TopShadow.enabled;
            image.enabled = InvoiceTop.activeSelf;
        }
        
    }
}
