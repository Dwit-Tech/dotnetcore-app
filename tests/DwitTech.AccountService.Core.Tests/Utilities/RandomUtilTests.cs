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
        [Theory]
        [InlineData("op1wUje9Y1SVY0qWAUS4")]
        public void GenerateUniqueCode_Returns_Unique_twenty_Character_Alphanum_string(string expected)
        {
            //Arrange/Act
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
                ()=> Assert.Equal(expected, actual1),
                ()=> Assert.Equal(expected, actual2),
                ()=> Assert.Equal(expected, actual3),
                ()=> Assert.Equal(expected, actual4),
                ()=> Assert.Equal(expected, actual5),
                ()=> Assert.Equal(expected, actual6),
                ()=> Assert.Equal(expected, actual7),
                ()=> Assert.Equal(expected, actual8),
                ()=> Assert.Equal(expected, actual9),
                ()=> Assert.Equal(expected, actual10)
                );
        }
    }
}
