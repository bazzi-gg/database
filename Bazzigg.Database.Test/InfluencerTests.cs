using Bazzigg.Database.Context;
using Bazzigg.Database.Entity;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzigg.Database.Test
{
    [TestClass]
    public class InfluencerTests
    {
        [TestMethod("추가")]
        public void Add()
        {
            using var context = new AppDbContext(TestOptions.AppDbContextOptions);
            var obj = new Influencer()
            {
                AccessId = "",
                Description = "",
                Keywords = new List<string>()
                {
                    "", ""
                },
                Nickname = ""
            };
            context.Influencer.Add(obj);
            context.SaveChanges();
        }

    }
}
