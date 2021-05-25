using UnityEngine;


public class CameraFollow : MonoBehaviour
{

	public GameObject target;

	private Vector3 lastPlayerPos;
	private float distanceToMove;

    private void Start()
    {
        lastPlayerPos = target.transform.position;
    }

    private void Update()
    {
        distanceToMove = target.transform.position.x - lastPlayerPos.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPos = target.transform.position;
    }
}
