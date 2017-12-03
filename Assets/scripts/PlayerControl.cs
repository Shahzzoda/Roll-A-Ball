using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    public float speed;
    public Text countText, winText, timeText;

    private Rigidbody rb;
    private int count;

    void Start()
    {

        Time.timeScale = 1;

        rb = GetComponent<Rigidbody>();
        count = 0;

        winText.text = "";
        timeText.text = Time.time.ToString();
        setCountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        timeText.text = Time.time + " sec.";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);

            count++;
            setCountText();
        }
    }

    private void setCountText()
    {
        countText.text = "count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
            Time.timeScale = 0;
        }
    }

}
