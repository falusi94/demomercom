using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
	public int			numberOfElements = 20;
	public float		xMin;
	public float		xMax;
	public float		zMin;
	public float		zMax;
	public float		y;
	public Transform 	element1;
	public Transform 	element2;
	public Transform 	element3;
	public Transform 	element4;
	public Transform 	element5;
	public Transform 	element6;
	public Transform	parentTransform;

	private float randomFloat(float min, float max) {
		float step = (max - min) / 10000;
		return Random.Range (0, 1000) * step + min;
	}

	// Use this for initialization
	void Start () {
		Transform[] elementTypes = {element1, element2, element3, element4, element5, element6};
		int numberOfElementType = elementTypes.Length;
		float step = (xMax - xMin) / numberOfElements;

		for (int i = 0; i < numberOfElements; i++) {

			Transform obj = elementTypes [Random.Range(0, numberOfElementType)];

			Transform element = GameObject.Instantiate (obj, parentTransform); 

			element.transform.Translate ( new Vector3(
				Random.Range(i-1, i+1) * step + xMin,
				y,
				randomFloat(zMin, zMax)));

			element.Rotate ( new Vector3(
				0,
				randomFloat(0, 180),
				0));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}