using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Media.Dom;
using Bunit;
using Motor_Information_Form.Components;
using Motor_Information_Form.Pages;
using Motor_Information_Form.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MotorFormTests
{
    public class RenderComp : TestContext
    {
        [Fact]
        public void RenderApiDataTable()
        {
            using var ctx = new RenderComp();

            string apiKey = "af0slhpNP42RKT9JNvHo2775PCqtZnJZkTUwQHj7";

            ctx.Services.AddSingleton(sp => new MotorInformationService(apiKey));

            var apiDataTable = ctx.RenderComponent<ApiDataTable>();
        }

        [Fact]
        public void RenderRegLookup()
        {
            using var ctx = new RenderComp();

            string apiKey = "af0slhpNP42RKT9JNvHo2775PCqtZnJZkTUwQHj7";

            ctx.Services.AddSingleton(sp => new MotorInformationService(apiKey));

            var regLookup = ctx.RenderComponent<Reg_Lookup>();
        }
    }
}
