using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected readonly List<IRobot> robots;
        public Procedure()
        {
            this.robots = new List<IRobot>();
        }

        protected IList<IRobot> Robots => this.robots;

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }
            robot.ProcedureTime -= procedureTime;
            this.robots.Add(robot);
        }

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            foreach (var robot in this.Robots)
            {
                sb.AppendLine($" Robot type: {robot.GetType().Name} - {robot.Name} - Happiness: {robot.Happiness} - Energy: {robot.Energy}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
