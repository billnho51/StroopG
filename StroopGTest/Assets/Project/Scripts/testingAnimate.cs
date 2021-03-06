using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class testingAnimate : MonoBehaviour
{
    TMP_Text textMesh;

    Mesh mesh;

    Vector3[] vertices;

    List<int> wordIndexes;
    List<int> wordLengths;

    public bool running;

    private float timeRemain = .25f;


    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMP_Text>();

        wordIndexes = new List<int>{0};
        wordLengths = new List<int>();
 
        string s = textMesh.text;
        for (int index = s.IndexOf(' '); index > -1; index = s.IndexOf(' ', index + 1))
        {
                wordLengths.Add(index - wordIndexes[wordIndexes.Count - 1]);
                wordIndexes.Add(index + 1);
        }
        wordLengths.Add(s.Length - wordIndexes[wordIndexes.Count - 1]);
    }

    // Update is called once per frame
    void Update()
    {

        if (running)
        {
            if (timeRemain > 0)
            {
                textMesh.ForceMeshUpdate();
                mesh = textMesh.mesh;
                vertices = mesh.vertices;
            
            

                for (int w = 0; w < wordIndexes.Count; w++)
                {
                    int wordIndex = wordIndexes[w];
                    Vector3 offset = wobble(Time.time + w);
                
 
                    for (int i = 0; i < wordLengths[w]; i++)
                    {
                        TMP_CharacterInfo c = textMesh.textInfo.characterInfo[wordIndex+i];
 
                        int index = c.vertexIndex;
                    
 
                        vertices[index] += offset;
                        vertices[index + 1] += offset;
                        vertices[index + 2] += offset;
                        vertices[index + 3] += offset;
                    }
                }

                mesh.vertices = vertices;
                textMesh.canvasRenderer.SetMesh(mesh);

                timeRemain -= Time.deltaTime;

            }
            else
            {
                timeRemain = .25f;
                running = false;

            }


        }
        
    }


    Vector2 wobble(float time)
    {
        return new Vector2(Mathf.Sin(time*10000f), Mathf.Cos(time*1));

    }

    public void setRun()
    {
        running = true;;

    }
}
