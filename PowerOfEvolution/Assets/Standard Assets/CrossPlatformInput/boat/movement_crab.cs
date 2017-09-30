using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class movement_crab : MonoBehaviour
{

    // Use this for initialization
    public bool agressive = true;
    private int current_move_time = 0;
    public double angle_y_axis = 0.0;
    public double[] velocity_vector_array = new double[] { 0.0, 0.0, 0.0, 0.0 };
    private double degrees_to_radians = 180 / Mathf.PI;
    private double to_rotate_y_axis = 0.0;
    private int todo = 0;
    private double[] follow_vector = new double[] { 0.0, 0.0, 0.0 };
    private double delta_Enemy_Player = 0;
    private double betha = 0;
    private double betha_direction = 0.0;

    private double a = 0;
    private double b = 0;
    private double term = 0;

    private double v_1 = 0.0;
    private double v_2 = 0.0;
    private double v_3 = 0.0;
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
        int direction = Random.Range(0, 6);

        return direction;
    }
    void calc_direction_vector_y_axis()
    {
        velocity_vector_array[0] = Mathf.Cos(Convert.ToSingle((float)angle_y_axis * degrees_to_radians));
        velocity_vector_array[1] = 0;
        velocity_vector_array[1] = Mathf.Sin(Convert.ToSingle((float)angle_y_axis * degrees_to_radians));
    }
    void calc_vector_tofollow()
    {
        follow_vector[0] = (Player.transform.position.x - this.transform.position.x);

        follow_vector[2] = (Player.transform.position.z - this.transform.position.z);
        delta_Enemy_Player = Mathf.Sqrt(Mathf.Abs(Convert.ToSingle((float)(follow_vector[0] * follow_vector[0] +
            follow_vector[2] * follow_vector[2]))));
        //  MonoBehaviour.print(delta_Enemy_Player);

    }


    void moveit()
    {
        //todo = 3;

        if (agressive == false)
        {
            if (current_move_time < 0)
            {
                todo = set_move();
                int seconds = Random.Range(1, 3);
                current_move_time = 60 * seconds;


            }
            else
            {
                current_move_time = current_move_time - 1;
                calc_vector_tofollow();

                if (todo == 0)
                {
                    //rotate left (y_axis)
                    to_rotate_y_axis = -1;
                    angle_y_axis = angle_y_axis + to_rotate_y_axis;
                    calc_direction_vector_y_axis();
                    this.transform.Rotate(0, Convert.ToSingle((float)to_rotate_y_axis), 0, Space.World);
                }
                else if (todo == 1)
                {
                    //rotate right(y_axis)
                    to_rotate_y_axis = 1;
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
                    var velocity_vector = new Vector3(Convert.ToSingle((float)velocity_vector_array[1] * 0.3),
                    0,
                    Convert.ToSingle((float)velocity_vector_array[0] * 0.3));
                    //move forward
                    this.transform.position += velocity_vector;// * Geschwindigkeit * Time.deltaTime;
                }
                else if (todo == 4)
                {
                    //create vector
                    var velocity_vector = new Vector3(Convert.ToSingle((float)velocity_vector_array[1] * 0.3),
                     0,
                     Convert.ToSingle((float)velocity_vector_array[0] * 0.3));
                    //move forward
                    this.transform.position += velocity_vector;// * Geschwindigkeit * Time.deltaTime;
                }
                else if (todo == 5)
                {
                    //create vector
                    var velocity_vector = new Vector3(Convert.ToSingle((float)velocity_vector_array[0] * -0.1),
                        0,
                        Convert.ToSingle((float)velocity_vector_array[1] * 0.1));
                    this.transform.position += velocity_vector;// * Geschwindigkeit * Time.deltaTime;
                }
            }
        }
        else if (agressive == true)
        {
            calc_vector_tofollow();
            calc_direction_vector_y_axis();
            
            if (betha > 0)
            {
                betha = betha - 1;
                this.transform.Rotate(0, Convert.ToSingle((float)1), 0, Space.World);
                angle_y_axis = angle_y_axis - 1;

            }
            else if (betha < -1)
            {
                betha = betha + 1;
                this.transform.Rotate(0, Convert.ToSingle((float)-1), 0, Space.World);
                angle_y_axis = angle_y_axis - 1;

            }
            else if (betha == 0)
            {
                calc_vector_tofollow();
                calc_direction_vector_y_axis();
                a = Convert.ToSingle((float)follow_vector[0] * velocity_vector_array[0] + follow_vector[2] * velocity_vector_array[2]);
                b = Mathf.Sqrt(Convert.ToSingle((float)(follow_vector[0] * follow_vector[0] + follow_vector[2] * follow_vector[2])))
                    *
                   Mathf.Sqrt(Convert.ToSingle((float)(velocity_vector_array[0] * velocity_vector_array[0] + velocity_vector_array[2] * velocity_vector_array[2])));
                term = a / b;

                betha = Mathf.Acos(Convert.ToSingle((float)term)) * (180 / Math.PI);
                if (this.transform.position.z < 0)
                {
                    betha += -90;
                    if (this.transform.position.x > 0)
                    {
                        betha =-(betha+ 90);
                    }
                }
                MonoBehaviour.print(betha);



            }
            else if (Mathf.Abs(Convert.ToSingle((float)betha)) < 1)
            {
                calc_vector_tofollow();
                v_1 = Convert.ToSingle((float)follow_vector[2] / Mathf.Abs(Convert.ToSingle((float)(follow_vector[2]))) * -0.3);
                v_3 = Convert.ToSingle((float)follow_vector[0] / Mathf.Abs(Convert.ToSingle((float)(follow_vector[0]))) * -0.3);
                if (v_1<0 && v_3 < 0)
                {
                    v_1 = -v_1;
                    v_3 = -v_3;
                }
                else if (v_1 > 0 && v_3 > 0)
                {
                    v_1 = -v_1;
                    v_3 = -v_3;
                }
                var velocity_vector = new Vector3(
                    Convert.ToSingle((float)v_1),
                    0,
                    Convert.ToSingle((float)v_3));
                this.transform.position += velocity_vector;// * Geschwindigkeit * Time.deltaTime;


            }

            //move forward





        }
    }


    // Update is called once per frame
    void Update()
    {
        moveit();
        agressive = true;

        if (delta_Enemy_Player < 40)
        {
            agressive = true;
        }



    }
}
