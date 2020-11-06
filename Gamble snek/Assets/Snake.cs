using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{

    List<Transform> tail = new List<Transform>();
    Vector2 dir = Vector2.right;
    bool ate = false;
    bool isDead = false;
    public GameObject tailPrefab;
    int _score = 0;
    bool _isGameOver = false;
    [SerializeField] GameObject _scoreText;
    [SerializeField] GameObject _gameOverText;
    void Start()
    {
        InvokeRepeating("Move", 0.08f, 0.08f);
    }

	void Update () {
		if (!isDead) {
			if (Input.GetKey (KeyCode.RightArrow))
				dir = Vector2.right;
			else if (Input.GetKey (KeyCode.DownArrow))
				dir = -Vector2.up;
			else if (Input.GetKey (KeyCode.LeftArrow))
				dir = -Vector2.right;
			else if (Input.GetKey (KeyCode.UpArrow))
				dir = Vector2.up;
		} else {
			if (Input.GetKey(KeyCode.R)){
				tail.Clear();
				transform.position = new Vector3(0, 0, 0);
				isDead = false;
			}
		}
	}

	void Move() {
		if (!isDead) 
        {
			Vector2 v = transform.position;
			transform.Translate (dir);
			if (ate) 
            {
				GameObject g = (GameObject)Instantiate (tailPrefab,v,Quaternion.identity);
				tail.Insert (0, g.transform);
				ate = false;

			} 
            else if (tail.Count > 0) 
            {
					tail.Last ().position = v;
					tail.Insert (0, tail.Last ());
					tail.RemoveAt (tail.Count - 1);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.name.StartsWith("Food")) 
        {
		    ate = true;
            Destroy(coll.gameObject);
            IncreaseScore(1);
        } 
            else 
        { 	
		    isDead = true;
            InitiateGameOver();
		}
	}

    public void IncreaseScore(int amount){
        _score += amount;
        _scoreText.GetComponent<Text>().text = "Score: " + _score;

    }

    public void InitiateGameOver() {
        _isGameOver = true;
        _gameOverText.SetActive(true);
		//Destroy();

		     
        //if (Input.GetKeyDown(KeyCode.R))
        //{
		//	InitiateNewGame();
        //}
    }

	public void InitiateNewGame() {
        SceneManager.LoadScene(0);
		_isGameOver = false;
		isDead = false;
		_gameOverText.SetActive(false);

	}


}
