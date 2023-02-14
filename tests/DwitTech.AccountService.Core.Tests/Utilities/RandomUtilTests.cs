using DwitTech.AccountService.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwitTech.AccountService.Core.Tests.Utilities
{
    public class RandomUtilTests
    {
        [Fact]
        public void GenerateUniqueCode_Returns_Unique_twenty_Character_Alphanum_string()
        {
            //Arrange
            string expected = RandomUtil.GenerateUniqueCode();
            
            //Act
            string actual1 = RandomUtil.GenerateUniqueCode();
            string actual2 = RandomUtil.GenerateUniqueCode();
            string actual3 = RandomUtil.GenerateUniqueCode();
            string actual4 = RandomUtil.GenerateUniqueCode();
            string actual5 = RandomUtil.GenerateUniqueCode();
            string actual6 = RandomUtil.GenerateUniqueCode();
            string actual7 = RandomUtil.GenerateUniqueCode();
            string actual8 = RandomUtil.GenerateUniqueCode();
            string actual9 = RandomUtil.GenerateUniqueCode();
            string actual10 = RandomUtil.GenerateUniqueCode();

            //Assert
            Assert.Multiple(
                ()=> Assert.NotEqual(expected, actual1),
                ()=> Assert.NotEqual(expected, actual2),
                ()=> Assert.NotEqual(expected, actual3),
                ()=> Assert.NotEqual(expected, actual4),
                ()=> Assert.NotEqual(expected, actual5),
                ()=> Assert.NotEqual(expected, actual6),
                ()=> Assert.NotEqual(expected, actual7),
                ()=> Assert.NotEqual(expected, actual8),
                ()=> Assert.NotEqual(expected, actual9),
                ()=> Assert.NotEqual(expected, actual10)
                );
        }
    }
}
