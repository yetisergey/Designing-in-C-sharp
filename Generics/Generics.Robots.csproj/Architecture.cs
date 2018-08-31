using System;
using System.Collections.Generic;

namespace Generics.Robots
{
    public interface RobotAI<out T> where T : IMoveCommand
    {
        IMoveCommand GetCommand();
    }

    public class ShooterAI<T> : RobotAI<T> where T : IMoveCommand
    {
        int counter = 1;
        public IMoveCommand GetCommand()
        {
            return ShooterCommand.ForCounter(counter++);
        }
    }

    public class BuilderAI<T> : RobotAI<T> where T : IMoveCommand
    {
        int counter = 1;
        public IMoveCommand GetCommand()
        {
            return BuilderCommand.ForCounter(counter++);
        }
    }

    public interface Device<in T>
    {
        string ExecuteCommand(T command);
    }

    public class Mover<T> : Device<T> where T : IMoveCommand
    {
        public string ExecuteCommand(T _command)
        {
            var command = _command as IMoveCommand;
            if (command == null)
                throw new ArgumentException();
            return $"MOV {command.Destination.X}, {command.Destination.Y}";
        }
    }



    public class Robot
    {
        RobotAI<IMoveCommand> ai;
        Device<IMoveCommand> device;

        public Robot(RobotAI<IMoveCommand> ai, Device<IMoveCommand> executor)
        {
            this.ai = ai;
            this.device = executor;
        }

        public IEnumerable<string> Start(int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                var command = ai.GetCommand();
                if (command == null)
                    break;
                yield return device.ExecuteCommand(command);
            }

        }

        public static Robot Create(RobotAI<IMoveCommand> ai, Device<IMoveCommand> executor)
        {
            return new Robot(ai, executor);
        }
    }
}