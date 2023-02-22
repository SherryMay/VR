using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject targetObject;
    private Vector3 mousePos;
    private bool isDrag;
    private GameObject go;
    private Vector3 oriScreenPos;
    public Camera theCamera;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            //�������������������������Ļ����ĵ�
            Ray ray = theCamera.ScreenPointToRay(Input.mousePosition);
            //����ײ����
            RaycastHit hit;
            //�������ײ������ײ�壬����ײ��ı�ǩ������������Ҫ��ק�����壬��ô�������߼�

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.name != "Plane")
                {
                    //res = hit.point;
                    //targetObject = hit.collider.gameObject;
                    //��¼�µ�ǰ���λ��
                    mousePos = Input.mousePosition;
                    isDrag = true;
                    go = hit.collider.gameObject;
                    //��¼����ק���ԭʼ��Ļ�ռ�λ��
                    oriScreenPos = theCamera.WorldToScreenPoint(go.transform.position);

                }
            }
        }
        //���һֱ���ڰ���״̬����Ϊ��ק����
        if (Input.GetMouseButton(1))
        {
            //�����ק״̬����true��������ק��
            if (isDrag && go)
            {
                //��ȡ��Ļ�ռ������������������ק��ԭʼλ�ã���Ļ�ռ���㣩
                Vector3 newPos = oriScreenPos + Input.mousePosition - mousePos;
                //����Ļ�ռ�����ת��Ϊ����ռ�
                Vector3 newWorldPos = theCamera.ScreenToWorldPoint(newPos);
                //������ռ�λ�ø�����ק��
                go.transform.position = newWorldPos;
            }
        }
        //�ɿ����
        if (Input.GetMouseButtonUp(1))
        {
            isDrag = false;
            go = null;
        }
    }
}
