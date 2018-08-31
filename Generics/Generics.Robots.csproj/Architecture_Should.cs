using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Robots
{
    [TestFixture]
    public class Architecture_Should
    {
        [Test]
        public void BeCorrectForShooter()
        {
            var robot = Robot.Create(new ShooterAI<IMoveCommand>(), new Mover<IMoveCommand>());
            var result = robot.Start(5);
            var dueResult = Enumerable.Range(1, 5).Select(z => $"MOV {z * 2}, {z * 3}");
            CollectionAssert.AreEqual(dueResult, result);
        }

        [Test]
        public void BeCorrectForBuilder()
        {
            var robot = Robot.Create(new BuilderAI<IMoveCommand>(), new Mover<IMoveCommand>());
            var result = robot.Start(5).ToArray();
            var dueResult = Enumerable.Range(1, 5).Select(z => $"MOV {z}, {z}");
            CollectionAssert.AreEqual(dueResult, result);
        }
    }
}
