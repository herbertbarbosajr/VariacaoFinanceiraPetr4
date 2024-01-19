using Microsoft.AspNetCore.Http.HttpResults;
using VariacaoFinanceira.API.Endpoints;
using VariacaoFinanceira.Domain.Entities;
using VariacaoFinanceira.Test.Helpers;

namespace VariacaoFinanceira.Test
{
    public class VariacaFinanceiraTest
    {
        [Fact]
        public async void InserirVariacao()
        {
            //Arrange
            DateTime CL_DATE = DateTime.Now;
            var CL_VALUE = 38.61;
            var CL_VARIATION_PREVIOUS_DATE = 1.63;
            var CL_VARIATION_FIRST_DATE = 14.03;

            var variacao = new Variacao(CL_DATE,CL_VALUE, CL_VARIATION_PREVIOUS_DATE, CL_VARIATION_FIRST_DATE);

            await using var context = new MockDb().CreateDbContext();

            //Act
            var result = VariacaoFinanceiraEndPoint.InsertVariacao(variacao, context);

            //Assert
            Assert.IsType<Created<Variacao>>(result);
            Assert.NotNull(variacao);
            Assert.NotEmpty(context.TB_VARIACAO_DAILY);
            Assert.Collection(context.TB_VARIACAO_DAILY, variacao =>
            {
                Assert.Equal(CL_VALUE, variacao.CL_VALUE);
            });
        }

        [Fact]
        public async void BuscarVariacao()
        {
            //Arrange
            DateTime CL_DATE = DateTime.Now.AddDays(-30);
            var CL_VALUE = 38.61;
            var CL_VARIATION_PREVIOUS_DATE = 1.63;
            var CL_VARIATION_FIRST_DATE = 14.03;

            var variacao = new Variacao(CL_DATE, CL_VALUE, CL_VARIATION_PREVIOUS_DATE, CL_VARIATION_FIRST_DATE);

            await using var context = new MockDb().CreateDbContext();

            //Act
            var result = VariacaoFinanceiraEndPoint.BuscarVariacao(context);

            //Assert
            Assert.IsAssignableFrom<IEnumerable<Variacao>>(result);
            Assert.NotNull(variacao);
            
        }
    }
}