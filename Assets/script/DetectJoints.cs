using UnityEngine;
using Windows.Kinect;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DetectJoints : MonoBehaviour
{
    [SerializeField]
    public GameObject BodySrcManager;
    private BodySourceManager bodyManager;

    public GameObject DephSrcManager;
    private DepthSourceManager depthManager;

    public JointType TrackedJoint;
    private Body[] bodies;
    private DepthFrameReader reader;

    public Vector3 multiplier = new Vector3(1,1,1); // 14 is the perfect multiplicator for corresponde to the reel life where 10 unit = 1 meter
    public Vector3 ofset = new Vector3(0,0,0);

    public float lerpValue = 2f;

    public float treadshold = 1f;

    private Vector3 globalPos = new Vector3(0,0,0);

    public lookatcamera cameraFollower;

    // Use this for initialization
    void Start()
    {

        if (BodySrcManager == null)
        {
            Debug.Log("Asign Game Object with Body Source Manager");
        }
        else
        {
            bodyManager = BodySrcManager.GetComponent<BodySourceManager>();
        }

        if (DephSrcManager == null)
        {
            Debug.Log("Asign Game Object with DepthSourceManager");
        }
        else
        {
            depthManager = DephSrcManager.GetComponent<DepthSourceManager>();
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (BodySrcManager == null)
        {
            return;
        }

        bodies = bodyManager.GetData();
        if (bodies == null)
        {
            return;
        }

        foreach (var body in bodies)
        {
            if (body == null)
            {
                continue;
            }
            if (body.IsTracked)
            {
                var pos = body.Joints[TrackedJoint].Position;
                //gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(-pos.X * multiplier, pos.Y * multiplier, 107), lerpValue);
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3((-pos.X + ofset.x) * multiplier.x, (pos.Y + ofset.y) * multiplier.y, (pos.Z + ofset.z) * multiplier.z), lerpValue);



                //cameraFollower.enabled = true; // enabled camera follower script after the first position set up because there is a bug lag if not

            }
        }

    }
}
