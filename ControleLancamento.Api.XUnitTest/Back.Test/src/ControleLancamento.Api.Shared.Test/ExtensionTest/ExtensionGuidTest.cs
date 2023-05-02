using ControleLancamento.Api.Application.AppLancamento;
using ControleLancamento.Api.Shared.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControleLancamento.Api.XUnitTest.Back.Test.src.ControleLancamento.Api.Shared.Test.ExtensionTest
{
    public class ExtensionGuidTest
    {
        [Fact]
        public void Dado_um_comando_valido()
        {
            var guidValido = Guid.NewGuid();

            Assert.True(guidValido.ValidationGuid());
        }

        [Fact]
        public void Dado_um_comando_invalido_zerado()
        {
            var guidValido = Guid.Parse("00000000-0000-0000-0000-000000000000");

            Assert.False(guidValido.ValidationGuid());
        }

        [Fact]
        public void Dado_um_comando_invalido_nulo()
        {
            var guidValido = Guid.Empty;

            Assert.False(guidValido.ValidationGuid());
        }
    }
}
