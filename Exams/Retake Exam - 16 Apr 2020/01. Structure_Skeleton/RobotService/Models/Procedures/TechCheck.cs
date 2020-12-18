using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedure
    {
        public TechCheck()
        {

        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Energy -= 8;
            if (!this.Robots.Contains(robot))
            {
                this.Robots.Add(robot);
            }
            if (!robot.IsChecked)
            {
                robot.IsChecked = true;
            }
        }
    }
}
