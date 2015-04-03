/*
 * Author : Iann
 * */

using UnityEngine;
using System.Collections;



/// <summary>
/// Layers script.
/// 
/// Etant donné la forte utilisation des layers, il nous a été préférable d'utiliser des mask pour 
/// le raycast plutot que le layer par défaut "Ignoreraycast"
/// </summary>
public class LayersScript : MonoBehaviour {

	[SerializeField]
	int mobLayer = 9;
	[SerializeField]
	int playerLayer = 10;
	[SerializeField]
	int defaultLayer = 0;
	[SerializeField]
	int baseLayer = 11;
	[SerializeField]
	int towerLayer = 12;

	int mobMask;
	int playerMask;
	int defaultMask;
	int baseMask;
	int towerMask;

	int combinedMaskForLaser;


	void Start()
	{
		mobMask = 1 << mobLayer;
		playerMask = 1 << playerLayer;
		defaultMask = 1 << defaultLayer;
		baseMask = 1 << baseLayer;
		towerMask = 1 << towerLayer;


		combinedMaskForLaser = mobMask | playerMask | defaultMask | baseMask | towerMask;
	}

	public int getLaserMask()
	{	
		return combinedMaskForLaser;
	}


}
