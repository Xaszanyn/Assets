using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Draggable : MonoBehaviour
{
    public bool dragLock { get; set; }
    [SerializeField] bool xLock;
    [SerializeField] bool yLock;
    [SerializeField] bool zLock;
    float xBase;
    float yBase;
    float zBase;
    Vector3 offset;
    float mouseZ;
    [SerializeField] float maxX;
    [SerializeField] float minX;
    [SerializeField] float maxY;
    [SerializeField] float minY;
    [SerializeField] float maxZ;
    [SerializeField] float minZ;
    void Start() {
        xBase = transform.position.x;
        yBase = transform.position.y;
        zBase = transform.position.z;

        if (maxX == 0) {
            maxX = float.MaxValue;
        }
        if (minX == 0) {
            minX = float.MinValue;
        }
        if (maxY == 0) {
            maxY = float.MaxValue;
        }
        if (minY == 0) {
            minY = float.MinValue;
        }
        if (maxZ == 0) {
            maxZ = float.MaxValue;
        }
        if (minZ == 0) {
            minZ = float.MinValue;
        }
    }
    void OnMouseDown()
    {
        mouseZ = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - MousePosition();

        transform.DOMoveY(4, 1);
        transform.DORotate(Vector3.zero, 1);
    }
    Vector3 MousePosition() 
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mouseZ;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
    void OnMouseDrag()
    {
        if (!dragLock) transform.position = MousePosition() + offset;

        if (transform.position.x > maxX) transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        if (transform.position.y > maxY) transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        if (transform.position.z > maxZ) transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);

        if (transform.position.x < minX) transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        if (transform.position.y < minY) transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        if (transform.position.z < minZ) transform.position = new Vector3(transform.position.x, transform.position.y, minZ);

        if (xLock) transform.position = new Vector3(xBase, transform.position.y, transform.position.z);
        if (yLock) transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (zLock) transform.position = new Vector3(transform.position.x, transform.position.y, zBase);

        transform.position = new Vector3(transform.position.x, 4, transform.position.z);
        transform.rotation = Quaternion.identity;
    }
}