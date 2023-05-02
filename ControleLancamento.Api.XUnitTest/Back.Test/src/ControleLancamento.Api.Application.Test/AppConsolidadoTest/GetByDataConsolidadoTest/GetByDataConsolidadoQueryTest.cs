using ControleLancamento.Api.Application.AppConsolidado;
using ControleLancamento.Api.Application.AppLancamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ControleLancamento.Api.XUnitTest.Back.Test.src.ControleLancamento.Api.Application.Test.AppConsolidadoTest.GetByDataConsolidadoTest
{
    public class GetByDataConsolidadoQueryTest
    {
        [Fact]
        public void Dado_um_comando_invalido()
        {
            GetByDataConsolidadoQuery _invalidCommand = new GetByDataConsolidadoQuery();

            _invalidCommand.Validate();

            Assert.Equal(_invalidCommand.Valid, false);
        }

        [Fact]
        public void Dado_um_comando_valido()
        {
            GetByDataConsolidadoQuery _validCommand = new GetByDataConsolidadoQuery()
            {
                Data = DateTime.Now,
            };

            _validCommand.Validate();

            Assert.Equal(_validCommand.Valid, true);
        }
    }
}
