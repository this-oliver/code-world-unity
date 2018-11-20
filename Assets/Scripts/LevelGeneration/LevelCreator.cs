﻿using System.IO;
using UnityEngine;

public class LevelCreator : MonoBehaviour {

    private JSONParser _jsonParser;
    private GameObjectCreator _gameObjectCreator;
    private StreamReader _streamReader;

	// Use this for initialization
	void Start () {
        _jsonParser = new JSONParser();
        _gameObjectCreator = new GameObjectCreator();

        string path = "Assets/Resources/mock.json"; //TODO: Change this so filename is more dynamic
        _streamReader = new StreamReader(path);
        SetupWorld();
	}

    public void SetupWorld()
    {
        string json = _streamReader.ReadToEnd();
        ClassObject[] classes = _jsonParser.Parse<ClassObject>(json);

        foreach (ClassObject c in classes)
        {
            GameObject gameObject = _gameObjectCreator.Compose(c);
            //Instantiate(gameObject); //TODO: Remove comments once GameObjectCreator works
        }

        Debug.Log(_jsonParser.ToJson(classes)); // DEV only
    }
}