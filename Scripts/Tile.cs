using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    float numberOfCollisions;
    Material myMaterial;
    AudioSource myAudioSource;
    [SerializeField] GameObject redVFX;
    [SerializeField] GameObject orangeVFX;
    [SerializeField] GameObject yellowVFX;
    [SerializeField] GameObject greenVFX;
    [SerializeField] GameObject blueVFX;
    [SerializeField] GameObject indigoVFX;
    [SerializeField] GameObject violetVFX;

    void Start()
    {
        numberOfCollisions = 0;
        myMaterial = this.GetComponent<Renderer>().material;
        myMaterial.color = Color.black;
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag != "Tile") {
            numberOfCollisions++;
            switch(numberOfCollisions) {
                case 1:
                    myMaterial.color = Color.red;
                    GameObject colorChange = Instantiate(redVFX,transform.position,transform.rotation);
                    Destroy(colorChange,1f);
                    break;
                case 2:
                    Color colorOrange = new Color(1f, .64f, 0f);
                    myMaterial.color = colorOrange;
                    GameObject colorChange1 = Instantiate(orangeVFX,transform.position,transform.rotation);
                    Destroy(colorChange1,1f);
                    break;
                case 3:
                    myMaterial.color = Color.yellow;
                    GameObject colorChange2 = Instantiate(yellowVFX,transform.position,transform.rotation);
                    Destroy(colorChange2,1f);
                    break;
                case 4:
                    myMaterial.color = Color.green;
                    GameObject colorChange3 = Instantiate(greenVFX,transform.position,transform.rotation);
                    Destroy(colorChange3,1f);
                    break;
                case 5:
                    myMaterial.color = Color.blue;
                    GameObject colorChange4 = Instantiate(blueVFX,transform.position,transform.rotation);
                    Destroy(colorChange4,1f);
                    break;
                case 6:
                    Color colorIndigo = new Color(.3f, 0f, .51f);
                    GameObject colorChange5 = Instantiate(indigoVFX,transform.position,transform.rotation);
                    Destroy(colorChange5,1f);
                    myMaterial.color = colorIndigo;
                    break;
                case 7:
                    Color colorViolet = new Color(.93f, .51f, .93f);
                    myMaterial.color = colorViolet;
                    GameObject colorChange6 = Instantiate(violetVFX,transform.position,transform.rotation);
                    Destroy(colorChange6,1f);
                    break;
                case 8:
                    LevelManager.bricksDestroyed++;
                    Destroy(this.gameObject);
                    break;
            }
        }
        

    }
    
}
