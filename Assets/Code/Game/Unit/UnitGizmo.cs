using UnityEngine;

public partial class UnitView : MonoBehaviour
{
    private void GizmoUpdate()
    {
        Debug.DrawRay(transform.position + Vector3.up * 1.05f, _data.Direction, Color.green);
        Debug.DrawRay(transform.position + Vector3.up, transform.forward, Color.red);
    }
}