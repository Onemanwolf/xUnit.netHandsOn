﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Test
{
    public class InternalHealthDamageTestData
    {
       

        public static IEnumerable<object[]> TestData
        {

            get
            {
                yield return new object[] { 0, 100 };
                yield return new object[] { 20, 80 };
                yield return new object[] { 50, 50 };
                yield return new object[] { 101, 1 };

            }
        }

    }
}
