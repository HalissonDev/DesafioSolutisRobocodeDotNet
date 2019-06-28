using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Added news 'using' declaration
using Robocode;
using System.Drawing; // For the colors


namespace SOLUTIS.HalissonRobot
{
    public class HalissonRobot : Robot  
    {
        public override void Run()
        {
            // -- Initialization of the robot --

            SetColors(Color.Olive, Color.Coral, Color.Aqua); //Setting robotcolor : body, gun, radar

            // Here we turn the robot to point upwards, and move the gun 90 degrees
            TurnLeft(Heading - 90);
            TurnGunRight(90);

            // Infinite loop making sure this robot runs till the end of the battle round
            while (true)
            {
                Ahead(3000);
                TurnRight(90);
            }

        }

        // Robot event handler, when the robot sees another robot
        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            //Fire(1);
            if (evnt.Distance < 100)
            {
                Fire(3);
            }
            else
            {
                Fire(1);
            }
        }

        public override void OnHitRobot(HitRobotEvent e)
        {
            // If he's in front of us, set back up a bit.
            if (e.Bearing > -90 && e.Bearing < 90)
            {
                Back(10);
            } // else he's in back of us, so set ahead a bit.
            else
            {
                Ahead(100);
            }
        }

        
        public override void OnHitByBullet(HitByBulletEvent evnt)
        {
            Back(10);
        }
        
         public override void OnWin(WinEvent e)
        {
            // Victory dance
            TurnRight(36000);
        }

    }
}
