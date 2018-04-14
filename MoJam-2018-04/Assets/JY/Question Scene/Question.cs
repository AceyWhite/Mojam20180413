using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Question : ScriptableObject {
	public string question;
	public bool level1;
	public bool level2;
	public bool level3;
	public bool level4;
	public bool level5;
	public string answers_correct;
	public string answers_a;
	public string answers_b;
	public string answers_c;
}
