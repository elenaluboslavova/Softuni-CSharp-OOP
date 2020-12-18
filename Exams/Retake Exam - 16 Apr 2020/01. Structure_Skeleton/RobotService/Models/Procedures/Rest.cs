using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Rest : Procedure
    {
        public Rest()
        {

        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Happiness -= 3;
            robot.Energy += 10;
            if (!this.Robots.Contains(robot))
            {
                this.Robots.Add(robot);
            }
        }
    }
}
