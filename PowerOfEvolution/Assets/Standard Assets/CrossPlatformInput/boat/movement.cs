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
    public double[] velocity_vector_array = new double[] { 0.0, 0.0 ,0.0, 0.0};
    private double degrees_to_radians = 180 / Mathf.PI;
    private double to_rotate_y_axis = 0.0;
    private int todo = 0;
    private double[] follow_vector = new double[] { 0.0, 0.0, 0.0 };
    private double delta_Enemy_Player=0;
    private double betha = 0;
    private double betha_direction = 0.0;

    //public  enemy;
    public GameObject Player;
    //private var velocity_vector = new Vector3(0f, 0f, 0f);
    
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
        int direction = Random.Range(0, 4);

        return direction;
    }
    void calc_direction_vector_y_axis()
    {
     velocity_vector_array[0] = Mathf.Cos(Convert.ToSingle((float) angle_y_axis* degrees_to_radians));
     velocity_vector_array[1] = 0;
     velocity_vector_array[1] = Mathf.Sin(Convert.ToSingle((float)angle_y_axis * degrees_to_radians));
    }
    void calc_vector_tofollow()
    {
        follow_vector[0] = Player.transform.position.x - this.transform.position.x;
        follow_vector[2] = Player.transform.position.z - this.transform.position.z;
        delta_Enemy_Player = Mathf.Sqrt(Mathf.Abs(Convert.ToSingle((float)(follow_vector[0] * follow_vector[0] + 
            follow_vector[2] * follow_vector[2]))));
      //  MonoBehaviour.print(delta_Enemy_Player);

    }


    void moveit()
    {
        //todo = 1;
        
        if (agressive == false) {
            if (current_move_time < 0) {
                todo = set_move();
                int seconds = Random.Range(1, 2);
                current_move_time = 60*seconds;


            }
            else
            {
                current_move_time = current_move_time - 1;
                calc_vector_tofollow();

                if (todo == 0)
                {
                    //rotate left (y_axis)
                    to_rotate_y_axis = -0.5;
                    angle_y_axis = angle_y_axis + to_rotate_y_axis;
                    calc_direction_vector_y_axis();
                    this.transform.Rotate(0, Convert.ToSingle((float)to_rotate_y_axis), 0, Space.World);
                }
                else if (todo == 1)
                {
                    //rotate right(y_axis)
                    to_rotate_y_axis = 0.5;
                    angle_y_axis = angle_y_axis + to_rotate_y_axis;
                    calc_direction_vector_y_axis();
                    this.transform.Rotate(0, Convert.ToSingle((float)to_rotate_y_axis), 0, Space.World);


                }
                else if (todo == 2)
                {
                    //just stand
                }
                else if (todo == 3)
                {


                    //create Vector
                    var velocity_vector = new Vector3(Convert.ToSingle((float)velocity_vector_array[1]*0.1),
                    0,
                    Convert.ToSingle((float)velocity_vector_array[0]*0.1));
                    //var velocity_vector = new Vector3(0f, 0f, -0.2f);
                    //move forward
                    this.transform.position += velocity_vector;// * Geschwindigkeit * Time.deltaTime;
                    //MonoBehaviour.print(this.transform.position);

                }
            }
        }
        else if (agressive==true)
        {
            betha = 
                Mathf.Acos(Convert.ToSingle(((float)
                velocity_vector_array[0] * follow_vector[0] + velocity_vector_array[2] * follow_vector[2])
                /
                (delta_Enemy_Player *
                Mathf.Abs(Convert.ToSingle((float)
                            velocity_vector_array[0] * velocity_vector_array[0] +
                            velocity_vector_array[2] * velocity_vector_array[2] 
                            )
                         )
                   )
                )
            );
            betha_direction = (betha / Mathf.Abs(Convert.ToSingle((float)betha)));
            //this.transform.Rotate(0, Convert.ToSingle((float)betha_direction), 0, Space.World);




        }
    }

	
	// Update is called once per frame
	void Update () {
        moveit();
        MonoBehaviour.print(agressive);

        if (delta_Enemy_Player<38)
        {
            agressive = true;
        }

        
        
	}
}
