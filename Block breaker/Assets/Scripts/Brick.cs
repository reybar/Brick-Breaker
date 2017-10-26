using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public static int breakableCount = 0;

    private LevelManager levelManager;

    public AudioClip crack;
    public Sprite[] hitSprites;
    public GameObject smoke;

    

    private int timesHit;

    private bool isBreakable;

	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable){
            breakableCount++;
            print(breakableCount);
            
        }

        levelManager = GameObject.FindObjectOfType<LevelManager>();
        
        timesHit = 0;

	}
	
	// Update is called once per frame
	void Update () {
        
            
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position, 0.5f);
        if (isBreakable){
            HandleHits();  
        }
                
    }

    void HandleHits() {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits){
            breakableCount--;
            print(breakableCount);
            PuffSmoke();
            Destroy(this.gameObject);
            levelManager.BrickDestoyed();
            
        }
        else{
            LoadSprites();
        }
    }

    void PuffSmoke() {
        GameObject puff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        puff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
        Destroy(puff, 2.0f);
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("none sprite");
        }
        

    }
    
   
}
