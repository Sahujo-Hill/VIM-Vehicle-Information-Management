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
    public class RenderCompTest : TestContext
    {
        [Fact]
        public void RenderApiDataTable()
        {
            using var ctx = new RenderCompTest();

            string apiKey = "af0slhpNP42RKT9JNvHo2775PCqtZnJZkTUwQHj7";
            ctx.Services.AddSingleton(sp => new MotorInformationService(apiKey));

            var apiDataTable = ctx.RenderComponent<ApiDataTable>();
        }

        [Fact]
        public void RenderRegLookup()
        {
            using var ctx = new RenderCompTest();

            string apiKey = "af0slhpNP42RKT9JNvHo2775PCqtZnJZkTUwQHj7";
            ctx.Services.AddSingleton(sp => new MotorInformationService(apiKey));

            var regLookup = ctx.RenderComponent<Reg_Lookup>();
        }

        [Fact]
        public void RenderMotorForm()
        {
            using var ctx = new RenderCompTest();

            string apiKey = "af0slhpNP42RKT9JNvHo2775PCqtZnJZkTUwQHj7";
            ctx.Services.AddSingleton(sp => new MotorInformationService(apiKey));

            var regLookup = ctx.RenderComponent<Vehicle_Info_Form>();
        }
    }
}
