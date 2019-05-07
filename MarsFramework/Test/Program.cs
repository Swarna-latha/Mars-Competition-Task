using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework
{
    public class Program
    {
       [TestFixture]
        [Category("Sprint1")]
        class Tenant : Global.Base
        {
            [Test]
            public void TestRun()
            {
                // Creates a toggle for the given test, adds all log events under it    
               // test = extent.StartTest("Share Skill");

                //Creates an class and object to call the method
                SignIn sin = new SignIn();
                sin.LoginSteps();

                //Create ShareSkill
                SharedSkill skill = new SharedSkill();
                skill.ShareSkillSteps();

                //Delete Skill
                ManageListing Del = new ManageListing();
                Del.DeleteSteps();
            }
        }
    }
}