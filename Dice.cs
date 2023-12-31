﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {
	[HideInInspector]
	public bool onMovement = false;
	bool calculated = false;
	public enum Operation {Sum, Rest, Mult, Div};
	public Operation currentOperation = Operation.Sum;
	public enum Direction {Up, Down, Left, Right};
	Direction lastDirection;
	public Vector3 currentPos;
	ArrayList numbers = new ArrayList();
	ArrayList currentNumbers = new ArrayList();
	Operation nextOperation;
	InGame inGame;
	AudioSource audio;
	public AudioClip audioRotation;
	public AudioClip audioCubeChange;
	Transform plane;
	public int steps = 0;
	public Material backgroundMaterial;
	public Texture backgroundSum;
	public Texture backgroundSubstraction;
	public Texture backgroundMultiplication;
	public Texture backgroundDivision;
	float timeLastMove;
	float hintTime = 10f;
	LineRenderer line;
	public Material[] materialsLine;
	public UITexture backgroundTexture;
	public ParticleSystem goodMove;
    bool dropped = false;
    // Use this for initialization
    bool swipe;

	void Awake(){
		inGame = Camera.main.GetComponent<InGame> ();
		numbers.Add(transform.Find("TextUp").GetComponent<TextMesh>());
		numbers.Add(transform.Find("TextDown").GetComponent<TextMesh>());
		numbers.Add(transform.Find("TextLeft").GetComponent<TextMesh>());
		numbers.Add(transform.Find("TextRight").GetComponent<TextMesh>());
		numbers.Add(transform.Find("TextForward").GetComponent<TextMesh>());
		numbers.Add(transform.Find("TextBackward").GetComponent<TextMesh>());

		currentNumbers = numbers;

    }
	void Start () {
		plane = GameObject.Find ("Plane").GetComponent<Transform> ();
		line = GetComponent<LineRenderer> ();
		currentPos = transform.position;
		

		
		audio = GetComponent<AudioSource> ();

		nextOperation = currentOperation;

		Camera.main.backgroundColor = new Color32 (253, 130, 138, 0);
		backgroundMaterial.mainTexture = backgroundSum;

		StartCoroutine(applyRootMotion ());

		timeLastMove = Time.timeSinceLevelLoad;
		if (PlayerPrefs.GetInt ("Control",0) == 0) {
			ToggleSwipe (true);
		} else {
			ToggleSwipe (false);
		}

		if(inGame.daily) inGame.currentBlock.currentNumbers = faceNumbers();
		hintTime = 5 + getHintTime();
	}

	int getHintTime(){
		if(inGame.currentScene <= 5)
			return 5;
		if(inGame.currentScene > 5 && inGame.currentScene <= 10)
			return 10;
		if(inGame.currentScene > 10 && inGame.currentScene <= 15)
			return 15;
		if(inGame.currentScene > 15 && inGame.currentScene <= 20)
			return 20;
		if(inGame.currentScene > 20)
			return 25;
		else
			return 5;
	}

	IEnumerator applyRootMotion(){
		yield return new WaitForSeconds (1.6f);
		transform.rotation = Quaternion.identity;
		GetComponent<Animator> ().applyRootMotion = true;
		inGame.UnPause();
		//if(inGame.daily)
            EnableTutorialSign(true);
		if(inGame.tutorial)
			inGame.NextTutorial(false);
	}

	public IEnumerator turn(Direction d){
		if(inGame.tutorial){
			if(inGame.tutorialIndex == 0 && d != Direction.Left || inGame.tutorialIndex == 1 && d != Direction.Down || inGame.tutorialIndex == 3 && d != Direction.Left)
				yield break;
			else
				inGame.NextTutorial(false);
		}
		EnableTutorialSign(false);
		onMovement = true;
		calculated = false;
		inGame.Pause();
		int nStemps = 10;
		//define el numero en la cara escondida
		switch(d){
		case Direction.Up:
			
			break;
		case Direction.Down:
			RaycastHit r;
			if(Physics.Raycast(transform.position - Vector3.forward + Vector3.up, new Vector3(0f, -1f, 0f), out r, 5f,LayerMask.GetMask(new string[1]{"Cell"}))){
				if (r.collider.GetComponent<Cell> ().stateCell == Cell.StateCell.Normal) {
					print (r.collider.name);
					((TextMesh)currentNumbers [5]).text = "" + inGame.checkOperationResult (int.Parse (((TextMesh)currentNumbers [4]).text), int.Parse (((TextMesh)currentNumbers [0]).text));
				}
			}
			break;
		case Direction.Left:
			if (Physics.Raycast (transform.position - Vector3.right + Vector3.up, new Vector3 (0f, -1f, 0f), out r, 5f,LayerMask.GetMask(new string[1]{"Cell"}))) {
				if (r.collider.GetComponent<Cell> ().stateCell == Cell.StateCell.Normal) {
					print (r.collider.name);
					((TextMesh)currentNumbers [3]).text = "" + inGame.checkOperationResult (int.Parse (((TextMesh)currentNumbers [2]).text), int.Parse (((TextMesh)currentNumbers [0]).text));
				}
			}
			break;
		case Direction.Right:
			
			break;
		}
		//gira en dado
		for (int i = 1; i <= nStemps; i++) {
			yield return new WaitForSeconds (0.01f);
			switch(d){
			case Direction.Up:
				transform.RotateAround (currentPos + new Vector3 (0f, -0.5f, 0.5f), Vector3.right, 90f / nStemps);
				if(plane != null)
					plane.position = new Vector3 (plane.position.x, plane.position.y, plane.position.z + 0.1f);
				break;
			case Direction.Down:
				transform.RotateAround (currentPos + new Vector3 (0f, -0.5f, -0.5f), Vector3.right, -90f / nStemps);
				if(plane != null)
				plane.position = new Vector3 (plane.position.x, plane.position.y, plane.position.z - 0.1f);
				break;
			case Direction.Left:
				transform.RotateAround (currentPos + new Vector3 (-0.5f, -0.5f, 0f), Vector3.forward, 90f / nStemps);
				if(plane != null)
				plane.position = new Vector3 (plane.position.x - 0.1f, plane.position.y, plane.position.z);
				break;
			case Direction.Right:
				transform.RotateAround (currentPos + new Vector3 (0.5f, -0.5f, 0f), Vector3.forward, -90f / nStemps);
				if(plane != null)
				plane.position = new Vector3 (plane.position.x + 0.1f, plane.position.y, plane.position.z);
				break;
			}
		}

		//ordena las caras y las almacena
		switch(d){
		case Direction.Up:
			TextMesh t = ((TextMesh)currentNumbers [5]);
			currentNumbers [5] = currentNumbers [0];
			currentNumbers [0] = currentNumbers [4];
			currentNumbers [4] = currentNumbers [1];
			currentNumbers [1] = t;
			break;
		case Direction.Down:
			t = ((TextMesh)currentNumbers [1]);
			currentNumbers [1] = currentNumbers [4];
			currentNumbers [4] = currentNumbers [0];
			currentNumbers [0] = currentNumbers [5];
			currentNumbers [5] = t;
			break;
		case Direction.Left:
			t = ((TextMesh)currentNumbers [1]);
			currentNumbers [1] = currentNumbers [2];
			currentNumbers [2] = currentNumbers [0];
			currentNumbers [0] = currentNumbers [3];
			currentNumbers [3] = t;
			break;
		case Direction.Right:
			t = ((TextMesh)currentNumbers [3]);
			currentNumbers [3] = currentNumbers [0];
			currentNumbers [0] = currentNumbers [2];
			currentNumbers [2] = currentNumbers [1];
			currentNumbers [1] = t;
			break;
		}
		//gira las caras
		Transform pos;
		switch(d){
		case Direction.Up:
			pos = ((TextMesh)currentNumbers [1]).transform;
			((TextMesh)currentNumbers [1]).transform.RotateAround (pos.position, pos.forward, -90);
			pos = ((TextMesh)currentNumbers [2]).transform;
			((TextMesh)currentNumbers [2]).transform.RotateAround (pos.position, pos.forward, -90);
			pos = ((TextMesh)currentNumbers [3]).transform;
			((TextMesh)currentNumbers [3]).transform.RotateAround (pos.position, pos.forward, 90);
			pos = ((TextMesh)currentNumbers [4]).transform;
			((TextMesh)currentNumbers [4]).transform.RotateAround (pos.position, pos.forward, 90);
			break;
		case Direction.Down:
			pos = ((TextMesh)currentNumbers [1]).transform;
			((TextMesh)currentNumbers [1]).transform.RotateAround (pos.position, pos.forward, -90);
			pos = ((TextMesh)currentNumbers [2]).transform;
			((TextMesh)currentNumbers [2]).transform.RotateAround (pos.position, pos.forward, 90);
			pos = ((TextMesh)currentNumbers [3]).transform;
			((TextMesh)currentNumbers [3]).transform.RotateAround (pos.position, pos.forward, -90);
			pos = ((TextMesh)currentNumbers [5]).transform;
			((TextMesh)currentNumbers [5]).transform.RotateAround (pos.position, pos.forward, 90);
			break;
		case Direction.Left:
			for (int i = 0; i < currentNumbers.Count; i++) {
				if (i != 3 && i != 5 && i != 1) {
					pos = ((TextMesh)currentNumbers [i]).transform;
					((TextMesh)currentNumbers [i]).transform.RotateAround (pos.position, pos.forward, -90);
				}
				if (i == 1) {
					pos = ((TextMesh)currentNumbers [i]).transform;
					((TextMesh)currentNumbers [i]).transform.RotateAround (pos.position, pos.forward, 180);
				}
				if (i == 5) {
					pos = ((TextMesh)currentNumbers [i]).transform;
					((TextMesh)currentNumbers [i]).transform.RotateAround (pos.position, pos.forward, 90);
				}
			}
			break;
		case Direction.Right:
			for (int i = 0; i < currentNumbers.Count; i++) {
				if (i != 1 && i != 5 && i != 2) {
					pos = ((TextMesh)currentNumbers [i]).transform;
					((TextMesh)currentNumbers [i]).transform.RotateAround (pos.position, pos.forward, 90);
				}
				if (i == 2) {
					pos = ((TextMesh)currentNumbers [i]).transform;
					((TextMesh)currentNumbers [i]).transform.RotateAround (pos.position, pos.forward, 180);
				}
				if (i == 5) {
					pos = ((TextMesh)currentNumbers [i]).transform;
					((TextMesh)currentNumbers [i]).transform.RotateAround (pos.position, pos.forward, -90);
				}
			}
			break;
		}
		lastDirection = d;
		onMovement = false;
		currentPos = transform.position;
		audio.pitch = Random.Range (0.95f, 1.05f);
		audio.PlayOneShot(audioRotation);
		steps++;
		timeLastMove = Time.timeSinceLevelLoad;
		hintTime = 10f;
	}

	public int[] faceNumbers(){
		ArrayList list = currentNumbers;
		/*switch(lastDirection){
			case Direction.Down:
			TextMesh t = ((TextMesh)list [1]);
			list [1] = list [4];
			list [4] = list [0];
			list [0] = list [5];
			list [5] = t;
			break;
		case Direction.Left:
			t = ((TextMesh)list [1]);
			list [1] = list [2];
			list [2] = list [0];
			list [0] = list [3];
			list [3] = t;
			break;
		}*/
		//Debug.Log(int.Parse (((TextMesh)list [1]).text)+", "+int.Parse (((TextMesh)list [2]).text)+", "+int.Parse (((TextMesh)list [4]).text));
		return new int[]{int.Parse (((TextMesh)list [0]).text),int.Parse (((TextMesh)list [2]).text),int.Parse (((TextMesh)list [4]).text)};
	}

	void OnTriggerStay(Collider c){
		if (c.CompareTag ("Untagged") || c.CompareTag ("Sum") || c.CompareTag ("Substraction") || c.CompareTag ("Multiplication") || c.CompareTag ("Division")) {
			if (onMovement || calculated)
				return;
			//print (c.GetComponent<Cell> ().stateCell);
			if(!inGame.daily && !inGame.tutorial && inGame.pause)
				inGame.UnPause();
			//comprueba que el calculo este bien
			//acepto para up y right, en ese caso comprueba que la celda haya sido pisada
			if (c.GetComponent<Cell> ().stateCell == Cell.StateCell.Normal) {
				int cellValue = c.GetComponent<Cell> ().number;
				int diceValueA = -100;
				int diceValueB = -1;
				switch (lastDirection) {
				case Direction.Up:
				//diceValueA = int.Parse (((TextMesh)currentNumbers [1]).text);
				//diceValueB = int.Parse (((TextMesh)currentNumbers [5]).text);
					cellValue = -1;
					break;
				case Direction.Down:
					diceValueA = int.Parse (((TextMesh)currentNumbers [1]).text);
					diceValueB = int.Parse (((TextMesh)currentNumbers [4]).text);
					break;
				case Direction.Left:
					diceValueA = int.Parse (((TextMesh)currentNumbers [1]).text);
					diceValueB = int.Parse (((TextMesh)currentNumbers [2]).text);
					break;
				case Direction.Right:
					cellValue = -1;
				//diceValueA = int.Parse (((TextMesh)currentNumbers [1]).text);
				//diceValueB = int.Parse (((TextMesh)currentNumbers [3]).text);
					break;
				}

 				print (diceValueA + " + " + diceValueB + " = " + cellValue);
				c.GetComponent<Cell> ().changeState (Cell.StateCell.Passed);
				//inGame.currentBlock.currentNumbers = faceNumbers();
				inGame.calculateResult (diceValueA, diceValueB, cellValue);

				//Cambia el color del dado si toca una operacion
				print(c.tag);
				switch (c.tag) {
				case "Sum":
					changeOperation (Operation.Sum);
					backgroundTexture.color = new Color (226f/255f, 54f/255f, 78f/255f, 255f/255f);
					backgroundMaterial.mainTexture = backgroundSum;
					break;
				case "Substraction":
					changeOperation (Operation.Rest);
					backgroundTexture.color = new Color (27f/255f, 88f/255f, 149f/255f, 255f/255f);
					backgroundMaterial.mainTexture = backgroundSubstraction;
					break;
				case "Multiplication":
					changeOperation (Operation.Mult);
					backgroundTexture.color = new Color (116f/255f, 20f/255f, 106f/255f, 255f/255f);
					backgroundMaterial.mainTexture = backgroundMultiplication;
					break;
				case "Division":
					changeOperation (Operation.Div);
					backgroundTexture.color = new Color (20f/255f, 116f/255f, 104f/255f, 255f/255f);
					backgroundMaterial.mainTexture = backgroundDivision;
					break;

				case "Death":
					//Rigidbody rb = GetComponent<Rigidbody> ();
					//rb.AddForce (new Vector3 (0f, -1000f, 0f));
					//Debug.Log("here");
					//Drop();
					//inGame.badMove ();
					break;
				}
				if (nextOperation != currentOperation) {
					currentOperation = nextOperation;
					switch (currentOperation) {
					case Operation.Sum:
						audio.pitch = 1f;
						GetComponent<Renderer> ().material.SetColor ("_Color", new Color32 (255, 90, 118, 255));
						GetComponent<Renderer> ().material.SetColor ("_EmissionColor", new Color32 ((int)(255 * 0.3676471f), (int)(255 * 0.1621972f), (int)(255 * 0.191952f), (int)(255 * 0.3676471f)));
						//line.material = materialsLine [0];
						break;
					case Operation.Rest:
						audio.pitch = 1.1f;
						GetComponent<Renderer> ().material.SetColor ("_Color", new Color32 (90, 112, 255, 255));
						GetComponent<Renderer> ().material.SetColor ("_EmissionColor", new Color32 ((int)(255 * 0.1621972f), (int)(255 * 0.2146223f), (int)(255 * 0.3676471f), (int)(255 * 0.3676471f)));
						//line.material = materialsLine [1];
						break;
					case Operation.Mult:
						audio.pitch = 1.2f;
						GetComponent<Renderer> ().material.SetColor ("_Color", new Color32 (125, 0, 255, 255));
						GetComponent<Renderer> ().material.SetColor ("_EmissionColor", new Color32 ((int)(255 * 0.3223064f), (int)(255 * 0.1621972f), (int)(255 * 0.3676471f), (int)(255 * 0.3676471f)));
						//line.material = materialsLine [2];
						break;
					case Operation.Div:
						audio.pitch = 1.3f;
						GetComponent<Renderer> ().material.SetColor ("_Color", new Color32 (60, 113, 46, 255));
						GetComponent<Renderer> ().material.SetColor ("_EmissionColor", new Color32((int)(255 * 0.1308764f), (int)(255 * 0.1985294f), (int)(255 * 0.07590831f), (int)(255 * 0.3676471f)));
						//line.material = materialsLine [3];
						break;
					}
					audio.PlayOneShot(audioCubeChange);
				}
			}
			if (c.GetComponent<Cell> ().stateCell == Cell.StateCell.EndCell) {
				c.GetComponent<Cell> ().stateCell = Cell.StateCell.Passed;
				inGame.finishGame ();
			}
			calculated = true;
		} else {
			switch (c.tag) {
			case "Rotate90CW":
				Destroy (c.gameObject);
				StartCoroutine (inGame.rotateCells (true));
				break;
			case "Rotate90CCW":
				Destroy (c.gameObject);
				StartCoroutine (inGame.rotateCells (false));
				break;
			case "Death":
                    if (!dropped)
                    {
                        dropped = true;
                        StartCoroutine(Drop());
                    }
				break;
			}
		}
	}

	public void changeOperation(Operation op){
		nextOperation = op;
		UpdateTutorialSign(op);
		EnableTutorialSign(false);
		//if(inGame.daily){
			switch(op){
				case Dice.Operation.Sum:
					backgroundTexture.color = new Color (226f/255f, 54f/255f, 78f/255f, 255f/255f);
					backgroundMaterial.mainTexture = backgroundSum;
					GetComponent<Renderer> ().material.SetColor ("_Color", new Color32 (255, 90, 118, 255));
					GetComponent<Renderer> ().material.SetColor ("_EmissionColor", new Color32 ((int)(255 * 0.3676471f), (int)(255 * 0.1621972f), (int)(255 * 0.191952f), (int)(255 * 0.3676471f)));	
					break;
				case Dice.Operation.Div:
					backgroundTexture.color = new Color (20f/255f, 116f/255f, 104f/255f, 255f/255f);
					backgroundMaterial.mainTexture = backgroundDivision;
					GetComponent<Renderer> ().material.SetColor ("_Color", new Color32 (60, 113, 46, 255));
					GetComponent<Renderer> ().material.SetColor ("_EmissionColor", new Color32((int)(255 * 0.1308764f), (int)(255 * 0.1985294f), (int)(255 * 0.07590831f), (int)(255 * 0.3676471f)));
					break;
				case Dice.Operation.Mult:
					backgroundTexture.color = new Color (116f/255f, 20f/255f, 106f/255f, 255f/255f);
					backgroundMaterial.mainTexture = backgroundMultiplication;
					GetComponent<Renderer> ().material.SetColor ("_Color", new Color32 (125, 0, 255, 255));
					GetComponent<Renderer> ().material.SetColor ("_EmissionColor", new Color32 ((int)(255 * 0.3223064f), (int)(255 * 0.1621972f), (int)(255 * 0.3676471f), (int)(255 * 0.3676471f)));	
					break;
				case Dice.Operation.Rest:
					backgroundTexture.color = new Color (27f/255f, 88f/255f, 149f/255f, 255f/255f);
					backgroundMaterial.mainTexture = backgroundSubstraction;
					GetComponent<Renderer> ().material.SetColor ("_Color", new Color32 (90, 112, 255, 255));
					GetComponent<Renderer> ().material.SetColor ("_EmissionColor", new Color32 ((int)(255 * 0.1621972f), (int)(255 * 0.2146223f), (int)(255 * 0.3676471f), (int)(255 * 0.3676471f)));	
					break;
			}
            if (currentOperation != op)
            {
                currentOperation = op;
                EnableTutorialSign(true);
                print("adentro");
            }
            else
            {
                EnableTutorialSign(false);
                print("afuera");
            }
		//}
	}
					

	IEnumerator Drop(){
        dropped = true;
		inGame.GetComponent<CameraControl> ().follow = false;
		for (int i = 0; i < 50; i++) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - ((i*i)/20f / (50f)), transform.position.z);
			yield return new WaitForSeconds (0.001f);
			if (i == 25) {
				inGame.badMove ();
			}
		}
    }
		

	public void ToggleSwipe(bool b){
		if (b) {
			swipe = true;
			plane.gameObject.SetActive (false);
			PlayerPrefs.SetInt ("Control", 0);
		} else {
			swipe = false;
			plane.gameObject.SetActive (true);
			PlayerPrefs.SetInt ("Control", 1);
		}
	}

	Vector3 initialPosition;
	float timeSwipe;

	/*public void EnableAdjCells(){
		foreach (Transform t in inGame.adjacentCells) {
			t.GetComponent<AdjacentCellFinder> ().EnableCell (true);
		}
	}*/

	// Update is called once per frame
	void Update () {
		inGame.tutorialv2.position = transform.position;
		if (onMovement || inGame.rotating || Time.timeSinceLevelLoad < 2f || inGame.pause)
			return;
		if(!inGame.daily && timeLastMove <= Time.timeSinceLevelLoad - inGame.pauseTime - hintTime){
			StartCoroutine (inGame.lightPath (0));
			//fix
			hintTime += getHintTime();
		}
		if (Input.GetKeyDown (KeyCode.W)) { if(!inGame.daily) StartCoroutine(turn (Direction.Up)); }
		if (Input.GetKeyDown (KeyCode.S)) { StartCoroutine(turn (Direction.Down)); }
		if (Input.GetKeyDown (KeyCode.A)) { StartCoroutine(turn (Direction.Left)); }
		if (Input.GetKeyDown (KeyCode.D)) { if(!inGame.daily) StartCoroutine(turn (Direction.Right));}

		if (swipe) {
			if (Input.GetMouseButtonDown (0)) {
				initialPosition = Input.mousePosition;
				timeSwipe = Time.time;
			}
			if (Input.GetMouseButtonUp (0)) {
				if (timeSwipe + 1f > Time.time && Vector3.Distance (initialPosition, Input.mousePosition) >= 50f) {
					Vector3 dir = (Input.mousePosition - initialPosition).normalized;
					print ("swipe!" + Vector3.Angle (new Vector3 (1f, 0f, 0f), dir));
					float angle = Vector3.Angle (new Vector3 (1f, 0f, 0f), dir);
					if (angle >= 0f && angle < 90f) {
						if (dir.y > 0f) {
							if(!inGame.daily) StartCoroutine (turn (Direction.Right));
						} else {
							StartCoroutine (turn (Direction.Down));
						}
					} else {
						if (dir.y > 0f) {
							if(!inGame.daily) StartCoroutine (turn (Direction.Up));
						} else {
							StartCoroutine (turn (Direction.Left));
						}
					}
				}
			}
		}
		
	}

	void UpdateTutorialSign(Operation op){
		string sign = "";
		switch(op){
			case Operation.Sum:
			sign = "+";
			break;
			case Operation.Div:
			sign = "÷";
			break;
			case Operation.Mult:
			sign = "x";
			break;
			case Operation.Rest:
			sign = "-";
			break;
		}
		inGame.tutorialv2.Find("Canvas/LSign").GetComponent<Text>().text = sign;
		inGame.tutorialv2.Find("Canvas/DSign").GetComponent<Text>().text = sign;
	}

	public void EnableTutorialSign(bool b){
		/*if(inGame.pause)
			return;*/
		Debug.Log("enable "+b);
		if(PlayerPrefs.GetInt("tutorialsDisabled",0) == 1){
			inGame.tutorialv2.gameObject.SetActive(false);
			return;
		}
		
		if(b)
			UpdateTutorialSign(currentOperation);
		
		inGame.tutorialv2.gameObject.SetActive(b);
	}
}
