using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;


public class movement : MonoBehaviour {

    // Use this for initialization
    private bool agressive = false;
    private int current_move_time = 0;
    public double angle_y_axis = 0.0;
    public double[] velocity_vector = new double[] { 0.0, 0.0 };
    private double degrees_to_radians = 180 / Mathf.PI;
    private double to_rotate = 0.0;
    private int todo = 0;

    void Start()
    {
        /*private bool agressive = false;
        private int current_move_time = 0;
        public float angle_y_axis = 0.0;
        public float[] velocity_vector = new float[] {0, 0};
        private float degrees_to_radians = 180 / Mathf.PI;
        private float to_rotate = 0.0;*/
    }


    private int set_move()
    {
        int direction = Random.Range(0, 3);
        return direction;
    }
    void calc_direction_vector_y_axis()
    {

     velocity_vector[2] = Mathf.Cos(Convert.ToSingle((float) angle_y_axis* degrees_to_radians));
     velocity_vector[1] = 0;
     velocity_vector[0] = Mathf.Sin(Convert.ToSingle((float)angle_y_axis * degrees_to_radians));
    
    }
    void moveit()
    {
        if (agressive == false) {
            if (current_move_time < 0) {
                todo = set_move();
                int seconds = Random.Range(1, 4);
                current_move_time = 60*seconds;
                
            }
            else
            {
                current_move_time = current_move_time - 1;
                if (todo == 0)
                {
                //rotate left (y_axis)
                angle_y_axis = angle_y_axis - 0.5;
                calc_direction_vector_y_axis();
                }
                else if (todo == 1)
                {
                //rotate right(y_axis)
                angle_y_axis=angle_y_axis+0.5;
                calc_direction_vector_y_axis();
                
                }
                else if (todo == 2)
                {
                    //just stand
                }
                else if (todo == 3)
                {
                    //move forward
                    this.transform.position = Convert.ToSingle((int)this.transform.position.x + velocity_vector[0]);
                    this.transform.position = (int)this.transform.position.y + velocity_vector[1];
                    this.transform.position = (int)this.transform.position.z + velocity_vector[2];
                }
            }
        }
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
