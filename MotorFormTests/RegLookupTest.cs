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
using Moq;
using System.Net.Http;

namespace MotorFormTests
{
    public class RegLookupTest : TestContext
    {
        [Fact]
        public void RenderError()
        {
            using var ctx = new RegLookupTest();

            var mockVehicleInfo = new Mock<MotorInformationService>("af0slhpNP42RKT9JNvHo2775PCqtZnJZkTUwQHj7");
            mockVehicleInfo.Setup(service => service.PostReg(It.IsAny<string>())).ThrowsAsync(new HttpRequestException());

            ctx.Services.AddSingleton(mockVehicleInfo.Object);

            var regLookup = ctx.RenderComponent<Reg_Lookup>();

            regLookup.Find("button.btn").Click();

            regLookup.WaitForState(() => regLookup.Find("div.alert") != null);

            regLookup.Find("div.alert").MarkupMatches("<div class=\"alert alert-danger\" style=\"width: fit-content;\">Unable to retrieve vehicle information. Did you enter a valid Registration?</div>");
        }
        

    }
}
