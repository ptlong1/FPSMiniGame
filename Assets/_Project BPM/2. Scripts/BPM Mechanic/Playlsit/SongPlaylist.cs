using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class SongInfo
{
	public AudioClip clip;
	public string name;
	public float songBpm;
	public float timeBeforeStart;
}
[CreateAssetMenu(fileName = "SongPlaylist", menuName = "ScriptableObjects/SongPlaylist", order = 1)]
public class SongPlaylist : ScriptableObject
{
	[SerializeField]
	public List<SongInfo> playlist;
	public int idx;

	public int Idx { 
		get
		{
			if (playlist == null || playlist.Count == 0) return 0;
			return idx % playlist.Count;
		}  
		set{
			if (playlist == null || playlist.Count == 0) return;
			idx = value % playlist.Count;
		}
	}

	public SongInfo CurrentSong { 
		get {
			if (playlist == null || playlist.Count == 0) return null;
			currentSong = playlist[Idx];
			return currentSong;
		}
	}

	private SongInfo currentSong;
}
