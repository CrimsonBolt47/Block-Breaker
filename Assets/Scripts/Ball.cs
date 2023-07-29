
using UnityEngine;


public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;


    Vector2 paddleToballVector;
    bool hasStarted=false;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;

    AudioSource myAudioSource;
    Rigidbody2D myrigidbody2D;




    

    void Start()
    {
        paddleToballVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();

        myrigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted == false)
        {
            Lockballtopaddle();
            Launchballonmouseclick();
        }

    }

    public void Launchballonmouseclick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            myrigidbody2D.velocity = new Vector2(xPush,yPush);//transform is available to every object but rigidbody2d is not ,so we need to use getcomponent to access rigidbody2d
            hasStarted = true;

        }
    }

    public void Lockballtopaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y); //curent position of paddle 
        transform.position = paddlePos + paddleToballVector;//position of ball =position of paddle+difference b/w ball and paddle so ball sticks to paddle wherever it moves
    }
    public void MakehasStartedFalse()
    {
        hasStarted = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f,randomFactor),Random.Range(0f,randomFactor));
        if (hasStarted == true)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)]; //instead of creating namespace we used hear only
            myAudioSource.PlayOneShot(clip);
            myrigidbody2D.velocity += velocityTweak;
        }
    }
}
