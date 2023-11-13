using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GalForUnity.Model.Scene
{
    public class jumpMainMap : SceneModel
    {
        // Start is called before the first frame update
        void Start()
        {
            SceneManager.LoadScene("MainMap");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
